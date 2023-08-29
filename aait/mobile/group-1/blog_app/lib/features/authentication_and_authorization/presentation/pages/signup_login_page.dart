import 'package:blog_app/features/authentication_and_authorization/domain/entities/login_user_entitiy.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/entities/sign_up_user_entity.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/bloc.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/event.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/Log_in_bloc/state.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/sign_up_bloc/bloc.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/sign_up_bloc/event.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/bloc/sign_up_bloc/state.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/pages/circular_indicator.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/pages/success_page.dart';
import 'package:blog_app/features/authentication_and_authorization/presentation/pages/wait_page.dart';
import 'package:blog_app/features/home_page/presentation/pages/home_page.dart';
import 'package:blog_app/features/user_profile/presentation/bloc/profile_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/utils/app_dimension.dart';
import '../../../user_profile/presentation/pages/profile.dart';

class StackOfCards extends StatefulWidget {
  @override
  State<StackOfCards> createState() => _StackOfCardsState();
}

class _StackOfCardsState extends State<StackOfCards> {
  bool is_signup = true;

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
          body: SingleChildScrollView(
        child: Stack(
          children: [
            Container(
                padding:
                    EdgeInsets.only(left: AppDimension.width(120, context)),
                child: Image.asset(
                  "assets/images/a2sv.png",
                  width: AppDimension.width(150, context),
                  height: AppDimension.height(150, context),
                )),
            Container(
              margin: EdgeInsets.only(top: AppDimension.height(180, context)),
              height: AppDimension.height(800, context),
              // width: 100,
              decoration: BoxDecoration(
                  color: Color(0XFF376AED),
                  borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(AppDimension.width(40, context)),
                    topRight: Radius.circular(AppDimension.width(40, context)),
                  )),
            ),
            Container(
              margin: EdgeInsets.only(
                  top: AppDimension.height(207, context),
                  left: AppDimension.width(60, context),
                  right: AppDimension.width(60, context)),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  TextButton(
                    onPressed: () {
                      setState(() {
                        is_signup = true;
                      });
                    },
                    child: Text(
                      "Log In",
                      style: TextStyle(
                          color: Colors.white,
                          fontSize: AppDimension.height(25, context)),
                    ),
                  ),
                  TextButton(
                    onPressed: () {
                      setState(() {
                        is_signup = false;
                      });
                    },
                    child: Text(
                      "Sign Up",
                      style: TextStyle(
                          color: Colors.white,
                          fontSize: AppDimension.height(25, context)),
                    ),
                  )
                ],
              ),
            ),
            is_signup ? LogIn() : SignUp()
          ],
        ),
      )),
    );
  }
}

class LogIn extends StatefulWidget {
  const LogIn();

  @override
  State<LogIn> createState() => _LogInState();
}

class _LogInState extends State<LogIn> {
  TextEditingController emailController = TextEditingController();
  TextEditingController passwordController = TextEditingController();

