import 'package:equatable/equatable.dart';

import 'profile_page_event.dart';

class ProfilePageState extends Equatable {
  final ProfileLayout layout;
  final bool showPost;

  const ProfilePageState({required this.layout, required this.showPost});

  @override
  List<Object?> get props => [layout, showPost];
}
