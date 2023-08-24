import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'core/network/custom_client.dart';
import 'core/network/network_info.dart';
import 'features/article/data/datasources/local/local.dart';
import 'features/article/data/datasources/remote/remote.dart';
import 'features/article/data/repositories/article_repository_impl.dart';
import 'features/article/domain/repositories/article_repository.dart';
import 'features/article/domain/usecases/usecases.dart';
import 'features/article/presentation/bloc/article_bloc.dart';

final serviceLocator = GetIt.instance;

Future<void> init() async {
  //! Features - Article
  // Bloc
  serviceLocator.registerFactory(
    () => ArticleBloc(
      createArticle: serviceLocator(),
      deleteArticle: serviceLocator(),
      getAllArticles: serviceLocator(),
      getArticle: serviceLocator(),
      updateArticle: serviceLocator(),
    ),
  );

  // Use cases
  serviceLocator.registerLazySingleton(
    () => CreateArticle(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => UpdateArticle(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => DeleteArticle(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => GetAllArticles(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => GetArticle(serviceLocator()),
  );

  // Core
  serviceLocator.registerLazySingleton<NetworkInfo>(
      () => NetworkInfoImpl(serviceLocator()));
  serviceLocator.registerLazySingleton<CustomClient>(
      () => CustomClient(serviceLocator()));

  // Repository
  serviceLocator.registerLazySingleton<ArticleRepository>(
    () => ArticleRepositoryImpl(
      remoteDataSource: serviceLocator(),
      localDataSource: serviceLocator(),
      networkInfo: serviceLocator(),
    ),
  );

  // Data sources
  serviceLocator.registerLazySingleton<ArticleLocalDataSource>(
    () => ArticleLocalDataSourceImpl(sharedPreferences: serviceLocator()),
  );
  serviceLocator.registerLazySingleton<ArticleRemoteDataSource>(
    () => ArticleRemoteDataSourceImpl(client: serviceLocator()),
  );

  // External
  final sharedPreferences = await SharedPreferences.getInstance();
  serviceLocator.registerLazySingleton(() => sharedPreferences);
  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
  serviceLocator.registerLazySingleton(() => http.Client());
}
