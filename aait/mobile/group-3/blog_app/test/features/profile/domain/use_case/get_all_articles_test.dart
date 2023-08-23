import 'package:blog_app/features/profile/domain/repositories/article_list_repository.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'get_all_articles_test.mocks.dart';

@GenerateNiceMocks([MockSpec<ProfileRepository>()])
void main() {
  late MockArticleListRepository mockArticleListRepository;
  late GetAllArticles usecase;

  setUp(() {
    mockArticleListRepository = MockArticleListRepository();
    usecase = GetAllArticles();
  });
}
