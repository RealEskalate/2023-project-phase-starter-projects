import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../data/models/sign_up_model.dart';
import '../bloc/auth_bloc.dart';
import 'custom_password_text_form_field.dart';
import 'custom_text_field.dart';
import 'elevated_button_style.dart';
import 'elevated_button_text.dart';
import 'show_welcome_message.dart';

class SignUpComponent extends StatefulWidget {
  const SignUpComponent({super.key, required this.toggleLoginMode});

  final Function toggleLoginMode;

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
        ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
            duration: Duration(seconds: 4),
            content: Text(' Successfully created account!. Please login')));
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
      const ShowWelcomeText(
          welcomeMessage: 'Welcome!',
          authMessage: 'provide credentials to sign up'),
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
          CustomPasswordTextField(
            passwordController: _passwordController,
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
                    if (_formKey.currentState!.validate()) {
                      SignUpRequestModel signUpRequestModel =
                          SignUpRequestModel(
                        email: _usernameController.text,
                        password: _passwordController.text,
                        fullName: _fullNameController.text,
                        expertise: _expertiseController.text,
                        bio: _bioController.text,
                      );

                      context
                          .read<AuthBloc>()
                          .add(SignUpEvent(signUpRequestModel));
                    }
                  },
                  style: elevatedButtonStyle(),
                  child: const ElevatedButtonText(),
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
                  color: AppColors.darkBlue,
                ),
              ),
              TextButton(
                onPressed: () => widget.toggleLoginMode(),
                child: Text(
                  'Login',
                  style: TextStyle(
                    fontSize: 14.sp,
                    fontFamily: 'UrbanistMedium',
                    color: AppColors.blue,
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
