import 'package:blog_app/core/utils/app_dimension.dart';
import 'package:flutter/material.dart';

class CustomCard extends StatelessWidget {
  final String author;
  final String date;
  CustomCard({required this.author, required this.date});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: AppDimension.height(230, context),
      child: Card(
        elevation: 4,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(AppDimension.height(
              20, context)), // Set your desired border radius here
        ),
        margin: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Stack(
              children: [
                Container(
                  margin: EdgeInsets.symmetric(
                      vertical: AppDimension.height(10, context),
                      horizontal: AppDimension.width(10, context)),
                  width: AppDimension.width(130, context),
                  height: AppDimension.height(140, context),
                  child: Image.asset(
                    "assets/images/a2sv.png",
                    fit: BoxFit.cover,
                  ),
                ),
                Container(
                  margin: EdgeInsets.only(
                      left: AppDimension.width(30, context),
                      top: AppDimension.height(10, context)),
                  height: AppDimension.height(30, context),
                  width: AppDimension.width(90, context),
                  color: Colors.red,
                )
              ],
            ),
            Expanded(
              child: Padding(
                padding: EdgeInsets.all(10),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Title',
                      style: TextStyle(
                        fontSize: 18,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    SizedBox(height: 5),
                    Text(
                      author,
                      style: TextStyle(
                        fontSize: 16,
                        color: Colors.grey,
                      ),
                    ),
                    SizedBox(height: 10),
                    Text(
                      date,
                      style: TextStyle(
                        fontSize: 14,
                        color: Colors.blue,
                        decoration: TextDecoration.underline,
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
