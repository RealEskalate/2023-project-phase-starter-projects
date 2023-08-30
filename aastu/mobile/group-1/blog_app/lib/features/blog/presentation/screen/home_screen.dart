import 'dart:developer';
import 'package:blog_app/core/utils/capitalize.dart';
import 'package:blog_app/core/utils/clear_token.dart';
import 'package:blog_app/core/utils/greeting.dart';
import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:blog_app/features/blog/domain/usecases/create_article.dart';
import 'package:blog_app/features/user/domain/entities/user.dart' as UserEntity;
import 'package:blog_app/features/blog/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/blog/domain/usecases/get_single_article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_tags.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_event.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_state.dart';
import 'package:blog_app/features/blog/presentation/blocs/get_tags/get_tag_event.dart';
import 'package:blog_app/features/blog/presentation/blocs/get_tags/get_tag_state.dart';
import 'package:blog_app/features/blog/presentation/screen/search_result.dart';
import 'package:blog_app/features/blog/presentation/widgets/tag_selector_widget.dart';
import 'package:blog_app/features/onboarding/widgets/loading_widget.dart';
import 'package:blog_app/features/user/presentation/blocs/bloc.dart';
import 'package:blog_app/features/user/presentation/blocs/bloc_state.dart';
import 'package:blog_app/features/user/presentation/blocs/get_user.dart/user_event.dart';
import 'package:blog_app/features/user/presentation/blocs/get_user.dart/user_state.dart';
import 'package:blog_app/injection.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:animated_text_kit/animated_text_kit.dart';
import 'package:shared_preferences/shared_preferences.dart';

class Home extends StatefulWidget {
  const Home({super.key});

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  List<String> tags = ["All"];
  GlobalKey<ScaffoldState> scaffoldKey = GlobalKey<ScaffoldState>();
  UserEntity.User user =
      UserEntity.User(fullName: '', email: '', expertise: '', bio: '');
  int _currentPage = 0;

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => BlogBloc(
        getAllArticle: sl<GetArticleUseCase>(),
        getSingleArticle: sl<GetSingleArticleUseCase>(),
        getTags: sl<GetTagsUseCase>(),
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

  String fullName = '';

  Future<void> _loadFullNameFromSharedPrefs() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    String savedFullName = prefs.getString("fullName") ?? '';
    setState(() {
      fullName = savedFullName;
    });
  }

  @override
  void initState() {
    super.initState();
    _loadFullNameFromSharedPrefs(); // Load the value when the widget initializes

    // Articles
    context.read<BlogBloc>().add(const GetAllArticlesEvent());

    // Tags
    context.read<BlogBloc>().add(const GetTagsEvent());
    context.read<BlogBloc>().stream.listen((state) {
      if (state is LoadedTagsState) {
        tags.addAll(state.tags.map((tag) => capitalizeFirstLetter(tag)));
      }
    });
  }

  void onDrawerItemClicked(String name) {
    Navigator.pop(context);
  }

  String greeting = getGreeting();

