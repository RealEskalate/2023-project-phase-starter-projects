import '../models/login_user_model.dart';
import '../models/sign_up_user_model.dart';
import '../models/user_data_model.dart';

abstract class AuthRemoteDataSource {
  Future<SignUpModel> signup(SignUpModel signUpModel);
  Future<UserDataModel> login(LoginUserModel loginUserModel);
}
