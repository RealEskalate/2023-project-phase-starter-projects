import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../data/models/sign_up_model.dart';
import '../bloc/auth_bloc.dart';
import 'custom_text_field.dart';

class SignUpComponent extends StatefulWidget {
  const SignUpComponent({super.key});

  @override
  State<SignUpComponent> createState() => _SignUpComponentState();
}

class _SignUpComponentState extends State<SignUpComponent> {
  final _formKey = GlobalKey<FormState>();

  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();
  final _fullNameController = TextEditingController();
  final _bioController = TextEditingController();
  final _expertiseController = TextEditingController();

  bool _isObscureText = true;

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<AuthBloc, AuthState>(listener: (context, state) {
      if (state is AuthError) {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text(state.message),
            duration: const Duration(seconds: 3),
          ),
        );
      }

      if (state is SignUpSuccessState) {
        ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(content: Text(' Successfully created account!')));

        Future.delayed(const Duration(seconds: 3), () {
          context.go('/create-article');
        });
      }
    }, builder: (context, state) {
      if (state is Loading) {
        return const Center(child: CircularProgressIndicator());
      } else if (state is AuthError) {
        return showSignUpForm(context);
      } else if (state is SignUpSuccessState) {
        return Container();
      } else {
        return showSignUpForm(context);
      }
    });
  }

  Column showSignUpForm(BuildContext context) {
    return Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
      Text('Welcome',
          style: TextStyle(
              fontSize: 24.sp,
              fontFamily: 'UrbanistSemiBold',
              color: const Color(0xFF0D253C))),
      SizedBox(height: 20.h),
      Text(
        'provide credentials to sign up',
        style: TextStyle(
          fontSize: 14.sp,
          fontFamily: 'PoppinsBlack',
          color: const Color(0xFF2D4379),
        ),
      ),
      SizedBox(height: 37.h),
      Form(
        key: _formKey,
        child: Column(children: [
          CustomTextFormField(
            controller: _fullNameController,
            labelText: 'Full Name',
          ),
          SizedBox(height: 10.h),
          CustomTextFormField(
            controller: _usernameController,
            labelText: 'Username',
          ),
          SizedBox(height: 10.h),
          SizedBox(
            height: 66.h,
            child: TextFormField(
              keyboardType: TextInputType.visiblePassword,
              controller: _passwordController,
              obscureText: _isObscureText,
              decoration: InputDecoration(
                labelText: 'Password',
                labelStyle: TextStyle(
                  fontSize: 14.sp,
                  fontFamily: 'UrbanistItalicThin',
                  color: const Color(0xFF2D4379),
                ),
                contentPadding: EdgeInsets.only(top: 5.h, bottom: 5.h),
                floatingLabelBehavior: FloatingLabelBehavior.always,
                suffixIcon: TextButton(
                  onPressed: () {
                    setState(() {
                      _isObscureText = !_isObscureText;
                    });
                  },
                  child: Text(
                    _isObscureText ? 'Show' : 'Hide',
                    style: TextStyle(
                      fontSize: 14.sp,
                      fontFamily: 'UrbanistMedium',
                      color: _isObscureText
                          ? const Color(0xFF376AED)
                          : Colors.red[300],
                    ),
                  ),
                ),
              ),
              style: TextStyle(
                fontSize: 16.sp,
                fontFamily: 'UrbanistMedium',
                color: const Color(0xFF0D253C),
              ),
            ),
          ),
          SizedBox(height: 10.h),
          CustomTextFormField(
            controller: _expertiseController,
            labelText: 'Expertise',
          ),
          SizedBox(height: 10.h),
          CustomTextFormField(
            controller: _bioController,
            labelText: 'Short Bio',
          ),
          SizedBox(height: 137.h),
          Row(
            children: [
              Expanded(
                child: ElevatedButton(
                  onPressed: () {
                    if (kDebugMode) {
                      print('username: ${_usernameController.text}');
                      print('password: ${_passwordController.text}');
                      print('full name: ${_fullNameController.text}');
                      print('expertise: ${_expertiseController.text}');
                      print('bio: ${_bioController.text}');
                    }

                    SignUpRequestModel signUpRequestModel = SignUpRequestModel(
                      email: _usernameController.text,
                      password: _passwordController.text,
                      fullName: _fullNameController.text,
                      expertise: _expertiseController.text,
                      bio: _bioController.text,
                    );

                    context
                        .read<AuthBloc>()
                        .add(SignUpEvent(signUpRequestModel));
                  },
                  style: ButtonStyle(
                    backgroundColor: MaterialStateProperty.all<Color>(
                        const Color(0xFF376AED)),
                    shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                        RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10.r),
                    )),
                  ),
                  child: Text(
                    'SIGN UP',
                    style: TextStyle(
                        fontSize: 18.sp,
                        fontFamily: 'UrbanistBold',
                        color: Colors.white),
                  ),
                ),
              ),
            ],
          ),
          SizedBox(height: 5.h),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                'Have an account already?',
                style: TextStyle(
                  fontSize: 14.sp,
                  fontFamily: 'PoppinsBlack',
                  color: const Color(0xFF2D4379),
                ),
              ),
              TextButton(
                onPressed: () {
                  setState(() {
                    // _isLogin = true;
                  });
                },
                child: Text(
                  'Login',
                  style: TextStyle(
                    fontSize: 14.sp,
                    fontFamily: 'UrbanistMedium',
                    color: const Color(0xFF376AED),
                  ),
                ),
              ),
            ],
          ),
        ]),
      )
    ]);
  }
}
