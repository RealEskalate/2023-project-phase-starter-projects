import 'package:blog_app/features/user/presentation/blocs/bloc_event.dart';

class GetUserEvent extends UserEvent {
  final String userId;

  const GetUserEvent(this.userId);
}
