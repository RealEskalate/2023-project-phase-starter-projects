import 'custom_categories_button.dart';
import 'custom_text_field.dart';
import 'package:flutter/material.dart';

class CustomTagButton extends StatefulWidget {
  const CustomTagButton({super.key});

  @override
  State<CustomTagButton> createState() => _CustomTagButtonState();
}

class _CustomTagButtonState extends State<CustomTagButton> {
  bool isAreaVisible = false;
  TextEditingController textTagController = TextEditingController();

  //Mock data to test the Tag button
  static Map<String, String> categories = {
    'Art': 'Art',
    'Design': 'Design',
    'Culture': 'Culture',
    'Production': 'Production'
  };

  void toogleAreaVisibilit() {
    setState(() {
      isAreaVisible = !isAreaVisible;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            const Expanded(
              flex: 1,
              child: CustomTextField(
                placeholder: 'Add tags',
              ),
            ),
            const SizedBox(
              width: 5,
            ),
            Expanded(
              flex: 0,
              child: IconButton(
                  onPressed: toogleAreaVisibilit,
                  icon: const Icon(
                    Icons.add_circle_outline_sharp,
                    color: Color(0xFF376AED),
                    size: 40,
                  )),
            )
          ],
        ),
        const SizedBox(height: 4),
        const Text(
          'add as many tags as you want',
          style: TextStyle(
              fontFamily: 'Poppins',
              fontWeight: FontWeight.w300,
              fontSize: 11,
              color: Color(0xFF979EA5)),
        ),
        if (isAreaVisible)
          Padding(
            padding: const EdgeInsets.symmetric(vertical: 10),
            child: Wrap(
              direction: Axis.horizontal,
              spacing: 10,
              runSpacing: 4,
              children: categories.entries.map((category) {
                final value = category.key;
                return Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    CustomCategoriesButton(label: value),
                  ],
                );
              }).toList(),
            ),
          ),
      ],
    );
  }
}
