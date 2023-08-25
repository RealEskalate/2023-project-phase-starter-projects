import 'package:flutter/material.dart';
import '../widgets/custom_publish_button.dart';
import '../widgets/custom_tag_button.dart';
import '../widgets/custom_text_area.dart';
import '../widgets/custom_text_field.dart';

class AddTaskBody extends StatelessWidget {
  const AddTaskBody({super.key});

  @override
  Widget build(BuildContext context) {
    return Material(
      child: Column(
        children: [
          Padding(
            padding: const EdgeInsets.fromLTRB(0, 70, 0, 0),
            child: Row(
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(40, 0, 0, 0),
                  child: Container(
                    width: 36,
                    height: 36,
                    decoration: BoxDecoration(
                        color: const Color(0xFFEAEBF0),
                        borderRadius: BorderRadius.circular(10)),
                    child: IconButton(
                      icon: const Icon(
                        Icons.arrow_back_ios_new,
                        color: Color(0xFF878585),
                        size: 17,
                      ),
                      onPressed: () {},
                    ),
                  ),
                ),
                const Padding(
                  padding: EdgeInsets.fromLTRB(40, 0, 0, 0),
                  child: Text(
                    "New Article",
                    style: TextStyle(
                      color: Color(0xFF0D253C),
                      fontFamily: "Poppins",
                      fontWeight: FontWeight.w500,
                      fontSize: 24,
                    ),
                  ),
                ),
              ],
            ),
          ),
          const Expanded(
            child: Padding(
              padding: EdgeInsets.symmetric(horizontal: 40, vertical: 35),
              child: SingleChildScrollView(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    CustomTextField(placeholder: 'Add title'),
                    CustomTextField(
                      placeholder: 'Add subtitle',
                    ),
                    CustomTagButton(),
                    SizedBox(
                      height: 50,
                    ),
                    CustomTextArea(placeholder: 'Article Content'),
                    SizedBox(height: 80),
                    CustomPublishButton(),
                  ],
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
