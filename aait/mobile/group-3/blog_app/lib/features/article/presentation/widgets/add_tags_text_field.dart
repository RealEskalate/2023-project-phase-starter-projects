import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

class AddTagsContainer extends StatefulWidget {
  @override
  _AddTagsContainerState createState() => _AddTagsContainerState();
}

class _AddTagsContainerState extends State<AddTagsContainer> {
  List<String> availableTags = [
    'Tag 1',
    'Tag 2',
    'Tag 3',
    'Tag 4',
    // Add more tags as needed
  ];

  List<String> selectedTags = [];

  void toggleTag(String tag) {
    setState(() {
      if (selectedTags.contains(tag)) {
        selectedTags.remove(tag);
      } else {
        selectedTags.add(tag);
      }
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
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text('Add Tags:'),
                SizedBox(
                  height: 4,
                ),
                Text(
                  "add as many tags as you want",
                  style: GoogleFonts.poppins(
                    fontSize: 11.sp,
                    fontWeight: FontWeight.w200,
                    color: Colors.black,
                  ),
                ),
              ],
            ),
            IconButton(
              icon: Icon(
                Icons.add_circle_outline,
                color: Colors.blue,
              ),
              onPressed: () {
                showDialog(
                  context: context,
                  builder: (context) {
                    return AlertDialog(
                      title: Text('Select Tags'),
                      content: Container(
                        width: double.maxFinite,
                        child: Wrap(
                          spacing: 8.0,
                          children: availableTags.map((tag) {
                            return GestureDetector(
                              onTap: () {
                                toggleTag(tag);
                                Navigator.pop(context);
                              },
                              child: RawChip(
                                label: Text(
                                  tag,
                                  style: TextStyle(
                                      color: selectedTags.contains(tag)
                                          ? Colors.white
                                          : Colors.blue),
                                ),
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(20),
                                  side: BorderSide(color: Colors.blue),
                                ),
                                backgroundColor: selectedTags.contains(tag)
                                    ? Colors.blue
                                    : Colors.white,
                              ),
                            );
                          }).toList(),
                        ),
                      ),
                    );
                  },
                );
              },
            ),
          ],
        ),
        Wrap(
          spacing: 8.0,
          children: selectedTags.map((tag) {
            return RawChip(
              label: Text(
                tag,
                style: TextStyle(color: Colors.blue),
              ),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(20),
                side: BorderSide(color: Colors.blue),
              ),
              onDeleted: () {
                toggleTag(tag);
              },
              deleteIconColor: Colors.lightBlue,
            );
          }).toList(),
        ),
        SizedBox(height: 16.0),
      ],
    );
  }
}
