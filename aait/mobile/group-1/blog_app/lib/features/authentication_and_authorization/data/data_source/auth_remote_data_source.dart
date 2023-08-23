

import 'package:blog_app/features/authentication_and_authorization/data/models/login_user_model.dart';
import 'package:blog_app/features/authentication_and_authorization/data/models/sign_up_user_model.dart';

abstract class AuthRemoteDataSource {
  Future<SignUpModel> signup(SignUpModel signUpModel);
  Future<LoginUserModel> login(LoginUserModel loginUserModel);
}
