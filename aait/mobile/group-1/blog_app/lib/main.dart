import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/bloc.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/sign_up_bloc/bloc.dart';
import 'package:blog_app/features/user_profile/presentation/bloc/profile_bloc.dart';
import 'package:device_preview/device_preview.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import './Injection/injection_container.dart' as di;
import './Injection/auth_injection.dart' as authdi;
import './Injection/main_injection.dart' as maindi;

import 'features/Article/presentation/bloc/article_bloc/article_bloc.dart';
import 'features/home_page/presentation/pages/home_page.dart';
import 'features/intro_screens/onboarding_screens/onboarding_screen1.dart';
import 'features/user_profile/presentation/pages/profile.dart';
import 'package:blog_app/features/home_page/presentation/bloc/article_bloc.dart'
    as newBloc;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await di.init();
  await authdi.init();
  await maindi.init();

  runApp(DevicePreview(
      enabled: !kReleaseMode,
      builder: (context) => MultiBlocProvider(providers: [
            BlocProvider(create: (context) => authdi.sl<LogInBloc>()),
            BlocProvider(create: (context) => authdi.sl<ArticleBloc>()),
            BlocProvider(create: (context) => authdi.sl<SignUpBloc>()),
            BlocProvider(create: (context) => authdi.sl<newBloc.ArticleBloc>()),
            BlocProvider<ProfileBloc>(
              create: (context) => ProfileBloc(),
            ),
          ], child: const MyApp())));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      //DevicePreview

      debugShowCheckedModeBanner: false,
      //DevicePreview

      home: OnboardingPage(),
    );
  }
}
