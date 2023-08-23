import 'package:flutter/material.dart';

import 'button_container.dart';

class RowButton extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.only(left: 72, right: 72, top: 250),
      child: Stack(
        children: [
          Center(
            child: Material(
              elevation: 30,
              borderRadius: BorderRadius.circular(16),
              color: Color(0xFF386BED),
              child: Container(
                alignment: Alignment.center,
                width: 153,
                height: 68,
              ),
            ),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              ButtonContainer(
                numberValue: 52,
                category: "Posts",
              ),
              ButtonContainer(
                color: Color(0xFF386BED),
                numberValue: 12,
                category: "Bookmarks",
              ),
            ],
          ),
        ],
      ),
    );
  }
}
