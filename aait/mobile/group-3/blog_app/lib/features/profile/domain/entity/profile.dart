import 'package:equatable/equatable.dart';

class Profile extends Equatable {
  final String username;
  final String fullName;
  final String imageName;
  final String expertise;

  Profile(
      {required this.username,
      required this.fullName,
      required this.imageName,
      required this.expertise});

  @override
  List<Object> get props => [username, fullName, imageName, expertise];
}
