import 'package:blog_app/core/color/colors.dart';
import 'package:blog_app/features/onboarding/widgets/on-boarding_images.dart';
import 'package:blog_app/features/onboarding/widgets/scrollable_content.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class OnboardingScreen extends StatefulWidget {
  const OnboardingScreen({Key? key});

  @override
  _OnboardingScreenState createState() => _OnboardingScreenState();
}

class _OnboardingScreenState extends State<OnboardingScreen> {
  final PageController _pageController = PageController();
  int _currentPage = 0;
  final List<Widget> _pages = [
    buildContent(
      "Read the article you want instantly",
      "You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.",
    ),
    buildContent(
      "Read the article you want instantly",
      "You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.",
    ),
    buildContent(
      "Read the article you want instantly",
      "You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.",
    ),
  ];

  @override
  void dispose() {
    _pageController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromARGB(248, 234, 234, 228),
      body: Column(
        children: [
          SizedBox(
            height: ScreenUtil().setHeight(116),
          ),
          OnboardingImagesWidget(),
          SizedBox(
            height: ScreenUtil().setHeight(40),
          ),
          Expanded(
            child: Container(
              decoration: BoxDecoration(
                color: whiteColor,
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(28.r),
                  topRight: Radius.circular(28.r),
                ),
              ),
              child: PageView.builder(
                controller: _pageController,
                itemCount: _pages.length,
                onPageChanged: (index) {
                  setState(() {
                    _currentPage = index;
                  });
                },
                itemBuilder: (context, index) {
                  return _pages[index];
                },
              ),
            ),
          ),
          Container(
            padding:
                EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(40)),
            decoration: BoxDecoration(
              color: whiteColor,
            ),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                SmoothPageIndicator(
                  controller: _pageController,
                  count: _pages.length,
                  effect: WormEffect(
                    dotWidth: 10.h,
                    dotHeight: 10.w,
                    activeDotColor: blue,
                    dotColor: lightGrey,
                  ),
                ),
                GestureDetector(
                  onTap: () {
                    if (_currentPage < _pages.length - 1) {
                      _pageController.nextPage(
                        duration: Duration(milliseconds: 300),
                        curve: Curves.easeInOut,
                      );
                    } else {
                      context.go('/login');
                    }
                  },
                  child: Container(
                    height: 50.h,
                    width: 88.w,
                    decoration: BoxDecoration(
                        color: blue,
                        borderRadius: BorderRadius.circular(12.r)),
                    child: Icon(
                      Icons.arrow_forward,
                      color: whiteColor,
                    ),
                  ),
                )
              ],
            ),
          ),
          Container(
            height: 40.h,
            decoration: BoxDecoration(
              color: whiteColor,
              borderRadius: BorderRadius.only(
                topLeft: Radius.circular(28.r),
                topRight: Radius.circular(28.r),
              ),
            ),
          )
        ],
      ),
    );
  }
}
