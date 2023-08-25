import 'package:blog_app/core/platform/network_info.dart';
import 'package:blog_app/features/user/data/datasources/remote_data_source.dart';
import 'package:test/test.dart';
import 'package:get_it/get_it.dart';
import 'package:mockito/mockito.dart';
import 'package:blog_app/injection.dart';

class MockNetworkInfo extends Mock implements NetworkInfo {}

void main() {
  group('Dependency Injection Test', () {
    final sl = GetIt.instance;

    setUp(() {
      // Reset the GetIt container before each test
      sl.reset();
    });

    test('should register and resolve NetworkInfo', () {
      sl.registerLazySingleton<NetworkInfo>(() => MockNetworkInfo());

      final networkInfo = sl<NetworkInfo>();
      expect(networkInfo, isA<NetworkInfo>());
    });

    test('should register and resolve UserRepository', () {
      // ...
    });

    test('should register and resolve UserUseCases', () {});

    // UserApiDataSource work as expected
    test('should register and resolve UserApiDataSource', () {
      sl.registerLazySingleton(
          () => UserApiDataSource('https://mock-api-url.com'));

      final dataSource = sl<UserApiDataSource>();
      expect(dataSource, isA<UserApiDataSource>());
    });
  });
}
