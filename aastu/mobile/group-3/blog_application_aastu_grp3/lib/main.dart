import 'package:animated_splash_screen/animated_splash_screen.dart';
import 'package:blog_application_aastu_grp3/features/authentication/data/datasource/auth_local_data_source.dart';
import 'package:blog_application_aastu_grp3/features/authentication/presentation/bloc/auth/auth_bloc_bloc.dart';
import 'package:blog_application_aastu_grp3/features/authentication/presentation/bloc/bloc/register_bloc.dart';
import 'package:blog_application_aastu_grp3/features/authentication/presentation/bloc/login/login_bloc_bloc.dart';
import 'package:blog_application_aastu_grp3/features/authentication/presentation/screens.dart';
import 'package:blog_application_aastu_grp3/features/authentication/presentation/screens/login_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'features/onboarding/onboarding.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  //
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<LoginBlocBloc>(
          lazy: false,
          create: (BuildContext context) => LoginBlocBloc(),
        ),
        BlocProvider<AuthBlocBloc>(
          lazy: false,
          create: (BuildContext context) => AuthBlocBloc()..add(AppStarted()),
        ),
        BlocProvider<RegisterBloc>(
          lazy: false,
          create: (BuildContext context) => RegisterBloc(),
        ),
      ],
      child: MaterialApp(
        title: 'Flutter Demo',
        theme: ThemeData(
          colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
          useMaterial3: true,
        ),
        home: BlocBuilder<AuthBlocBloc, AuthBlocState>(
          builder: (context, state) {
            if(state is AuthBlocInitial){
              return SplashScreen();
            }
            if(state is AuthenticationAuthenticated){
              
              return LandingPage();
            }

            if(state is AuthenticationUnAuthenticated){
              return SigninToggle();
            }

            return SigninToggle();
          },
        ),
      ),
    );
  }
}

class SplashScreen extends StatelessWidget {
  const SplashScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(

      body: Container(
        child: Text("Splash screen"),
      ),
      // body: AnimatedSplashScreen(
      //     splashIconSize: 150,
      //     splashTransition: SplashTransition.slideTransition,
      //     duration: 5,
      //     animationDuration: Duration(seconds: 2),
      //     splash: Image.asset('assets/images/a2sv_logo.png'),
      //     nextScreen: MyHomePage(title: "Blog")),
    );
  }
}

class LandingPage extends StatefulWidget {
  const LandingPage({super.key});

  @override
  State<LandingPage> createState() => _LandingPageState();
}

class _LandingPageState extends State<LandingPage> {
  @override
  Widget build(BuildContext context) {
    final LocalDataSource lds = LocalDataSource();
    return Center(
      child: ElevatedButton(
        onPressed: () async {
        await lds.deleteFromStorage("Token");
        print("logging out");
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => SigninToggle()));
      }, child: Text("LOGOUT")),
    );
  }
}
