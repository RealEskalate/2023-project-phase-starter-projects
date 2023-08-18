import 'package:get_it/get_it.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/core/platform/network_info.dart';
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_local_data_source.dart';
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

  sl.registerSingleton<TodoLocalDataSource>(
      TodoLocalDataSourceImp(sharedPreferences: sl()));
  sl.registerSingleton<TodoRepository>(TodoRepositoryImpl(sl()));
  sl.registerLazySingleton(() => GetAllTask(sl()));
  sl.registerLazySingleton(() => GetSingleTask(sl()));
  sl.registerLazySingleton(() => UpdateTask(sl()));
  sl.registerLazySingleton(() => DeleteTask(sl()));

  // network info
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));
}
