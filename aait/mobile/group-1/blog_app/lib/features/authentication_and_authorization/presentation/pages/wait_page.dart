import 'package:blog_app/features/authentication_and_authorization/domain/entities/login_user_entitiy.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/bloc.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/event.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/state.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/pages/circular_indicator.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/pages/success_page.dart';
import 'package:blog_app/features/user_profile/presentation/pages/profile.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class WaitPage extends StatefulWidget {
  final String email;
  final String password;
  const WaitPage({super.key, required this.email, required this.password});

  @override
  State<WaitPage> createState() => _WaitPageState();
}

class _WaitPageState extends State<WaitPage> {
  @override
  void initState() {
    super.initState();
    BlocProvider.of<LogInBloc>(context).add(OnLogInButtonPressedEvent(
        loginUserEnity:
            LoginUserEnity(email: widget.email, password: widget.password)));
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<LogInBloc, LoginState>(
      listener: (context, state) {
        if (state is LoginLoadedState) {
          Navigator.push(
              context, MaterialPageRoute(builder: (context) => ProfilePage()));
        }
      },
      builder: (context, state) {
        return CircularIndicator();
      },
    );
  }
}