  bool _obscure_text = true;
  @override
  Widget build(BuildContext context) {
    return BlocConsumer<LogInBloc, LoginState>(
      listener: (context, state) {
        if (state is LoginLoadedState) {
          Navigator.push(
              context, MaterialPageRoute(builder: (context) => HomePage()));
        } else if (state is ErrorState) {
          ScaffoldMessenger.of(context)
              .showSnackBar(SnackBar(content: Text(state.message)));
        }
      },
      builder: (context, state) {
        if (state is LoginLoadingState) {
          return CircularIndicator();
        } else {
          return Container(
            margin: EdgeInsets.only(top: AppDimension.height(280, context)),
            height: AppDimension.height(700, context),
            width: MediaQuery.of(context).size.width,
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(AppDimension.width(40, context)),
                  topRight: Radius.circular(AppDimension.width(40, context)),
                )),
            child: Container(
              margin: EdgeInsets.only(
                  left: AppDimension.width(40, context),
                  right: AppDimension.width(40, context)),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                      margin: EdgeInsets.only(
                          top: AppDimension.height(20, context)),
                      child: Text(
                        "Welcome back",
                        style: TextStyle(
                            fontSize: AppDimension.height(35, context)),
                      )),
                  Container(
                      margin: EdgeInsets.only(
                          top: AppDimension.height(20, context)),
                      child: Text(
                        "Sign in with your account",
                        style: TextStyle(
                            fontSize: AppDimension.height(20, context),
                            fontWeight: FontWeight.w700),
                      )),
                  SizedBox(
                    height: AppDimension.height(15, context),
                  ),
                  Form(
                      child: Column(
                    children: [
                      TextField(
                        controller: emailController,
                        style: TextStyle(
                            fontSize: AppDimension.height(25, context)),
                        decoration: InputDecoration(
                          labelText: 'Email',
                        ),
                      ),
                      SizedBox(
                        height: AppDimension.height(10, context),
                      ),
                      TextField(
                        controller: passwordController,
                        style: TextStyle(
                            fontSize: AppDimension.height(25, context)),
                        obscureText: _obscure_text,
                        decoration: InputDecoration(
                            labelText: 'Password',
                            suffixIcon: TextButton(
                              onPressed: () {
                                setState(() {
                                  _obscure_text = !_obscure_text;
                                });
                              },
                              child: Text(
                                _obscure_text ? "Show" : "Hide",
                                style: TextStyle(
                                    color: Colors.blue,
                                    fontSize: AppDimension.height(20, context)),
                              ),
                            )),
                      ),
                      SizedBox(
                        height: AppDimension.height(100, context),
                      ),
                      Container(
                          height: AppDimension.height(60, context),
                          width: double.infinity,
                          child: ElevatedButton(
                              style: ElevatedButton.styleFrom(
                                  shape: RoundedRectangleBorder(
                                    borderRadius: BorderRadius.circular(
                                        AppDimension.height(20,
                                            context)), // Set your desired border radius
                                  ),
                                  backgroundColor: Color(0XFF376AED)),
                              onPressed: () {
                                LoginUserEnity loginUserEnity = LoginUserEnity(
                                    email: emailController.text,
                                    password: passwordController.text);

                                BlocProvider.of<LogInBloc>(context).add(
                                    OnLogInButtonPressedEvent(
                                        loginUserEnity: loginUserEnity));
                              },
                              child: Text(
                                "Login",
                                style: TextStyle(
                                    fontSize: AppDimension.height(25, context)),
                              ))),
                    ],
                  ))
                ],
              ),
            ),
          );
        }
      },
    );
  }
}

class SignUp extends StatefulWidget {
  const SignUp({
    Key? key,
  }) : super(key: key);

  @override
  State<SignUp> createState() => _SignUpState();
}

class _SignUpState extends State<SignUp> {
  TextEditingController fullnameController = TextEditingController();
  TextEditingController passwordController = TextEditingController();
  TextEditingController expertiseController = TextEditingController();
  TextEditingController descriptionController = TextEditingController();
  TextEditingController emailEditingController = TextEditingController();

