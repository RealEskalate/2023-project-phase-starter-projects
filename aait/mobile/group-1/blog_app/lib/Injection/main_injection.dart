import 'package:blog_app/features/home_page/data/datasources/local/local_datasource.dart';
import 'package:blog_app/features/home_page/data/datasources/local/local_datasource_impl.dart';
import 'package:blog_app/features/home_page/data/repositories/article_repository_impl.dart';
import 'package:blog_app/features/home_page/domain/repository/article_repository.dart';
import 'package:blog_app/features/home_page/domain/usecases/filter_articles.dart';
import 'package:blog_app/features/home_page/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/home_page/domain/usecases/get_article.dart';
import 'package:get_it/get_it.dart';

import '../features/home_page/data/datasources/remote/remote_datasource.dart';
import '../features/home_page/data/datasources/remote/remote_datasource_impl.dart';
import '../features/home_page/presentation/bloc/article_bloc.dart';

final sl = GetIt.instance;

Future<void> init() async {
  //! Features - Task Management
  // Bloc
  sl.registerFactory(() => ArticleBloc(
      filterArticles: sl(), getAllArticles: sl(), getArticle: sl()));

  // Use cases
  sl.registerLazySingleton(() => FilterArticles(sl()));
  sl.registerLazySingleton(() => GetAllArticles(sl()));
  sl.registerLazySingleton(() => GetArticle(sl()));

  // sl.registerLazySingleton(() => LoginUseCase(repository: sl()));

  // Repository
  sl.registerLazySingleton<ArticleRepository>(() => ArticleRepositoryImpl(
      localDataSource: sl(), networkInfo: sl(), remoteDataSource: sl()));

  // Data sources
  sl.registerLazySingleton<ArticleLocalDataSource>(
      () => ArticleLocalDataSourceImpl(sharedPreferences: sl()));
  sl.registerLazySingleton<ArticleRemoteDataSource>(
      () => ArticleRemoteDataSourceImpl(client: sl()));

  // classes

  // //! Core
  // sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  // //! External
  // sl.registerLazySingleton(() => InternetConnectionChecker());

  // final sharedPreferences = await SharedPreferences.getInstance();
  // sl.registerLazySingleton(() => sharedPreferences);
}
