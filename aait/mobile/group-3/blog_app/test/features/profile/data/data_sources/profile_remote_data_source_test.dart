import 'dart:convert';

import 'package:blog_app/core/error/exception.dart';
import 'package:blog_app/features/profile/data/data_sources/profile_remote_data_source.dart';
import 'package:blog_app/features/profile/data/models/profile_model.dart';
import 'package:http/http.dart' as http;
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:mockito/annotations.dart';
import '../../../../fixtures/fixture.dart';
import 'profile_remote_data_source_test.mocks.dart';

@GenerateNiceMocks([MockSpec<http.Client>()])
void main() {
  late ProfileRemoteDataSourceImpl dataSource;
  late MockClient mockClient;

  setUp(() {
    mockClient = MockClient();
    dataSource = ProfileRemoteDataSourceImpl(client: mockClient);
  });

  group('getProfile', () {
    final json = jsonDecode(fixture('profile.json'));
    final ProfileModel tProfileModel = ProfileModel.fromJson(json);

    test('Should perform a GET request on a URL', () async {
      when(mockClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response(fixture('profile.json'), 200));
      final result = await dataSource.getProfile();
      expect(result, equals(tProfileModel));
    });

    test('Should throw a ServerException when the response is an error',
        () async {
      when(mockClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response(fixture('profile.json'), 404));
      expect(() => dataSource.getProfile(), throwsA(isA<ServerException>()));
    });
  });
}
