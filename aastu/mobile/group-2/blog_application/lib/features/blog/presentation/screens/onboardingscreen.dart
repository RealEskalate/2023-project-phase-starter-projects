import 'package:flutter/material.dart';
import 'package:get/get.dart';

class Onboarding extends StatefulWidget {
  const Onboarding({super.key});

  @override
  State<Onboarding> createState() => _OnboardingState();
}

class _OnboardingState extends State<Onboarding> {
  late PageController _pageController;
  int currentIndex = 0;

  var duration = const Duration(milliseconds: 250);
  var curveEase = Curves.ease;

  neaxtPage() {
    _pageController.nextPage(duration: duration, curve: curveEase);
  }

  previousPage() {
    _pageController.previousPage(duration: duration, curve: curveEase);
  }

  onChangedPage(int index) {
    setState(() {
      currentIndex = index;
    });
  }

  @override
  void initState() {
    _pageController = PageController();
    super.initState();
  }

  Widget buildOnboardingBody() {
    return Container(
      // color: Colors.yellow.withOpacity(0.1),
      width: Get.width,
      height: Get.height / 2.8,
      child: Column(
        children: [
          SizedBox(height: 60,),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Container(
                width: 100,
                height: 180,
                decoration: BoxDecoration(
                  image: DecorationImage(
                  //  image: AssetImage("assets/images/sunset.png"),

                    image: NetworkImage("https://s3-alpha-sig.figma.com/img/aeed/373f/3f775725a29bf9bc64e570e80ccb66aa?Expires=1693785600&Signature=g0bA82Ej~p1uDLPLCBLIJuX2zIjbm~huSPOJimYausUYH79hiIuaO5Pwii2PONsouIx49eHJA5cmB4dnl8MiNH6uYieRAK6rJ5pwpk5nHBwyI5kG~VaTv40D3vsdWNAw1ydzfmMsz7FTJLqm1JPri7PPRdY27JY9uVI00nL46NP7fpse1a52JfKfMHzvxkcBbAh0VxXVTYFBz7Ma5TbdKmTcl6dDy0FsSFw2J3fUetX-u5VLCEXp7Xw~Lo12gyN65~x6P9F9UkrWm1U~L-COfhoqGA2EMzWGgx5vTUSSLHVKQssOxkEo-j1qDCZNgGw~vnFQnaZrr3ReWbIvDg0hbg__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4"),
                    fit: BoxFit.cover,
                  ),
                  borderRadius: BorderRadius.circular(24),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withOpacity(0.2), // Shadow color
                      offset: Offset(0, 16), // Offset in the Y direction
                      blurRadius: 16, // Spread of the shadow
                      spreadRadius: 0, // Size of the shadow
                    ),
                  ],
                ),
              ),

              
              SizedBox(
                width: 13,
              ),
              Container(
                width: 200,
                height: 180,
                decoration: BoxDecoration(
                  image: DecorationImage(
                    // image: AssetImage("assets/images/vr.png"),

                    image: NetworkImage("https://s3-alpha-sig.figma.com/img/6418/b594/986b33bf295d16c030dd35d97f6fda42?Expires=1693785600&Signature=GqB-3KqD30kCD~HHmr7A05k1BYumcVP949M6v3C~mUIL4RuBd2kEJQs9omf7LD~0VZSd4YYCBZPN7wleCZhy9GNVFZykSAchv1diy9c0Zn6VxRB0F~Pi4LVhlIdm2XM~1reiR3vcQCeeQucA5DFqqsrjYQFXQdfZolvgZ0r-kYbOLMbMAVE7CYQ13pp5ljjjzfNjYt1poXoojLxlcUF4ulPSdxwTWV8Hb41Df37lHFmx-RP~Os0ndZbkmnWeggPigWlI6C~b99lMYuWpyUOd2ZgVeU9Z4Oq~tsPuYcXCSLDPhjBdBIf9MlVZhjm8NmAt8rJxiAStrNRvwwjyZfKLdQ__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4"),
                    fit: BoxFit.cover,
                  ),
                  borderRadius: BorderRadius.circular(24),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withOpacity(0.2), // Shadow color
                      offset: Offset(0, 16), // Offset in the Y direction
                      blurRadius: 16, // Spread of the shadow
                      spreadRadius: 0, // Size of the shadow
                    ),
                  ],
                ),
              ),
              
            ],
          ),
          SizedBox(
            height: 20,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Container(
                width: 200,
                height: 180,
                decoration: BoxDecoration(
                  image: DecorationImage(
                    // image: AssetImage("assets/images/diver.png"),

                    image: NetworkImage("https://s3-alpha-sig.figma.com/img/56b5/ed4e/ceaac86458af93e92c5af6ac96a56280?Expires=1693785600&Signature=NiPTvTW88BkE-ZJde-FimJS5Ud2zsAj6ZX15gcQF9UGWAXAXLQcAU7t22v75vaNXq2QWoegtWxwnjyo3wJX2~PXKlcZcuzMP~ps-xuL3bR7bq1YImfIZSCVYNqoAsDnfJVte7AqD~8XL5icT7uUvpH4Krh8-JePSJm-6pJKAC0UbdfMJ7va5Y3-9skXb6NWr4o1u6ir44yby-4tL2euGQtEgJs0qAuZg2PT~0emt-5KcwIiztot6rRhevhYUIpWbEkIlGcW-jTHPukqOZS-ZI-lIN1uDqWNcq3L5AN-vj9~jaIMalgNgnYemylb65A-O~sKY-rk8Zm-uodsT8lGCog__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4"),
                    fit: BoxFit.cover,
                  ),
                  borderRadius: BorderRadius.circular(24),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withOpacity(0.2), // Shadow color
                      offset: Offset(0, 16), // Offset in the Y direction
                      blurRadius: 16, // Spread of the shadow
                      spreadRadius: 0, // Size of the shadow
                    ),
                  ],
                ),
              ),
              
              SizedBox(
                width: 10,
              ),
              Container(
                width: 100,
                height: 180,
                // child: Image.asset("assets/images/horizon.png"),

                decoration: BoxDecoration(
                  image: DecorationImage(
                      // image: AssetImage("assets/images/horizon.png"),
                    image: NetworkImage("https://s3-alpha-sig.figma.com/img/9125/8996/a1535c615827aa0a97b81b21199e3d69?Expires=1693785600&Signature=VjrE-O~BlhKHxqyXrKrqkwNgfjxeO3WGP40x75Z9fT-tvibpzm6ZgsT-jTBAZu1LbTio53mxTRE94eVCNYB6nqvZa4mOe2TDetO3hRLkMLoJPvI2j59MDa6en7xP1BF5dMDjNLxR6XHU1~0bmw5yGe9qTu260j376vtI9EzzJ-lYv-DjYOXpRGB5ilWuzYEk8gSOJA9LCMg9BQ~FQhydtdUtydurGY299eqUP8fO4994IsUhKL~wAZVdXewREWdeR5902kdO2jzNsb3vrNo9T0E302P5KgXgTujaFtf1LvrLRwLJnB5ajwObHa-QI6gm1-VqJkbIDRaNtaOZO3V7~A__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4"),
                    fit: BoxFit.cover,
                  ),
                  borderRadius: BorderRadius.circular(24),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withOpacity(0.2), // Shadow color
                      offset: Offset(0, 16), // Offset in the Y direction
                      blurRadius: 16, // Spread of the shadow
                      spreadRadius: 0, // Size of the shadow
                    ),
                  ],
                ),
              ),
              
            ],
          ),
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xFFF4F7FF),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        mainAxisSize: MainAxisSize.max,
        children: [
          Container(
            margin: EdgeInsets.only(top: 48),
            height: Get.height / 1.7,
            child: PageView(
              controller: _pageController,
              onPageChanged: onChangedPage,
              children: [
                buildOnboardingBody(),
                buildOnboardingBody(),
                buildOnboardingBody(),
              ],
            ),
          ),
          Expanded(
            child: Container(
              decoration: BoxDecoration(
                color: const Color.fromARGB(255, 255, 255, 255),
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(28),
                  topRight: Radius.circular(28),
                ),
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                    // margin: EdgeInsets.only(left: 20, top: 30),
                    child: Column(
                      children: [
                        Container(
                          margin: EdgeInsets.only(left: 40, top: 40),
                          width: 275,
                          child: Text(
                            'Read the article you want instantly',
                            style: TextStyle(
                              color: Color(0xFF0D253C),
                              fontSize: 24,
                              fontStyle: FontStyle.italic,
                              fontFamily: 'Urbanist',
                              fontWeight: FontWeight.w100,
                              height: 1.33,
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        Container(
                          margin: EdgeInsets.only(
                            left: 40,
                          ),
                          padding: EdgeInsets.only(left: 7),
                          width: 295,
                          child: Text(
                            'You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.',
                            style: TextStyle(
                              color: Color(0xFF2D4379),
                              fontSize: 15,
                              fontFamily: 'Urbanist',
                              fontWeight: FontWeight.w900,
                              height: 1.57,
                            ),
                          ),
                        )
                      ],
                    ),
                  ),
                  SizedBox(
                    height: 40,
                  ),
                  Container(
                    padding: EdgeInsets.only(left: 40),
                    child: Row(
                      mainAxisSize: MainAxisSize.max,
                      mainAxisAlignment: MainAxisAlignment.start,
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        DotIndicator(
                          positionIndex: 0,
                          currentIndex: currentIndex,
                        ),
                        SizedBox(
                          width: 8,
                        ),
                        DotIndicator(
                          positionIndex: 1,
                          currentIndex: currentIndex,
                        ),
                        SizedBox(
                          width: 8,
                        ),
                        DotIndicator(
                          positionIndex: 2,
                          currentIndex: currentIndex,
                        ),
                        SizedBox(
                          width: 160,
                        ),
                        Container(
                          // margin: EdgeInsets.only(top: 20, left: 160),
                          decoration: BoxDecoration(
                            color: Colors.blue,
                            borderRadius: BorderRadius.circular(12),
                          ),
                          width: 70,
                          height: 50,
                          child: IconTheme(
                            data: const IconThemeData(
                              color: Colors.white,
                              opacity: 1.0,
                              size: 20,
                            ),
                            child: IconButton(
                              onPressed: neaxtPage,
                              icon: Icon(Icons.arrow_forward),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),

          // InkWell(onTap: neaxtPage, child: Text("next")),
        ],
      ),
    );
  }
}

class DotIndicator extends StatelessWidget {
  final int positionIndex;
  final int currentIndex;

  const DotIndicator(
      {super.key, required this.positionIndex, required this.currentIndex});

  @override
  Widget build(BuildContext context) {
    return AnimatedContainer(
      margin: EdgeInsets.only(left: 5, top: 20),
      height: 10,
      width: positionIndex == currentIndex ? 20 : 10,
      decoration: BoxDecoration(
          color:
              positionIndex == currentIndex ? Colors.blue : Color(0xFFF4F7FF),
          borderRadius: BorderRadius.circular(32)),
      duration: Duration(milliseconds: 250),
    );
  }
}
