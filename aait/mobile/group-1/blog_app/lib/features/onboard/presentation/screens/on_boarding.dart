import 'package:blog_app/features/authentication_and_authorization/presentation/pages/signup_login_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';

import '../widgets/on_boarding_widget.dart';

class OnBoarding extends StatefulWidget {
  const OnBoarding({super.key});

  @override
  State<OnBoarding> createState() => _OnBoardingState();
}

class _OnBoardingState extends State<OnBoarding> {
  var _currentPageIndex = 0;

  @override
  Widget build(BuildContext context) {
    PageController controller = PageController();

    final List<Map<String, String>> pages = [
      {
        'title': 'Welcome to Blog App',
        'description':
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod.',
      },
      {
        'title': 'Welcome to Blog App',
        'description':
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod.',
      },
      {
        'title': 'Welcome to Blog App',
        'description':
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod.',
      },
    ];

    return Scaffold(
      body: Container(
        color: Colors.grey[100],
        child: Column(
          children: [
            Expanded(
              child: Container(
                padding: EdgeInsets.only(top: 30.h),
                child: Image.asset(
                  'assets/images/IMAGETILES.png',
                  width: double.infinity,
                ),
              ),
            ),
            Container(
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(25.r),
                  topRight: Radius.circular(25.r),
                ),
              ),
              padding: EdgeInsets.only(
                left: 32.w,
                right: 32.w,
                top: 32.h,
                bottom: 32.h,
              ),
              child: Column(
                children: [
                  SizedBox(
                    height: ScreenUtil().screenHeight * 0.3,
                    child: PageView.builder(
                      itemCount: pages.length,
                      controller: controller,
                      onPageChanged: (index) {
                        setState(() {
                          _currentPageIndex = index;
                        });
                      },
                      itemBuilder: (BuildContext context, int index) {
                        return OnBoardingWidget(
                          onBoardHeader: pages[index]['title']!,
                          onBoardDescription: pages[index]['description']!,
                        );
                      },
                    ),
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      SmoothPageIndicator(
                        controller: controller,
                        count: 3,
                        effect: ExpandingDotsEffect(
                          dotColor: Colors.blue,
                          activeDotColor: Colors.blue,
                          dotHeight: 10,
                          dotWidth: 10,
                          spacing: 10,
                        ),
                      ),
                      GestureDetector(
                        onTap: () {
                          if (_currentPageIndex < (pages.length - 1)) {
                            controller.nextPage(
                              duration: const Duration(seconds: 1),
                              curve: Curves.easeOut,
                            );
                          } else {
                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => StackOfCards()));
                          }
                        },
                        child: Container(
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(10.r),
                            color: Colors.blue,
                          ),
                          padding: EdgeInsets.only(
                            top: 20.h,
                            bottom: 20.h,
                            left: 25.w,
                            right: 25.w,
                          ),
                          child: const Icon(
                            color: Colors.white,
                            Icons.arrow_forward,
                          ),
                        ),
                      )
                    ],
                  ),
                  SizedBox(
                    height: 20.h,
                  )
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
