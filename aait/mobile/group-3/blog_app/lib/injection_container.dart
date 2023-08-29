import 'package:blog_app/features/auth/data/data_sources/local_data_source.dart';
import 'package:blog_app/features/auth/data/data_sources/remote_data_source.dart';
import 'package:blog_app/features/auth/data/repository/auth_repository_impl.dart';
import 'package:blog_app/features/auth/domain/repository/auth_repository.dart';
import 'package:blog_app/features/auth/domain/use_case/login_usecase.dart';
import 'package:blog_app/features/auth/domain/use_case/signup_usecase.dart';
import 'package:blog_app/features/auth/presentation/bloc/login_bloc/bloc/login_bloc.dart';
import 'package:blog_app/features/auth/presentation/bloc/signup_bloc/bloc/signup_bloc.dart';
import 'package:blog_app/features/profile/data/data_sources/profile_local_data_source.dart';
import 'package:blog_app/features/profile/data/data_sources/profile_remote_data_source.dart';
import 'package:blog_app/features/profile/data/repository/profile_repository_impl.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:blog_app/features/profile/domain/use_case/get_profile.dart';
import 'package:blog_app/features/profile/domain/use_case/update_profile_picture.dart';
import 'package:blog_app/features/profile/presentation/bloc/profile_bloc.dart';
import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'core/network/network_info.dart';

final serviceLocator = GetIt.instance;

Future<void> init() async {
  //! Features - Article
  // Bloc
  serviceLocator.registerFactory(
    () => ProfileBloc(
        getProfile: serviceLocator(), updateProfilePicture: serviceLocator()),
  );

  serviceLocator.registerFactory(
    () => SignupBloc(signUpUsecase: serviceLocator()),
  );

  serviceLocator.registerFactory(
    () => LoginBloc(logInUsecase: serviceLocator()),
  );


  // Use cases
  serviceLocator.registerLazySingleton(
    () => GetProfile(repository: serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => UpdateProfilePicture(repository: serviceLocator()),
  );

  serviceLocator.registerLazySingleton(
    () => LogInUsecase(serviceLocator()),
  );

  serviceLocator.registerLazySingleton(
    () => SignUpUsecase(serviceLocator()),
  );


  // Core
  serviceLocator.registerLazySingleton<NetworkInfo>(
      () => NetworkInfoImpl(serviceLocator()));

  // Repository
  serviceLocator.registerLazySingleton<ProfileRepository>(
    () => ProfileRepositoryImpl(
      remoteDataSource: serviceLocator(),
      localDataSource: serviceLocator(),
      networkInfo: serviceLocator(),
    ),
  );

  serviceLocator.registerLazySingleton<AuthRepository>(
    () => AuthRepositoryImpl(serviceLocator())
  );


  // Data sources
  serviceLocator.registerLazySingleton<ProfileLocalDataSource>(
    () => ProfileLocalDataSourceImpl(sharedPreferences: serviceLocator()),
  );
  serviceLocator.registerLazySingleton<ProfileRemoteDataSource>(
    () => ProfileRemoteDataSourceImpl(client: serviceLocator()),
  );

  serviceLocator.registerLazySingleton<AuthRemoteDataSource>(
    () => AuthRemoteDataSourceImpl(networkInfo: serviceLocator(), localDataSource: serviceLocator()),
  );

  serviceLocator.registerLazySingleton<LocalDataSource>(
    () => LocalDataSourceImpl(prefs: serviceLocator()),
  );

  // External
  final sharedPreferences = await SharedPreferences.getInstance();
  serviceLocator.registerLazySingleton(() => sharedPreferences);
  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
  serviceLocator.registerLazySingleton(() => http.Client());  
}
