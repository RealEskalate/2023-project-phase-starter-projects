import 'package:flutter_test/flutter_test.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mockito/mockito.dart';
import 'package:todo_main_app/core/platform/network_info.dart';

class MockInternetConnectionChecker extends Mock
    implements InternetConnectionChecker {}

void main() {
  late NetworkInfoImpl networkInfo;
  late MockInternetConnectionChecker mockConnectionChecker;

  setUp(() {
    mockConnectionChecker = MockInternetConnectionChecker();
    networkInfo = NetworkInfoImpl(mockConnectionChecker);
  });

  group('isConnected', () {
    test('should forward the call to InternetConnectionChecker.hasConnection',
        () async {
      // Arrange
      when(mockConnectionChecker.hasConnection).thenAnswer((_) async => true);

      // Act
      final result = await networkInfo.isConnected;

      // Assert
      expect(result, true);
      verify(mockConnectionChecker.hasConnection);
    });
  });
}
