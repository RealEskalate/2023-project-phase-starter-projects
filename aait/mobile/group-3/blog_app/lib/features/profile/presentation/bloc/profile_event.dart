part of 'profile_bloc.dart';

@immutable
sealed class ProfileEvent extends Equatable {
  @override
  List<Object> get props => [];
}

final class GetData extends ProfileEvent {}

final class UpdatePicture extends ProfileEvent {
  final XFile? imageFile;

  UpdatePicture({required this.imageFile});

}

final class ToggleViewMode extends ProfileEvent {
  final bool isGridView;

  ToggleViewMode({required this.isGridView});

  @override
  List<Object> get props => [isGridView];
}

final class ToggleUserChoice extends ProfileEvent {
  final bool isBookmark;

  ToggleUserChoice({required this.isBookmark});

  @override
  List<Object> get props => [isBookmark];
}
