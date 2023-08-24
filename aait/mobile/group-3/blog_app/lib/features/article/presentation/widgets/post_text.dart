import 'package:flutter/material.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';

class PostText extends StatelessWidget {
  const PostText({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 23.w),
      child: Text(
        '''That marked a turnaround from last year, when the social network reported a decline in users for the first time. 
        \nThe drop wiped billions from the firm's market value.
        \nSince executives disclosed the fall in February, the firm's share price has nearly halved. But shares jumped 19% in after-hours trade on Wednesday.
''',
        style: GoogleFonts.poppins(
          fontSize: 16.sp,
          fontWeight: FontWeight.w400,
          color: darkBlueText,
        ),
        textAlign: TextAlign.start,
      ),
    );
  }
}