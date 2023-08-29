import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';
import '../../domain/entities/login_entity.dart';
import '../bloc/auth_bloc.dart';
import 'custom_text_field.dart';
import 'custom_password_text_form_field.dart';
import 'elevated_button_style.dart';
import 'elevated_button_text.dart';
import 'forgot_password.dart';
import 'show_welcome_message.dart';

class LoginComponent extends StatefulWidget {
  const LoginComponent({super.key});

  @override
  State<LoginComponent> createState() => _LoginComponentState();
}

class _LoginComponentState extends State<LoginComponent> {
  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();

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
            const SnackBar(
              content: Text('Successfully logged in!'),
              duration: Duration(seconds: 4),
            ),
          );

          context.go(Routes.articles);
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
      const ShowWelcomeText(),
      SizedBox(height: 37.h),
      Form(
        key: _formKey,
        child: Column(children: [
          CustomTextFormField(
            controller: _usernameController,
            labelText: 'Username',
          ),
          SizedBox(height: 10.h),
          CustomPasswordTextField(passwordController: _passwordController),
          SizedBox(height: 137.h),
          Row(
            children: [
              Expanded(
                child: ElevatedButton(
                  onPressed: () {
                    if (_formKey.currentState!.validate()) {
                      LoginRequestEntity loginRequestEntity =
                          LoginRequestEntity(
                        email: _usernameController.text,
                        password: _passwordController.text,
                      );

                      context.read<AuthBloc>().add(LoginEvent(
                            loginRequestEntity: loginRequestEntity,
                          ));
                    }
                  },
                  style: elevatedButtonStyle(),
                  child: const ElevatedButtonText(
                    text: 'LOGIN',
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
