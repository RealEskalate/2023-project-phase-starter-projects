import 'package:blog_app/features/blog/presentation/screen/viewBlog.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import '../widgets/like_button.dart';
import '../../../../core/utils/human_readable_time.dart';

class Blog {
  final String image;
  final String title;
  final String subtitle;
  final String date;
  final String category;
  final int likes;

  Blog(
      {required this.category,
      required this.image,
      required this.title,
      required this.subtitle,
      required this.date,
      required this.likes});
}

List<Blog> blogs = [
  Blog(
      image: 'assets/images/bigdata.png',
      title: 'Big Data Analytics for Beginners - Level 1',
      subtitle: 'Subtitle 1',
      date: '2023-08-01',
      category: 'Big Data',
      likes: 200),
  Blog(
      image: 'assets/images/bif.jpg',
      title:
          'Ethiopia: The Battle for Benshangul-Gumuz is a Battle for Ethiopia',
      subtitle: 'Subtitle 2',
      date: '2023-08-02',
      category: 'Scocial',
      likes: 100),
  Blog(
      image: 'assets/images/images.jpg',
      title: 'Blog Title 3',
      subtitle: 'Subtitle 3',
      date: '2023-08-03',
      category: 'Data science',
      likes: 300),
];

class BlogCards extends StatelessWidget {
  final Blog object;
  final int index;

  const BlogCards({
    Key? key,
    required this.index,
    required this.object,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () {
        //navigate to ViewBlog() without named
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => ViewBlog(),
          ),
        );
      },
      child: Container(
        height: 180,
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
                    child: Image.asset(
                      object.image,
                      height: 120,
                      width: 100,
                      fit: BoxFit.cover,
                    ),
                  ),
                  Container(width: 20),
                  Expanded(
                    child: Column(
                      crossAxisAlignment:
                          CrossAxisAlignment.start, // Align text to the left
                      children: <Widget>[
                        Container(height: 25),
                        Text(
                          object.title,
                          maxLines: 3,
                          style: const TextStyle(
                            color: Color.fromARGB(255, 70, 66, 66),
                            fontWeight: FontWeight.w200,
                            fontSize: 18,
                            fontFamily: 'Urbanist',
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.only(
                              top: 8.0, bottom: 16.0, left: 0, right: 8.0),
                          child: Text(
                            object.title,
                            maxLines: 3,
                            style: TextStyle(
                              color: Colors.grey[800],
                              fontWeight: FontWeight.w500,
                              fontSize: 16,
                              fontFamily: 'Urbanist',
                            ),
                          ),
                        ),
                        // Spacer(),
                        Row(
                          children: <Widget>[
                            LikeButton(
                              initialLikes: object.likes,
                              onLikeChanged: (isLiked, likes) {
                                print('Is Liked: $isLiked,K: $likes');
                              },
                            ),
                            const Spacer(),
                            const FaIcon(FontAwesomeIcons.clock,
                                size: 16, color: Colors.grey),
                            Padding(
                              padding: const EdgeInsets.only(left: 8.0),
                              child: Text(
                                formatDateTimeDifference(
                                    DateTime.parse(object.date)),
                                style: TextStyle(
                                  color: Colors.grey[400],
                                  fontSize: 12,
                                ),
                              ),
                            ),
                            const Spacer(),
                            //    const FaIcon(FontAwesomeIcons.solidBookmark)
                          ],
                        ),
                      ],
                    ),
                  )
                ],
              ),
            ),
            Container(height: 10),
            const Divider(height: 0),
          ],
        ),
      ),
    );
  }
}
