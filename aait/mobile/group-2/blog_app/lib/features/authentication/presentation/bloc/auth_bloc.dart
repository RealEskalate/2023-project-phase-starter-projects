import 'dart:async';

import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/network/custom_client.dart';
import '../../../../core/usecase/usecase.dart';
import '../../domain/entities/authenticated_user_info.dart';
import '../../domain/entities/authentication_entity.dart';
import '../../domain/entities/login_entity.dart';
import '../../domain/entities/sign_up_entity.dart';
import '../../domain/use_cases/auth_use_case.dart';

part 'auth_event.dart';
part 'auth_state.dart';

const String SERVER_FAILURE_MESSAGE = 'Server Failure: Please try again later';
const String LOGIN_FAILURE_MESSAGE =
    'Login Failure: Please check your username and password';
const String SIGN_UP_FAILURE_MESSAGE =
    'Sign Up Failure: Please check your information';

const String LOGOUT_FAILURE_MESSAGE = 'Logout Failure: Please try again later';

const String NETWORK_FAILURE_MESSAGE =
    'Network Failure: Please check your internet connection';

const String CACHE_FAILURE_MESSAGE = 'Cache Failure';

const String UNKNOWN_FAILURE_MESSAGE = 'Unknown error';

class AuthBloc extends Bloc<AuthEvent, AuthState> {
  final LoginUseCase loginUseCase;
  final SignUpUseCase signUpUseCase;
  final LogoutUseCase logoutUseCase;
  final GetTokenUseCase getTokenUsecase;
  final CustomClient customClient;

  String? _token;

  String get authToken => _token ?? '';

  AuthBloc({
    required this.getTokenUsecase,
    required this.loginUseCase,
    required this.signUpUseCase,
    required this.logoutUseCase,
    required this.customClient,
  }) : super(AuthInitial()) {
    on<LoginEvent>(_onLoginEvent);
    on<SignUpEvent>(_onSignUpEvent);
    on<LogoutEvent>(_onLogoutEvent);
    on<GetTokenEvent>(_onGetTokenEvent);
  }

  Future<void> _onGetTokenEvent(
      GetTokenEvent event, Emitter<AuthState> emit) async {
    emit(Loading());
    final failureOrLoginResult = await getTokenUsecase(NoParams());

    failureOrLoginResult.fold(
      (failure) {
        _token = null;

        emit(const UserAuthState(null));
      },
      (token) {
        customClient.authToken = token;
        _token = token;

        emit(UserAuthState(token));
      },
    );
  }

  Future<void> _onLoginEvent(LoginEvent event, Emitter<AuthState> emit) async {
    emit(Loading());
    final failureOrLoginResult = await loginUseCase(event.loginRequestEntity);

    failureOrLoginResult.fold(
      (failure) {
        emit(AuthError(message: _mapErrorToMessage(failure)));
      },
      (loginResult) {
        customClient.authToken = loginResult.token;
        _token = loginResult.token;

        emit(LoginSuccessState(authenticationEntity: loginResult));
      },
    );
  }

  Future<void> _onSignUpEvent(
      SignUpEvent event, Emitter<AuthState> emit) async {
    emit(Loading());

    final failureOrSignUpResult = await signUpUseCase(event.signUpRequest);

    failureOrSignUpResult.fold(
      (failure) {
        emit(AuthError(message: _mapErrorToMessage(failure)));
      },
      (signUpResult) {
        emit(SignUpSuccessState(authenticatedUserInfo: signUpResult));
      },
    );
  }

  Future<void> _onLogoutEvent(
      LogoutEvent event, Emitter<AuthState> emit) async {
    emit(Loading());

    final failureOrLogoutResult = await logoutUseCase('');

    _token = null;

    failureOrLogoutResult.fold(
      (failure) {
        emit(AuthError(message: _mapErrorToMessage(failure)));
      },
      (logoutResult) {
        customClient.authToken = null;
        _token = null;
        emit(LogoutSuccessState());
      },
    );
  }

  String _mapErrorToMessage(Failure failure) {
    switch (failure.runtimeType) {
      case ServerFailure:
        return SERVER_FAILURE_MESSAGE;
      case LoginFailure:
        return LOGIN_FAILURE_MESSAGE;
      case SignUpFailure:
        return SIGN_UP_FAILURE_MESSAGE;
      case LogoutFailure:
        return LOGOUT_FAILURE_MESSAGE;
      case NetworkFailure:
        return NETWORK_FAILURE_MESSAGE;
      case CacheFailure:
        return CACHE_FAILURE_MESSAGE;
      default:
        return UNKNOWN_FAILURE_MESSAGE;
    }
  }
}
