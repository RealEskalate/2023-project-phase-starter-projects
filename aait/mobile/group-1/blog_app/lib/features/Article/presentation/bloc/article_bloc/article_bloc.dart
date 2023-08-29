import 'package:blog_app/features/Article/domain/entities/article_enitity.dart';
import 'package:blog_app/features/Article/domain/usecases/create_article.dart';
import 'package:blog_app/features/Article/domain/usecases/get_article.dart';
import 'package:blog_app/features/Article/domain/usecases/update_article.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../../../../../Injection/article_injection.dart';
import '../../../../../Injection/injection_container.dart';
import '../../../../../core/network/network_info.dart';
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
      CreateArticle usecase = CreateArticle(repository);
      emit(Loading());
      await usecase.repository.createArticle(event.article);
      emit(Idle());
    });

    on<UpdateArticleEvent>((UpdateArticleEvent event, Emitter emit) async {
      UpdateArticle usecase = UpdateArticle(repository);
      emit(Loading());
      await usecase.repository.updateArticle(event.article);
      emit(Idle());
    });

    on<GetArticleEvent>((GetArticleEvent event, Emitter emit) async {
      GetArticle usecase = GetArticle(repository);
      final article = await usecase.repository.getArticle(event.id);
      if (article is Article) {
        emit(ArticleFetched(article as Article));
      } else {
        emit(Error());
      }
    });
  }
}
