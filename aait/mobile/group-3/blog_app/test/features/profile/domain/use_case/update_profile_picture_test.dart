import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:blog_app/features/profile/domain/use_case/update_profile_picture.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'update_profile_picture_test.mocks.dart';

@GenerateNiceMocks([MockSpec<ProfileRepository>()])
void main() {
  late MockProfileRepository mockProfileRepository;
  late UpdateProfilePicture usecase;
  final tProfile = Profile(
    bookmarks: [],
      username: "",
      articles: [],
      fullName: "",
      imageName: "",
      expertise: "",
      bio: "");
  setUp(() {
    mockProfileRepository = MockProfileRepository();
    usecase = UpdateProfilePicture(repository: mockProfileRepository);
  });
  test("Should be able to call repository when usecase is called", () async {
    when(mockProfileRepository.updateProfilePicture(any))
        .thenAnswer((_) async => Right(tProfile));
    final result = await usecase(Params("evrgfdrgf"));
    verify(mockProfileRepository.updateProfilePicture(any));
    verifyNoMoreInteractions(mockProfileRepository);
    expect(result, equals(Right(tProfile)));
  });
}
