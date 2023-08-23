import 'package:flutter/material.dart';

class ProfileTabItem extends StatelessWidget {
  bool selected;
  String top;
  String bottom;
  ProfileTabItem({
    super.key,
    this.selected = false,
    this.top = '52',
    this.bottom = 'Post',
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: (){

      },
      child: Container(
        width: 77,
        height: 68,
        decoration: ShapeDecoration(
          color: selected ? Color(0xFF2151CD) : Color(0xFF386BED),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(12),
          ),
        ),

          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                this.top,
                textAlign: TextAlign.center,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 20,
                  fontWeight: FontWeight.w400,
                  height: 1.10,
                ),
              ),
              SizedBox(height: 4),
              Text(
                this.bottom,
                textAlign: TextAlign.center,
                style: TextStyle(
                  color: Colors.white.withOpacity(0.8700000047683716),
                  fontSize: 12,
                  fontWeight: FontWeight.w400,
                  height: 1.50,
                ),
              ),
            ],
          ),

      ),
    );
  }
}