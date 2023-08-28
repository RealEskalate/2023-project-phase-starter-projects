import 'package:flutter/material.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/color/colors.dart';
import '../../../../core/util/image_sheet.dart';
import '../widgets/widgets.dart';

class WriteArticlePage extends StatefulWidget {
  const WriteArticlePage({super.key});

  @override
  State<WriteArticlePage> createState() => _WriteArticlePageState();
}

class _WriteArticlePageState extends State<WriteArticlePage> {
  XFile? _file;
  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
        designSize: const Size(428, 926),
        builder: (BuildContext context, child) {
          return Scaffold(
            backgroundColor: Colors.white,
            appBar: PreferredSize(
              preferredSize: Size.fromHeight(74.h),
              child: const CustomAppBarNewArticle(),
            ),
            body: Padding(
              padding: EdgeInsets.symmetric(horizontal: 45.w),
              child: SingleChildScrollView(
                child: SafeArea(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const CustomTextField(hint: "Add title"),
                      const CustomTextField(hint: "add subtitle"),
                      AddTagsContainer(),
                      SizedBox(height: 4.39.h),
                      SizedBox(height: 49.h),
                      const ArticleContentTextField(),
                      SizedBox(height: 40.h),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Text("Upload Image",
                              style: GoogleFonts.poppins(
                                  fontSize: 16.sp,
                                  fontWeight: FontWeight.w500,
                                  color: Colors.black)),
                          GestureDetector(
                            onTap: () {
                              setState(() async {
                                _file = await ImageSheet().show(context);
                              });
                            },
                            child: Icon(
                              Icons.camera_alt_outlined,
                              color: Colors.blue,
                            ),
                          )
                        ],
                      ),
                      SizedBox(
                        height: 5.h,
                      ),
                      Container(
                        child: TextField(
                          controller: TextEditingController(text: _file?.path),
                          decoration: InputDecoration(
                              hintText: _file != null
                                  ? _file?.path
                                  : "No Image is selected"),
                        ),
                      ),
                      const FormSubmitButton()
                    ],
                  ),
                ),
              ),
            ),
          );
        });
  }
}
