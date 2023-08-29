import 'package:blog_app/core/utils/app_dimension.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/pages/circular_indicator.dart';
import 'package:blog_app/features/blog/domain/usecases/create_article.dart';
import 'package:blog_app/features/blog/presentation/pages/create_blog.dart';
import 'package:blog_app/features/home_page/presentation/bloc/article_bloc.dart';
import 'package:blog_app/features/home_page/presentation/pages/custon_card.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../article_reading/presentation/pages/read_article.dart';
import '../../../user_profile/presentation/pages/profile.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  List<String> tags = [
    "All",
    "Sports",
    "Tech",
    "Politics",
    "Art",
    "Design",
    "Culture",
    "Production",
    "Others",
  ];

  String selectedTag = "";
  @override
  Widget build(BuildContext context) {
    @override
    void initState() {
      super.initState();
      BlocProvider.of<ArticleBloc>(context).add(LoadAllArticlesEvent());

      // Access the context captured in the build method
    }

    return SafeArea(
      child: Scaffold(
        backgroundColor: Colors.grey.shade100,
        body: Padding(
          padding: EdgeInsets.symmetric(
              horizontal: AppDimension.width(10, context),
              vertical: AppDimension.height(10, context)),
          child: Center(
            child: Stack(
              alignment: Alignment.bottomCenter,
              children: [
                Column(
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Icon(
                          Icons.sort,
                          size: AppDimension.height(40, context),
                        ),
                        Text(
                          "Welcome",
                          style: TextStyle(
                              fontSize: AppDimension.height(30, context)),
                        ),
                        IconButton(
                          onPressed: () {
                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => ProfilePage()));
                          },
                          icon: Icon(
                            Icons.person,
                            size: 40,
                          ),
                        )
                        // CircleAvatar(

                        //   backgroundColor: Colors.blue,
                        //   radius: AppDimension.height(30, context),
                        // ),
                      ],
                    ),
                    Padding(
                      padding: EdgeInsets.symmetric(
                          vertical: AppDimension.height(20, context),
                          horizontal: AppDimension.width(15, context)),
                      child: Container(
                        height: AppDimension.height(70, context),
                        decoration: BoxDecoration(
                          color: Colors.white,
                          borderRadius: BorderRadius.circular(8),
                        ),
                        child: Row(
                          children: [
                            Expanded(
                              child: Padding(
                                padding: EdgeInsets.only(
                                    left: AppDimension.width(10, context)),
                                child: TextField(
                                  decoration: InputDecoration(
                                    hintText: 'Search',
                                    hintStyle: TextStyle(color: Colors.grey),
                                    border: InputBorder.none,
                                  ),
                                  style: TextStyle(
                                    color: Colors.black,
                                    fontSize: AppDimension.height(25, context),
                                  ),
                                ),
                              ),
                            ),
                            Container(
                              height: double.infinity,
                              width: AppDimension.width(60, context),
                              decoration: BoxDecoration(
                                  color: Colors.blue,
                                  borderRadius: BorderRadius.circular(
                                      AppDimension.height(10, context))),
                              child: IconButton(
                                icon: Icon(Icons.search, color: Colors.white),
                                onPressed: () {},
                              ),
                            ),
                          ],
                        ),
                      ),
                    ),
                    Container(
                      height: 30,
                      width: double.infinity,
                      child: ListView.builder(
                          itemCount: tags.length,
                          scrollDirection: Axis.horizontal,
                          itemBuilder: (context, index) {
                            final tag = tags[index];
                            bool isSelected = tag == selectedTag;
                            return GestureDetector(
                              onTap: () {
                                setState(() {
                                  selectedTag = isSelected ? "" : tag;
                                });
                              },
                              child: Container(
                                margin: EdgeInsets.symmetric(
                                    horizontal:
                                        AppDimension.width(10, context)),
                                padding: EdgeInsets.symmetric(
                                    horizontal:
                                        AppDimension.width(10, context)),
                                width: AppDimension.width(100, context),
                                decoration: BoxDecoration(
                                  color: isSelected
                                      ? Color(0xFF376AED)
                                      : Colors.white,
                                  borderRadius: BorderRadius.circular(20),
                                  border: isSelected
                                      ? null
                                      : Border.all(
                                          color: Color(0xFF376AED),
                                          width:
                                              AppDimension.height(2, context),
                                        ),
                                ),
                                child: Center(
                                  child: Text(
                                    tag,
                                    style: TextStyle(
                                        color: isSelected
                                            ? Colors.white
                                            : Color(0xFF376AED),
                                        fontWeight: isSelected
                                            ? FontWeight.bold
                                            : FontWeight.normal,
                                        fontSize:
                                            AppDimension.height(20, context)),
                                  ),
                                ),
                              ),
                            );
                          }),
                    ),
                    BlocBuilder<ArticleBloc, ArticleState>(
                      builder: (context, state) {
                        if (state is ArticleLoadingState) {
                          return Center(
                            child: CircularProgressIndicator(),
                          );
                        } else if (state is ArticleErrorState) {
                          return Center(child: Text(state.message));
                        } else if (state is AllArticlesLoadedState) {
                          print(state.articles);

                          return Container(
                            height: AppDimension.height(480, context),
                            child: ListView.builder(
                                itemCount: state.articles.length,
                                itemBuilder: (context, index) {
                                  return GestureDetector(
                                      onTap: () {
                                        Navigator.push(
                                            context,
                                            MaterialPageRoute(
                                                builder: (context) =>
                                                    ArticleDetail(
                                                      article:
                                                          state.articles[index],
                                                    )));
                                      },
                                      child: CustomCard(
                                        author: state.articles[index].author
                                            .toString(),
                                        date: state.articles[index].date
                                            .toString(),
                                      ));
                                }),
                          );
                        } else {
                          return Container();
                        }
                      },
                    ),
                    SizedBox(
                      height: AppDimension.height(30, context),
                    ),
                  ],
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    SizedBox(
                      height: AppDimension.height(5, context),
                      width: AppDimension.width(5, context),
                    ),
                    Container(
                      margin: EdgeInsets.only(
                          top: AppDimension.height(15, context),
                          left: AppDimension.width(60, context)),
                      height: AppDimension.height(60, context),
                      width: AppDimension.width(60, context),
                      decoration: BoxDecoration(
                          color: Colors.blue,
                          borderRadius: BorderRadius.circular(
                              AppDimension.height(10, context))),
                      child: IconButton(
                        icon: Icon(Icons.add, color: Colors.white),
                        onPressed: () {
                          Navigator.push(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => CreateBlogPage()));
                          // Navigator.push(context, route)
                        },
                      ),
                    ),
                  ],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
