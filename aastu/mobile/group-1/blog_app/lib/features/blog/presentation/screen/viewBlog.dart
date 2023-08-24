import 'package:flutter/material.dart';

import '../widgets/MiniBlogInfo.dart';
import '../widgets/inputForm.dart';

class ViewBlog extends StatelessWidget {
  const ViewBlog({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Container(
      child: SafeArea(
        child: Stack(
          children: [
            SingleChildScrollView(
              child: Column(
                children: [
                  Container(
                    margin: EdgeInsets.fromLTRB(40, 40, 40, 20),
                    child: Column(
                      children: [
                        Row(
                          mainAxisSize: MainAxisSize.max,
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Container(
                              width: 36,
                              height: 38,
                              child: IconButton(
                                onPressed: () {},
                                icon: const Icon(
                                  Icons.arrow_back_ios,
                                  size: 25,
                                ),
                              ),
                            ),
                            Container(
                              width: 36,
                              height: 38,
                              child: IconButton(
                                onPressed: () {},
                                icon: const Icon(
                                  Icons.more_horiz,
                                  size: 25,
                                ),
                              ),
                            ),
                            // Spacer(),
                          ],
                        ),
                        const Text("Four Things Every Programmer Needs To Know",
                            style: TextStyle(
                                fontSize: 20,
                                fontWeight: FontWeight.w600,
                                fontFamily: "poppins")),
                        Container(
                          padding: EdgeInsets.only(top: 15),
                          child: const Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              Row(
                                children: [
                                  MiniBlogInfo(),
                                ],
                              ),
                              //bookmark icon here
                              Icon(
                                Icons.bookmark_border_outlined,
                                color: Color(0xff376AED),
                              ),
                            ],
                          ),
                        ),
                        Text("")
                      ],
                    ),
                  ),
                  Image.asset("assets/images/banner.png"),
                  Container(
                    margin: EdgeInsets.fromLTRB(40, 40, 40, 20),
                    child: Column(
                      children: [
                        Text(
                            style: TextStyle(color: Color(0xff2D4379)),
                            "In publishing and graphic design,\ Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available. In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available")
                      ],
                    ),
                  )
                ],
              ),
            ),
            Positioned(
              // alignment: Alignment.bottomRight,
              right: 40,
              bottom: 45,
              child: Container(
                decoration: BoxDecoration(
                    color: Color(0xff376AED),
                    border: Border.all(
                      // width: 2,
                      color: Color(0xff376AED),
                    ),
                    borderRadius: BorderRadius.all(Radius.circular(10))),
                //like button icon
                padding: EdgeInsets.fromLTRB(15, 13, 15, 13),

                child: const Row(
                  children: [
                    Icon(
                      Icons.thumb_up_off_alt,
                      color: Colors.white,
                    ),
                    Text(
                      "2.1k",
                      style: TextStyle(color: Colors.white),
                    )
                  ],
                ),
              ),
            )
          ],
        ),
      ),
    ));
  }
}
