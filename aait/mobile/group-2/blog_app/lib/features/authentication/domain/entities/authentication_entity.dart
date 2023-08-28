import 'package:equatable/equatable.dart';

import 'authenticated_user_info.dart';

class AuthenticationEntity extends Equatable {
  final AuthenticatedUserInfo authenticatedUserInfo;
  final String token;

  const AuthenticationEntity(
      {required this.authenticatedUserInfo, required this.token});

  @override
  List<Object?> get props => [authenticatedUserInfo, token];
}