  bool _obscure_text = true;

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<SignUpBloc, SignUpState>(listener: (context, state) {
      if (state is SignUpLoadedState) {
        Navigator.push(
            context,
            MaterialPageRoute(
                builder: (context) => WaitPage(
                    email: emailEditingController.text,
                    password: passwordController.text)));
      } else if (state is SignupErrorState) {
        ScaffoldMessenger.of(context)
            .showSnackBar(SnackBar(content: Text(state.message)));
      }
    }, builder: (context, state) {
      if (state is SignupLoadingState) {
        return CircularIndicator();
      } else {
        return Container(
          margin: EdgeInsets.only(top: AppDimension.height(280, context)),
          height: AppDimension.height(850, context),
          width: MediaQuery.of(context).size.width,
          decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.only(
                topLeft: Radius.circular(AppDimension.width(40, context)),
                topRight: Radius.circular(AppDimension.width(40, context)),
              )),
          child: Container(
            margin: EdgeInsets.only(
                left: AppDimension.width(40, context),
                right: AppDimension.width(40, context)),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                    margin:
                        EdgeInsets.only(top: AppDimension.height(20, context)),
                    child: Text(
                      "Welcome ",
                      style:
                          TextStyle(fontSize: AppDimension.height(35, context)),
                    )),
                Container(
                    margin:
                        EdgeInsets.only(top: AppDimension.height(20, context)),
                    child: Text(
                      "Provide Credential to Signup",
                      style: TextStyle(
                          fontSize: AppDimension.height(20, context),
                          fontWeight: FontWeight.w700),
                    )),
                SizedBox(
                  height: AppDimension.height(15, context),
                ),
                Form(
                    child: Column(
                  children: [
                    TextField(
                      controller: fullnameController,
                      style:
                          TextStyle(fontSize: AppDimension.height(25, context)),
                      decoration: InputDecoration(
                        labelText: 'Full Name',
                      ),
                    ),
                    TextField(
                      controller: emailEditingController,
                      style:
                          TextStyle(fontSize: AppDimension.height(25, context)),
                      decoration: InputDecoration(
                        labelText: 'Email',
                      ),
                    ),
                    SizedBox(
                      height: AppDimension.height(10, context),
                    ),
                    TextField(
                      controller: passwordController,
                      style:
                          TextStyle(fontSize: AppDimension.height(25, context)),
                      obscureText: _obscure_text,
                      decoration: InputDecoration(
                          labelText: 'Password',
                          suffixIcon: TextButton(
                            onPressed: () {
                              setState(() {
                                _obscure_text = !_obscure_text;
                              });
                            },
                            child: Text(
                              _obscure_text ? "Show" : "Hide",
                              style: TextStyle(
                                  color: Colors.blue,
                                  fontSize: AppDimension.height(20, context)),
                            ),
                          )),
                    ),
                    TextField(
                      controller: expertiseController,
                      style:
                          TextStyle(fontSize: AppDimension.height(25, context)),
                      decoration: InputDecoration(
                        labelText: 'Expertise',
                      ),
                    ),
                    SizedBox(
                      height: AppDimension.height(35, context),
                    ),
                    Container(
                      height: AppDimension.height(100, context),
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(
                            AppDimension.height(10, context)),
                        color: Colors.white,
                        border: Border.all(color: Colors.grey),
                      ),
                      child: Padding(
                        padding: EdgeInsets.symmetric(horizontal: 20),
                        child: TextFormField(
                          controller: descriptionController,
                          key: Key('descriptionField'),
                          validator: (value) {
                            if (value == null || value.isEmpty) {
                              return 'Please enter a Description';
                            }
                            return null;
                          },
                          style: TextStyle(
                              fontSize: AppDimension.height(20, context)),
                          decoration: InputDecoration(
                            labelText: 'Bio',
                            border: InputBorder.none,
                          ),
                          maxLines: 3,
                        ),
                      ),
                    ),
                    SizedBox(
                      height: AppDimension.height(60, context),
                    ),
                    Container(
                        height: AppDimension.height(60, context),
                        width: double.infinity,
                        child: ElevatedButton(
                            style: ElevatedButton.styleFrom(
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(
                                      AppDimension.height(20,
                                          context)), // Set your desired border radius
                                ),
                                backgroundColor: Color(0XFF376AED)),
                            onPressed: () {
                              SignUpUserEnity signUpUserEntity =
                                  SignUpUserEnity(
                                      bio: descriptionController.text,
                                      fullName: fullnameController.text,
                                      password: passwordController.text,
                                      email: emailEditingController.text,
                                      expertise: expertiseController.text);

                              BlocProvider.of<SignUpBloc>(context).add(
                                  OnSignUpButtonPressedEvent(
                                      signUpUserEnity: signUpUserEntity));
                            },
                            child: Text(
                              "Sign Up",
                              style: TextStyle(
                                  fontSize: AppDimension.height(25, context)),
                            ))),
                    SizedBox(
                      height: AppDimension.height(10, context),
                    )
                  ],
                )),
                Container(
                  margin:
                      EdgeInsets.only(left: AppDimension.width(50, context)),
                  child: TextButton(
                      onPressed: () {},
                      child: Row(
                        children: [Text("Have an Account ? "), Text("Login")],
                      )),
                ),
                SizedBox(
                  height: AppDimension.height(30, context),
                )
              ],
            ),
          ),
        );
      }
    });
  }
}
