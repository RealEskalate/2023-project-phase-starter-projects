import 'package:blog_app/features/article/presentation/bloc/create_article_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/color/colors.dart';
import '../../../../core/util/image_sheet.dart';
import '../../../profile/presentation/widgets/loading_widget.dart';
import '../widgets/widgets.dart';

class WriteArticlePage extends StatelessWidget {
  WriteArticlePage({super.key});

  // final _formkey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    final bloc = context.read<CreateArticleBloc>();
    return BlocConsumer<CreateArticleBloc, CreateArticleState>(
      listener: (context, state) {
        if (state is CreateArticleResult) {
          context.push('/article', extra: state.article.id);
        }
      },
      builder: (context, state) {
        switch (state) {
          case CreateArticleResult():
            bloc.add(ResetCreate());
            return Container();
          case CreateArticleLoading():
            return Scaffold(
                body: LoadingWidget(message: "Creating article please wait"));
          case CreateArticleInitial():
            XFile? file;
            return ScreenUtilInit(
                designSize: const Size(428, 926),
                builder: (BuildContext context, child) {
                  return Scaffold(
                    backgroundColor: whiteColor,
                    appBar: AppBar(
                      backgroundColor: whiteColor,
                      elevation: 0,
                      leading: BackButton(
                        color: darkBlue,
                        onPressed: () => context.pop(),
                      ),
                    ),
                    body: Padding(
                      padding: EdgeInsets.symmetric(horizontal: 45.w),
                      child: SingleChildScrollView(
                        child: SafeArea(
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              CustomTextField(
                                hint: "Add title",
                                controller: state.title,
                              ),
                              CustomTextField(
                                hint: "Add subtitle",
                                controller: state.subTitle,
                              ),
                              AddTagsContainer(),
                              SizedBox(height: 4.39.h),
                              SizedBox(height: 49.h),
                              ArticleContentTextField(
                                  controller: state.content),
                              SizedBox(height: 40.h),
                              Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                children: [
                                  Text("Upload Image",
                                      style: GoogleFonts.poppins(
                                          fontSize: 16.sp,
                                          fontWeight: FontWeight.w500,
                                          color: darkBlue)),
                                  GestureDetector(
                                    onTap: () async {
                                      file = await ImageSheet().show(context);
                                    },
                                    child: Icon(
                                      Icons.camera_alt_outlined,
                                      color: blue,
                                    ),
                                  )
                                ],
                              ),
                              SizedBox(
                                height: 5.h,
                              ),
                              Container(
                                child: TextField(
                                  controller: state.photoImage,
                                  decoration: InputDecoration(
                                      hintText: file != null
                                          ? file?.path.toString()
                                          : "No Image is selected"),
                                ),
                              ),
                              FormSubmitButton(
                                onSumbit: () {
                                  bloc.add(SendData(
                                    title: state.title.text,
                                    subTitle: state.subTitle.text,
                                    content: state.content.text,
                                    postImage: file!,
                                    tags: ["art"],
                                  ));
                                },
                              ),
                            ],
                          ),
                        ),
                      ),
                    ),
                  );
                });
          default:
            return Scaffold(
              body: Center(
                child: Text("Unimplemted state from WriteArticlePage $state"),
              ),
            );
        }
      },
    );
  }
}
