import 'dart:io';

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_cache_manager/flutter_cache_manager.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:image_picker/image_picker.dart';
import 'package:top_snackbar_flutter/custom_snack_bar.dart';
import 'package:top_snackbar_flutter/top_snack_bar.dart';

import '../../../../core/color/colors.dart';
import '../../../../core/util/image_sheet.dart';
import '../../../../injection_container.dart';
import '../bloc/update_article_bloc.dart';
import '../widgets/loading_widget.dart';
import '../widgets/widgets.dart';

class UpdateArticlePage extends StatefulWidget {
  final String articleId;
  const UpdateArticlePage({super.key, required this.articleId});

  @override
  State<UpdateArticlePage> createState() => _UpdateArticlePageState();
}

class _UpdateArticlePageState extends State<UpdateArticlePage> {
  late UpdateArticleBloc
      bloc; // Declare a late variable to hold the bloc instance

  @override
  void initState() {
    super.initState();
    bloc = context.read<UpdateArticleBloc>(); // Initialize the bloc
  }

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
    return BlocProvider(
      create: (_) => serviceLocator<UpdateArticleBloc>(),
      child: BlocConsumer<UpdateArticleBloc, UpdateArticleState>(
        listener: (context, state) {
          if (state is UpdateArticleResult) {
            showTopSnackBar(
                Overlay.of(context),
                const CustomSnackBar.success(
                    message: "Article Updated successfully"));
            context.push('/article', extra: state.article.id);
          } else if (state is UpdateArticleError) {
            showTopSnackBar(
                Overlay.of(context),
                const CustomSnackBar.error(
                    message: "Oops unable to update the article"));
            context.push('/home');
          }
        },
        builder: (context, state) {
          switch (state) {
            case UpdateArticleInitial():
              BlocProvider.of<UpdateArticleBloc>(context)
                  .add(GetArticleData(id: widget.articleId));

              return const Scaffold(
                body: LoadingWidget(message: "Fetching Article..."),
              );
            case UpdateArticleLoading():
              return const Scaffold(
                body: LoadingWidget(message: "Updating article please wait"),
              );
            case UpdateArticleResult():
              context.push('/article', extra: state.article.id);
              return const SizedBox.shrink();
            case UpdateArticleLoaded():
              return ScreenUtilInit(
                  designSize: const Size(428, 926),
                  builder: (BuildContext context, child) {
                    return Scaffold(
                        backgroundColor: whiteColor,
                        appBar: AppBar(
                          title: Text(
                            "Update Article",
                            style: TextStyle(
                              fontSize: 24.sp,
                              fontWeight: FontWeight.w500,
                              color: darkBlue,
                            ),
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
                                    hint: "add subtitle",
                                    controller: state.subTitle,
                                  ),
                                  AddTagsContainer(
                                    availableTags: state.availableTags,
                                    selectedTags: state.selectedTags,
                                    onlTagsSelected: updateSelectedTags,
                                  ),
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
                                        onTap: () async {
                                          this.file =
                                              await ImageSheet().show(context);
                                          if (file != null) {
                                            setState(() {
                                              updateImageStatus(
                                                  File(file!.path));
                                            });
                                          }
                                        },
                                        child: const Icon(
                                          Icons.camera_alt_outlined,
                                          color: blue,
                                        ),
                                      )
                                    ],
                                  ),
                                  SizedBox(
                                    height: 5.h,
                                  ),
                                  selectedFile != null
                                      ? Image.file(
                                          File(selectedFile!.path),
                                          height: 100,
                                          width: 100,
                                          fit: BoxFit.cover,
                                        )
                                      : Image.network(
                                          state.photoImage,
                                          height: 100,
                                          width: 100,
                                          fit: BoxFit.cover,
                                        ),
                                  FormSubmitButton(
                                    onSumbit: () async {
                                      final prevImage =
                                          await DefaultCacheManager()
                                              .getSingleFile(state.photoImage);

                                      BlocProvider.of<UpdateArticleBloc>(
                                              context)
                                          .add((UpdateData(
                                        id: state.articleId,
                                        title: state.title.text,
                                        subTitle: state.subTitle.text,
                                        content: state.content.text,
                                        postImage:
                                            this.file ?? XFile(prevImage.path),
                                        tags: selectedTags,
                                      )));
                                      // await file.delete();
                                    },
                                  )
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
                  child: Text(
                    "Unimplemented state error from update article page $state",
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
                ),
              );
          }
        },
      ),
    );
  }
}
