import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../bloc/auth_bloc.dart';
import '../widgets/show_login_component.dart';
import '../widgets/show_sign_up_component.dart';

class AuthPage extends StatefulWidget {
  const AuthPage({super.key});

  @override
  State<AuthPage> createState() => _AuthPageState();
}

class _AuthPageState extends State<AuthPage> {
  final _formKey = GlobalKey<FormState>();

  bool _isLogin = true;

  void toggleLoginMode() {
    setState(() {
      _isLogin = true;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
          child: BlocConsumer<AuthBloc, AuthState>(
        listener: (context, state) {
          if (state is SignUpSuccessState) {
            setState(() {
              _isLogin = true;
            });
          }
        },
        builder: (context, state) {
          return Column(
            children: [
              Expanded(
                child: SingleChildScrollView(
                  child: Column(
                    children: [
                      SizedBox(height: 21.h),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Image.asset(
                            'assets/images/a2sv_logo_blue.png',
                            width: 141.w,
                            height: 54.h,
                          ),
                        ],
                      ),
                      SizedBox(height: 54.h),
                      Stack(children: [
                        Container(
                          height: _isLogin ? 700.h : 900.h,
                          padding: EdgeInsets.only(top: 24.h),
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.only(
                                topLeft: Radius.circular(30.r),
                                topRight: Radius.circular(30.r)),
                            color: AppColors.blue,
                          ),
                          child: Row(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              ElevatedButton(
                                  style: ButtonStyle(
                                    elevation: MaterialStateProperty.all(0.0),
                                    backgroundColor: MaterialStateProperty.all(
                                        Colors.transparent),
                                  ),
                                  onPressed: () {
                                    setState(() {
                                      _isLogin = true;
                                    });
                                    _formKey.currentState?.reset();
                                  },
                                  child: Text('LOGIN',
                                      style: TextStyle(
                                          fontSize: 18.sp,
                                          fontFamily: 'UrbanistBold',
                                          color: _isLogin
                                              ? AppColors.white
                                              : AppColors.white
                                                  .withOpacity(0.75)))),
                              SizedBox(width: 84.w),
                              ElevatedButton(
                                  style: ButtonStyle(
                                    elevation: MaterialStateProperty.all(0.0),
                                    backgroundColor: MaterialStateProperty.all(
                                        Colors.transparent),
                                  ),
                                  onPressed: () {
                                    setState(() {
                                      _isLogin = false;
                                    });
                                    _formKey.currentState?.reset();
                                  },
                                  child: Text('SIGN UP',
                                      style: TextStyle(
                                          fontSize: 18.sp,
                                          fontFamily: 'UrbanistBold',
                                          color: _isLogin
                                              ? AppColors.white
                                                  .withOpacity(0.75)
                                              : AppColors.white))),
                            ],
                          ),
                        ),
                        Positioned(
                          top: 96.h,
                          left: 0,
                          right: 0,
                          height: 800.h,
                          child: Container(
                            padding: EdgeInsets.only(
                              top: 32.h,
                              left: 40.w,
                              right: 40.w,
                            ),
                            decoration: BoxDecoration(
                              borderRadius: BorderRadius.only(
                                  topLeft: Radius.circular(25.r),
                                  topRight: Radius.circular(25.r)),
                              color: AppColors.white,
                            ),
                            child: _isLogin
                                ? const LoginComponent()
                                : SignUpComponent(
                                    toggleLoginMode: toggleLoginMode),
                          ),
                        )
                      ]),
                    ],
                  ),
                ),
              ),
            ],
          );
        },
      )),
    );
  }
}
