import 'package:blog_app/features/auth/presentation/bloc/signup_bloc/bloc/signup_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../widgets/password_widget.dart';
import '../widgets/text_field_widget.dart';

// ignore: must_be_immutable
class SignupSlide extends StatelessWidget {
  final VoidCallback pageChange;
  SignupSlide({super.key, required this.pageChange});
  TextEditingController fullNameController = TextEditingController();
  TextEditingController emailController = TextEditingController();
  TextEditingController passwordController = TextEditingController();
  TextEditingController bioController = TextEditingController();
  TextEditingController expertiseController = TextEditingController();

  @override
  Widget build(BuildContext context) {
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
              "Welcome",
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w600,
                fontSize: 24.sp,
              ),
            ),
            Text(
              "provide credentials to signup",
              style: TextStyle(
                fontFamily: 'Poppins',
                fontWeight: FontWeight.w900,
                fontSize: 14.sp,
                color: Color(0xFF2D4379),
              ),
            ),
            SizedBox(
              height: 20.h,
            ),
            CustomizeTextFieldWidget(
              text: 'Full Name',
              icon: Icons.person,
              controller: fullNameController,
            ),
            SizedBox(
              height: 10.h,
            ),
            CustomizeTextFieldWidget(
              text: 'User Name',
              icon: Icons.email,
              controller: emailController,
            ),
            SizedBox(
              height: 10.h,
            ),
            PasswordWidget(
              controller: passwordController,
            ),
            SizedBox(
              height: 10.h,
            ),
            CustomizeTextFieldWidget(
              text: 'Bio',
              icon: Icons.edit,
              controller: bioController,
            ),
            SizedBox(
              height: 10.h,
            ),
            CustomizeTextFieldWidget(
              text: 'Expertise',
              icon: Icons.star,
              controller: expertiseController,
            ),
            SizedBox(
              height: 30.h,
            ),
            BlocBuilder<SignupBloc, SignupState>(
              builder: (context, state) {
                if (state is SignupLoadingState) {
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
                } else if (state is SignupSuccessState) {
                  // todo
                } else if (state is SignupErrorState) {
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
                            BlocProvider.of<SignupBloc>(context).add(
                              SignUp(
                                email: emailController.text,
                                password: passwordController.text,
                                bio: bioController.text,
                                expertise: expertiseController.text,
                                fullName: fullNameController.text,
                              ),
                            );
                          },
                          child: Text(
                            "SIGNUP",
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
                      BlocProvider.of<SignupBloc>(context).add(
                        SignUp(
                          email: emailController.text,
                          password: passwordController.text,
                          bio: bioController.text,
                          expertise: expertiseController.text,
                          fullName: fullNameController.text,
                        ),
                      );
                    },
                    child: Text(
                      "SIGNUP",
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
                  "Have an account?",
                  style: TextStyle(
                    fontFamily: 'Poppins',
                    fontWeight: FontWeight.w900,
                    fontSize: 14.sp,
                    color: Color(0xFF2D4379),
                  ),
                ),
                TextButton(
                  onPressed: () {
                    pageChange();
                  },
                  child: Text(
                    "Login",
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
            SizedBox(height: 500.h,),
          ],
        ),
      ),
    );
  }
}
