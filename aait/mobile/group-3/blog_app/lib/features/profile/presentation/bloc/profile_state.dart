part of 'profile_bloc.dart';

@immutable
sealed class ProfileState extends Equatable {
  @override
  List<Object> get props => [];
}

final class ProfileInitial extends ProfileState {}

final class ProfileLoading extends ProfileState {}

final class ProfileLoaded extends ProfileState {
  final List<Article> articles;
  final Profile profile;
  final bool isGridView;

  ProfileLoaded(
      {required this.articles,
      required this.profile,
      required this.isGridView});
  @override
  List<Object> get props => [articles, profile, isGridView];
}

final class ProfileEmpty extends ProfileState {}

final class ProfileError extends ProfileState {}
