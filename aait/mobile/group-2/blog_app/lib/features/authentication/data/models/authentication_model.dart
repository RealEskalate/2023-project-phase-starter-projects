import '../../domain/entities/authenticated_user_info.dart';
import '../../domain/entities/authentication_entity.dart';
import 'authenticated_user_info_model.dart';

class AuthenticationModel extends AuthenticationEntity {
  const AuthenticationModel(
      {required AuthenticatedUserInfo authenticatedUserInfo,
      required String token})
      : super(authenticatedUserInfo: authenticatedUserInfo, token: token);

  factory AuthenticationModel.fromJson(Map<String, dynamic> json) {
    return AuthenticationModel(
      authenticatedUserInfo: AuthenticatedUserInfoModel.fromJson(json['data']),
      token: json['token'],
    );
  }
}
