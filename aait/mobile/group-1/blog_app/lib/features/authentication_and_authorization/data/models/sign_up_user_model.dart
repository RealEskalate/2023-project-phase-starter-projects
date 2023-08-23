import 'package:blog_app/features/authentication_and_authorization/domain/entities/sign_up_user_entity.dart';


class SignUpModel extends SignUpUserEnity {
  const SignUpModel(
      {required id,
      required fullName,
      required email,
      required password,
      required expertise,
      required bio,
      required image})
      : super(
            bio: bio,
            fullName: fullName,
            id: id,
            password: password,
            expertise: expertise,
            image: image,
            email: email);

  factory SignUpModel.fromJson(Map<String, dynamic> json) {
    return SignUpModel(
        id: json['id'],
        fullName: json['fullName'],
        email: json['email'],
        password: json['password'],
        expertise: json['expertise'],
        bio: json['bio'],
        image: json['image']);
  }

  Map<String, dynamic> toJson() {
    return {
      "id": id,
      "fullName": fullName,
      "email": email,
      "password": password,
      "expertise": expertise,
      "bio": bio,
      "image": image
    };
  }
}

