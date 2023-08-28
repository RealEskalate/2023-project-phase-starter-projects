import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';
import '../../../../injection_container.dart';
import '../bloc/article_bloc.dart';
import '../bloc/tag_selector_bloc.dart';
import '../widgets/create_article_form.dart';
import '../widgets/snackbar.dart';

class ArticleFormScreen extends StatelessWidget {
  const ArticleFormScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.background,
        elevation: 0,
        title: Center(
          child: Text('New article',
              style: Theme.of(context).textTheme.titleMedium),
        ),
      ),

      //
      body: MultiBlocProvider(
        providers: [
          BlocProvider<ArticleBloc>(
            create: (context) =>
                serviceLocator<ArticleBloc>()..add(LoadAllTagsEvent()),
          ),
          BlocProvider<TagSelectorBloc>(
            create: (context) => serviceLocator<TagSelectorBloc>(),
          ),
        ],

        //
        child: BlocListener<ArticleBloc, ArticleState>(
          listener: (context, state) {
            if (state is ArticleCreatedState) {
              showSuccess(context, 'Article created successfully');
              context.go(Routes.articleDetail, extra: state.article);
            }

            // Show error
            else if (state is ArticleErrorState) {
              showError(context, state.message);
            }
          },
          child: const CreateArticleForm(),
        ),
      ),
    );
  }
}
