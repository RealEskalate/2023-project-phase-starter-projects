import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:blog_app/features/profile/domain/use_case/get_profile.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'get_profile_test.mocks.dart';

@GenerateNiceMocks([MockSpec<ProfileRepository>()])
void main() {
  late MockProfileRepository mockProfileRepository;
  late GetProfile usecase;

  setUp(() {
    mockProfileRepository = MockProfileRepository();
    usecase = GetProfile(repository: mockProfileRepository);
  });

  group("GetProfile", () {
    final Profile tProfile = Profile(
      bookmarks: [],
        username: "@John",
        articles: [],
        fullName: "John Doe",
        imageName: "",
        expertise: "",
        bio: "");
    test(
        'Should be able to call getProfile from repository when usecase is called',
        () async {
      when(mockProfileRepository.getProfile())
          .thenAnswer((_) async => Right(tProfile));
      await usecase(NoParams());
      verify(mockProfileRepository.getProfile());
      verifyNoMoreInteractions(mockProfileRepository);
    });

    test('Should return a valid Profile type when a successful call was made',
        () async {
      when(mockProfileRepository.getProfile())
          .thenAnswer((_) async => Right(tProfile));
      final result = await usecase(NoParams());
      expect(result, Right(tProfile));
    });
  });
}
