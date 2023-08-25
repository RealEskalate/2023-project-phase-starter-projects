import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';
import '../../../../core/presentation/theme/app_colors.dart';
import '../widgets/custom_chip.dart';
import '../widgets/custom_text_field.dart';
import '../widgets/multiline_text_field.dart';

class ArticleFormScreen extends StatelessWidget {
  const ArticleFormScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.background,
        elevation: 0,
        title: Center(
          child: Text('New article',
              style: Theme.of(context).textTheme.titleMedium),
        ),
      ),

      //
      body: SingleChildScrollView(
        padding: EdgeInsets.symmetric(
          horizontal: 45.w,
          vertical: 45.h,
        ),
        child: Form(
          child: Column(
            children: [
              const CustomTextField(
                hintText: 'Add title',
              ),
              const SizedBox(height: 15),
              const CustomTextField(
                hintText: 'Add subtitle',
              ),
              const SizedBox(height: 15),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Row(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Flexible(
                        child: CustomTextField(
                          hintText: 'Add tags',
                        ),
                      ),
                      const SizedBox(width: 15),
                      GestureDetector(
                        onTap: () {},
                        child: const Icon(
                          Icons.add_circle_outline,
                          color: AppColors.blue,
                          size: 26,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 5),
                  const Text(
                    'add as many tags as you want',
                    style: TextStyle(
                      color: AppColors.gray300,
                      fontFamily: 'Poppins',
                      fontSize: 13,
                      fontWeight: FontWeight.w200,
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 15),
              const SizedBox(
                width: double.infinity,
                child: Wrap(
                  runSpacing: 10,
                  spacing: 10,
                  children: [
                    CustomChip(label: 'Art'),
                    CustomChip(label: 'Design'),
                    CustomChip(label: 'Culture'),
                    CustomChip(label: 'Production'),
                  ],
                ),
              ),
              const SizedBox(height: 30),
              const MultilineTextInput(
                hintText: 'Article content',
              ),
              const SizedBox(height: 50),
              Center(
                child: ElevatedButton(
                  onPressed: () => context.push(Routes.articleDetail),
                  child: const Text('Publish'),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
