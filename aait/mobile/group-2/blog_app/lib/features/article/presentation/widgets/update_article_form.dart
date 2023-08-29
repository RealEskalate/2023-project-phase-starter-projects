import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/utils/url_to_file.dart';
import '../../../user/domain/entities/user_data.dart';
import '../../domain/entities/article.dart';
import '../bloc/article_bloc.dart';
import '../bloc/tag_bloc.dart';
import '../bloc/tag_selector_bloc.dart';
import 'custom_chip.dart';
import 'custom_text_field.dart';
import 'image_selector.dart';
import 'multiline_text_field.dart';
import 'snackbar.dart';
import 'tag_selector.dart';

class UpdateArticleForm extends StatefulWidget {
  final Article article;

  const UpdateArticleForm({super.key, required this.article});

  @override
  State<UpdateArticleForm> createState() => _UpdateArticleFormState();
}

class _UpdateArticleFormState extends State<UpdateArticleForm> {
  final titleFieldController = TextEditingController();
  final subtitleFieldController = TextEditingController();
  final contentFieldController = TextEditingController();

  XFile? image;

  @override
  void initState() {
    titleFieldController.text = widget.article.title;
    subtitleFieldController.text = widget.article.subTitle;
    contentFieldController.text = widget.article.content;

    for (final tag in widget.article.tags) {
      context.read<TagSelectorBloc>().add(AddTagEvent(tag));
    }

    urlToFile(widget.article.photoUrl).then((file) {
      file.fold(
        (l) => showError(context, 'Error loading image'),
        (r) {
          if (mounted) {
            setState(() {
              image = XFile(r.path);
            });
          }
        },
      );
    });

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      padding: EdgeInsets.symmetric(
        horizontal: 45.w,
        vertical: 45.h,
      ),
      child: Form(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // Title field
            CustomTextField(
              controller: titleFieldController,
              hintText: 'Add title',
            ),
            const SizedBox(height: 15),

            // Subtitle field
            CustomTextField(
              controller: subtitleFieldController,
              hintText: 'Add subtitle',
            ),
            const SizedBox(height: 15),

            // Tag field
            BlocBuilder<TagBloc, TagState>(
              builder: (context, state) {
                if (state is AllTagsLoadedState) {
                  return TagSelector(tags: state.tags);
                }

                return const CustomTextField(
                  hintText: 'Add tags',
                );
              },
            ),
            const SizedBox(height: 5),
            const Text(
              'add as many tags as you want',
              style: TextStyle(
                color: AppColors.gray300,
                fontFamily: 'Poppins',
                fontSize: 13,
                fontWeight: FontWeight.w200,
              ),
            ),
            const SizedBox(height: 15),

            // Selected tags
            SizedBox(
              width: double.infinity,
              child: BlocBuilder<TagSelectorBloc, TagSelectorState>(
                builder: (context, state) {
                  return Wrap(
                    runSpacing: 10,
                    spacing: 10,
                    children: state.tags
                        .map<Widget>((tag) => CustomChip(
                              label: tag.name,
                              onDelete: () {
                                context
                                    .read<TagSelectorBloc>()
                                    .add(RemoveTagEvent(tag));
                              },
                            ))
                        .toList(),
                  );
                },
              ),
            ),
            const SizedBox(height: 30),

            // Article Image
            ImageSelector(onImageSelected: _selectImage, image: image),
            const SizedBox(height: 30),

            // Content field
            MultilineTextInput(
              controller: contentFieldController,
              hintText: 'Article content',
            ),
            const SizedBox(height: 50),

            // Create article button
            Center(
              child: ElevatedButton(
                onPressed: () => _publishArticle(context),
                child: const Text('Update'),
              ),
            ),
          ],
        ),
      ),
    );
  }

  void _selectImage(XFile? file) {
    setState(() {
      image = file;
    });
  }

  void _publishArticle(BuildContext context) {
    final articleBloc = context.read<ArticleBloc>();
    final tagsBloc = context.read<TagSelectorBloc>();

    if (image != null) {
      final article = Article(
        id: widget.article.id,
        title: titleFieldController.text,
        subTitle: subtitleFieldController.text,
        content: contentFieldController.text,
        photoUrl: image!.path,
        tags: tagsBloc.selectedTags.toList(),
        author: const UserData(
            articles: [],
            bio: '',
            createdAt: '',
            email: '',
            expertise: '',
            fullName: '',
            id: '',
            image: '',
            imageCloudinaryPublicId: ''),
        date: DateTime.now(),
        estimatedReadTime: '3min',
      );
      articleBloc.add(UpdateArticleEvent(article));
    } else {
      showError(context, 'Please select an image');
    }
  }
}
