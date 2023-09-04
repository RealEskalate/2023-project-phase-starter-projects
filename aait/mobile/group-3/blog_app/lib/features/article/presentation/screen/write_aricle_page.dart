import 'dart:io';

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:image_picker/image_picker.dart';
import 'package:top_snackbar_flutter/custom_snack_bar.dart';
import 'package:top_snackbar_flutter/top_snack_bar.dart';

import '../../../../core/color/colors.dart';
import '../../../../core/util/image_sheet.dart';
import '../../../article/presentation/widgets/loading_widget.dart';
import '../bloc/create_article_bloc.dart';
import '../widgets/widgets.dart';

class WriteArticlePage extends StatefulWidget {
  const WriteArticlePage({super.key});

  @override
  State<WriteArticlePage> createState() => _WriteArticlePageState();
}

class _WriteArticlePageState extends State<WriteArticlePage> {
  List<String> selectedTags = [];
  File? selectedFile;
  XFile? file;
  void updateSelectedTags(List<String> tagsSelected) {
    setState(() {
      selectedTags = tagsSelected;
    });
  }

  void updateImageStatus(img) {
    setState(() {
      this.selectedFile = img;
    });
  }

  @override
  Widget build(BuildContext context) {
    final bloc = context.read<CreateArticleBloc>();
    return BlocConsumer<CreateArticleBloc, CreateArticleState>(
      listener: (context, state) {
        if (state is CreateArticleResult) {
          showTopSnackBar(
              Overlay.of(context),
              const CustomSnackBar.success(
                  message: "Article Created Successfully"));
          context.push('/article', extra: state.article.id);
        } else if (state is CreateArticleError) {
          showTopSnackBar(
              Overlay.of(context),
              const CustomSnackBar.error(
                  message: "Oops unable to create the article"));
          context.pop();
        }
      },
      builder: (context, state) {
        switch (state) {
          case CreateArticleResult():
            bloc.add(ResetCreate());
            return SizedBox.shrink();
          case CreateArticleInitial():
            bloc.add(GetAllTags());
            return const Scaffold(
              body: LoadingWidget(message: "featching tags.."),
            );
          case CreateArticleLoading():
            return const Scaffold(
                body: LoadingWidget(message: "Creating article please wait"));
          case GetAllTagsLoading():
            return const Scaffold(
                body: LoadingWidget(message: "Featching Tags please wait"));
          case AllTagsLoaded():
            // File? selectedFile;
            final List<String> selectedTags = [];
            return ScreenUtilInit(
                designSize: const Size(428, 926),
                builder: (BuildContext context, child) {
                  return Scaffold(
                      backgroundColor: whiteColor,
                      appBar: AppBar(
                        title: Text(
                          "Create Article",
                          style: TextStyle(
                              fontSize: 24.sp,
                              fontWeight: FontWeight.w500,
                              color: darkBlue),
                        ),
                        centerTitle: true,
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
                                AddTagsContainer(
                                  availableTags: state.tags,
                                  selectedTags: selectedTags,
                                  onlTagsSelected: updateSelectedTags,
                                ),
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
                                        this.file =
                                            await ImageSheet().show(context);
                                        if (file != null) {
                                          setState(() {
                                            updateImageStatus(File(file!.path));
                                          });
                                        }
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
                                this.selectedFile != null
                                    ? Image.file(
                                        File(
                                          selectedFile!.path,
                                        ),
                                        width:
                                            100, // Adjust the width as needed
                                        height:
                                            100, // Adjust the height as needed
                                        fit: BoxFit
                                            .cover, // You can use different BoxFit options
                                      )
                                    : Text("Please select image"),
                                SizedBox(
                                  height: 5.h,
                                ),
                                FormSubmitButton(
                                  onSumbit: () {
                                    bloc.add(SendData(
                                      title: state.title.text,
                                      subTitle: state.subTitle.text,
                                      content: state.content.text,
                                      postImage: this.file!,
                                      tags: selectedTags,
                                    ));
                                  },
                                ),
                                SizedBox(
                                  height: 5.h,
                                ),
                              ],
                            ),
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
                });
          default:
            return Scaffold(
                body: Center(
                  child: Text("Unimplemted state from WriteArticlePage $state"),
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
        }
      },
    );
  }
}
