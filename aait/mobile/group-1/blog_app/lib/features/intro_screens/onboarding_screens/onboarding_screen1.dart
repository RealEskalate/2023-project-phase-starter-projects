import 'package:flutter/material.dart';

import '../../authentication_and_authorization/presentation/pages/signup_login_page.dart';

class OnboardingPage extends StatefulWidget {
  @override
  _OnboardingPageState createState() => _OnboardingPageState();
}

class _OnboardingPageState extends State<OnboardingPage> {
  final PageController _pageController = PageController();
  int _currentPage = 0;

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Container(
              padding:
                  EdgeInsets.only(left: 10, right: 10, top: 20, bottom: 20),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  ClipRRect(
                    borderRadius: BorderRadius.circular(33),
                    child: Image.asset(
                      "assets/images/img2.png",
                    ),
                  ),
                  ClipRRect(
                    borderRadius: BorderRadius.circular(33),
                    child: Image.asset(
                      "assets/images/img1.png",
                    ),
                  ),
                ],
              ),
            ),
            Container(
              padding: EdgeInsets.only(left: 10, right: 10, bottom: 30),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  ClipRRect(
                    borderRadius: BorderRadius.circular(33),
                    child: Image.asset(
                      "assets/images/img3.png",
                    ),
                  ),
                  ClipRRect(
                    borderRadius: BorderRadius.circular(33),
                    child: Image.asset(
                      "assets/images/img4.png",
                    ),
                  ),
                ],
              ),
            ),
            Expanded(
              child: ClipRRect(
                borderRadius: const BorderRadius.only(
                  topLeft: Radius.circular(20.0),
                  topRight: Radius.circular(20.0),
                ),
                child: PageView(
                  controller: _pageController,
                  onPageChanged: (index) {
                    setState(() {
                      _currentPage = index;
                    });
                  },
                  children: [
                    Container(
                      color: Colors.white,
                      child: Column(
                        children: [
                          Container(
                            padding: EdgeInsets.only(
                                left: 20, top: 20, right: 20, bottom: 10),
                            child: Text(
                              "Read the article you want instantly",
                              style: TextStyle(
                                  fontFamily: "Urbanist",
                                  color: Colors.blue[900],
                                  fontSize: 27),
                            ),
                          ),
                          Container(
                            padding: EdgeInsets.only(
                                left: 20, right: 20, bottom: 18),
                            child: Text(
                              "You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.",
                              style: TextStyle(
                                  fontFamily: "Poppins",
                                  fontSize: 18,
                                  fontWeight: FontWeight.w500),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Container(
                      color: Colors.white,
                      child: Column(
                        children: [
                          Container(
                            padding: EdgeInsets.only(
                                left: 20, top: 20, right: 20, bottom: 10),
                            child: Text(
                              "Discover, Save, and Share: Your Journey Starts Here!",
                              style: TextStyle(
                                  fontFamily: "Urbanist",
                                  color: Colors.blue[900],
                                  fontSize: 27),
                            ),
                          ),
                          Container(
                            padding: EdgeInsets.only(
                                left: 20, right: 20, bottom: 18),
                            child: Text(
                              "Welcome aboard! With our platform, you're not just accessing articles – you're embarking on a journey of discovery.",
                              style: TextStyle(
                                  fontFamily: "Poppins",
                                  fontSize: 18,
                                  fontWeight: FontWeight.w500),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Container(
                      color: Colors.white,
                      child: Column(
                        children: [
                          Container(
                            padding: EdgeInsets.only(
                                left: 20, top: 20, right: 20, bottom: 10),
                            child: Text(
                              "Unleash the Power of Knowledge Instantly!",
                              style: TextStyle(
                                  fontFamily: "Urbanist",
                                  color: Colors.blue[900],
                                  fontSize: 27),
                            ),
                          ),
                          Container(
                            padding: EdgeInsets.only(
                                left: 20, right: 20, bottom: 18),
                            child: Text(
                              "Greetings, knowledge seeker! The doors to enlightenment are wide open on ArticleSphere.",
                              style: TextStyle(
                                  fontFamily: "Poppins",
                                  fontSize: 18,
                                  fontWeight: FontWeight.w500),
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
              ),
            ),
            Container(
              decoration: BoxDecoration(color: Colors.white),
              child: Padding(
                padding: const EdgeInsets.only(bottom: 20, left: 20, right: 20),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Row(
                      children: List.generate(
                        3,
                        (indexDots) => Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: Container(
                            width: _currentPage == indexDots ? 25 : 8,
                            height: 8,
                            decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(8),
                              color: _currentPage == indexDots
                                  ? Colors.blue
                                  : Colors.grey,
                            ),
                          ),
                        ),
                      ),
                    ),
                    SizedBox(
                      width: 110,
                      height: 73,
                      child: ElevatedButton(
                        onPressed: () {
                          if (_currentPage == 2) {
                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => StackOfCards()));
                          } else {
                            _pageController.nextPage(
                              duration: Duration(milliseconds: 300),
                              curve: Curves.easeInOut,
                            );
                          }
                        },
                        style: ElevatedButton.styleFrom(
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(20),
                          ),
                        ),
                        child: Icon(
                          Icons.arrow_forward,
                          size: 30,
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
