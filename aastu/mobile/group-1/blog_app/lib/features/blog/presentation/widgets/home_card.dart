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
    return Container(
      width: 388,
      height: 240,
      padding: const EdgeInsets.symmetric(horizontal: 5),
      decoration: BoxDecoration(
          color: Colors.white, borderRadius: BorderRadius.circular(12)),
      child: Row(
        children: [
          Stack(
            children: [
              Container(
                margin: const EdgeInsets.only(bottom: 50),
                width: 160,
                height: 200,
                child: Image.asset('assets/images/doctor.jpg'),
              ),
              Positioned(
                top: 35,
                left: 25,
                child: Container(
                  width: 76,
                  height: 26,
                  decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(20)),
                  child: const Center(
                    child: Text(
                      '5 min read',
                      style: TextStyle(
                          fontSize: 10, fontFamily: 'Poppins-Regular'),
                    ),
                  ),
                ),
              ),
            ],
          ),
          const SizedBox(
            width: 15,
          ),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(
                height: 16,
              ),
              SizedBox(
                width: 175,
                child: Text(
                  widget.article.title ?? 'Loading ..', // Card Title Goes here
                  style: const TextStyle(
                      fontSize: 17, fontFamily: 'Urbanist-Regular'),
                ),
              ),
              const SizedBox(
                height: 10,
              ),
              Container(
                width: 71,
                height: 24,
                decoration: BoxDecoration(
                    color: const Color(0xFF5E5F6F),
                    borderRadius: BorderRadius.circular(6)),
                child: Center(
                  child: Text(
                    widget.article.tags?[0] ?? "", //  Tag Goes here
                    style: const TextStyle(fontSize: 10, color: Colors.white),
                  ),
                ),
              ),
              const SizedBox(
                height: 10,
              ),
              Container(
                child: Text(
                  'by ${widget.article.user}', // Author Name Goes here
                  style: const TextStyle(
                      fontSize: 14, fontFamily: 'Poppins-Regular'),
                ),
              ),
              const SizedBox(
                height: 5,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  const SizedBox(width: 90),
                  Text(
                    widget.article.createdAt.toString(),
                    style: const TextStyle(
                        fontSize: 14, fontFamily: 'Poppins-ExtraLight'),
                  ),
                ],
              ),
            ],
          )
        ],
      ),
    );
  }
}
