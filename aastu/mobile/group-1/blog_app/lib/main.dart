import 'package:blog_app/core/bloc.dart';
import 'package:blog_app/features/blog/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/blog/domain/usecases/get_single_article.dart';
import 'package:blog_app/features/blog/presentation/blocs/bloc.dart';
import 'package:blog_app/features/blog/presentation/screen/addBlog.dart';
import 'package:blog_app/features/blog/presentation/screen/home_screen.dart';
import 'package:blog_app/features/user/domain/usecases/get_user.dart';
import 'package:blog_app/features/user/domain/usecases/login_user.dart';
import 'package:blog_app/features/user/domain/usecases/register_user.dart';
import 'package:blog_app/features/user/domain/usecases/update_user.dart';
import 'package:blog_app/features/user/presentation/blocs/bloc.dart';
import 'package:blog_app/features/user/presentation/pages/login.dart';
import 'package:blog_app/features/user/presentation/pages/user_profile_screen.dart';
import 'package:blog_app/injection.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:blog_app/features/onboarding/screens/splash.dart';
import 'package:flutter/material.dart';
import 'package:blog_app/injection.dart' as di;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await di.init();
  Bloc.observer = const AppBlocObserver();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      // Use MultiBlocProvider to provide multiple blocs
      providers: [
        BlocProvider<UserBloc>(
          // Provide UserBloc here
          create: (context) => UserBloc(
            registerUser: sl<RegisterUserUseCase>(),
            getUser: sl<GetUserUseCase>(),
            loginUser: sl<LoginUserUseCase>(),
            updateProfilePhoto: sl<UpdateProfilePhotoUseCase>(),
          ),
        ),
        // BlogBLoc
        BlocProvider<BlogBloc>(
          create: (context) => BlogBloc(
            getAllArticle: sl<GetArticleUseCase>(),
            getSingleArticle: sl<GetSingleArticleUseCase>(),
          ),
        ),
        // Other BlocProviders if needed
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'BLOG APP',
        theme: ThemeData(
          colorScheme: ColorScheme.fromSeed(
              seedColor: Colors.white, secondary: const Color(0xffEE6F57)),
          useMaterial3: true,
        ),
        home: const Splash(),
        routes: {
          '/home': (context) => const Home(
                userId: '64e839adac244566c7725f35',
              ),
          '/profile': (context) => const UserProfileScreen(),
          '/login': (context) => const Login(),
          '/addBlog': (context) => const AddBlog(),

          // define routes here
        },
      ),
    );
  }
}
