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

  @override
  List<Object> get props => [title, subTitle, createdAt, image, id];
}
