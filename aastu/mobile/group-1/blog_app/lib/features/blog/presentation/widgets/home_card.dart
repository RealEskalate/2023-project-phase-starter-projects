import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:flutter/material.dart';

class CustomizedCard extends StatefulWidget {
  final Article article;
  const CustomizedCard({super.key, required this.article});

  @override
  State<CustomizedCard> createState() => _CustomizedCardState();
}

class _CustomizedCardState extends State<CustomizedCard> {
  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () {},
      child: Container(
        height: 140,
        width: double.infinity,
        padding: const EdgeInsets.fromLTRB(15, 5, 15, 5),
        child: Column(
          children: <Widget>[
            Expanded(
              child: Row(
                children: <Widget>[
                  Card(
                    margin: const EdgeInsets.all(0),
                    elevation: 0,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(8),
                    ),
                    clipBehavior: Clip.antiAliasWithSaveLayer,
                    child: widget.article.image != null
                        ? Image.network(
                            widget.article.image!,
                            height: 100,
                            width: 100,
                            fit: BoxFit.cover,
                          )
                        : Image.asset(
                            "assets/images/doctor.jpg",
                            height: 100,
                            width: 100,
                            fit: BoxFit.cover,
                          ),
                  ),
                  Container(width: 10),
                  Expanded(
                    child: Column(
                      children: <Widget>[
                        Text(
                          widget.article.title ?? "",
                          maxLines: 3,
                          style: const TextStyle(fontSize: 20),
                        ),
                        Container(height: 5),
                        ElevatedButton(
                          onPressed: () {
                            // Add your onPressed callback here
                          },
                          style: ElevatedButton.styleFrom(
                            backgroundColor: const Color(
                                0xFF333333), // Background color (#333)
                            minimumSize: const Size(50, 26), // Small size
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(
                                  8), // Rectangular shape with rounded corners
                            ),
                          ),
                          child: const Text(
                            "Education",
                            style: TextStyle(
                              color: Colors.white, // Text color
                              fontSize: 14,
                            ),
                          ),
                        ),
                        Row(
                          children: <Widget>[
                            Text(
                              "By ${widget.article.user?.fullName}",
                            ),
                          ],
                        ),
                      ],
                    ),
                  )
                ],
              ),
            ),
            Container(height: 10),
            const Divider(height: 0)
          ],
        ),
      ),
    );
  }
}
