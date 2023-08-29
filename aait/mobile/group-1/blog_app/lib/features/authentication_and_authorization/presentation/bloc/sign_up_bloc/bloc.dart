import 'package:blog_app/features/authentication_and_authorization/domain/entities/login_user_entitiy.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/usecases/login_use_case.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../../core/errors/failures/failure.dart';
import '../../../../../core/utils/input_converter.dart';
import '../../../domain/usecases/sign_up_use_case.dart';
import 'event.dart';
import 'state.dart';

const String INVALID_INPUT_FAILURE_MESSAGE =
    'Invalid input - the number must be a positive integer or zero';
const String SERVER_FAILURE_MESSAGE = 'Server Failure';
const String CACHE_FAILURE_MESSAGE = 'Cache Failure';
const String DATA_BASE_FAILURE_MESSAGE = "Database Failure";
const String LOCATION_FAILURE_MESSAGE = "Location Failure";
const String CONNECTION_FAILURE_MESSAGE = "Connection Failure";
const String PERMISSION_FAILURE_MESSAGE = "Permission Failure";

class SignUpBloc extends Bloc<SignUpEvent, SignUpState> {
  final SignUpUseCase signUp;
  final LoginUseCase loginUseCase;
  SignUpBloc({required this.loginUseCase, required this.signUp})
      : super(SignupInitState()) {
    on<OnSignUpButtonPressedEvent>(_onSignUpButtonPressed);
  }

  Future<void> _onSignUpButtonPressed(
    OnSignUpButtonPressedEvent event,
    Emitter<SignUpState> emit,
  ) async {
    emit(SignupLoadingState());

    final result = await signUp(event.signUpUserEnity);

    return result.fold(
        (failure) =>
            emit(SignupErrorState(message: _mapFailureToMessage(failure))),
        (user) =>emit(SignUpLoadedState(signUpUserEnity: user))
    );
  }

  String _mapFailureToMessage(Failure failure) {
    switch (failure.runtimeType) {
      case ServerFailure:
        return SERVER_FAILURE_MESSAGE;
      case CacheFailure:
        return CACHE_FAILURE_MESSAGE;
      case InvalidInputFailure:
        return INVALID_INPUT_FAILURE_MESSAGE;

      case ConnectionFailure:
        return CONNECTION_FAILURE_MESSAGE;
      case DatabaseFailure:
        return DATA_BASE_FAILURE_MESSAGE;
      case LocationFailure:
        return LOCATION_FAILURE_MESSAGE;
      case PermissionFailure:
        return PERMISSION_FAILURE_MESSAGE;

      default:
        return 'Unexpected error';
    }
  }
}
