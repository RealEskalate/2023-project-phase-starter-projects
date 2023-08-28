import 'package:blog_app/features/blog/presentation/blocs/bloc.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_event.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc_state.dart';
import 'package:blog_app/features/blog/presentation/widgets/home_card.dart';
import 'package:blog_app/features/blog/presentation/widgets/list_loading_skeleton.dart';
import 'package:blog_app/features/onboarding/widgets/loading_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class All extends StatefulWidget {
  const All({super.key});

  @override
  State<All> createState() => _AllState();
}

class _AllState extends State<All> {
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
            return ListView.builder(
              itemCount: state.articles.length,
              itemBuilder: (context, index) {
                return CustomizedCard(
                  article: state.articles[index],
                );
              },
            );
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
