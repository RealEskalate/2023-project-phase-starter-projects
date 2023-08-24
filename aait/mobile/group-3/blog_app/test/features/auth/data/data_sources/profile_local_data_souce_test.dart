import 'dart:convert';

import 'package:blog_app/features/profile/data/data_sources/profile_local_data_source.dart';
import 'package:blog_app/features/profile/data/models/article_model.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:mockito/annotations.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../fixtures/fixture.dart';
import 'profile_local_data_souce_test.mocks.dart';

@GenerateNiceMocks([MockSpec<SharedPreferences>()])
void main() {
  late ProfileLocalDataSourceImpl dataSource;
  late MockSharedPreferences mockSharedPreferences;

  setUp(() {
    mockSharedPreferences = MockSharedPreferences();
    dataSource =
        ProfileLocalDataSourceImpl(sharedPreferences: mockSharedPreferences);
  });

  group('getBookmarkArticles', () {
    final jsonList = jsonDecode(fixture('articles.json'));
    final tArticleModel =
        jsonList["articles"].map((e) => ArticleModel.fromJson(e)).toList();
    final List<ArticleModel> tEmptyArticleList = [];

    test(
        'Should return Articles from SharedPreferences when there is one in the cache',
        () async {
      when(mockSharedPreferences.getString(any))
          .thenReturn(fixture('articles.json'));
      final result = await dataSource.getBookmarkArticles();
      verify(mockSharedPreferences.getString(CACHED_ARTICLE_LIST));
      expect(result, equals(tArticleModel));
    });

    test("Should give an empty list when there is none in the cache", () async {
      when(mockSharedPreferences.getString(any)).thenReturn(null);
      final result = await dataSource.getBookmarkArticles();
      expect(result, tEmptyArticleList);
    });
  });
}
