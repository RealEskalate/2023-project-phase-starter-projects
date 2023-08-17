import 'package:flutter_test/flutter_test.dart';
import 'package:get_it/get_it.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/core/platform/network_info.dart';
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_local_data_source.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';
import 'package:todo_main_app/features/todo/domain/repositories/todo_repository.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_all_tasks.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_single_task.dart';
import 'package:mockito/mockito.dart';

class MockSharedPreferences extends Mock implements SharedPreferences {}

void main() {
  late GetIt sl;

  setUp(() {
    sl = GetIt.instance;
  });

  test('should register and resolve dependencies correctly', () async {
    // Arrange
    final mockSharedPreferences = MockSharedPreferences();

    // Register mock dependencies
    sl.registerSingleton<SharedPreferences>(mockSharedPreferences);
    sl.registerSingleton<TodoLocalDataSource>(
        TodoLocalDataSourceImp(sharedPreferences: sl()));
    sl.registerSingleton<TodoRepository>(TodoRepositoryImpl(sl()));
    sl.registerLazySingleton(() => GetAllTask(sl()));
    sl.registerLazySingleton(() => GetSingleTask(sl()));
    sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

    // Act and Assert
    expect(sl.isRegistered<SharedPreferences>(), true);
    expect(sl.isRegistered<TodoLocalDataSource>(), true);
    expect(sl.isRegistered<TodoRepository>(), true);
    expect(sl.isRegistered<GetAllTask>(), true);
    expect(sl.isRegistered<GetSingleTask>(), true);
    expect(sl.isRegistered<NetworkInfo>(), true);
  });
}
