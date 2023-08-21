import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/core/platform/network_info.dart';
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_local_data_source.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_remote_data_source.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';
import 'package:todo_main_app/features/todo/domain/repositories/todo_repository.dart';
import 'package:todo_main_app/features/todo/domain/usecases/delete_task.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_all_tasks.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_single_task.dart';
import 'package:todo_main_app/features/todo/domain/usecases/update_task.dart';

final sl = GetIt.instance;

Future<void> init() async {
  final sharedPreference = await SharedPreferences.getInstance();
  sl.registerSingleton<SharedPreferences>(sharedPreference);
  sl.registerSingleton<InternetConnectionChecker>(InternetConnectionChecker());

  // network info
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  sl.registerSingleton<TodoLocalDataSource>(
      TodoLocalDataSourceImp(sharedPreferences: sl()));
  // remote
  sl.registerSingleton<TodoRemoteDataSource>(
      TodoRemoteDataSourceImp(baseUrl: 'https://a2sv-todo-app.onrender.com'));
  sl.registerSingleton<TodoRepository>(TodoRepositoryImpl(
    localDataSource: sl(),
    remoteDataSource: sl(),
    networkInfo: sl(),
  ));
  sl.registerLazySingleton(() => GetAllTask(sl()));
  sl.registerLazySingleton(() => GetSingleTask(sl()));
  sl.registerLazySingleton(() => UpdateTask(sl()));
  sl.registerLazySingleton(() => DeleteTask(sl()));
}
