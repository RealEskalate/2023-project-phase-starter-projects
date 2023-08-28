import 'package:equatable/equatable.dart';

sealed class TagEvent extends Equatable {
  const TagEvent();

  @override
  List<Object> get props => [];
}

final class LoadAllTagsEvent extends TagEvent {}
