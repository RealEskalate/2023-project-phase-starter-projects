import 'package:equatable/equatable.dart';

class Article extends Equatable {
  final List<String> tags;
  final String content;
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final Map<String, dynamic> user;
  final String image;
  final String imageCludinaryPublicId;
  final DateTime createdAt;
  final String id;

  const Article({
    required this.tags,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.estimatedReadTime,
    required this.user,
    required this.image,
    required this.imageCludinaryPublicId,
    required this.createdAt,
    required this.id,
  });

  Article.empty()
      : this(
          tags: ['_empty.tags'],
          content: '_empty.content',
          title: '_empty.title',
          subTitle: '_empty.subTitle',
          estimatedReadTime: '_empty.estimatedReadTime',
          user: {
            "_id": "64e25674bfc65d390e781205",
            "fullName": "Tamirat Dereje",
            "email": "tamiratdereje@gmail.com",
            "expertise": "designer",
            "bio": "I am passionate designer who see beauty in everything",
            "createdAt": "2023-08-20T18:07:48.829Z",
            "__v": 0,
            "image":
                "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
            "imageCloudinaryPublicId": "guf4tul1ftar9hdpnaev",
            "id": "64e25674bfc65d390e781205"
          },
          image: '_empty.image',
          imageCludinaryPublicId: '_empty.imageCludinaryPublicId',
          createdAt: DateTime.parse('1969-07-20 20:18:04Z'),
          id: '1',
        );

  @override
  List<Object?> get props => [id];
}
