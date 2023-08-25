import 'package:bloc/bloc.dart';
import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/profile/domain/use_case/get_profile.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';
import 'package:meta/meta.dart';

import '../../domain/entity/profile.dart';

part 'profile_event.dart';
part 'profile_state.dart';

class ProfileBloc extends Bloc<ProfileEvent, ProfileState> {
  final GetProfile getProfile;
  ProfileBloc({required this.getProfile}) : super(ProfileInitial()) {
    on<GetData>(_fetchData);
    on<ToggleViewMode>(_toggleButton);
    on<ToggleUserChoice>(_toggleChoice);
  }
  _fetchData(event, emit) async {
    emit(ProfileLoading());
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
}
