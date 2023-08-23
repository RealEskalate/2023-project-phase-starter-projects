import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';
import 'package:meta/meta.dart';

import '../../domain/entity/article.dart';
import '../../domain/entity/profile.dart';

part 'profile_event.dart';
part 'profile_state.dart';

class ProfileBloc extends Bloc<ProfileEvent, ProfileState> {
  ProfileBloc() : super(ProfileInitial()) {
    on<GetData>(_fetchData);
    on<ToggleViewMode>(_toggleButton);
    on<ToggleUserChoice>(_toggleChoice);
  }
  _fetchData(event, emit) async {
    emit(ProfileLoading());
    await Future.delayed(Duration(seconds: 1));
    emit(ProfileLoaded(
        profile: _getDummyProfile(), isGridView: false, isBookmark: false));
  }

  _toggleButton(ToggleViewMode event, emit) {
    final _state = state as ProfileLoaded;
    emit(ProfileLoaded(
        isBookmark: _state.isBookmark,
        profile: _state.profile,
        isGridView: event.isGridView));
  }

  _getDummyArticles() {
    final List<Article> _articles = [
      Article(
          title: "GAME",
          subTitle: "Why Elden Ring is the best game ever made",
          createdAt: DateTime(2023, 8, 20),
          id: "gashbvSAahnvbvsfw",
          image:
              "https://www.techspot.com/images2/news/bigimage/2022/03/2022-03-17-image-37.jpg"),
      Article(
          title: "SPACE",
          subTitle: "How are galaxies constantly expanding",
          createdAt: DateTime(2023, 8, 22, 12),
          id: "bsdrnvjwnvwjsd",
          image:
              "https://t4.ftcdn.net/jpg/05/51/96/35/360_F_551963598_53hrJ2UXDoC00XhkqJ8lKN8Xa2EQg4no.jpg"),
      Article(
          title: "VALHEIM",
          subTitle: "Valheim next biggest update is the ocean",
          createdAt: DateTime(2023, 8, 22, 16),
          id: "bsdrnvfdsfgdgfgfdd",
          image:
              "https://i.etsystatic.com/24434904/r/il/b2ba6a/4092042802/il_fullxfull.4092042802_q13p.jpg")
    ];
    return _articles;
  }

  _getDummyProfile() {
    final Profile _profile = Profile(
        username: "@joevidan",
        fullName: "Jovi Daniel",
        bio:
            "Madison Blackstone is a director of user experience design, with experience managing global teams.",
        imageName:
            "https://images.pexels.com/photos/2379004/pexels-photo-2379004.jpeg?cs=srgb&dl=pexels-italo-melo-2379004.jpg&fm=jpg",
        expertise: "UX Designer",
        articles: _getDummyArticles());
    return _profile;
  }

  _toggleChoice(ToggleUserChoice event, emit) {
    final _state = state as ProfileLoaded;
    final newList = _getDummyArticles();

    if (!event.isBookmark) {
      newList.add(Article(
          title: "Travel",
          subTitle: "The northen lights sky is to be seen by everyone",
          createdAt: DateTime(2023, 8, 13),
          id: "gadAGfvsdfgavd",
          image:
              "https://media.istockphoto.com/id/1176475543/vector/forest-scene-with-aurora.jpg?s=612x612&w=0&k=20&c=ao8xZMIZ-_dHl-ctw5YhJQgpAItFWbCcZWlS70n7_I8="));
    } else {
      newList.add(Article(
          title: "Skyrim",
          subTitle: "How to get dragon armor in skyrim ",
          createdAt: DateTime(2022, 11, 29),
          id: "xbzvsasgbvsrewg",
          image:
              "https://standardof.net/wp-content/uploads/2020/09/Dragonscale-Armor-Set-The-Elder-Scrolls-V-Skyrim.png"));
    }
    emit(ProfileLoaded(
        profile: _state.profile.copyWith(articles: newList),
        isGridView: _state.isGridView,
        isBookmark: event.isBookmark));
  }
}
