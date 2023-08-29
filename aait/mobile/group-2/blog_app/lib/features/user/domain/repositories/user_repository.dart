import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../article/data/models/article_model.dart';
import '../../../article/domain/entities/article.dart';
import '../entities/user_data.dart';

abstract class UserRepository {
  Future<Either<Failure, UserData>> getUserData(String token);
  Future<Either<Failure, UserData>> updateUserPhoto(
      String token, String imagePath);
  Future<Either<Failure, List<Article>>> getBookmarkedArticles();
  Future<Either<Failure, ArticleModel>> addBookmark(ArticleModel article);
}
