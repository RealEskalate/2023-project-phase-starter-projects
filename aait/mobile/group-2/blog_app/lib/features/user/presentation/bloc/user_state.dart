part of 'user_bloc.dart';

sealed class UserState extends Equatable {
  const UserState();

  @override
  List<Object> get props => [];
}

class UserInitial extends UserState {}

class LoadingState extends UserState {}

class LoadedUserState extends UserState {
  final UserData userData;

  const LoadedUserState({required this.userData});
}

class UserProfileUpdatedState extends UserState {}

class LoadedBookmarkedArticlesState extends UserState {
  final List<Article> articles;

  const LoadedBookmarkedArticlesState({required this.articles});
}

class ErrorState extends UserState {
  final String message;

  const ErrorState({required this.message});
}
