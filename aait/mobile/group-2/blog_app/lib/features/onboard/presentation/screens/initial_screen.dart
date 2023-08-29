import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';
import '../../../../injection_container.dart';
import '../../../authentication/presentation/bloc/auth_bloc.dart';
import '../../../user/presentation/bloc/user_bloc.dart';
import 'splash_screen_static.dart';

class AppInitialScreen extends StatelessWidget {
  const AppInitialScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider<UserBloc>(
      create: (context) => serviceLocator<UserBloc>(),

      //
      child: BlocListener<AuthBloc, AuthState>(
        listener: (context, state) {
          if (state is UserAuthState) {
            if (state.token != null) {
              context.read<UserBloc>().add(GetUserEvent(token: state.token!));
            } else {
              context.go(Routes.onBoard);
            }
          }
        },
        child: BlocListener<UserBloc, UserState>(
          listener: (context, state) {
            if (state is LoadedUserState) {
              context.go(Routes.articles);
            } else if (state is ErrorState) {
              context.go(Routes.onBoard);
            }
          },
          child: const SplashScreenStatic(),
        ),
      ),
    );
  }
}
