import 'package:blog_app/Injection/auth_injection.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/bloc.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/sign_up_bloc/bloc.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/pages/signup_login_page.dart';
import 'package:blog_app/features/user_profile/presentation/bloc/profile_bloc.dart';
import 'package:device_preview/device_preview.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'Injection/auth_injection.dart' as di;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await di.init();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
        providers: [
          BlocProvider(create: (context)=>sl<LogInBloc>()),
          BlocProvider(create: (context)=>sl<SignUpBloc>())
        ],
        child: MaterialApp(
          darkTheme: ThemeData.dark(),
          debugShowCheckedModeBanner: false,
          home: StackOfCards(),
        ));
  }
}