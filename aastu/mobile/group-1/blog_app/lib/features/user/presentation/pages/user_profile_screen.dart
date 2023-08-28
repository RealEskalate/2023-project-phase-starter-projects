import 'dart:developer';

import 'package:blog_app/features/user/domain/usecases/get_user.dart';
import 'package:blog_app/features/user/domain/usecases/login_user.dart';
import 'package:blog_app/features/user/domain/usecases/register_user.dart';
import 'package:blog_app/features/user/domain/usecases/update_user.dart';
import 'package:blog_app/features/user/presentation/blocs/bloc.dart';
import 'package:blog_app/features/user/presentation/blocs/bloc_state.dart';
import 'package:blog_app/features/user/presentation/blocs/get_user.dart/user_event.dart';
import 'package:blog_app/features/user/presentation/blocs/get_user.dart/user_state.dart';
import 'package:blog_app/features/user/presentation/widgets/about_me.dart';
import 'package:blog_app/features/user/presentation/widgets/header.dart';
import 'package:blog_app/features/user/presentation/widgets/my_activities.dart';
import 'package:blog_app/injection.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class UserProfileScreen extends StatefulWidget {
  const UserProfileScreen({super.key});

  @override
  State<UserProfileScreen> createState() => _UserProfileScreenState();
}

class _UserProfileScreenState extends State<UserProfileScreen> {
  late String selectedActivity = 'Posts';
  late int selectedIndex = 0; // Initially selected index

  void updateSelectedActivity(String newActivity) {
    setState(() {
      selectedActivity = newActivity;
    });
  }

  @override
  void initState() {
    super.initState();
    context.read<UserBloc>().add(const GetUserEvent());
  }

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => UserBloc(
          getUser: sl<GetUserUseCase>(),
          loginUser: sl<LoginUserUseCase>(),
          registerUser: sl<RegisterUserUseCase>(),
          updateProfilePhoto: sl<UpdateProfilePhotoUseCase>()),
      child: BlocConsumer<UserBloc, UserState>(
        listener: (context, state) {
          if (state is LoadedGetUserState) {
            log("User name is ----- " + state.user.fullName!);

            Text("User is Fetched on Bloc${state.user.fullName!}");
          }
          // loading state
          else if (state is UserLoading) {
            log("Loading Displaying User");
          } else if (state is UserError) {
            // Handle error if login fails
            log("Eror Displaying User");
          } else if (state is UserInitial) {
            context.read<UserBloc>().add(const GetUserEvent());
          } else {
            log("Error" + state.toString());
          }
        },
        builder: (context, state) {
          return buildBody(context);
        },
      ),
    );
  }
}

Widget buildBody(BuildContext context) {
  return RefreshIndicator(
      onRefresh: () async {
        context.read<UserBloc>().add(const GetUserEvent());
      },
      child: Container(
        color: const Color.fromARGB(255, 255, 255, 255),
        child: MaterialApp(
          title: 'Profile',
          home: Scaffold(
            backgroundColor: const Color.fromARGB(255, 255, 255, 255),
            appBar: header(),
            body: const Column(
              children: [
                // Padding(
                //   padding: const EdgeInsets.all(8.0),
                //   child: Aboutme(onActivitySelected: updateSelectedActivity),
                // ),
                // Expanded(
                //   child: MyActivity(activity: selectedActivity),
                // ),
              ],
            ),
          ),
        ),
      ));
}
