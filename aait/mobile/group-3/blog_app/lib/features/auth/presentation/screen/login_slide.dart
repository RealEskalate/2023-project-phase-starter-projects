import 'package:blog_app/features/auth/presentation/bloc/login_bloc/bloc/login_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../widgets/password_widget.dart';
import '../widgets/text_field_widget.dart';

// ignore: must_be_immutable
class LoginSlide extends StatefulWidget {
  final VoidCallback pageChange;
  LoginSlide({super.key, required this.pageChange});

  @override
  State<LoginSlide> createState() => _LoginSlideState();
}

class _LoginSlideState extends State<LoginSlide> {
  TextEditingController emailController = TextEditingController();

  TextEditingController passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    final bloc = context.watch<LoginBloc>();

    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(
              height: 32.h,
            ),
            Text(
              "Welcome back",
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w600,
                fontSize: 24.sp,
              ),
            ),
            Text(
              "sign in with your account",
              style: TextStyle(
                fontFamily: 'Poppins',
                fontWeight: FontWeight.w900,
                fontSize: 14.sp,
                color: Color(0xFF2D4379),
              ),
            ),
            SizedBox(
              height: 37.h,
            ),
            CustomizeTextFieldWidget(
              text: 'User Name',
              icon: Icons.person,
              controller: emailController,
            ),
            SizedBox(
              height: 25.h,
            ),
            PasswordWidget(
              controller: passwordController,
            ),
            SizedBox(
              height: 200.h,
            ),
            BlocConsumer<LoginBloc, LoginState>(
              listener: (context, state) {
                if (state is LoginSuccessState) {
                  context.go('/home');
                }
              },
              builder: (context, state) {
                if (state is LoginLoadingState) {
                  return SizedBox(
                    width: 295.w,
                    height: 60.h,
                    child: ElevatedButton(
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Color(0xFF376AED),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(12.r),
                        ),
                      ),
                      onPressed: () {},
                      child: const CircularProgressIndicator.adaptive(),
                    ),
                  );
                } else if (state is LoginErrorState) {
                  return Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Text(
                        "! ${state.errorStateMessage}",
                        style: const TextStyle(color: Colors.red),
                      ),
                      const SizedBox(
                        height: 6,
                      ),
                      SizedBox(
                        width: 295.w,
                        height: 60.h,
                        child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            backgroundColor: Color(0xFF376AED),
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(12.r),
                            ),
                          ),
                          onPressed: () {
                            bloc.add(
                              Login(
                                email: emailController.text,
                                password: passwordController.text,
                              ),
                            );
                          },
                          child: Text(
                            "LOGIN",
                            style: TextStyle(
                              fontFamily: 'Urbanist',
                              fontWeight: FontWeight.w700,
                              fontSize: 16.sp,
                            ),
                          ),
                        ),
                      ),
                    ],
                  );
                }
                return SizedBox(
                  width: 295.w,
                  height: 60.h,
                  child: ElevatedButton(
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Color(0xFF376AED),
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(12.r),
                      ),
                    ),
                    onPressed: () {
                      BlocProvider.of<LoginBloc>(context).add(
                        Login(
                          email: emailController.text,
                          password: passwordController.text,
                        ),
                      );
                    },
                    child: Text(
                      "LOGIN",
                      style: TextStyle(
                        fontFamily: 'Urbanist',
                        fontWeight: FontWeight.w700,
                        fontSize: 16.sp,
                      ),
                    ),
                  ),
                );
              },
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text(
                  "Forgot your password?",
                  style: TextStyle(
                    fontFamily: 'Poppins',
                    fontWeight: FontWeight.w900,
                    fontSize: 14.sp,
                    color: Color(0xFF2D4379),
                  ),
                ),
                TextButton(
                  onPressed: () {},
                  child: Text(
                    "Reset here",
                    style: TextStyle(
                      fontFamily: 'Urbanist',
                      fontWeight: FontWeight.w500,
                      fontSize: 14.sp,
                      color: Color(0xFF376AED),
                    ),
                  ),
                ),
              ],
            ),
            SizedBox(
              height: 500.h,
            ),
          ],
        ),
      ),
    );
  }
}
