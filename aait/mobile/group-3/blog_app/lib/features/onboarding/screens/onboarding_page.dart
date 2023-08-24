import 'package:blog_app/features/onboarding/widgets/onboarding_images_widget.dart';
import 'package:flutter/material.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../widgets/scrollable_widget.dart';

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

  static Widget _buildContent(String title, String description) {
    return Column(
      children: [
        SizedBox(height: ScreenUtil().setHeight(15)),
        Container(
          padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(40)),
          child: Text(
            title,
            style: TextStyle(
              fontSize: 24.sp,
              fontWeight: FontWeight.w100,
              color: Color(0xFF0D253C),
            ),
          ),
        ),
        SizedBox(height: ScreenUtil().setHeight(5)),
        Container(
          padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(40)),
          child: Text(
            description,
            style: TextStyle(
              fontWeight: FontWeight.w900,
              fontSize: 14.sp,
              color: Color(0xFF2D4379),
            ),
          ),
        ),
        SizedBox(height: ScreenUtil().setHeight(10)),
      ],
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromARGB(248, 234, 234, 228),
      body: Column(
        children: [
          SizedBox(
            height: ScreenUtil().setHeight(100),
          ),
          OnboardingImagesWidget(),
          SizedBox(
            height: ScreenUtil().setHeight(60),
          ),
          Expanded(
            child: Container(
              decoration: BoxDecoration(
                color: Colors.white,
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
              color: Colors.white,
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
                    activeDotColor: Colors.blue,
                    dotColor: Colors.grey,
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
                      Navigator.of(context).pushReplacement(
                        MaterialPageRoute(builder: (context) => Container()),
                      );
                    }
                  },
                  child: Container(
                    height: 50.h,
                    width: 88.w,
                    decoration: BoxDecoration(
                        color: Colors.blue,
                        borderRadius: BorderRadius.circular(12.r)),
                    child: Icon(
                      Icons.arrow_forward,
                      color: Colors.white,
                    ),
                  ),
                )
              ],
            ),
          ),
          Container(
            height: 40.h,
            decoration: BoxDecoration(
              color: Colors.white,
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
