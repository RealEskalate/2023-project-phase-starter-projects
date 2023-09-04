import 'package:blog_app/core/util/image_sheet.dart';
import 'package:blog_app/features/profile/presentation/bloc/profile_bloc.dart';
import 'package:blog_app/features/profile/presentation/widgets/loading_widget.dart';
import 'package:blog_app/injection_container.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../widgets/feed_content.dart';
import '../widgets/post_content.dart';
import '../widgets/profile_content.dart';
import '../widgets/row_button.dart';
import '../widgets/title_bar.dart';

class ProfileScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return BlocProvider<ProfileBloc>(
      create: (_) => serviceLocator<ProfileBloc>(),
      child: BlocConsumer<ProfileBloc, ProfileState>(
        builder: (context, state) {
          switch (state) {
            case ProfileInitial():
              BlocProvider.of<ProfileBloc>(context).add(GetData());
              return Scaffold(
                  body: LoadingWidget(
                message: state.message,
              ));
            case ProfileLoading():
              return Scaffold(
                body: LoadingWidget(message: state.message),
              );
            case ProfileLoaded():
              return Scaffold(
                  body: SingleChildScrollView(
                    child: SafeArea(
                      child: Column(
                        children: [
                          TitleBar(),
                          SizedBox(
                            height: 25.h,
                          ),
                          Stack(children: [
                            ProfileContent(
                              profile: state.profile,
                              onChangeImage: () async {
                                final file = await ImageSheet().show(context);
                                BlocProvider.of<ProfileBloc>(context)
                                    .add(UpdatePicture(imageFile: file));
                              },
                            ),
                            Column(children: [
                              SizedBox(
                                height: 52.h,
                              ),
                              Container(
                                alignment: Alignment.center,
                                child: RowButton(),
                              )
                            ]),
                          ]),
                          SizedBox(
                            height: 32.h,
                          ),
                          FeedContent(innerContent: PostContent()),
                        ],
                      ),
                    ),
                  ),
                  floatingActionButton: FloatingActionButton.extended(
                    onPressed: () {
                      context.push('/home');
                    },
                    label: Icon(
                      Icons.home,
                      size: 32.sp,
                    ),
                  ));
            default:
              return Scaffold(
                body: Center(
                  child: Text("Unimplemeted State error from ProfileScreen"),
                ),
                floatingActionButton: FloatingActionButton.extended(
                    onPressed: () {
                      context.push('/home');
                    },
                    label: Icon(
                      Icons.home,
                      size: 32.sp,
                    ),
                  )
              );
          }
        },
        listener: (context, state) {},
      ),
    );
  }
}
