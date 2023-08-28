import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../../core/errors/failures/failure.dart';
import '../../../../../core/utils/input_converter.dart';
import '../../../domain/usecases/login_use_case.dart';
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

class LogInBloc extends Bloc<LogInEvent, LoginState> {
  final LoginUseCase loginUseCase;
  LogInBloc({required this.loginUseCase}) : super(LoginInitState()) {
    on<OnLogInButtonPressedEvent>(_onLoginButtonPressed);
  }
  Future<void> _onLoginButtonPressed(
      OnLogInButtonPressedEvent event, Emitter<LoginState> emit) async {
    emit(LoginLoadingState());
    final result = await loginUseCase(event.loginUserEnity);
    return result.fold(
        (failure) => emit(ErrorState(message: _mapFailureToMessage(failure))),
        (user) => emit(LoginLoadedState(loginUserEnity: user)));
  }
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
