import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../domain/entities/login_entity.dart';
import '../bloc/auth_bloc.dart';
import 'custom_text_field.dart';
import 'forgot_password.dart';

class LoginComponent extends StatefulWidget {
  const LoginComponent({super.key});

  @override
  State<LoginComponent> createState() => _LoginComponentState();
}

class _LoginComponentState extends State<LoginComponent> {
  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();

  bool _isObscureText = true;

  final _formKey = GlobalKey<FormState>();
  @override
  Widget build(BuildContext context) {
    return BlocConsumer<AuthBloc, AuthState>(
      listener: (context, state) {
        if (state is AuthError) {
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text(state.message),
              duration: const Duration(seconds: 4),
            ),
          );
        }

        if (state is LoginSuccessState) {
          ScaffoldMessenger.of(context).showSnackBar(
              const SnackBar(content: Text('Successfully logged in!')));

          Future.delayed(const Duration(seconds: 3), () {
            context.go('/create-article');
          });
        }
      },
      builder: (context, state) {
        if (state is Loading) {
          return const Center(child: CircularProgressIndicator());
        } else if (state is AuthError) {
          return showLoginForm();
        } else if (state is LoginSuccessState) {
          return showLoginForm();
        } else {
          return showLoginForm();
        }
      },
    );
  }

  Column showLoginForm() {
    return Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
      Text('Welcome Back!',
          style: TextStyle(
              fontSize: 24.sp,
              fontFamily: 'UrbanistSemiBold',
              color: const Color(0xFF0D253C))),
      SizedBox(height: 20.h),
      Text(
        'Sign in with your account',
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
          SizedBox(height: 137.h),
          Row(
            children: [
              Expanded(
                child: ElevatedButton(
                  onPressed: () {
                    if (kDebugMode) {
                      print('username: ${_usernameController.text}');
                      print('password: ${_passwordController.text}');
                    }

                    LoginRequestEntity loginRequestEntity = LoginRequestEntity(
                      email: _usernameController.text,
                      password: _passwordController.text,
                    );
                    context.read<AuthBloc>().add(LoginEvent(
                          loginRequestEntity: loginRequestEntity,
                        ));
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
                    'LOGIN',
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
          const ForgotPassword(),
        ]),
      )
    ]);
  }
}
