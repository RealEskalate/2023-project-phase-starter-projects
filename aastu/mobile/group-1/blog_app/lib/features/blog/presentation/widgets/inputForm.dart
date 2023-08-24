import 'package:blog_app/features/blog/presentation/widgets/AddButtonCustom.dart';
import 'package:blog_app/features/blog/presentation/widgets/CustomSnackbar.dart';
import 'package:blog_app/features/blog/presentation/widgets/DynamicWrapper.dart';
import 'package:blog_app/features/blog/presentation/widgets/inputField.dart';
import 'package:flutter/material.dart';

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
      crossAxisAlignment: CrossAxisAlignment.start,
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
              print(titleController.text.toString());
              // check if fields are empty
              // if not empty then publish

              if (titleController.text.toString().isEmpty ||
                  subTitleController.text.toString().isEmpty ||
                  articleContentController.text.toString().isEmpty) {
                print("fields are empty");
                ScaffoldMessenger.of(context)
                    .showSnackBar(customSnackBar("Fields shouldn't be empty"));
              }
            },
            child: Text("Publish"),
            style: ElevatedButton.styleFrom(shape: StadiumBorder())),
      ],
    );
  }
}
