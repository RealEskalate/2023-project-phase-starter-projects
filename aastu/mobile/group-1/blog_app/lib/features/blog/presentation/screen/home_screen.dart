import 'dart:developer';
import 'package:blog_app/core/utils/greeting.dart';
import 'package:blog_app/features/blog/domain/usecases/create_article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/blog/domain/usecases/get_single_article.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_event.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_state.dart';
import 'package:blog_app/features/blog/presentation/widgets/home_card.dart';
import 'package:blog_app/features/blog/presentation/widgets/list_loading_skeleton.dart';
import 'package:blog_app/features/blog/presentation/widgets/sport.dart';
import 'package:blog_app/features/onboarding/widgets/loading_widget.dart';
import 'package:blog_app/injection.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:animated_text_kit/animated_text_kit.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../widgets/all.dart';
import '../widgets/politics.dart';

class Home extends StatefulWidget {
  final String userId;
  const Home({Key? key, required this.userId}) : super(key: key);

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  String _userName = "Abel";
  var cats = ['All', 'Sports', 'Tech', 'Politics'];
  // list of widgets
  final List<Widget> _room = [const All(), const Sport(), const Politics()];
  var scroll = ['1', '2', '3'];
  int _currentPage = 0;

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => BlogBloc(
        getAllArticle: sl<GetArticleUseCase>(),
        getSingleArticle: sl<GetSingleArticleUseCase>(),
        createArticle: sl<CreateArticleUseCase>(),
      ),
      child: BlocConsumer<BlogBloc, BlogState>(
        listener: (context, state) {
          if (state is LoadedGetBlogState) {
          }
          // loading state
          else if (state is BlogLoading) {
            loadingDialog(context);
          } else if (state is BlogError) {
            // Handle error if login fails
          }
        },
        builder: (context, state) {
          return buildBody(context);
        },
      ),
    );
  }

  @override
  void initState() {
    super.initState();
    context.read<BlogBloc>().add(const GetAllArticlesEvent());
    _loadUserName();
  }

  Future<void> _loadUserName() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    String userName = prefs.getString("userName") ?? "";
    setState(() {
      userName = userName;
    });
  }

  String greeting = getGreeting();
  Widget buildBody(BuildContext context) {
    return RefreshIndicator(
      onRefresh: () async {
        context.read<BlogBloc>().add(const GetAllArticlesEvent());
        // title animation
        setState(() {
          _userName = _userName;
        });
      },
      child: Scaffold(
        backgroundColor: const Color(0xffF8FAFF),
        appBar: AppBar(
          leading: IconButton(
            icon: const Icon(
              Icons.sort,
              color: Colors.black,
              size: 45,
            ),
            onPressed: () {},
          ),
          backgroundColor: const Color.fromRGBO(248, 250, 255, 1),
          title: Center(
            child: Column(
              children: [
                AnimatedTextKit(
                  animatedTexts: [
                    TyperAnimatedText(
                      "",
                      textStyle: const TextStyle(
                        fontFamily: 'Poppins-SemiBold',
                        fontWeight: FontWeight.bold,
                        color: Colors.black,
                      ),
                    ),
                    TyperAnimatedText(
                      "Hello, $_userName" + '   ',
                      textStyle: const TextStyle(
                        fontFamily: 'Poppins-SemiBold',
                        fontWeight: FontWeight.bold,
                        color: Colors.black,
                      ),
                    ),
                    TyperAnimatedText(
                      "Welcome back!",
                      textStyle: const TextStyle(
                        fontFamily: 'Poppins-SemiBold',
                        fontWeight: FontWeight.bold,
                        color: Colors.black,
                      ),
                    ),
                  ],
                  onTap: () {
                    log("Tap Event");
                  },
                  pause: const Duration(milliseconds: 1000),
                  stopPauseOnTap: true,
                  isRepeatingAnimation: false,
                  totalRepeatCount: 3,
                  repeatForever: false,
                ),

                const SizedBox(height: 10), // Add some spacing between lines

                // Hide if user name is empty
              ],
            ),
          ),
          toolbarHeight: 80,
          actions: [
            Container(
                width: 42,
                margin: const EdgeInsets.only(
                    left: 0, right: 20, top: 0, bottom: 0),
                child: GestureDetector(
                  onTap: () {
                    Navigator.pushNamed(context, '/profile');
                  },
                  child: const CircleAvatar(
                    radius: 40,
                    backgroundImage: AssetImage("assets/images/doctor.jpg"),
                  ),
                )),
          ],
        ),
        body: Column(
          children: [
            Container(
              margin:
                  const EdgeInsets.only(top: 0, right: 20, left: 20, bottom: 0),
              height: 50,
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(12),
              ),
              child: Row(
                children: [
                  Expanded(
                    child: TextField(
                      decoration: InputDecoration(
                        hintText: "Search an article...",
                        hintStyle: TextStyle(
                          fontFamily: 'Poppins-ExtraLight',
                          color: Colors.grey.shade400,
                          fontSize: 15,
                        ),
                        contentPadding: const EdgeInsets.only(
                            left: 10, top: 12, bottom: 12), // Add padding here
                        border: InputBorder.none,
                        suffixIcon: Container(
                          width: 50,
                          height: 100,
                          decoration: BoxDecoration(
                            color: const Color(0xff376AED),
                            borderRadius: BorderRadius.circular(12),
                          ),
                          child: IconButton(
                            icon: const Icon(
                              Icons.search,
                              size: 32,
                            ),
                            color: Colors.white,
                            onPressed: () {},
                          ),
                        ),
                      ),
                    ),
                  ),
                  const Padding(padding: EdgeInsets.only(bottom: 10))
                ],
              ),
            ),
            Container(
              height: 70,
              margin: const EdgeInsets.symmetric(horizontal: 20),
              child: ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: cats.length,
                  itemBuilder: (ctx, index) {
                    return Container(
                      width: 70,

                      // color: _currentPage == index?Color.fromRGBO(55, 106, 237, 1): null,
                      margin: const EdgeInsets.symmetric(
                          horizontal: 5, vertical: 18.5),
                      decoration: BoxDecoration(
                        color: _currentPage == index
                            ? const Color(0xff376AED)
                            : null,
                        borderRadius: BorderRadius.circular(20),
                        border: _currentPage == index
                            ? null
                            : Border.all(
                                color: const Color(0xff376AED), width: 2),
                      ),
                      child: TextButton(
                        onPressed: () {
                          setState(() {
                            _currentPage = index;
                          });
                        },
                        child: Text(
                          cats[index],
                          style: TextStyle(
                            color: _currentPage == index
                                ? Colors.white
                                : const Color(0xff376AED),
                            fontSize: 11.5,
                            fontFamily: 'Poppins-Regular',
                          ),
                        ),
                      ),
                    );
                  }),
            ),
            Container(
              child: _room[_currentPage],
            )

            //   Expanded(
            //     child: BlocBuilder<BlogBloc, BlogState>(
            //       builder: (context, state) {
            //         if (state is BlogLoading) {
            //           return ListView.builder(
            //             itemCount: 7,
            //             itemBuilder: (context, index) {
            //               return const ListLoading();
            //             },
            //           );
            //         } else if (state is BlogError) {
            //           return const Center(
            //             child: Text('Error loading articles'),
            //           );
            //         } else if (state is BlogInitial) {
            //           context.read<BlogBloc>().add(const GetAllArticlesEvent());
            //           return loadingDialog(context);
            //         } else if (state is LoadedGetBlogState) {
            //           return ListView.builder(
            //             itemCount: state.articles.length,
            //             itemBuilder: (context, index) {
            //               return CustomizedCard(
            //                 article: state.articles[index],
            //               );
            //             },
            //           );
            //         } else {
            //           return const Center(
            //             child: Text('No articles'),
            //           );
            //         }
            //       },
            //     ),
            //   ),
          ],
        ),
        floatingActionButton: FloatingActionButton(
          onPressed: () {
            // AddBlog
            Navigator.pushNamed(context, '/addBlog');
          },
          backgroundColor: const Color(0xff376AED),
          child: const Icon(
            Icons.add,
            color: Colors.white,
          ),
        ),
      ),
    );
  }
}
