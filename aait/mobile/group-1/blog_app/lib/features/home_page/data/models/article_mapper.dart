import '../../domain/entities/article.dart';
import 'article_model.dart';

extension ArticleMapper on Article {
  ArticleModel toArticleModel() {
    return ArticleModel(
      id: id,
      title: title,
      subTitle: subTitle,
      content: content,
      tags: tags,
      author: author,
      date: date,
      photoUrl: photoUrl,
      estimatedReadTime: estimatedReadTime,
    );
  }
}
