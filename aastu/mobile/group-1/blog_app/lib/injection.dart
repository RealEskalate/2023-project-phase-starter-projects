import 'package:blog_app/core/platform/network_info.dart';
import 'package:blog_app/features/blog/data/datasources/data_source_api.dart';
import 'package:blog_app/features/blog/data/datasources/remote_data_source.dart';
import 'package:blog_app/features/blog/data/repositories/article_repository_imp.dart';
import 'package:blog_app/features/blog/domain/repositories/article_repository.dart';
import 'package:blog_app/features/blog/domain/usecases/create_article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/blog/domain/usecases/get_single_article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_tags.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc.dart';
import 'package:blog_app/features/user/data/datasources/local_data_source.dart';
import 'package:blog_app/features/user/data/datasources/remote_data_source.dart';
import 'package:blog_app/features/user/data/datasources/data_source_api.dart';
import 'package:blog_app/features/user/data/repositories/repository_imp.dart';
import 'package:blog_app/features/user/domain/repositories/user_repository.dart';
import 'package:blog_app/features/user/domain/usecases/get_user.dart';
import 'package:blog_app/features/user/domain/usecases/login_user.dart';
import 'package:blog_app/features/user/domain/usecases/register_user.dart';
import 'package:blog_app/features/user/domain/usecases/update_user.dart';
import 'package:blog_app/features/user/presentation/blocs/bloc.dart';
import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'package:http/http.dart' as http;

final sl = GetIt.instance;

Future<void> init() async {
  final sharedPreference = await SharedPreferences.getInstance();
  sl.registerSingleton<SharedPreferences>(sharedPreference);

  // Register network info
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());

  // register bloc
  sl.registerFactory(() => UserBloc(
        registerUser: sl(),
        loginUser: sl(),
        getUser: sl(),
        updateProfilePhoto: sl(),
      ));
  //

  // register blog
  sl.registerFactory(() => BlogBloc(
        getAllArticle: sl(),
        getSingleArticle: sl(),
        getTags: sl(),
        createArticle: sl<CreateArticleUseCase>(),
      ));

  // Register use cases
  sl.registerFactory(() => RegisterUserUseCase(sl()));
  sl.registerFactory(() => LoginUserUseCase(sl()));
  sl.registerFactory(() => GetUserUseCase(sl()));
  sl.registerFactory(() => UpdateProfilePhotoUseCase(sl()));

  // Register usecases
  sl.registerFactory(() => CreateArticleUseCase(sl()));
  sl.registerFactory(() => GetArticleUseCase(sl()));
  sl.registerFactory(() => GetSingleArticleUseCase(sl()));
  sl.registerFactory(() => GetTagsUseCase(sl()));

  // register ArticleRepositoryImpl
  sl.registerLazySingleton<ArticleRepository>(
      () => ArticleRepositoryImpl(remoteDataSource: sl()));

  //RemoteDataSource
  sl.registerLazySingleton<BlogRemoteDataSource>(() =>
      RemoteDataSource(baseUrl: 'https://blog-api-4z3m.onrender.com/api/v1'));

  sl.registerLazySingleton<UserApiDataSource>(() =>
      UserApiDataSource(baseUrl: 'https://blog-api-4z3m.onrender.com/api/v1'));
  // UserLocalDataSourceImpl
  sl.registerLazySingleton<UserLocalDataSource>(
      () => UserLocalDataSourceImpl(sharedPreferences: sl()));
  // Register repositories
  sl.registerLazySingleton<UserRepository>(
      () => UserRepositoryImpl(remoteDataSource: sl(), localDataSource: sl()));

//'https://blog-api-4z3m.onrender.com'
}
