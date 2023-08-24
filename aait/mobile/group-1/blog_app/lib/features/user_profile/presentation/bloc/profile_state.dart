part of 'profile_bloc.dart';

@immutable
abstract class ProfileState {}

class ProfileInitial extends ProfileState {}

class Error extends ProfileState {}

class Loading extends ProfileState {}

class Loaded extends ProfileState {
  final User user;
  Loaded(this.user);
}
