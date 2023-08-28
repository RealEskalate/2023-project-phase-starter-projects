import 'package:blog_app/features/user/presentation/widgets/post_list.dart';
import 'package:blog_app/features/user/presentation/widgets/post_list_grid.dart';
import 'package:flutter/material.dart';

Widget blogListView(bool showGridView) {
  //         BlocProvider(
  //   create: (context) => UserBloc(
  //       getUser: sl<GetUserUseCase>(),
  //       loginUser: sl<LoginUserUseCase>(),
  //       registerUser: sl<RegisterUserUseCase>(),
  //       updateProfilePhoto: sl<UpdateProfilePhotoUseCase>()),
  //   child: BlocBuilder<UserBloc, UserState>(
  //     builder: (context, state) {
  //       if (state is LoadedGetUserState) {
  //         log("User is fetched on User Profile Page");

  //         return
  //       // loading state
  //       else if (state is UserLoading) {
  //         log("Loading Displaying User");
  //         return Container(
  //             color: Colors.white,
  //             child: const Center(
  //               child: CircularProgressIndicator(),
  //             ));
  //       } else if (state is UserError) {
  //         // Handle error if login fails
  //         log("Eror Displaying User");
  //         return const Center(
  //           child: Text("Error"),
  //         );
  //       } else if (state is UserInitial) {
  //         context.read<UserBloc>().add(const GetUserEvent());
  //         return const Center(
  //           child: CircularProgressIndicator(),
  //         );
  //       } else {
  //         log("Error $state");
  //         return Center(
  //           child: Text("Error $state"),
  //         );
  //       }
  //     },
  //   ),
  // );
  return showGridView
      ? GridView.builder(
          gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
            crossAxisCount: 2,
          ),
          itemCount: grid_blogs.length,
          itemBuilder: (context, index) {
            return BlogGridCards(index: index, object: grid_blogs[index]);
          },
        )
      : ListView.builder(
          itemCount: blogs.length,
          itemBuilder: (context, index) {
            return BlogCards(index: index, object: blogs[index]);
          },
        );
}
