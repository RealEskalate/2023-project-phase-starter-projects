import 'package:flutter_bloc/flutter_bloc.dart';

import 'profile_page_event.dart';
import 'profile_page_state.dart';

export 'profile_page_event.dart';
export 'profile_page_state.dart';

class ProfilePageBloc extends Bloc<ProfilePageEvent, ProfilePageState> {
  ProfilePageBloc()
      : super(const ProfilePageState(
          layout: ProfileLayout.list,
          showPost: true,
        )) {
    //
    //
    on<ShowBookmarksEvent>(_showBookmarks);
    on<ShowPostsEvent>(_showPosts);
    on<SwitchToGridViewEvent>(_switchToGridView);
    on<SwitchToListViewEvent>(_switchToListView);
  }

  void _showBookmarks(
      ShowBookmarksEvent event, Emitter<ProfilePageState> emit) {
    emit(ProfilePageState(layout: state.layout, showPost: false));
  }

  void _showPosts(ShowPostsEvent event, Emitter<ProfilePageState> emit) {
    emit(ProfilePageState(layout: state.layout, showPost: true));
  }

  void _switchToGridView(
      SwitchToGridViewEvent event, Emitter<ProfilePageState> emit) {
    emit(
        ProfilePageState(layout: ProfileLayout.grid, showPost: state.showPost));
  }

  void _switchToListView(
      SwitchToListViewEvent event, Emitter<ProfilePageState> emit) {
    emit(
        ProfilePageState(layout: ProfileLayout.list, showPost: state.showPost));
  }
}
