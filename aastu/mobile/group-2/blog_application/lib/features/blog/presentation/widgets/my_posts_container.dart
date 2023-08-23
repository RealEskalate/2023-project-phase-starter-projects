import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

import 'my_post_card.dart';

class MyPostsContainer extends StatelessWidget {
  const MyPostsContainer({super.key});

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        padding: EdgeInsets.all(20),
        width: 375,
        height: 345,
        decoration: const ShapeDecoration(
          color: Colors.white,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.only(
              topLeft: Radius.circular(30),
              topRight: Radius.circular(30),
            ),
          ),
          shadows: [
            BoxShadow(
              color: Color(0x115182FF),
              blurRadius: 32,
              offset: Offset(0, -25),
              spreadRadius: 0,
            )
          ],
        ),
        child: Column(
          children: [
             Row(
              children: [
                Text(
                  'My Posts',
                  style: TextStyle(
                    color:const Color(0xFF0D253C),
                    fontSize: 20,
                    fontFamily: GoogleFonts.urbanist().fontFamily,
                    fontWeight: FontWeight.w500,
                  ),
                ),
                const SizedBox(
                  width: 150,
                ),
                const Icon(
                  Icons.grid_view,
                  size: 25,
                  color: Color(0xFF386BED),
                ),
                const SizedBox(
                  width: 20,
                ),
                const Icon(
                  Icons.format_list_bulleted,
                  color: Color.fromARGB(255, 106, 125, 173),
                  size: 25,
                
                )
              ],              
            ),
            Expanded(
              child: ListView.builder(
                itemCount: 3,
                itemBuilder: (context, index) {
                  return const MyPostCard(
                    title: 'Title',
                    subtitle: 'Subtitle',
                  );
                },
              ),
            ),

          ],
        ),
      ),
    );
  }
}

