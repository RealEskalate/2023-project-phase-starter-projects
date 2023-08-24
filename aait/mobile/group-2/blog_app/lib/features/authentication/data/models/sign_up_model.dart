import '../../domain/entities/sign_up_entity.dart';

class SignUpRequestModel extends SignUpEntity {
  const SignUpRequestModel(
      {required String email,
      required String password,
      required String fullName,
      required String bio,
      required String expertise})
      : super(
            email: email,
            password: password,
            fullName: fullName,
            expertise: expertise,
            bio: bio);

  factory SignUpRequestModel.fromJson(Map<String, dynamic> json) {
    return SignUpRequestModel(
      email: json['email'],
      password: json['password'],
      fullName: json['fullName'],
      bio: json['bio'],
      expertise: json['expertise'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'email': email,
      'password': password,
      'fullName': fullName,
      'bio': bio,
      'expertise': expertise,
    };
  }
}
