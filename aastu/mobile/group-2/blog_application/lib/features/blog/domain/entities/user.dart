import 'package:equatable/equatable.dart';

class User extends Equatable {
  User({
    required this.id,
    required this.email,
    this.bio,
    this.fullName,
    this.expertise,
    this.createdAt,
    this.updatedAt,
  });

  final String id;
  final String email;
  final String? bio;
  final String? fullName;
  final String? expertise;
  final DateTime? createdAt;
  final DateTime? updatedAt;

  @override
  List<Object?> get props => [id, email, bio, fullName, expertise, createdAt, updatedAt];
}