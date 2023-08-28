import 'package:blog_app/features/blog/domain/usecases/create_article.dart';
import 'package:blog_app/features/blog/domain/usecases/update_article.dart';
import 'package:blog_app/features/blog/presentation/bloc/article_bloc/article_bloc.dart';
import 'package:blog_app/features/user_profile/data/repository/user_repository_implementaion.dart';
import 'package:blog_app/features/user_profile/domain/repositories/user_repository.dart';
import 'package:blog_app/features/user_profile/domain/usecases/get_user_info.dart';
import 'package:blog_app/features/user_profile/domain/usecases/update_user_info.dart';
import 'package:blog_app/features/user_profile/presentation/bloc/profile_bloc.dart';
import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'core/network/network_info.dart';
import 'features/blog/data/datasources/remote_remote_data_source.dart';
import 'features/user_profile/data/datasources/profile_local_data_source.dart';
import 'features/user_profile/data/datasources/proile_remote_data_source.dart';
import 'features/user_profile/domain/entities/user_entity.dart';

final sl = GetIt.instance;

Future<void> init() async {
  //! Features - Task Management
  // Bloc
  sl.registerFactory(() => ProfileBloc());
  sl.registerFactory(() => ArticleBloc());

  // Use cases
  sl.registerLazySingleton(() => GetUserInfo(sl()));
  sl.registerLazySingleton(() => UpdateUserInfo(sl()));
  sl.registerLazySingleton(() => UpdateArticle(sl()));
  sl.registerLazySingleton(() => CreateArticle(sl()));

  // Repository
  sl.registerLazySingleton<UserRepository>(() => UserRepositoryImpl(
      localDataSource: sl(), networkInfo: sl(), remoteDataSource: sl()));

  // Data sources
  sl.registerLazySingleton<ProfileLocalDataSource>(
      () => ProfileLocalDataSourceImpl());

  sl.registerLazySingleton<ProfileRemoteDataSource>(
      () => ProfileRemoteDataSourceImpl());

  sl.registerLazySingleton<ArticleRemoteDataSource>(
      () => articleRemoteDataSourceImpl());
  // classes
  sl.registerLazySingleton(() => <User>[]);

  //! Core
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  //! External
  sl.registerLazySingleton(() => InternetConnectionChecker());

  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
}

articleRemoteDataSourceImpl() {}
