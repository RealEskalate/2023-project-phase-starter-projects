import 'package:equatable/equatable.dart';

class Article extends Equatable {
  final String title;
  final String subTitle;
  final DateTime createdAt;
  final String image;
  final String id;

  Article(
      {required this.title,
      required this.subTitle,
      required this.createdAt,
      required this.id,
      required this.image});
  String formatDate() {
    final difference = DateTime.now().difference(this.createdAt);
    if (difference.inMinutes < 1) {
      return '${difference.inSeconds}sec ago';
    } else if (difference.inHours < 1) {
      return '${difference.inMinutes}mins ago';
    } else if (difference.inDays < 1) {
      return '${difference.inHours}hr ago';
    } else {
      return '${difference.inDays}days ago';
    }
  }

  @override
  List<Object> get props => [title, subTitle, createdAt, image, id];
}
