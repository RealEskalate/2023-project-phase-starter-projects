import 'package:equatable/equatable.dart';

class UserDataEntity extends Equatable{
  final Data data;
  final String token;

  UserDataEntity({
    required this.data,
    required this.token,
  });
  @override
  List<Object?> get props => [data,token];


}

class Data {
  String id;
  String fullName;
  String email;
  String password;
  String expertise;
  String bio;
  DateTime createdAt;
  int v;
  String image;
  String imageCloudinaryPublicId;

  Data({
    required this.id,
    required this.fullName,
    required this.email,
    required this.password,
    required this.expertise,
    required this.bio,
    required this.createdAt,
    required this.v,
    required this.image,
    required this.imageCloudinaryPublicId,
  });

}
