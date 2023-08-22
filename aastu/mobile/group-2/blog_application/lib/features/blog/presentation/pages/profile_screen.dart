
import 'package:flutter/material.dart';

class ProfileScreen extends StatelessWidget {
  const ProfileScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Padding(
          padding: EdgeInsets.symmetric(horizontal: 16.0),
          child: Text('Profile'),
        ),
        actions: [
          IconButton(
            icon: const Icon(Icons.more_horiz),
            onPressed: () {},
          ),
        ],
      ),
      body:
          Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Center(
                child: Container(
                  height: 400,
                  child: const Stack(
                     alignment: Alignment.center,
                    children: [
                     ProfileCard(),
                      Positioned(
                          bottom: 12,
                          child: ProfileTab()),
                    ],
                  ),
      ),
              ),
            ],
          ),
    );
  }
}
class ProfileCard extends StatelessWidget {
  const ProfileCard({super.key});
  @override
  Widget build(BuildContext context) {
    return Container(
      width: 295,
      height: 284,
      decoration: ShapeDecoration(
        color: Colors.white,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(16),
        ),
        shadows: const [
          BoxShadow(
            color: Color(0x0F5182FF),
            blurRadius: 15,
            offset: Offset(0, 10),
            spreadRadius: 0,
          )
        ],
      ),
      child: Padding(
        padding: const EdgeInsets.all(32.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              children: [
                Container(
                  width: 84,
                  height: 84,
                  decoration: ShapeDecoration(
                    shape: RoundedRectangleBorder(
                      side: BorderSide(width: 2, color: Color(0xFF376AED)),
                      borderRadius: BorderRadius.circular(28),
                    ),
                  ),
                ),
                SizedBox(width: 24),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      '@joviedan',
                      style: TextStyle(
                        color: Color(0xFF2D4379),
                        fontSize: 14,
                        fontFamily: 'Poppins',
                        fontWeight: FontWeight.w900,
                        letterSpacing: -0.24,
                      ),
                    ),
                    Text(
                      'Jovi Daniel',
                      style: TextStyle(
                        color: Color(0xFF0D253C),
                        fontSize: 18,
                        fontStyle: FontStyle.italic,
                        fontFamily: 'Urbanist',
                        fontWeight: FontWeight.w100,
                      ),
                    ),
                    Text(
                      'UX Designer',
                      style: TextStyle(
                        color: Color(0xFF376AED),
                        fontSize: 16,
                        fontStyle: FontStyle.italic,
                        fontFamily: 'Urbanist',
                        fontWeight: FontWeight.w100,
                        height: 1.25,
                      ),
                    )
                  ],
                )
              ],
            ),
            SizedBox(height: 24),
            Text(
              'About me',
              style: TextStyle(
                color: Color(0xFF0D253C),
                fontSize: 16,
                fontStyle: FontStyle.italic,
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w100,
              ),
            ),
            SizedBox(height: 11),
            Text(
              'Madison Blackstone is a director of user experience design, with experience managing global teams.',
              style: TextStyle(
                color: Color(0xFF2D4379),
                fontSize: 14,
                fontStyle: FontStyle.italic,
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w100,
                height: 1.43,
              ),
            ),
          ]
        ),
      )
    );
  }
}
class ProfileTab extends StatelessWidget {
  const ProfileTab({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 231,
      height: 68,
      decoration: ShapeDecoration(
        shadows: const [
          BoxShadow(
            color: Color(0x0F5182FF),
            blurRadius: 15,
            offset: Offset(0, 10),
            spreadRadius: 0,
          ),

        ],
        color: Color(0xFF386BED),
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(12),
        ),
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          ProfileTabItem(selected: true, top: '52', bottom: 'Post',),
          ProfileTabItem(top: '250', bottom: 'Following'),
          ProfileTabItem(top: '4.5K', bottom: 'Followers'),
        ]
      )
    );
  }
}

class ProfileTabItem extends StatelessWidget {
  bool selected;
  String top;
  String bottom;
  ProfileTabItem({
    super.key,
    this.selected = false,
    this.top = '52',
    this.bottom = 'Post',
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: (){

      },
      child: Container(
        width: 77,
        height: 68,
        decoration: ShapeDecoration(
          color: selected ? Color(0xFF2151CD) : Color(0xFF386BED),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(12),
          ),
        ),

          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                this.top,
                textAlign: TextAlign.center,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 20,
                  fontWeight: FontWeight.w400,
                  height: 1.10,
                ),
              ),
              SizedBox(height: 4),
              Text(
                this.bottom,
                textAlign: TextAlign.center,
                style: TextStyle(
                  color: Colors.white.withOpacity(0.8700000047683716),
                  fontSize: 12,
                  fontWeight: FontWeight.w400,
                  height: 1.50,
                ),
              ),
            ],
          ),

      ),
    );
  }
}
