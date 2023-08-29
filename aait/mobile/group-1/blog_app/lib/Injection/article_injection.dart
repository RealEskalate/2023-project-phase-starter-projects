// import 'package:blog_app/features/Article/domain/usecases/get_article.dart';
// import 'package:blog_app/features/Article/presentation/bloc/article_bloc/article_bloc.dart';
// import 'package:blog_app/features/blog/data/datasources/remote_remote_data_source.dart';
// import 'package:blog_app/features/blog/data/repository/article_repository_implimentation.dart';
// import 'package:blog_app/features/blog/domain/entities/create_article_entity.dart';
// import 'package:blog_app/features/blog/domain/repositories/article_repository.dart';
// import 'package:blog_app/features/blog/domain/usecases/create_article.dart';
// import 'package:blog_app/features/blog/domain/usecases/update_article.dart';
// import 'package:get_it/get_it.dart';
// import 'package:internet_connection_checker/internet_connection_checker.dart';
// import 'package:shared_preferences/shared_preferences.dart';

// import '../core/network/network_info.dart';
// import '../features/Article/domain/entities/article_enitity.dart';

// final sl = GetIt.instance;

// Future<void> init() async {
//   //! Features - Task Management
//   // Bloc
//   sl.registerFactory(() => ArticleBloc());

//   // Use cases
//   sl.registerLazySingleton(() => GetArticle(sl()));
//   sl.registerLazySingleton(() => CreateArticle(sl()));
//   sl.registerLazySingleton(() => UpdateArticle(sl()));
  
//   // Repository
//   sl.registerLazySingleton<ArticleRemoteDataSource>(
//       () => ArticleRemoteDataSourceImpl());
//   sl.registerLazySingleton<ArticleRepository>(
//       () => ArticleRepositoryImpl(networkInfo: sl(), remoteDataSource: sl()));

//   // classes
//   sl.registerLazySingleton(() => <Article>[]);
//   sl.registerLazySingleton(() => <CreateArticleEntity>[]);
//   //! Core
//   sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

//   //! External
//   sl.registerLazySingleton(() => InternetConnectionChecker());

//   final sharedPreferences = await SharedPreferences.getInstance();
//   sl.registerLazySingleton(() => sharedPreferences);
// }
