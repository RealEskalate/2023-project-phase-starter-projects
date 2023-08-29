import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';
import '../../../../injection_container.dart';
import '../../domain/entities/article.dart';
import '../bloc/article_bloc.dart';
import '../bloc/tag_bloc.dart';
import '../bloc/tag_selector_bloc.dart';
import '../widgets/create_article_form.dart';
import '../widgets/snackbar.dart';
import '../widgets/update_article_form.dart';

class ArticleFormScreen extends StatelessWidget {
  final Article? article;

  const ArticleFormScreen({super.key, this.article});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.background,
        elevation: 0,
        title: Center(
          child: Text(article == null ? 'New article' : 'Edit article',
              style: Theme.of(context).textTheme.titleMedium),
        ),
      ),

      //
      body: MultiBlocProvider(
        providers: [
          BlocProvider<TagBloc>(
            create: (context) =>
                serviceLocator<TagBloc>()..add(LoadAllTagsEvent()),
          ),
          BlocProvider<ArticleBloc>(
              create: (context) => serviceLocator<ArticleBloc>()),
          BlocProvider<TagSelectorBloc>(
            create: (context) => serviceLocator<TagSelectorBloc>(),
          ),
        ],

        //
        child: BlocConsumer<ArticleBloc, ArticleState>(
          listener: (context, state) {
            if (state is ArticleCreatedState) {
              showSuccess(context, 'Article created successfully');
              context.push(Routes.articleDetail, extra: state.article);
            }

            //
            else if (state is ArticleUpdatedState) {
              showSuccess(context, 'Article updated successfully');
              context.push(Routes.articleDetail, extra: state.article);
            }

            // Show error
            else if (state is ArticleErrorState) {
              showError(context, state.message);
            }
          },
          builder: (context, state) {
            if (state is ArticleLoadingState) {
              return const Center(child: CircularProgressIndicator());
            }

            if (article != null) {
              return UpdateArticleForm(article: article!);
            }

            return const CreateArticleForm();
          },
        ),
      ),
    );
  }
}
