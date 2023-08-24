// ignore_for_file: prefer_const_constructors, prefer_const_literals_to_create_immutables

import "package:blog_app/core/utils/colors.dart";
import "package:blog_app/features/user_profile/domain/entities/article.dart";
import "package:flutter/material.dart";

class MyPost extends StatefulWidget {
  const MyPost({
    super.key,
    required this.article,
  });

  final Article article;
  @override
  State<MyPost> createState() => _MyPostState();
}

class _MyPostState extends State<MyPost> {
  @override
  Widget build(BuildContext context) {
    return Container(
      height: 141,
      margin: EdgeInsets.only(bottom: 20),
      decoration: ShapeDecoration(
        color: Colors.white,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(16),
        ),
        shadows: [
          BoxShadow(
            color: Color(0x0F5182FF),
            blurRadius: 15,
            offset: Offset(0, 10),
            spreadRadius: 0,
          )
        ],
      ),
      child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
        Container(
          width: 92,
          decoration: ShapeDecoration(
            image: DecorationImage(
              image: NetworkImage(widget.article.image!),
              fit: BoxFit.fill,
            ),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(16),
            ),
          ),
        ),
        SizedBox(
          width: 200,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                widget.article.title,
                style: TextStyle(
                  color: kLightBlue,
                  fontSize: 18,
                  fontStyle: FontStyle.italic,
                  fontFamily: 'Urbanist',
                  fontWeight: FontWeight.w100,
                  height: 1.43,
                ),
              ),
              SizedBox(
                width: 163,
                child: Text(
                  widget.article.subTitle,
                  style: TextStyle(
                    color: Color(0xFF0D253C),
                    fontSize: 15,
                    fontFamily: 'Urbanist',
                    fontWeight: FontWeight.w500,
                    height: 1.43,
                  ),
                ),
              ),
              SizedBox(
                height: 10,
              )
            ],
          ),
        )
      ]),
    );
  }
}

              // Row(
              //   mainAxisAlignment: MainAxisAlignment.spaceBetween,
              //   children: [
              //     Row(
              //       children: [
              //         IconButton(
              //           onPressed: () {
              //             setState(() {
              //               if (widget.isLiked) {
              //                 widget.likes += 1;
              //               } else {
              //                 widget.likes -= 1;
              //               }
              //               widget.isLiked = !widget.isLiked;
              //             });
              //           },
              //           icon: Icon(
              //             widget.isLiked
              //                 ? Icons.thumb_up_outlined
              //                 : Icons.thumb_up,
              //             size: 18,
              //             color: Colors.blue[800],
              //           ),
              //         ),
              //         Container(
              //           margin: EdgeInsets.only(right: 10),
              //           child: Text(
              //             widget.likes.toString(),
              //             style: TextStyle(
              //               color: Colors.grey[800],
              //               fontSize: 14,
              //               fontFamily: 'Urbanist',
              //               fontWeight: FontWeight.w500,
              //               height: 1.33,
              //             ),
              //           ),
              //         ),
              //       ],
              //     ),
              //     Row(
              //       children: [
              //         Icon(
              //           Icons.history_outlined,
              //           size: 20,
              //           color: Colors.blue[800],
              //         ),
              //         Container(
              //           margin: EdgeInsets.only(left: 5),
              //           child: Text(
              //             '1hr ago',
              //             style: TextStyle(
              //               color: Colors.grey[800],
              //               fontSize: 14,
              //               fontFamily: 'Urbanist',
              //               fontWeight: FontWeight.w500,
              //               height: 1.33,
              //             ),
              //           ),
              //         )
              //       ],
              //     ),
              //     IconButton(
              //       onPressed: () {
              //         setState(() {
              //           widget.isSaved = !widget.isSaved;
              //         });
              //       },
              //       icon: Icon(
              //         widget.isSaved
              //             ? Icons.bookmark
              //             : Icons.bookmark_add_outlined,
              //         color: Colors.blue[800],
              //       ),
              //     )
              //   ],
              // )