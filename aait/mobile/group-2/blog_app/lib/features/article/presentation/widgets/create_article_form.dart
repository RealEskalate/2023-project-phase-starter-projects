import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/utils/time_calculator.dart';
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

class CreateArticleForm extends StatefulWidget {
  const CreateArticleForm({super.key});

  @override
  State<CreateArticleForm> createState() => _CreateArticleFormState();
}

class _CreateArticleFormState extends State<CreateArticleForm> {
  final titleFieldController = TextEditingController();
  final subtitleFieldController = TextEditingController();
  final contentFieldController = TextEditingController();

  XFile? image;

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
                        .map((tag) => CustomChip(
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
            ImageSelector(
              onImageSelected: _selectImage,
            ),
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
                child: const Text('Publish'),
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
      final estimatedReadTime =
          estimatedReadTimeCalculator(contentFieldController.text);

      final article = Article(
        id: '',
        title: titleFieldController.text,
        subTitle: subtitleFieldController.text,
        content: contentFieldController.text,
        photoUrl: image!.path,
        tags: tagsBloc.selectedTags.toList(),
        author: UserData.empty,
        date: DateTime.now(),
        estimatedReadTime: '${estimatedReadTime.inMinutes} min',
      );

      articleBloc.add(CreateArticleEvent(article));
    } else {
      showError(context, 'Please select an image');
    }
  }
}
