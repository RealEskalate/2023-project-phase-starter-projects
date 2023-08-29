import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'bloc_observer.dart';
import 'core/presentation/router/router.dart';
import 'core/presentation/theme/app_theme.dart';
import 'features/authentication/presentation/bloc/auth_bloc.dart';
import 'injection_container.dart' as di;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await di.init();
  Bloc.observer = SimpleBlocObserver();

  runApp(const App());
}

class App extends StatelessWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
      designSize: const Size(390, 844),
      minTextAdapt: true,
      splitScreenMode: true,
      builder: (_, child) => MultiBlocProvider(
        providers: [
          BlocProvider<AuthBloc>(
            create: (_) => di.serviceLocator<AuthBloc>()..add(GetTokenEvent()),
          ),
        ],
        child: MaterialApp.router(
          title: 'Blog app',
          theme: AppTheme.themeData,
          debugShowCheckedModeBanner: false,
          routerConfig: router,
        ),
      ),
    );
  }
}
