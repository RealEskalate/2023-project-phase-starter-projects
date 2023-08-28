import 'package:bloc/bloc.dart';
import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/auth/domain/entity/auth_entitie.dart';
import 'package:blog_app/features/auth/domain/use_case/signup_usecase.dart';
import 'package:equatable/equatable.dart';

part 'signup_event.dart';
part 'signup_state.dart';

class SignupBloc extends Bloc<SignupEvent, SignupState> {
  final SignUpUsecase signUpUsecase;
  SignupBloc({required this.signUpUsecase}) : super(SignupInitial()) {
    on<SignUp>((event, emit) async {
      emit(SignupLoadingState());
      var result = await signUpUsecase(
        Params(
          AuthEntitie(
            email: event.email,
            password: event.password,
            fullName: event.fullName,
            expertise: event.expertise,
            bio: event.bio,
          ),
        ),
      );

      result.fold(
        (l) => emit(
          SignupErrorState(
            errorStateMessage: l.message,
          ),
        ),
        (r) => emit(
          SignupSuccessState(),
        ),
      );
    });
  }
}