  Widget buildBody(BuildContext context) {
    return RefreshIndicator(
      onRefresh: () async {
        context.read<BlogBloc>().add(const GetAllArticlesEvent());
      },
      child: Scaffold(
        key: scaffoldKey,
        backgroundColor: const Color(0xffF8FAFF),
        appBar: AppBar(
          leading: IconButton(
            icon: const Icon(
              Icons.sort,
              color: Colors.black,
              size: 45,
            ),
            onPressed: () {
              // open or close drawer
              scaffoldKey.currentState!.openDrawer();
            },
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
                      "Hello, $fullName",
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
                    // child: const CircleAvatar(
                    //   radius: 40,
                    //   backgroundImage: AssetImage("assets/images/no_profile.png"),
                    // ),
                    child: Image.asset(
                      "assets/images/no_profile.png",
                      width: 42,
                      height: 42,
                      fit: BoxFit.cover,
                    ))),
          ],
        ),
        drawer: Drawer(
          child: SingleChildScrollView(
            child: Column(
              children: <Widget>[
                Container(
                  height: 190,
                  child: Stack(
                    children: <Widget>[
                      Image.asset(
                        "assets/images/banner_1.png",
                        width: double.infinity,
                        height: double.infinity,
                        fit: BoxFit.cover,
                      ),
                      Padding(
                        padding: const EdgeInsets.symmetric(
                            vertical: 40, horizontal: 14),
                        child: CircleAvatar(
                          radius: 36,
                          backgroundColor: Colors.grey[100],
                          child: const CircleAvatar(
                            radius: 33,
                            backgroundImage:
                                AssetImage("assets/images/no_profile.png"),
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.bottomLeft,
                        child: Padding(
                          padding: const EdgeInsets.symmetric(
                              horizontal: 20, vertical: 18),
                          child: Column(
                            mainAxisSize: MainAxisSize.min,
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: <Widget>[
                              Text(fullName,
                                  style: TextStyle(
                                      color: Colors.grey[100],
                                      fontWeight: FontWeight.bold)),
                              Container(height: 5),
                              Text("",
                                  style: TextStyle(color: Colors.grey[100]))
                            ],
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
                ListTile(
                  title: const Text("Blogs",
                      style: TextStyle(
                          color: Colors.black, fontWeight: FontWeight.w500)),
                  leading: const Icon(Icons.newspaper,
                      size: 25.0, color: Colors.grey),
                  onTap: () {},
                ),
                ListTile(
                  title: const Text("Add Blog",
                      style: TextStyle(
                          color: Colors.black, fontWeight: FontWeight.w500)),
                  leading:
                      const Icon(Icons.edit, size: 25.0, color: Colors.grey),
                  onTap: () {
                    Navigator.pushNamed(context, '/addBlog');
                  },
                ),
                ListTile(
                  title: const Text("Profile",
                      style: TextStyle(
                          color: Colors.black, fontWeight: FontWeight.w500)),
                  leading:
                      const Icon(Icons.person, size: 25.0, color: Colors.grey),
                  onTap: () {
                    Navigator.pushNamed(context, '/profile');
                  },
                ),
                const Divider(),
                ListTile(
                  title: const Text("Logout",
                      style: TextStyle(
                          color: Colors.black, fontWeight: FontWeight.w500)),
                  leading:
                      const Icon(Icons.logout, size: 25.0, color: Colors.grey),
                  onTap: () async {
                    await clearAuthToken();

                    // ignore: use_build_context_synchronously
                    Navigator.pushReplacementNamed(context, '/login');
                  },
                ),
              ],
            ),
          ),
        ),
        body: Container(
          decoration: const BoxDecoration(
            color: Color(0xffF8FAFF),
          ),
          child: Column(
            children: [
              Container(
                margin: const EdgeInsets.only(
                    top: 0, right: 20, left: 20, bottom: 0),
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
                              left: 10,
                              top: 12,
                              bottom: 12), // Add padding here
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
                              onPressed: () {
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                    builder: (context) => const SearchResult(
                                      keyword: '',
                                    ),
                                  ),
                                );
                              },
                            ),
                          ),
                        ),
                      ),
                    ),
                    const Padding(padding: EdgeInsets.only(bottom: 7))
                  ],
                ),
              ),
              Container(
                decoration: const BoxDecoration(
                  color: Color(0xffF8FAFF),
                ),
                height: 70,
                margin: const EdgeInsets.symmetric(horizontal: 20),
                child: ListView.builder(
                    scrollDirection: Axis.horizontal,
                    itemCount: tags.length,
                    itemBuilder: (ctx, index) {
                      return Container(
                        constraints: const BoxConstraints(minWidth: 70),
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
                          child: Padding(
                            padding: const EdgeInsets.only(left: 3, right: 3),
                            child: Text(
                              tags[index],
                              style: TextStyle(
                                color: _currentPage == index
                                    ? Colors.white
                                    : const Color(0xff376AED),
                                fontSize: 11.5,
                                fontFamily: 'Poppins-Regular',
                              ),
                            ),
                          ),
                        ),
                      );
                    }),
              ),
              TagSelector(tag: tags[_currentPage])
            ],
          ),
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
