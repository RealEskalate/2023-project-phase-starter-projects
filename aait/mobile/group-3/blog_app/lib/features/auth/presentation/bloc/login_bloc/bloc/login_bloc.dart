import 'package:bloc/bloc.dart';
import 'package:blog_app/features/auth/domain/use_case/login_usecase.dart';
import 'package:equatable/equatable.dart';

import '../../../../../../core/use_case/usecase.dart';
import '../../../../domain/entity/auth_entitie.dart';

part 'login_event.dart';
part 'login_state.dart';

class LoginBloc extends Bloc<LoginEvent, LoginState> {
  final LogInUsecase logInUsecase;
  LoginBloc({required this.logInUsecase}) : super(LoginInitial()) {
    on<Login>((event, emit) async{
      emit(LoginLoadingState());
      var result = await logInUsecase(
        Params(
          AuthEntitie(
            email: event.email,
            password: event.password,
          ),
        ),
      );

      result.fold(
        (l) => emit(
          LoginErrorState(
            errorStateMessage: l.message,
          ),
        ),
        (r) => emit(
          LoginSuccessState(),
        ),
      );
    });
  }
}
