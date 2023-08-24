class Article {
  Article({
    required this.id,
    required this.title,
    required this.content,
    required this.authorId,
    required this.subTitle,
    this.image,
    this.tags = const [],
  });

  final String id;
  final String title;
  final String subTitle;
  final String content;
  final String authorId;
  final String? image;
  final List<String> tags;
}

// "_id": "64e26b23fe68a176cdbc52c4",
//         "tags": [
//           "Others",
//           "Sports"
//         ],
//         "content": "Triceps workout are very important",
//         "title": "Workout",
//         "subTitle": "Triceps",
//         "estimatedReadTime": "5min",
//         "user": "64e25674bfc65d390e781205",
//         "image": "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692560163/usay3yegvnh0abxfslvh.png",
//         "imageCloudinaryPublicId": "usay3yegvnh0abxfslvh",
//         "createdAt": "2023-08-20T19:36:03.414Z",
//         "__v": 0,
//         "id": "64e26b23fe68a176cdbc52c4"