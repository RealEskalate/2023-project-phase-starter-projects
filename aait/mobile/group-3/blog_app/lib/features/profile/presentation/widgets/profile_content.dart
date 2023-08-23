import 'package:flutter/material.dart';

import 'about_section.dart';
import 'basic_information_widget.dart';
import 'profile_image.dart';

class ProfileContent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 40),
      child: Card(
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
        elevation: 3,
        child: Column(
          children: [
            Row(
              children: [
                Container(
                  alignment: Alignment.centerLeft,
                  padding: EdgeInsets.symmetric(horizontal: 32, vertical: 32),
                  child: ProfileImage(
                    imageName:
                        'https://images.pexels.com/photos/2379004/pexels-photo-2379004.jpeg?cs=srgb&dl=pexels-italo-melo-2379004.jpg&fm=jpg',
                  ),
                ),
                SizedBox(
                  width: 20,
                ),
                Container(
                  child: BasicInformationWidget(
                      username: "@joeviedan",
                      fullName: "Jovi Daniel",
                      occupation: "UX Designer"),
                ),
                SizedBox(
                  height: 24,
                ),
              ],
            ),
            Container(
              padding: EdgeInsets.symmetric(horizontal: 32),
              alignment: Alignment.centerLeft,
              child: AboutSection(
                  description:
                      "Madison Blackstone is a director of user experience design, with experience managing global teams."),
            ),
          ],
        ),
      ),
    );
  }
}
