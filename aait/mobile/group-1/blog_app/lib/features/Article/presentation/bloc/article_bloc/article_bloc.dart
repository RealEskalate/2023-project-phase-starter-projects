import 'package:blog_app/features/Article/domain/usecases/create_article.dart';
import 'package:blog_app/features/Article/domain/usecases/update_article.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../../core/network/network_info.dart';
import '../../../../../injection_container.dart';
import '../../../data/datasources/remote_remote_data_source.dart';
import '../../../data/repository/article_repository_implimentation.dart';
import '../../../domain/repositories/article_repository.dart';
import 'article_event.dart';
import 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  final NetworkInfo networkInfo = sl();
  final ArticleRemoteDataSource remoteDataSource = sl();

  ArticleBloc() : super(Idle()) {
    ArticleRepository repository = ArticleRepositoryImpl(
        networkInfo: networkInfo, remoteDataSource: remoteDataSource);

    on<CreateArticleEvent>((CreateArticleEvent event, Emitter emit) async {
      CreateArticle createArticle = CreateArticle(repository);
    });

    on<UpdateArticleEvent>((UpdateArticleEvent event, Emitter emit) async {
      UpdateArticle updateArticle = UpdateArticle(repository);
    });

    on<GetArticleEvent>((GetArticleEvent event, Emitter emit) async {});
  }
}
