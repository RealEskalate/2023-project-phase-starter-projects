import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_event.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_state.dart';
import 'package:blog_app/features/blog/presentation/widgets/home_card.dart';
import 'package:blog_app/features/blog/presentation/widgets/list_loading_skeleton.dart';
import 'package:blog_app/features/onboarding/widgets/loading_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class TagSelector extends StatefulWidget {
  final String tag;

  const TagSelector({super.key, required this.tag});

  @override
  State<TagSelector> createState() => _TagSelectorState();
}

class _TagSelectorState extends State<TagSelector> {
  @override
  void initState() {
    super.initState();
    context.read<BlogBloc>().add(const GetAllArticlesEvent());
  }

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: BlocBuilder<BlogBloc, BlogState>(
        builder: (context, state) {
          if (state is BlogLoading) {
            return ListView.builder(
              itemCount: 7,
              itemBuilder: (context, index) {
                return const ListLoading();
              },
            );
          } else if (state is BlogError) {
            return const Center(
              child: Text('Error loading articles'),
            );
          } else if (state is BlogInitial) {
            context.read<BlogBloc>().add(const GetAllArticlesEvent());
            return loadingDialog(context);
          } else if (state is LoadedGetBlogState) {
            List<Article> sportArticles = state.articles;
            if (widget.tag.toLowerCase() != "all") {
              sportArticles = state.articles
                  .where((article) =>
                      article.tags != null &&
                      article.tags!.contains(widget.tag.toLowerCase()))
                  .toList();
            }

            if (sportArticles.isEmpty) {
              return const Center(
                child: Text('No articles'),
              );
            } else {
              return ListView.builder(
                itemCount: sportArticles.length,
                itemBuilder: (context, index) {
                  return CustomizedCard(
                    article: sportArticles[index],
                  );
                },
              );
            }
          } else {
            return const Center(
              child: Text('No articles'),
            );
          }
        },
      ),
    );
  }
}
