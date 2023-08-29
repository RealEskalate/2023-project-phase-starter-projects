import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'core/constants/constants.dart';
import 'core/network/custom_client.dart';
import 'core/network/network_info.dart';
import 'features/article/data/datasources/local/local.dart';
import 'features/article/data/datasources/remote/remote.dart';
import 'features/article/data/repositories/article_repository_impl.dart';
import 'features/article/domain/repositories/article_repository.dart';
import 'features/article/domain/usecases/usecases.dart';
import 'features/article/presentation/bloc/article_bloc.dart';
import 'features/article/presentation/bloc/bookmark_bloc.dart';
import 'features/article/presentation/bloc/tag_bloc.dart';
import 'features/article/presentation/bloc/tag_selector_bloc.dart';
import 'features/authentication/data/data_sources/local_data_source.dart';
import 'features/authentication/data/data_sources/local_data_source_impl.dart';
import 'features/authentication/data/data_sources/remote_data_source.dart';
import 'features/authentication/data/data_sources/remote_data_source_impl.dart';
import 'features/authentication/data/repositories/auth_repository_impl.dart';
import 'features/authentication/domain/repositories/auth_repo.dart';
import 'features/authentication/domain/use_cases/auth_use_case.dart';
import 'features/authentication/presentation/bloc/auth_bloc.dart';
import 'features/user/data/datasources/local/user_local_data_source.dart';
import 'features/user/data/datasources/local/user_local_data_source_impl.dart';
import 'features/user/data/datasources/user_remote_data_source.dart';
import 'features/user/data/datasources/user_remote_data_source_impl.dart';
import 'features/user/data/repositories/user_repository_impl.dart';
import 'features/user/domain/repositories/user_repository.dart';
import 'features/user/domain/usecases/user_usecases/get_user_data_usecase.dart';
import 'features/user/domain/usecases/user_usecases/update_user_photo_usecase.dart';
import 'features/user/presentation/bloc/profile_page_bloc.dart';
import 'features/user/presentation/bloc/user_bloc.dart';

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
        filterArticles: serviceLocator()),
  );
  serviceLocator.registerFactory(
    () => BookmarkBloc(
      loadBookmarks: serviceLocator(),
      addToBookmark: serviceLocator(),
      removeFromBookmark: serviceLocator(),
    ),
  );
  serviceLocator.registerFactory(
    () => TagSelectorBloc(),
  );
  serviceLocator.registerFactory(
    () => TagBloc(getTags: serviceLocator()),
  );
  serviceLocator.registerFactory(
    () => ProfilePageBloc(),
  );

  serviceLocator.registerFactory(() => UserBloc(
        getUser: serviceLocator(),
        updateUserPhoto: serviceLocator(),
      ));

  // Use cases
  serviceLocator.registerLazySingleton(
    () => GetTags(serviceLocator()),
  );

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
  serviceLocator.registerLazySingleton(
    () => FilterArticles(serviceLocator()),
  );

  serviceLocator.registerLazySingleton(
    () => LoadBookmarks(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => AddToBookmark(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => RemoveFromBookmark(serviceLocator()),
  );

  serviceLocator.registerLazySingleton(
    () => GetUserData(serviceLocator()),
  );

  serviceLocator.registerLazySingleton(
    () => UpdateUserPhoto(serviceLocator()),
  );

  serviceLocator.registerLazySingleton(
    () => GetTokenUseCase(authRepository: serviceLocator()),
  );

  // Core
  serviceLocator.registerLazySingleton<NetworkInfo>(
      () => NetworkInfoImpl(serviceLocator()));
  serviceLocator.registerLazySingleton<CustomClient>(
    () => CustomClient(serviceLocator(), apiBaseUrl: apiBaseUrl),
  );

  // Repository
  serviceLocator.registerLazySingleton<ArticleRepository>(
    () => ArticleRepositoryImpl(
      remoteDataSource: serviceLocator(),
      localDataSource: serviceLocator(),
      networkInfo: serviceLocator(),
    ),
  );

  serviceLocator.registerLazySingleton<UserRepository>(
    () => UserRespositoryImpl(
      networkInfo: serviceLocator(),
      remoteDataSource: serviceLocator(),
      localDataSource: serviceLocator(),
    ),
  );

  // Data sources
  serviceLocator.registerLazySingleton<ArticleLocalDataSource>(
    () => ArticleLocalDataSourceImpl(sharedPreferences: serviceLocator()),
  );
  serviceLocator.registerLazySingleton<ArticleRemoteDataSource>(
    () => ArticleRemoteDataSourceImpl(client: serviceLocator()),
  );

  serviceLocator.registerLazySingleton<UserLocalDataSource>(
    () => UserLocalDataSourceImpl(sharedPreferences: serviceLocator()),
  );
  serviceLocator.registerLazySingleton<UserRemoteDataSource>(
    () => UserRemoteDataSourceImpl(client: serviceLocator()),
  );

  // Feature-Authentication
  //! Bloc
  serviceLocator.registerFactory(
    () => AuthBloc(
      getTokenUsecase: serviceLocator(),
      loginUseCase: serviceLocator(),
      signUpUseCase: serviceLocator(),
      logoutUseCase: serviceLocator(),
      customClient: serviceLocator(),
    ),
  );

  //! Use cases
  serviceLocator.registerLazySingleton(
    () => LoginUseCase(
      authRepository: serviceLocator(),
    ),
  );

  serviceLocator.registerLazySingleton(
    () => SignUpUseCase(
      authRepository: serviceLocator(),
    ),
  );

  serviceLocator.registerLazySingleton(
    () => LogoutUseCase(
      authRepository: serviceLocator(),
    ),
  );

  //! Repository
  serviceLocator.registerLazySingleton<AuthRepository>(
    () => AuthRepositoryImpl(
      authRemoteDataSource: serviceLocator(),
      authLocalDataSource: serviceLocator(),
      networkInfo: serviceLocator(),
    ),
  );

  //! Data sources
  serviceLocator.registerLazySingleton<AuthRemoteDataSource>(
    () => AuthRemoteDataSourceImpl(
      client: serviceLocator(),
    ),
  );

  serviceLocator.registerLazySingleton<AuthLocalDataSource>(
    () => AuthLocalDataSourceImpl(
      sharedPreferences: serviceLocator(),
    ),
  );

  // External
  final sharedPreferences = await SharedPreferences.getInstance();
  serviceLocator.registerLazySingleton(() => sharedPreferences);
  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
  serviceLocator.registerLazySingleton(() => http.Client());
}
