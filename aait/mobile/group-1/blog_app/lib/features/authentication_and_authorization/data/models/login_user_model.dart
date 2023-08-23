import 'package:blog_app/features/authentication_and_authorization/domain/entities/login_user_entitiy.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter_test/flutter_test.dart';

class LoginUserModel extends LoginUserEnity {
  const LoginUserModel(
      {
      required email,
      required password,
})
      : super(

            password: password,

            email: email);

  factory LoginUserModel.fromJson(Map<String, dynamic> json) {
    return LoginUserModel(

        email: json['email'],
        password: json['password'],
);
  }

  Map<String, dynamic> toJson() {
    return {
      "email": email,
      "password": password,

    };
  }
}


// import 'package:equatable/equatable.dart';

// class LoginUserEnity extends Equatable {
//   final String id;
//   final String fullName;
//   final String email;
//   final String password;
//   final String expertise;
//   final String bio;
//   final String image;

//   const LoginUserEnity(
//       {required this.id,
//       required this.fullName,
//       required this.email,
//       required this.password,
//       required this.expertise,
//       required this.bio,
//       required this.image});
//   @override
//   List<Object?> get props => [id, fullName, email, password, expertise,bio,image];
// }