import 'package:blog_app/core/util/app_colors.dart'; // Importing app-specific colors
import 'package:flutter/material.dart';

class TagButtonListWidget extends StatelessWidget {
  final List<String> tagNames;
  final double borderRadius;
  final double horizontalPadding;
  final Color buttonColor;
  final Color outlineColor;
  final double spaceBetweenButtons;

  const TagButtonListWidget({
    Key? key,
    required this.tagNames,
    this.borderRadius = 20, // Default border radius
    this.horizontalPadding = 25, // Default horizontal padding
    this.buttonColor = const Color(0xFF376AED), // Default button color
    this.outlineColor = const Color(0xFF376AED), // Default border color
    this.spaceBetweenButtons = 10, // Default spacing between buttons
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    // Button styles for selected and unselected buttons
    var outlinedButtonStyle = OutlinedButton.styleFrom(
      side: BorderSide(color: outlineColor),
      padding: EdgeInsets.symmetric(
        vertical: 5,
        horizontal: horizontalPadding,
      ),
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(borderRadius),
      ),
    );

    var elevatedButtonStyle = ElevatedButton.styleFrom(
      backgroundColor: buttonColor,
      padding: EdgeInsets.symmetric(
        vertical: 2,
        horizontal: horizontalPadding,
      ),
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(borderRadius),
      ),
    );

    return SingleChildScrollView(
      // Allow tags horizontal scrolling
      scrollDirection: Axis.horizontal,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.start,
        children: [
          // "All" button
          SizedBox(
            height: 30,
            width: 100,
            child: ElevatedButton(
              onPressed: () {
                // Action for the "All" button
              },
              style: elevatedButtonStyle, // Apply selected button style
              child: const Text(
                'All',
                style: TextStyle(
                  color: AppColors.whiteColor,
                ),
                maxLines: 1,
                overflow: TextOverflow.ellipsis,
              ),
            ),
          ),
          // Space between "All" and other buttons
          SizedBox(width: spaceBetweenButtons),
          // Create buttons for each tag name in the list
          ...tagNames.map(
            (tagName) {
              return Container(
                height: 30,
                width: 100,
                margin: EdgeInsets.only(right: spaceBetweenButtons),
                child: OutlinedButton(
                  onPressed: () {}, // Action for each tag button
                  style: outlinedButtonStyle, // Apply unselected button style
                  child: Text(
                    tagName, // Display the tag name on the button
                    style: TextStyle(
                      color: outlineColor,
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
