import 'dart:developer';

import 'package:blog_app/features/blog/presentation/blocs/bloc.dart';
import 'package:blog_app/features/blog/presentation/blocs/createBlog/blog_event.dart';
import 'package:blog_app/features/blog/presentation/widgets/AddButtonCustom.dart';
import 'package:blog_app/features/blog/presentation/widgets/CustomSnackbar.dart';
import 'package:blog_app/features/blog/presentation/widgets/DynamicWrapper.dart';
import 'package:blog_app/features/blog/presentation/widgets/inputField.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class InputForm extends StatefulWidget {
  @override
  State<InputForm> createState() => _InputFormState();
}

class _InputFormState extends State<InputForm> {
  final titleController = TextEditingController();
  final subTitleController = TextEditingController();
  final articleContentController = TextEditingController();
  var dynamicWrapper = DynamicWrapper();

  @override
  Widget build(BuildContext build) {
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
        dynamicWrapper,
        MultiLineInputField(
            label: "Article content", controller: articleContentController),
        ElevatedButton(
            onPressed: () {
              log(titleController.text.toString());
              // check if fields are empty
              // if not empty then publish

              var title = titleController.text.toString();
              var subTitle = subTitleController.text.toString();
              var content = articleContentController.text.toString();

              if (title.isEmpty || subTitle.isEmpty || content.isEmpty) {
                log("fields are empty");
                ScaffoldMessenger.of(context)
                    .showSnackBar(customSnackBar("Fields shouldn't be empty"));
              } else {
                // log("Publishing blog <> Input form");
                context.read<BlogBloc>().add(CreateBlogEvent(
                    title: title,
                    subTitle: subTitle,
                    tags: ["tag1", "tag2"],
                    content: content));
              }
            },
            child: Text("Publish"),
            style: ElevatedButton.styleFrom(shape: StadiumBorder())),
      ],
    );
  }
}
