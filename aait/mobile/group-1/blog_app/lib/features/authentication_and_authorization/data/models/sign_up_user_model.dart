import '../../domain/entities/sign_up_user_entity.dart';
class SignUpModel extends SignUpUserEnity {
  const SignUpModel(
      {
      required fullName,
      required email,
      required password,
      required expertise,
      required bio,
      })
      : super(
            bio: bio,
            fullName: fullName,
            password: password,
            expertise: expertise,
            email: email);

factory SignUpModel.fromJson(Map<String, dynamic> json) {
  return SignUpModel(
    fullName: json['fullName'],
    email: json['email'],
    password: json['password'],
    expertise: json['expertise'],
    bio: json['bio'],
  );
}

  Map<String, dynamic> toJson() {
    return {
      "fullName": fullName,
      "email": email,
      "password": password,
      "expertise": expertise,
      "bio": bio,
    };
  }
}

