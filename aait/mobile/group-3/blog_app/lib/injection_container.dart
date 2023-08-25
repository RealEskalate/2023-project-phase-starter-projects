
import 'package:blog_app/features/profile/data/data_sources/profile_local_data_source.dart';
import 'package:blog_app/features/profile/data/data_sources/profile_remote_data_source.dart';
import 'package:blog_app/features/profile/data/repository/profile_repository_impl.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:blog_app/features/profile/domain/use_case/get_profile.dart';
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
    () => ProfileBloc(),
  );

  // Use cases
  serviceLocator.registerLazySingleton(
    () => GetProfile(repository: serviceLocator()),
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

  // Data sources
  serviceLocator.registerLazySingleton<ProfileLocalDataSource>(
    () => ProfileLocalDataSourceImpl(sharedPreferences: serviceLocator()),
  );
  serviceLocator.registerLazySingleton<ProfileRemoteDataSource>(
    () => ProfileRemoteDataSourceImpl(client: serviceLocator()),
  );

  // External
  final sharedPreferences = await SharedPreferences.getInstance();
  serviceLocator.registerLazySingleton(() => sharedPreferences);
  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
  serviceLocator.registerLazySingleton(() => http.Client());
}
