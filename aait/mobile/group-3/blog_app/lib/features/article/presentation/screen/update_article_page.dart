import 'package:blog_app/features/article/presentation/bloc/update_article_bloc.dart';
import 'package:blog_app/features/article/presentation/widgets/loading_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/color/colors.dart';
import '../../../../core/util/image_sheet.dart';
import '../widgets/widgets.dart';

class UpdateArticlePage extends StatefulWidget {
  final String articleId;
  const UpdateArticlePage({super.key, required this.articleId});

  @override
  State<UpdateArticlePage> createState() => _UpdateArticlePageState();
}

class _UpdateArticlePageState extends State<UpdateArticlePage> {
  @override
  Widget build(BuildContext context) {
    final bloc = context.read<UpdateArticleBloc>();
    return BlocConsumer<UpdateArticleBloc, UpdateArticleState>(
      listener: (context, state) {
        if (state is UpdateArticleResult) {
          context.push('/article', extra: state.article.id);
        }
      },
      builder: (context, state) {
        switch (state) {
          case UpdateArticleInitial():
            bloc.add(GetArticleData(id: widget.articleId));
            return Scaffold(
              body: LoadingWidget(message: "Fetching Article..."),
            );
          case UpdateArticleLoading():
            return Scaffold(
              body: LoadingWidget(message: "Updating article please wait"),
            );

          case UpdateArticleResult():
            bloc.add(ResetUpdateField(id: state.article.id));
            return SizedBox();

          case UpdateArticleLoaded():
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
                                hint: "add subtitle",
                                controller: state.subTitle,
                              ),
                              AddTagsContainer(),
                              SizedBox(height: 4.39.h),
                              SizedBox(height: 49.h),
                              ArticleContentTextField(
                                controller: state.content,
                              ),
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
                                    onTap: () {
                                      setState(() async {
                                        file = await ImageSheet().show(context);
                                      });
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
                                  controller:
                                      TextEditingController(text: file?.path),
                                  decoration: InputDecoration(
                                      hintText: file != null
                                          ? file?.path
                                          : "No Image is selected"),
                                ),
                              ),
                              FormSubmitButton(
                                onSumbit: () {
                                  bloc.add(UpdateData(
                                    id: state.articleId,
                                    title: state.title.text,
                                    subTitle: state.subTitle.text,
                                    content: state.content.text,
                                    postImage: file!,
                                    tags: ["art"],
                                  ));
                                },
                              )
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
                child: Text(
                  "Unimplemented state error from update article page $state",
                ),
              ),
            );
        }
      },
    );
  }
}
