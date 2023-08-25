part of 'profile_bloc.dart';

@immutable
sealed class ProfileState extends Equatable {
  @override
  List<Object> get props => [];
}

final class ProfileInitial extends ProfileState {}

final class ProfileLoading extends ProfileState {}

final class ProfileLoaded extends ProfileState {
  final Profile profile;
  final bool isGridView;
  final bool isBookmark;
  ProfileLoaded(
      {required this.profile,
      required this.isGridView,
      required this.isBookmark});
  @override
  List<Object> get props => [isBookmark,profile, isGridView];
}

final class ProfileEmpty extends ProfileState {}

final class ProfileError extends ProfileState {}
