import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'login_slide.dart';
import 'signup_slide.dart';

// ignore: must_be_immutable
class LoginSignUpPage extends StatefulWidget {
  LoginSignUpPage({super.key});

  @override
  State<LoginSignUpPage> createState() => _LoginSignUpPageState();
}

class _LoginSignUpPageState extends State<LoginSignUpPage> {
  final PageController pageController = PageController(initialPage: 0);
  int currentPage = 0;
  void pageChangeSlideLoginToSignup() {
    Future.delayed(Duration.zero, () {
      pageController.animateToPage(
        1,
        duration: Duration(milliseconds: 400),
        curve: Curves.easeInOut,
      );
    });
  }

  void pageChangeSlideSignupToLogin() {
    Future.delayed(Duration.zero, () {
      pageController.animateToPage(
        0,
        duration: Duration(milliseconds: 400),
        curve: Curves.easeInOut,
      );
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            Padding(
              padding: EdgeInsets.only(
                left: 117.w,
                right: 117.w,
                top: 65.h,
              ),
              child: Image(
                image: const AssetImage(
                  "assets/images/a2sv.png",
                ),
                width: 141.w,
                height: 54.h,
              ),
            ),
            SizedBox(
              height: 54.h,
            ),
            Container(
              decoration: BoxDecoration(
                color: const Color(0xFF376AED),
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(28.r),
                  topRight: Radius.circular(28.r),
                ),
              ),
              child: Column(
                children: [
                  Padding(
                    padding: EdgeInsets.symmetric(vertical: 10.h),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        TextButton(
                          onPressed: () {
                            pageChangeSlideSignupToLogin();
                          },
                          child: Text(
                            "LOGIN",
                            style: TextStyle(
                              color: currentPage == 0 ? Colors.white : null,
                              fontFamily: 'Urbanist',
                              fontWeight: FontWeight.w700,
                              fontSize: 18.sp,
                            ),
                          ),
                        ),
                        TextButton(
                          onPressed: () {
                            pageChangeSlideLoginToSignup();
                          },
                          child: Text(
                            "SIGN UP",
                            style: TextStyle(
                              color: currentPage == 1 ? Colors.white : null,
                              fontFamily: 'Urbanist',
                              fontWeight: FontWeight.w700,
                              fontSize: 18.sp,
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                  Container(
                    height: 581.h,
                    width: 375.w,
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.only(
                        topLeft: Radius.circular(28.r),
                        topRight: Radius.circular(28.r),
                      ),
                    ),
                    child: PageView(
                      controller: pageController,
                      onPageChanged: (pageIndex) {
                        setState(() {
                          currentPage = pageIndex;
                        });
                      },
                      children: [
                        LoginSlide(pageChange: pageChangeSlideLoginToSignup),
                        SignupSlide(pageChange: pageChangeSlideSignupToLogin),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
