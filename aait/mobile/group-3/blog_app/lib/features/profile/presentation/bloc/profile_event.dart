part of 'profile_bloc.dart';

@immutable
sealed class ProfileEvent extends Equatable {
  @override
  List<Object> get props => [];
}

final class GetData extends ProfileEvent {}

final class ShowPosts extends ProfileEvent {
  final bool active;

  ShowPosts({required this.active});

  @override
  List<Object> get props => [active];
}

final class ShowBookMarks extends ProfileEvent {
  final bool active;

  ShowBookMarks({required this.active});

  @override
  List<Object> get props => [active];
}

final class ToggleViewMode extends ProfileEvent {
  final bool isGridView;

  ToggleViewMode({required this.isGridView});

  @override
  List<Object> get props => [isGridView];
}
