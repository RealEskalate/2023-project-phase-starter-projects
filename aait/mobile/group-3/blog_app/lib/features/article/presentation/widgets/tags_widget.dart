import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/util/app_colors.dart';
import '../bloc/article_bloc.dart';

class TagButtonListWidget extends StatefulWidget {
  final List<String> tagNames;
  final double borderRadius;
  final double horizontalPadding;
  final Color buttonColor;
  final Color outlineColor;
  final double spaceBetweenButtons;
  final Function SearchByTags;

  const TagButtonListWidget(
      {Key? key,
      this.tagNames = const [
        "others",
        "sports",
        "oech",
        "politics",
        "art",
        "design",
        "culture",
        "production"
      ],
      this.borderRadius = 20,
      this.horizontalPadding = 25,
      this.buttonColor = const Color(0xFF376AED),
      this.outlineColor = const Color(0xFF376AED),
      this.spaceBetweenButtons = 10,
      required this.SearchByTags})
      : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _TagButtonListWidgetState createState() => _TagButtonListWidgetState();
}

class _TagButtonListWidgetState extends State<TagButtonListWidget> {
  String selectedTag = '';

  @override
  Widget build(BuildContext context) {
    var outlinedButtonStyle = OutlinedButton.styleFrom(
      side: BorderSide(color: widget.outlineColor),
      padding: EdgeInsets.symmetric(
        vertical: 5,
        horizontal: widget.horizontalPadding,
      ),
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(widget.borderRadius),
      ),
    );

    var elevatedButtonStyle = ElevatedButton.styleFrom(
      backgroundColor: widget.buttonColor,
      padding: EdgeInsets.symmetric(
        vertical: 2,
        horizontal: widget.horizontalPadding,
      ),
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(widget.borderRadius),
      ),
    );

    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.start,
        children: [
          SizedBox(
            height: 30,
            width: 100,
            child: ElevatedButton(
              onPressed: () {
                setState(() {
                  selectedTag = ''; // Clear the selected tag
                });

                // Emit a search event with an empty query when "All" is clicked
                context
                    .read<ArticleBloc>()
                    .add(GetAllArticlesEvent(searchQuery: "", tags: []));
              },
              style: selectedTag.isEmpty
                  ? elevatedButtonStyle
                  : outlinedButtonStyle,
              child: const Text(
                'All',
                style: TextStyle(
                  color: Colors.white,
                ),
                maxLines: 1,
                overflow: TextOverflow.ellipsis,
              ),
            ),
          ),
          SizedBox(width: widget.spaceBetweenButtons),
          ...widget.tagNames.map(
            (tagName) {
              return Container(
                height: 30,
                width: 100,
                margin: EdgeInsets.only(right: widget.spaceBetweenButtons),
                child: OutlinedButton(
                  onPressed: () {
                    setState(() {
                      selectedTag = tagName; // Update selected tag
                    });
                    widget.SearchByTags(selectedTag);
                    // Emit a search event with the clicked tag as the query
                  },
                  style: selectedTag == tagName
                      ? elevatedButtonStyle
                      : outlinedButtonStyle,
                  child: Text(
                    tagName,
                    style: TextStyle(
                      color: selectedTag == tagName
                          ? AppColors.whiteColor
                          : widget.outlineColor,
                      fontFamily: 'Urbanist',
                    ),
                    maxLines: 1,
                    overflow: TextOverflow.ellipsis,
                  ),
                ),
              );
            },
          ),
        ],
      ),
    );
  }
}
