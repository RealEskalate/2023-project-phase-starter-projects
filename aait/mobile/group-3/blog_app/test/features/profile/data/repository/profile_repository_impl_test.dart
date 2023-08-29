import 'package:blog_app/core/error/exception.dart';
import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/core/network/network_info.dart';
import 'package:blog_app/features/profile/data/data_sources/profile_local_data_source.dart';
import 'package:blog_app/features/profile/data/data_sources/profile_remote_data_source.dart';
import 'package:blog_app/features/profile/data/models/profile_model.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:blog_app/features/profile/data/models/article_model.dart';

import '../../../../../lib/features/profile/data/repository/profile_repository_impl.dart';
import 'profile_repository_impl_test.mocks.dart';

@GenerateNiceMocks([
  MockSpec<ProfileRemoteDataSource>(),
  MockSpec<ProfileLocalDataSource>(),
  MockSpec<NetworkInfo>()
])
void main() {
  late MockProfileLocalDataSource localDataSource;
  late MockProfileRemoteDataSource remoteDataSource;
  late MockNetworkInfo networkInfo;
  late ProfileRepositoryImpl repository;

  setUp(() {
    remoteDataSource = MockProfileRemoteDataSource();
    localDataSource = MockProfileLocalDataSource();
    networkInfo = MockNetworkInfo();
    repository = ProfileRepositoryImpl(
        networkInfo: networkInfo,
        localDataSource: localDataSource,
        remoteDataSource: remoteDataSource);
  });

  group('getProfile', () {
    final tProfileModel = ProfileModel(
      bookmarks: [],
        username: "@tamiratdereje",
        articles: [
          ArticleModel(
              title: "Workout",
              subTitle: "Triceps",
              createdAt: DateTime(2023, 8, 20),
              id: "64e26b23fe68a176cdbc52c4",
              image:
                  "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692560163/usay3yegvnh0abxfslvh.png")
        ],
        fullName: "Tamirat Dereje",
        imageName:
            "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
        expertise: "designer",
        bio: "I am passionate designer who see beauty in everything");

    test("Should return remote data when the call to remote data is successful",
        () async {
      when(remoteDataSource.getProfile())
          .thenAnswer((_) async => tProfileModel);
      final result = await repository.getProfile();
      verify(remoteDataSource.getProfile());
      expect(result, equals(Right(tProfileModel)));
    });
    test(
        'Should return server failure when the call to remote data is unsuccessful',
        () async {
      when(remoteDataSource.getProfile())
          .thenThrow(ServerException(statusCode: 400, message: "Something Went wrong"));
      final result = await repository.getProfile();
      verify(remoteDataSource.getProfile());
      verifyZeroInteractions(localDataSource);
      expect(
          result,
          equals(Left(ServerFailure(
              message: "Couldn't connect to the internet", statusCode: 400))));
    });
  });
}
