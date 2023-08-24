import '../../domain/entities/login_entity.dart';

class LoginRequestModel extends LoginRequestEntity {
  const LoginRequestModel({required String email, required String password})
      : super(email: email, password: password);

  factory LoginRequestModel.fromJson(Map<String, dynamic> json) {
    return LoginRequestModel(
      email: json['email'],
      password: json['password'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'email': email,
      'password': password,
    };
  }
}
