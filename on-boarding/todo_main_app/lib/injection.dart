import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';
import 'package:todo_main_app/core/usecases/create_task.dart';
import 'package:todo_main_app/core/usecases/delete_task.dart';
import 'package:todo_main_app/core/usecases/get_all_tasks.dart';
import 'package:todo_main_app/core/usecases/update_task.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_data_source.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_local_data_source.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/todo_bloc.dart';

final sl = GetIt.instance;

Future<void> init() async {
  //! Features - Todo
  // Bloc
  sl.registerFactory(
    () => TodoBloc(
      getAllTasks: sl(),
      getSingleTask: sl(),
      updateTask: sl(),
      deleteTask: sl(),
      createTask: sl(),
    ),
  );

  // Use cases
  sl.registerLazySingleton(() => GetTodosUseCase(sl()));
  sl.registerLazySingleton(() => CreateTask(sl()));
  sl.registerLazySingleton(() => UpdateTask(sl()));
  sl.registerLazySingleton(() => DeleteTask(sl()));

  // Repository
  sl.registerLazySingleton<TodoRepository>(
    () => TodoRepositoryImpl(sl()),
  );
  // Data sources
  sl.registerLazySingleton<TodoDataSource>(
    () => TodoLocalDataSource(
      sharedPreferences: sl(),
    ),
  );

  //! External
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => InternetConnectionChecker());
}
