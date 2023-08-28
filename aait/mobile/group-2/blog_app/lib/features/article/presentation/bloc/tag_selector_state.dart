import 'package:equatable/equatable.dart';

import '../../domain/entities/tag.dart';

class TagSelectorState extends Equatable {
  final List<Tag> tags;

  const TagSelectorState(this.tags);

  @override
  List<Object?> get props => [tags];
}
