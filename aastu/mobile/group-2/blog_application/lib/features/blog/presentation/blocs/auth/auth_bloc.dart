import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';
import '../../../domain/usecases/login_usecase.dart';
import '../../../domain/usecases/register_usecase.dart';

part 'auth_event.dart';
part 'auth_state.dart';

class AuthBloc extends Bloc<AuthEvent, AuthState> {
  AuthBloc(
    this.loginUseCase,
    this.registerUseCase,
  ) : super(AuthInitial()) {
    on<AuthEvent>((event, emit) {});
    on<AuthLogin>(_onAuthLogin);
    on<AuthRegister>(_onAuthRegister);
  }

  final LoginUseCase loginUseCase;
  final RegisterUseCase registerUseCase;

  void _onAuthLogin(AuthLogin event, Emitter<AuthState> emit) async {
    emit(AuthLoading());
    final result = await loginUseCase(event.email, event.password);
    result.fold((l) => emit(AuthFailed(l.message)), (r) => emit(AuthPass()));
  }

  void _onAuthRegister(AuthRegister event, Emitter<AuthState> emit) async {
    emit(AuthLoading());
    final result = await registerUseCase(event.email, event.password);
    result.fold((l) => emit(AuthFailed(l.message)), (r) => emit(AuthPass()));
  }
}
