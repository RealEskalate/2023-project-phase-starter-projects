import 'package:equatable/equatable.dart';

class User extends Equatable {
  final String fullName;
  final String email;
  final String expertise;
  final String bio;
  final DateTime createdAt;
  final String image;
  final String imageCloudinaryPublicId;
  final String id;

  const User({
    required this.fullName,
    required this.email,
    required this.expertise,
    required this.bio,
    required this.createdAt,
    required this.image,
    required this.imageCloudinaryPublicId,
    required this.id,
  });

  User.empty()
      : this(
          fullName: "Tamirat Dereje",
          email: "tamiratdereje@gmail.com",
          expertise: "designer",
          bio: "I am passionate designer who see beauty in everything",
          createdAt: DateTime.parse('1969-07-20 20:18:04Z'),
          image:
              "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
          imageCloudinaryPublicId: "guf4tul1ftar9hdpnaev",
          id: "64e25674bfc65d390e781205",
        );

  @override
  List<Object> get props => [id];
}
