import 'dart:developer';
import 'dart:io';

import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:blog_app/features/blog/domain/usecases/create_article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/blog/domain/usecases/get_single_article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_tags.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_state.dart';
import 'package:blog_app/features/blog/presentation/blocs/create_blog/create_blod_state.dart';
import 'package:blog_app/features/blog/presentation/blocs/create_blog/create_blog_event.dart';
import 'package:blog_app/features/blog/presentation/widgets/AddButtonCustom.dart';
import 'package:blog_app/features/blog/presentation/widgets/CustomSnackbar.dart';
import 'package:blog_app/features/blog/presentation/widgets/DynamicWrapper.dart';
import 'package:blog_app/features/blog/presentation/widgets/dialog.dart';
import 'package:blog_app/features/blog/presentation/widgets/inputField.dart';
import 'package:blog_app/injection.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_styled_toast/flutter_styled_toast.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:image_cropper/image_cropper.dart';
import 'package:image_picker/image_picker.dart';

class EditInputForm extends StatefulWidget {
  final Article article;

  const EditInputForm({super.key, required this.article});
  @override
  State<EditInputForm> createState() => _EditInputFormState();
}

class _EditInputFormState extends State<EditInputForm> {
  var add_image = "Add image";

  File photo = File('');
  Future<void> updateProfileImage() async {
    final picker = ImagePicker();
    try {
      final pickedImage = await picker.pickImage(
        source: ImageSource.gallery,
      );

      if (pickedImage != null) {
        final croppedImage = await ImageCropper().cropImage(
          sourcePath: pickedImage.path,
          aspectRatioPresets: [
            CropAspectRatioPreset.square,
            CropAspectRatioPreset.ratio3x2,
            CropAspectRatioPreset.original,
            CropAspectRatioPreset.ratio4x3,
            CropAspectRatioPreset.ratio16x9
          ],
          uiSettings: [
            AndroidUiSettings(
                toolbarTitle: 'Cropper',
                toolbarColor: const Color(0xffF8FAFF),
                backgroundColor: Color(0xffF8FAFF),
                toolbarWidgetColor: const Color(0xff212121),
                initAspectRatio: CropAspectRatioPreset.original,
                lockAspectRatio: false),
            IOSUiSettings(
              title: 'Cropper',
            ),
            // ignore: use_build_context_synchronously
            WebUiSettings(
              context: context,
            ),
          ],
        );

        if (croppedImage != null) {
          setState(() {
            photo = File(croppedImage.path);
            add_image = "1 selected";
          });
          // successfully updated alert
          // ignore: use_build_context_synchronously
        } else {
          log('Image cropping canceled.');
        }
      } else {
        log('No image selected.');
      }
    } catch (e) {
      log('Error: $e');
    }
  }

  final titleController = TextEditingController();
  final subTitleController = TextEditingController();
  final articleContentController = TextEditingController();
  var dynamicWrapper = DynamicWrapper();
  bool _isLoading = false;
  TextEditingController tagsController = TextEditingController();
  List<String> tags = [
    "Art",
    "design",
  ];

  void addTag() {
    String tag = tagsController.text.toLowerCase();
    if (tag.isNotEmpty && !tags.contains(tag)) tags.add(tag);
    print(tags);
    setState(() {});
    tagsController.clear();
  }

  void removeTag(int index) {
    tags.removeAt(index);
    setState(() {});
  }

