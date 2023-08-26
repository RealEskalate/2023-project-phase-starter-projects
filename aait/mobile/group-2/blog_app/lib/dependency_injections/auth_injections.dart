import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../core/network/network_info.dart';
import '../features/authentication/data/data_sources/local_data_source.dart';
import '../features/authentication/data/data_sources/local_data_source_impl.dart';
import '../features/authentication/data/data_sources/remote_data_source.dart';
import '../features/authentication/data/data_sources/remote_data_source_impl.dart';
import '../features/authentication/data/repositories/auth_repository_impl.dart';
import '../features/authentication/domain/repositories/auth_repo.dart';
import '../features/authentication/domain/use_cases/auth_use_case.dart';
import '../features/authentication/presentation/bloc/auth_bloc.dart';

final sl = GetIt.instance;

Future<void> init() async {
  // Feature-Authentication
  //! Bloc
  sl.registerFactory(
    () => AuthBloc(
      loginUseCase: sl(),
      signUpUseCase: sl(),
      logoutUseCase: sl(),
    ),
  );

  //! Use cases
  sl.registerLazySingleton(
    () => LoginUseCase(
      authRepository: sl(),
    ),
  );

  sl.registerLazySingleton(
    () => SignUpUseCase(
      authRepository: sl(),
    ),
  );

  sl.registerLazySingleton(
    () => LogoutUseCase(
      authRepository: sl(),
    ),
  );

  //! Repository

  sl.registerLazySingleton<AuthRepository>(
    () => AuthRepositoryImpl(
      authRemoteDataSource: sl(),
      authLocalDataSource: sl(),
      networkInfo: sl(),
    ),
  );

  //! Data sources

  sl.registerLazySingleton<AuthRemoteDataSource>(
    () => AuthRemoteDataSourceImpl(
      client: sl(),
    ),
  );

  sl.registerLazySingleton<AuthLocalDataSource>(
    () => AuthLocalDataSourceImpl(
      sharedPreferences: sl(),
    ),
  );

  //! Core
  sl.registerLazySingleton<NetworkInfo>(
    () => NetworkInfoImpl(
      sl(),
    ),
  );

  //! External
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}
