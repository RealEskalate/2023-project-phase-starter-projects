import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';

class ProfileAvatar extends StatelessWidget {
  final String image;
  const ProfileAvatar({required this.image, super.key});

  @override
  Widget build(BuildContext context) {
    return Stack(
      alignment: Alignment.center,
      children: [
        CachedNetworkImage(
          imageUrl: image,
          imageBuilder: (context, imageProvider) => CircleAvatar(
            radius: 20.0,
            backgroundColor: Colors.blue,
            backgroundImage: imageProvider,
          ),
          placeholder: (context, url) => const Icon(Icons.person),
          errorWidget: (context, url, error) {
            return const Icon(Icons.person);
          },
        ),
        Container(
          width: 38.0,
          height: 38.0,
          decoration: BoxDecoration(
            color: Colors.transparent,
            borderRadius: BorderRadius.circular(100.0),
            border: Border.all(
              color: Colors.white,
              width: 1.5,
            ),
          ),
        ),
      ],
    );
  }
}
