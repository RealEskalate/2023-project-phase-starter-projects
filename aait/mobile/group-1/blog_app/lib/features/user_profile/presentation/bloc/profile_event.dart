part of 'profile_bloc.dart';

@immutable
abstract class ProfileEvent {}

class GetProfileInfo extends ProfileEvent {}

class ProfileUpdated extends ProfileEvent {
  final User user;
  ProfileUpdated(this.user);
}
