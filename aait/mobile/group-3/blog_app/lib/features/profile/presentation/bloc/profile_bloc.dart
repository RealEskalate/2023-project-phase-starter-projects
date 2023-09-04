import 'package:bloc/bloc.dart';
import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/profile/domain/use_case/get_profile.dart';
import 'package:blog_app/features/profile/domain/use_case/update_profile_picture.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:meta/meta.dart';

import '../../domain/entity/profile.dart';

part 'profile_event.dart';
part 'profile_state.dart';

class ProfileBloc extends Bloc<ProfileEvent, ProfileState> {
  final GetProfile getProfile;
  final UpdateProfilePicture updateProfilePicture;
  ProfileBloc({required this.getProfile, required this.updateProfilePicture})
      : super(ProfileInitial(message: "Connecting...")) {
    on<GetData>(_fetchData);
    on<UpdatePicture>(_sendImage);
    on<ToggleViewMode>(_toggleButton);
    on<ToggleUserChoice>(_toggleChoice);
  }
  _fetchData(event, emit) async {
    emit(ProfileLoading(message: "Loading..."));
    final result = await getProfile(NoParams());

    result.fold((failure) => emit(ProfileError()), (profile) {
      emit(ProfileLoaded(
          profile: profile, isGridView: false, isBookmark: false));
    });
  }

  _toggleButton(ToggleViewMode event, emit) {
    final _state = state as ProfileLoaded;
    emit(ProfileLoaded(
        isBookmark: _state.isBookmark,
        profile: _state.profile,
        isGridView: event.isGridView));
  }

  _toggleChoice(ToggleUserChoice event, emit) {
    final _state = state as ProfileLoaded;
    emit(ProfileLoaded(
        profile: _state.profile,
        isGridView: _state.isGridView,
        isBookmark: event.isBookmark));
  }

  _sendImage(UpdatePicture event, emit) async {
    final _state = state as ProfileLoaded;
    if (event.imageFile != null) {
      emit(ProfileLoading(message: "Updating Profile Picture..."));
      final result = await updateProfilePicture(Params(event.imageFile));
      result.fold(
          (failure) => emit(ProfileError()),
          (profile) => emit(ProfileLoaded(
              profile: profile,
              isGridView: _state.isGridView,
              isBookmark: _state.isBookmark)));
    }
  }
}
