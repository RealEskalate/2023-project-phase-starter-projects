import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../core/network/network_info.dart';
import '../core/utils/input_converter.dart';
import '../features/authentication_and_authorization/data/data_source/auth_local_data_source.dart';
import '../features/authentication_and_authorization/data/data_source/auth_local_data_source_Impl.dart';
import '../features/authentication_and_authorization/data/data_source/auth_remote_data_source.dart';
import '../features/authentication_and_authorization/data/data_source/auth_remote_data_source_Impl.dart';
import '../features/authentication_and_authorization/data/repository/auth_repository_Impl.dart';
import '../features/authentication_and_authorization/domain/repositories/auth_repository.dart';
import '../features/authentication_and_authorization/domain/usecases/login_use_case.dart';
import '../features/authentication_and_authorization/domain/usecases/sign_up_use_case.dart';
import '../features/authentication_and_authorization/presentation/bloc/Log_in_bloc/bloc.dart';
import '../features/authentication_and_authorization/presentation/bloc/sign_up_bloc/bloc.dart';

final sl = GetIt.instance;
Future<void> init() async {
  //Bloc
  sl.registerFactory(() => SignUpBloc(signUp: sl(), loginUseCase: sl()));
  sl.registerFactory(() => LogInBloc(loginUseCase: sl()));

  //usecases

  sl.registerLazySingleton(() => SignUpUseCase(repository: sl()));
  sl.registerLazySingleton(() => LoginUseCase(repository: sl()));

  //repository
  sl.registerLazySingleton<AuthRepository>(() => AuthRepositoryImpl(
      authLocalDataSource: sl(),
      authRemoteDataSource: sl(),
      networkInfo: sl()));
  //datasource
  sl.registerLazySingleton<AuthRemoteDataSource>(
      () => AuthRemoteDataSourceImpl(client: sl()));
  sl.registerLazySingleton<AuthLocalDataSource>(
      () => LocalDataSourceImpl(sharedPreferences: sl()));
  //! Core
  sl.registerLazySingleton(() => InputConverter());

  sl.registerLazySingleton(() => http.Client());
}
