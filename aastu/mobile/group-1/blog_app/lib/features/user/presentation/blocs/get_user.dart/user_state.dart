import 'package:blog_app/features/user/domain/entities/user.dart';
import 'package:blog_app/features/user/presentation/blocs/bloc_state.dart';

class LoadedGetUserState extends UserState {
  final User user;

  const LoadedGetUserState(this.user);

  @override
  List<Object> get props => [user];
}
