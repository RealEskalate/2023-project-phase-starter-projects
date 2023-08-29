import 'package:equatable/equatable.dart';

enum ProfileLayout { list, grid }

sealed class ProfilePageEvent extends Equatable {
  const ProfilePageEvent();

  @override
  List<Object?> get props => [];
}

final class ShowBookmarksEvent extends ProfilePageEvent {}

final class ShowPostsEvent extends ProfilePageEvent {}

final class SwitchToGridViewEvent extends ProfilePageEvent {}

final class SwitchToListViewEvent extends ProfilePageEvent {}
