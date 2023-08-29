import 'package:blog_app/features/home_page/domain/entities/article.dart';
import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';

class ArticleDetail extends StatefulWidget {
  const ArticleDetail({super.key, required this.article});
  final Article article;

  @override
  State<ArticleDetail> createState() => ArticleDetailState();
}

class ArticleDetailState extends State<ArticleDetail> {
  bool isSaved = false;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        child: ListView(
          children: [
            Container(
              padding: EdgeInsets.symmetric(horizontal: 25, vertical: 2),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Container(
                    padding: const EdgeInsets.symmetric(
                        vertical: 10, horizontal: 20),
                    margin: const EdgeInsets.only(bottom: 20),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Icon(
                          Icons.arrow_back_ios,
                          color: Colors.black,
                          size: 30,
                        ),
                        Text('')
                      ],
                    ),
                  ),
                  Container(
                      margin: EdgeInsets.only(right: 20),
                      child:
                          Icon(Icons.more_horiz, color: Colors.black, size: 40))
                ],
              ),
            ),
            Container(
              // width: 303,
              margin: EdgeInsets.only(left: 40, right: 40, top: 20),
              child: Text(
                widget.article.title,
                style: TextStyle(
                  color: Color(0xFF0D253C),
                  fontSize: 26,
                  fontFamily: 'Poppins',
                  fontWeight: FontWeight.w600,
                ),
              ),
            ),
            Container(
              height: 65,
              margin: EdgeInsets.symmetric(horizontal: 40, vertical: 20),
              padding: EdgeInsets.symmetric(horizontal: 5, vertical: 10),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Row(
                    children: [
                      // avatar
                      (widget.article.author.image != null)
                          ? CircleAvatar(
                              backgroundImage: NetworkImage(
                                  widget.article.author.image ?? ""),
                            )
                          : Icon(Icons.person),

                      SizedBox(width: 10),

                      // author name and time
                      Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Text(
                            widget.article.author.fullName ?? "",
                            style: TextStyle(
                                fontSize: 18, fontWeight: FontWeight.w400),
                          ),
                          Text("2m ago",
                              style: TextStyle(
                                  fontSize: 16, fontWeight: FontWeight.w500)),
                        ],
                      ),
                    ],
                  ),

                  // bookmark icon
                  IconButton(
                    onPressed: () {
                      setState(() {
                        isSaved = !isSaved;
                      });
                    },
                    icon: Icon(
                      isSaved ? Icons.bookmark_border : Icons.bookmark,
                      size: 30,
                      color: Colors.blue,
                    ),
                  ),
                ],
              ),
            ),
            Container(
              child: Column(children: [
                ClipRRect(
                    borderRadius: const BorderRadius.only(
                      topLeft: Radius.circular(45),
                      topRight: Radius.circular(45),
                    ),
                    child: (widget.article.photoUrl != null)
                        ? Image(
                            image: NetworkImage(
                            widget.article.photoUrl ?? "",
                          ))
                        : Container())
              ]),
            ),
            Container(
              // width: 331,
              // height: 436,
              margin: EdgeInsets.symmetric(horizontal: 35, vertical: 20),
              child: Text(
                widget.article.content,
                style: TextStyle(
                  color: Color(0xFF2D4379),
                  fontSize: 20,
                  fontFamily: 'Poppins',
                  fontWeight: FontWeight.w400,
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