  List<String> getTags() {
    return tags;
  }

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
        create: (context) => BlogBloc(
              createArticle: sl<CreateArticleUseCase>(),
              getAllArticle: sl<GetArticleUseCase>(),
              getSingleArticle: sl<GetSingleArticleUseCase>(),
              getTags: sl<GetTagsUseCase>(),
            ),
        child: BlocConsumer<BlogBloc, BlogState>(
          listener: (context, state) {
            if (state is BlogInitial) {
              // Navigator.pushNamed(context, '/home', arguments: state.user.id);
              log('initial state');
            }
            // loading state
            else if (state is CreatingBlogState) {
              setState(() {
                _isLoading = true;
              });
              log('creating blog state');
            } else if (state is CreatedBlogState) {
              log('CREATED blog state');
              // snackbar with success
              ScaffoldMessenger.of(context).showSnackBar(
                const SnackBar(
                  backgroundColor: Colors.green,
                  content: Text('Article created successfully'),
                ),
              );
              setState(() {
                _isLoading = false;
              });
            } else if (state is BlogError) {
              // Handle error if login fails
              // ScaffoldMessenger.of(context).showSnackBar(
              //   SnackBar(
              //     backgroundColor: Colors.red,
              //     content: Text(state.errorMessage),
              //   ),
              // );
              ScaffoldMessenger.of(context).showSnackBar(
                const SnackBar(
                  backgroundColor: Colors.green,
                  content: Text('Article created successfully'),
                ),
              );
              setState(() {
                _isLoading = false;
              });
            } else {
              log('else state');
            }
          },
          builder: (context, state) {
            return buildBody(context);
          },
        ));
  }

  Widget buildBody(BuildContext context) {
    titleController.text = widget.article.title!;
    subTitleController.text = widget.article.subTitle!;
    articleContentController.text = widget.article.content!;
    photo = File(widget.article.image!);

    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      // mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        InputField(
          label: "Add title",
          controller: titleController,
        ),
        InputField(
          label: "Add subtitle",
          controller: subTitleController,
        ),
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              mainAxisSize: MainAxisSize.max,
              children: [
                Expanded(
                    child: InputField(
                  label: "Add tags",
                  controller: tagsController,
                )),
                AddButtonCustom(
                  onpressed: addTag,
                ),
                Column(
                  children: [
                    IconButton(
                      onPressed: () {
                        // Handle edit icon click
                        updateProfileImage();
                      },
                      icon: const Icon(FontAwesomeIcons.camera,
                          color: Color.fromARGB(255, 26, 25, 25), size: 18),
                    ),
                    Text(
                      add_image,
                      style: const TextStyle(fontSize: 11),
                    ),
                  ],
                ),
              ],
            ),
            const Text(
              "Add as many tags as you want",
              style: TextStyle(fontSize: 16),
            ),
            Container(
              padding: const EdgeInsets.fromLTRB(0, 15, 0, 0),
              child: Wrap(
                spacing: 5,
                // add vertical spacing here
                runSpacing: 5,
                children: [
                  ...[for (var i = 0; i < tags.length; i++) generateChip(i)]
                ],
              ),
            ),
          ],
        ),
        Stack(
          children: [
            Column(
              children: [
                MultiLineInputField(
                    label: "Article content",
                    controller: articleContentController),
              ],
            ),
            Positioned(
              top: 13,
              left: 0,
              child: ElevatedButton(
                  onPressed: () {
                    GenDialog(context);
                  },
                  style: ElevatedButton.styleFrom(
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(40),
                    ),
                    // backgroundColor: const Color(0xff376AED),
                  ),
                  child: const Text("Generate with AI",
                      style: TextStyle(fontSize: 12))),
            ),
          ],
        ),
        ElevatedButton(
          onPressed: () {
            final title = titleController.text.toString();
            final subtitle = subTitleController.text.toString();
            final content = articleContentController.text.toString();

            log(title);
            if (title.isEmpty ||
                subTitleController.text.toString().isEmpty ||
                articleContentController.text.toString().isEmpty) {
              log("fields are empty");

              ScaffoldMessenger.of(context)
                  .showSnackBar(customSnackBar("Fields shouldn't be empty"));
            } else {
              context.read<BlogBloc>().add(CreateBlogEvent(
                  title: title,
                  subTitle: subtitle,
                  tags: tags[0],
                  image: photo,
                  content: content));
            }
          },
          style: ElevatedButton.styleFrom(
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(20),
            ),
            backgroundColor: const Color(0xff376AED),
          ),
          child: _isLoading
              ? const CircularProgressIndicator(
                  color: Colors.white,
                ) // Show a CircularProgressIndicator if login is in progress
              : const Text(
                  '  Publish  ',
                  style: TextStyle(
                    color: Colors.white,
                    fontFamily: 'Urbanist-Bold',
                    fontSize: 16,
                  ),
                ),
        ),
        Container(
          height: 10,
        )
      ],
    );
  }

  Container generateChip(int index) {
    return Container(
      padding: const EdgeInsets.fromLTRB(10, 0, 0, 0),
      child: Chip(
        deleteIconColor: Colors.blue,
        label: Text(
          tags[index],
          style: const TextStyle(color: Colors.blue, fontSize: 14),
        ),
        backgroundColor: Colors.white,
        shape: const StadiumBorder(
          side: BorderSide(color: Colors.blue, width: 1),
        ),
        onDeleted: () {
          // Handle delete action
          removeTag(index);
        },
      ),
    );
  }

  // class DialogForm extends StatelessWidget {
  // DialogForm({super.key});
  // @override
  // Widget build(BuildContext context) {
  //   // return Text("data");
  //   return ElevatedButton(
  //     onPressed: () {
  //       print('pressed');
  //       GenDialog(context);
  //     },
  //     child: Text("data"),
  //   );
  // }

  Future<dynamic> GenDialog(BuildContext context) {
    TextEditingController promptController = TextEditingController();
    TextEditingController genController = TextEditingController();

    var genIcon = GenerateIcon(
      promptController: promptController,
      genController: genController,
    );
    // genIcon.icon = _refreshIcon({t});

    return showDialog(
        context: context,
        barrierDismissible: false,
        builder: (BuildContext context) {
          return AlertDialog(
            scrollable: true,
            title: Row(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                // Text('Generate text'),
                IconButton(
                    icon: const Icon(Icons.close),
                    onPressed: () {
                      // your code
                      Navigator.pop(context);
                    })
              ],
            ),
            content: Padding(
              padding: const EdgeInsets.all(0),
              child: Column(
                children: [
                  TextField(
                      controller: promptController,
                      decoration: InputDecoration(
                          labelText: 'Prompt', suffixIcon: genIcon
                          // suffix: ElevatedButton(
                          // onPressed: () {}, child: Text("cgen"))),
                          )),
                  TextField(
                    controller: genController,
                    maxLines: 5,
                    keyboardType: TextInputType.multiline,
                    decoration: const InputDecoration(
                      hintText: 'Generated text',
                    ),
                  ),
                ],
              ),
            ),
            actions: [
              IconButton(
                onPressed: () async {
                  log("Copying");
                  String genText = genController.text.toString().trim();
                  await Clipboard.setData(ClipboardData(text: genText));
                  showToast("Text is Copied", context: context);
                },
                icon: const Icon(Icons.copy),
              )
            ],
          );
        });
  }
}
