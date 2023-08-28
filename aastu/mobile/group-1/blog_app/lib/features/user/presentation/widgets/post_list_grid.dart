import 'package:blog_app/core/utils/human_readable_time.dart';
import 'package:blog_app/features/blog/presentation/screen/viewBlog.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import '../widgets/like_button.dart';

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

List<Blog> grid_blogs = [
  Blog(
      image: 'assets/images/bigdata.png',
      title: 'Blog Title 1',
      subtitle: 'Subtitle 1',
      date: '2023-08-01',
      category: 'Big Data',
      likes: 200),
  Blog(
      image: 'assets/images/bif.jpg',
      title: 'Blog Title 2',
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

class BlogGridCards extends StatelessWidget {
  final Blog object;
  final int index;

  const BlogGridCards({
    Key? key,
    required this.index,
    required this.object,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    double screenWidth = MediaQuery.of(context).size.width;
    double screenHeight = MediaQuery.of(context).size.height;
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
        height: 210,
        color: Color(0xFFF8FAFF),
        padding: const EdgeInsets.fromLTRB(20, 5, 20, 5),
        margin: const EdgeInsets.all(5),
        child: Center(
          child: Column(
            children: <Widget>[
              Expanded(
                child: Card(
                  margin: const EdgeInsets.all(0),
                  elevation: 0,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(8),
                  ),
                  clipBehavior: Clip.antiAliasWithSaveLayer,
                  child: Image.asset(
                    object.image,
                    height: screenHeight * 0.14,
                    width: screenWidth * 0.25,
                    fit: BoxFit.cover,
                  ),
                ),
              ),
              Expanded(
                child: Column(
                  crossAxisAlignment:
                      CrossAxisAlignment.center, // Align text to the left
                  children: <Widget>[
                    Text(
                      object.category,
                      maxLines: 3,
                      style: const TextStyle(
                        color: Color.fromARGB(255, 70, 66, 66),
                        fontWeight: FontWeight.w200,
                        fontSize: 1,
                        fontFamily: 'Urbanist',
                      ),
                    ),
                    Row(
                      children: <Widget>[
                        LikeButton(
                          initialLikes: object.likes,
                          onLikeChanged: (isLiked, likes) {
                            print('Is Liked: $isLiked,K: $likes');
                          },
                        ),
                        const Spacer(),
                        const FaIcon(
                          FontAwesomeIcons.solidBookmark,
                          size: 17,
                        )
                      ],
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
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
                      ],
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
