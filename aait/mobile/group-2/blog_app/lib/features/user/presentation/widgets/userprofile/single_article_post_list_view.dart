import 'package:flutter/material.dart';

class SingleArticlePostListView extends StatelessWidget {
  final String imageUrl, articleTitle, articleSubTitle, likes;
  final double timeSincePosted;
  const SingleArticlePostListView({
    Key? key,
    required this.imageUrl,
    required this.articleTitle,
    required this.articleSubTitle,
    required this.likes,
    required this.timeSincePosted,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 20),
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(16.0),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            SizedBox(
              width: 92,
              height: 141,
              child: ClipRRect(
                borderRadius: BorderRadius.circular(16),
                child: Image.network(
                  imageUrl,
                  fit: BoxFit.cover,
                ),
              ),
            ),
            const SizedBox(width: 20),
            Expanded(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    articleTitle,
                    style: const TextStyle(
                      fontWeight: FontWeight.w100,
                      fontSize: 14,
                      color: Color(0xFF376AED),
                    ),
                  ),
                  const SizedBox(height: 4),
                  Text(
                    articleSubTitle,
                    style: const TextStyle(
                      fontWeight: FontWeight.w500,
                      fontSize: 14,
                      color: Color(0xFF0D253C),
                    ),
                  ),
                  const SizedBox(height: 21),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                        children: [
                          const Icon(
                            Icons.thumb_up_alt_outlined,
                            color: Color(
                              0xFF2D4379,
                            ),
                          ),
                          const SizedBox(
                            width: 6,
                          ),
                          Text(
                            likes,
                            style: const TextStyle(
                              fontSize: 12,
                              fontWeight: FontWeight.w500,
                              color: Color(0xFF2D4379),
                            ),
                          ),
                        ],
                      ),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                        children: [
                          const Icon(Icons.access_time,
                              color: Color(
                                0xFF2D4379,
                              )),
                          const SizedBox(
                            width: 6,
                          ),
                          Text(
                            "$timeSincePosted hr ago",
                            style: const TextStyle(
                              fontSize: 12,
                              fontWeight: FontWeight.w500,
                              color: Color(0xFF2D4379),
                            ),
                          ),
                        ],
                      ),
                      const Icon(Icons.bookmark_outlined,
                          color: Color(
                            0xFF376AED,
                          )),
                    ],
                  )
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
