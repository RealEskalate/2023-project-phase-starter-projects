import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../bloc/profile_bloc.dart';
import 'grid_view_article_card.dart';
import 'list_view_article_card.dart';

class PostContent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final bloc = context.watch<ProfileBloc>();
    final state = bloc.state;

    switch (state) {
      case ProfileLoading():
        return Center(
          child: CircularProgressIndicator(),
        );
      case ProfileInitial():
        bloc.add(GetData());
        return Center(
          child: CircularProgressIndicator(),
        );
      case ProfileLoaded():
        final activeColor = Color(0xFF376AED);
        final inActiveColor = Color(0xFF7B8BB2);
        final stateIsGridView = state.isGridView;
        return Column(
          children: [
            Container(
              alignment: Alignment.centerLeft,
              padding: EdgeInsets.symmetric(horizontal: 32, vertical: 40),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                    "My Posts",
                    style: TextStyle(fontWeight: FontWeight.w500, fontSize: 20),
                  ),
                  Row(
                    children: [
                      IconButton(
                        onPressed: () {
                          bloc.add(ToggleViewMode(isGridView: true));
                        },
                        icon: Icon(Icons.grid_view),
                        color: stateIsGridView ? activeColor : inActiveColor,
                      ),
                      IconButton(
                        onPressed: () {
                          bloc.add(ToggleViewMode(isGridView: false));
                        },
                        icon: Icon(Icons.list),
                        color: stateIsGridView ? inActiveColor : activeColor,
                      )
                    ],
                  )
                ],
              ),
            ),
            !stateIsGridView
                ? ListView.builder(
                    shrinkWrap: true,
                    physics: NeverScrollableScrollPhysics(),
                    itemCount: state.articles.length,
                    itemBuilder: (context, index) {
                      return ListViewArticleCard(
                          article: state.articles[index]);
                    },
                  )
                : GridView.count(
                    shrinkWrap: true,
                    crossAxisCount: 2,
                    primary: false,
                    mainAxisSpacing: 20,
                    children: state.articles
                        .map((e) => GridViewArticleCard(article: e))
                        .toList(),
                  )
          ],
        );
      default:
        return const Text("UnrecognizedState");
    }
  }
}
