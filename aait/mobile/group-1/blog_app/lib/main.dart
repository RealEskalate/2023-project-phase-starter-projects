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
import './features/user_profile/presentation/pages/profile.dart';
import './Injection/injection_container.dart' as di;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await di.init();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      //DevicePreview
      locale: DevicePreview.locale(context),
      builder: DevicePreview.appBuilder,
      debugShowCheckedModeBanner: false,
      //DevicePreview

      darkTheme: ThemeData.dark(),
      home: const ProfilePage(),
    );
  }
}
