import 'package:flutter/material.dart';

import '../widgets/MiniBlogInfo.dart';
import '../widgets/inputForm.dart';

class ViewBlog extends StatelessWidget {
  const ViewBlog({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Color(0XFFF8FAFF),
        foregroundColor: Colors.black,
        leading: Padding(
          padding: const EdgeInsets.only(left: 20),
          child: IconButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              icon: Icon(
                Icons.arrow_back_ios,
              )),
        ),
        elevation: 0,
        actions: [
          IconButton(
            onPressed: () {},
            icon: const Icon(
              Icons.more_horiz,
              size: 25,
              color: Colors.black,
            ),
          ),
        ],
      ),
      body: Container(
        color: Color(0XFFF8FAFF),
        child: SafeArea(
          child: Stack(
            children: [
              SingleChildScrollView(
                child: Column(
                  children: [
                    Container(
                      margin: EdgeInsets.fromLTRB(30, 20, 30, 20),
                      child: Column(
                        children: [
                          const Text(
                            "Four Things Every Programmer Needs To Know",
                            style: TextStyle(
                                color: Color(0xFF0D253C),
                                fontSize: 24,
                                fontWeight: FontWeight.w600,
                                fontFamily: "poppins"),
                          ),
                          Container(
                            padding:
                                EdgeInsets.only(top: 15, left: 10, right: 10),
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
                                  size: 24,
                                ),
                              ],
                            ),
                          ),
                          Text("")
                        ],
                      ),
                    ),
                    Container(
                      width: MediaQuery.of(context).size.width,
                      height: 219,
                      child: Image.asset("assets/images/banner.png"),
                      decoration: const BoxDecoration(
                        borderRadius: BorderRadius.only(
                          topLeft: Radius.circular(20),
                          topRight: Radius.circular(20),
                        ),
                      ),
                    ),
                    Container(
                      margin: EdgeInsets.fromLTRB(40, 40, 40, 20),
                      child: Column(
                        children: [
                          Text(
                              style: TextStyle(
                                color: Color(0xff2D4379),
                                fontFamily: "Poppins",
                                fontSize: 16,
                              ),
                              "In publishing and graphic design,\ Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available. In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available")
                        ],
                      ),
                    )
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
      floatingActionButton: Container(
        width: 111,
        height: 48,
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
          mainAxisAlignment: MainAxisAlignment.center,
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
    );
  }
}
