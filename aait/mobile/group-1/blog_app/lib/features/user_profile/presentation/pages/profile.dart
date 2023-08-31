// ignore_for_file: prefer_const_constructors, prefer_const_literals_to_create_immutables

import 'dart:io';

import 'package:blog_app/features/user_profile/presentation/widgets/my_post.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:image_picker/image_picker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/utils/colors.dart';
import '../../../authentication_and_authorization/presentation/pages/signup_login_page.dart';
import '../bloc/profile_bloc.dart';
import '../widgets/my_posts.dart';

class ProfilePage extends StatefulWidget {
  const ProfilePage({super.key});

  @override
  State<ProfilePage> createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  @override
  void initState() {
    BlocProvider.of<ProfileBloc>(context).add(GetProfileInfo());
    super.initState();
  }

  final ImagePicker picker = ImagePicker();
  Widget profileImage = Icon(Icons.person);
  bool firstTime = true;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: BlocBuilder<ProfileBloc, ProfileState>(
        builder: (context, state) {
          if (state is Loaded) {
            if (state.user.image != null && firstTime) {
              profileImage = Image(image: NetworkImage(state.user.image!));
              firstTime = false;
            }
            return SafeArea(
              child: SizedBox(
                height: MediaQuery.of(context).size.height,
                child: ListView(
                    // mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Column(children: [
                        Container(
                          padding: const EdgeInsets.symmetric(
                              vertical: 10, horizontal: 30),
                          margin: const EdgeInsets.only(bottom: 15),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.start,
                            children: [
                              IconButton(
                                onPressed: () {
                                  Navigator.pop(context);
                                },
                                icon: Icon(Icons.arrow_back_ios),
                              ),
                              Text(
                                'Profile',
                                style: TextStyle(
                                  color: kTextColorPrimary,
                                  fontSize: 24,
                                  fontFamily: 'Urbanist',
                                  fontWeight: FontWeight.w500,
                                ),
                              ),
                            ],
                          ),
                        ),
                        Container(
                            margin: EdgeInsets.symmetric(horizontal: 40),
                            decoration: ShapeDecoration(
                              color: Colors.white,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(16),
                              ),
                              shadows: [
                                BoxShadow(
                                  color: Color(0x0F5182FF),
                                  blurRadius: 15,
                                  offset: Offset(0, 10),
                                  spreadRadius: 0,
                                )
                              ],
                            ),
                            child: Container(
                              margin: const EdgeInsets.symmetric(
                                  vertical: 10, horizontal: 10),
                              child: Column(children: [
                                Row(
                                    crossAxisAlignment:
                                        CrossAxisAlignment.center,
                                    mainAxisAlignment:
                                        MainAxisAlignment.spaceAround,
                                    children: [
                                      Container(
                                        margin:
                                            EdgeInsets.only(top: 5, bottom: 10),
                                        child: TextButton(
                                          onPressed: () async {
                                            await showDialog(
                                                context: context,
                                                builder:
                                                    (BuildContext context) {
                                                  return Column(
                                                      mainAxisAlignment:
                                                          MainAxisAlignment
                                                              .center,
                                                      children: [
                                                        Container(
                                                          margin:
                                                              EdgeInsets.only(
                                                                  bottom: 8),
                                                          child: TextButton(
                                                            style: ButtonStyle(
                                                                padding: MaterialStatePropertyAll(
                                                                    EdgeInsets.symmetric(
                                                                        vertical:
                                                                            15,
                                                                        horizontal:
                                                                            25)),
                                                                backgroundColor:
                                                                    MaterialStatePropertyAll(
                                                                        Colors.grey[
                                                                            200])),
                                                            onPressed:
                                                                () async {
                                                              final XFile?
                                                                  image =
                                                                  await picker
                                                                      .pickImage(
                                                                          source:
                                                                              ImageSource.gallery);

                                                              setState(() {
                                                                profileImage =
                                                                    Image.file(
                                                                        File(image!
                                                                            .path));
                                                                Navigator.pop(
                                                                    context);
                                                                BlocProvider.of<
                                                                            ProfileBloc>(
                                                                        context)
                                                                    .add(ProfileUpdated(state
                                                                        .user
                                                                        .copyWith(
                                                                  image: image
                                                                      .path,
                                                                )));
                                                              });
                                                            },
                                                            child: Text(
                                                              "Gallery",
                                                              style: TextStyle(
                                                                fontSize: 22,
                                                                color: Colors
                                                                    .grey[800],
                                                                fontWeight:
                                                                    FontWeight
                                                                        .w500,
                                                              ),
                                                            ),
                                                          ),
                                                        ),
                                                        TextButton(
                                                          style: ButtonStyle(
                                                              padding: MaterialStatePropertyAll(
                                                                  EdgeInsets.symmetric(
                                                                      vertical:
                                                                          15,
                                                                      horizontal:
                                                                          25)),
                                                              backgroundColor:
                                                                  MaterialStatePropertyAll(
                                                                      Colors.grey[
                                                                          200])),
                                                          onPressed: () async {
                                                            final XFile? photo =
                                                                await picker.pickImage(
                                                                    source: ImageSource
                                                                        .camera);

                                                            setState(() {
                                                              profileImage =
                                                                  Image.file(
                                                                      File(photo!
                                                                          .path));
                                                              Navigator.pop(
                                                                  context);
                                                              BlocProvider.of<
                                                                          ProfileBloc>(
                                                                      context)
                                                                  .add(ProfileUpdated(
                                                                      state.user
                                                                          .copyWith(
                                                                image:
                                                                    photo.path,
                                                              )));
                                                            });
                                                          },
                                                          child: Text(
                                                            "Camera",
                                                            style: TextStyle(
                                                              fontSize: 22,
                                                              color: Colors
                                                                  .grey[800],
                                                              fontWeight:
                                                                  FontWeight
                                                                      .w500,
                                                            ),
                                                          ),
                                                        ),
                                                      ]);
                                                });
                                          },
                                          child: Stack(
                                            alignment: Alignment.center,
                                            children: [
                                              SizedBox(
                                                  width: 80,
                                                  height: 80,
                                                  child: profileImage),
                                              Stack(
                                                alignment:
                                                    Alignment.bottomCenter,
                                                children: [
                                                  Container(
                                                    width: 92,
                                                    height: 92,
                                                    decoration: ShapeDecoration(
                                                      shape:
                                                          RoundedRectangleBorder(
                                                        side: BorderSide(
                                                            width: 1,
                                                            color: kLightBlue),
                                                        borderRadius:
                                                            BorderRadius
                                                                .circular(28),
                                                      ),
                                                    ),
                                                  ),
                                                ],
                                              ),
                                            ],
                                          ),
                                        ),
                                      ),
                                      Container(
                                        height: 88,
                                        child: Column(
                                          mainAxisAlignment:
                                              MainAxisAlignment.spaceBetween,
                                          children: [
                                            Text(
                                              state.user.fullName,
                                              style: TextStyle(
                                                color: kTextColorPrimary,
                                                fontSize: 20,
                                                fontFamily: 'Urbanist',
                                                fontWeight: FontWeight.w500,
                                              ),
                                            ),
                                            Text(
                                              '${state.user.email}',
                                              style: TextStyle(
                                                color: kBlueBlack,
                                                fontSize: 18,
                                                fontFamily: 'Poppins',
                                                fontWeight: FontWeight.w400,
                                                letterSpacing: -0.24,
                                              ),
                                            ),
                                            Text(
                                              state.user.expertise ?? "",
                                              style: TextStyle(
                                                color: Color(0xFF376AED),
                                                fontSize: 16,
                                                fontFamily: 'Urbanist',
                                                fontWeight: FontWeight.w300,
                                                height: 1.25,
                                              ),
                                            ),
                                          ],
                                        ),
                                      )
                                    ]),
                                SizedBox(
                                  width: double.infinity,
                                  child: Column(
                                    children: [
                                      Container(
                                        margin: const EdgeInsets.only(
                                            top: 10, bottom: 10),
                                        child: Text(
                                          "About me",
                                          style: TextStyle(
                                              fontSize: 20,
                                              fontWeight: FontWeight.w500),
                                        ),
                                      ),
                                      Container(
                                        padding: EdgeInsets.symmetric(
                                            vertical: 4, horizontal: 15),
                                        margin: EdgeInsets.only(bottom: 10),
                                        decoration: BoxDecoration(
                                            color: Colors.white,
                                            borderRadius:
                                                BorderRadius.circular(2),
                                            border: Border.all(
                                                color: Color.fromARGB(
                                                    255, 232, 232, 232))),
                                        height: 100,
                                        child: SingleChildScrollView(
                                          child: Text(
                                            state.user.bio ?? "",
                                            style: TextStyle(
                                                fontSize: 16,
                                                color: Colors.grey[700]),
                                          ),
                                        ),
                                      )
                                    ],
                                  ),
                                ),
                                Container(
                                  margin: EdgeInsets.only(top: 10),
                                  width: 231,
                                  height: 68,
                                  decoration: ShapeDecoration(
                                    color: kLightBlue,
                                    shape: RoundedRectangleBorder(
                                      borderRadius: BorderRadius.circular(12),
                                    ),
                                  ),
                                  child: Row(
                                    mainAxisAlignment:
                                        MainAxisAlignment.spaceBetween,
                                    children: [
                                      Container(
                                        width: 77,
                                        height: 68,
                                        decoration: ShapeDecoration(
                                          color: Color(0xFF2151CD),
                                          shape: RoundedRectangleBorder(
                                            borderRadius:
                                                BorderRadius.circular(12),
                                          ),
                                        ),
                                        child: Column(
                                            mainAxisAlignment:
                                                MainAxisAlignment.center,
                                            children: [
                                              Text(
                                                state.user.articles.length
                                                    .toString(),
                                                textAlign: TextAlign.center,
                                                style: TextStyle(
                                                  color: Colors.white,
                                                  fontSize: 20,
                                                  fontFamily: 'Urbanist',
                                                  fontWeight: FontWeight.w400,
                                                  height: 1.10,
                                                ),
                                              ),
                                              SizedBox(
                                                width: 63,
                                                child: Text(
                                                  'Post',
                                                  textAlign: TextAlign.center,
                                                  style: TextStyle(
                                                    color: Colors.white
                                                        .withOpacity(
                                                            0.8700000047683716),
                                                    fontSize: 16,
                                                    fontFamily: 'Mulish',
                                                    fontWeight: FontWeight.w400,
                                                    height: 1.50,
                                                  ),
                                                ),
                                              )
                                            ]),
                                      ),
                                      TextButton(
                                        style: ButtonStyle(
                                            padding: MaterialStatePropertyAll(
                                                EdgeInsets.all(0))),
                                        onPressed: () {},
                                        child: Column(
                                            mainAxisAlignment:
                                                MainAxisAlignment.center,
                                            children: [
                                              Text(
                                                'Saved',
                                                textAlign: TextAlign.center,
                                                style: TextStyle(
                                                  color: Colors.white,
                                                  fontSize: 20,
                                                  fontFamily: 'Urbanist',
                                                  fontWeight: FontWeight.w400,
                                                  height: 1.10,
                                                ),
                                              ),
                                              SizedBox(
                                                width: 63,
                                                child: Text(
                                                  'blogs',
                                                  textAlign: TextAlign.center,
                                                  style: TextStyle(
                                                    color: Colors.white
                                                        .withOpacity(
                                                            0.8700000047683716),
                                                    fontSize: 16,
                                                    fontFamily: 'Mulish',
                                                    fontWeight: FontWeight.w400,
                                                    height: 1.50,
                                                  ),
                                                ),
                                              )
                                            ]),
                                      ),
                                      Container(
                                        decoration: ShapeDecoration(
                                          color: kRed,
                                          shape: RoundedRectangleBorder(
                                            borderRadius:
                                                BorderRadius.circular(12),
                                          ),
                                        ),
                                        child: TextButton(
                                          onPressed: () async {
                                            SharedPreferences prefs =
                                                await SharedPreferences
                                                    .getInstance();
                                            prefs.remove('token');
                                            Navigator.push(
                                                context,
                                                MaterialPageRoute(
                                                    builder: (context) =>
                                                        StackOfCards()));
                                          },
                                          child: Column(
                                              mainAxisAlignment:
                                                  MainAxisAlignment.center,
                                              children: [
                                                Container(
                                                  padding: EdgeInsets.symmetric(
                                                      horizontal: 10),
                                                  child: Text(
                                                    'Log',
                                                    textAlign: TextAlign.center,
                                                    style: TextStyle(
                                                      color: Colors.white,
                                                      fontSize: 20,
                                                      fontFamily: 'Urbanist',
                                                      fontWeight:
                                                          FontWeight.w400,
                                                      height: 1.10,
                                                    ),
                                                  ),
                                                ),
                                                SizedBox(
                                                  width: 63,
                                                  child: Text(
                                                    'Out',
                                                    textAlign: TextAlign.center,
                                                    style: TextStyle(
                                                      color: Colors.white
                                                          .withOpacity(
                                                              0.8700000047683716),
                                                      fontSize: 16,
                                                      fontFamily: 'Mulish',
                                                      fontWeight:
                                                          FontWeight.w400,
                                                      height: 1.50,
                                                    ),
                                                  ),
                                                )
                                              ]),
                                        ),
                                      ),
                                    ],
                                  ),
                                )
                              ]),
                            ))
                      ]),
                      Container(
                        margin: EdgeInsets.only(top: 30),
                        child: Stack(
                          alignment: Alignment.bottomCenter,
                          children: [
                            Container(
                              height: MediaQuery.of(context).size.height / 2,
                              decoration: ShapeDecoration(
                                color: Colors.white,
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.only(
                                    topLeft: Radius.circular(28),
                                    topRight: Radius.circular(28),
                                  ),
                                ),
                                shadows: [
                                  BoxShadow(
                                    color: Color(0x115182FF),
                                    blurRadius: 32,
                                    offset: Offset(0, -25),
                                    spreadRadius: 0,
                                  )
                                ],
                              ),
                              child: Column(children: [
                                Container(
                                  alignment: Alignment.centerLeft,
                                  padding: EdgeInsets.only(
                                      left: 40, right: 40, top: 30, bottom: 20),
                                  child: Row(
                                    mainAxisAlignment:
                                        MainAxisAlignment.spaceBetween,
                                    children: [
                                      Text(
                                        'My Posts',
                                        style: TextStyle(
                                          color: kTextColorPrimary,
                                          fontSize: 24,
                                          fontFamily: 'Urbanist',
                                          fontWeight: FontWeight.w500,
                                        ),
                                      ),
                                    ],
                                  ),
                                ),
                                MyPostsList(
                                  myPosts: state.user.articles
                                      .map(
                                          (article) => MyPost(article: article))
                                      .toList(),
                                )
                              ]),
                            ),
                            Container(
                              width: 375,
                              height: 116,
                              decoration: BoxDecoration(
                                gradient: LinearGradient(
                                  begin: Alignment(0.00, -1.00),
                                  end: Alignment(0, 1),
                                  colors: [
                                    Color(0x00F9FAFF),
                                    Color(0xFFFAFBFF)
                                  ],
                                ),
                              ),
                            )
                          ],
                        ),
                      )
                    ]),
              ),
            );
          } else if (state is Error) {
            return Center(
              child: Text("Error"),
            );
          } else {
            return Center(
              child: CircularProgressIndicator(),
            );
          }
        },
      ),
    );
  }
}
