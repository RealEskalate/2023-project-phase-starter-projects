import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../domain/entities/tag.dart';
import '../bloc/tag_selector_bloc.dart';
import 'custom_text_field.dart';

// ignore: must_be_immutable
class TagSelector extends StatelessWidget {
  final List<Tag> tags;

  TextEditingController? controller;
  FocusNode? textFieldFocusNode;

  TagSelector({super.key, required this.tags});

  @override
  Widget build(BuildContext context) {
    return Autocomplete<Tag>(
        optionsBuilder: (textEditingValue) {
          final options = tags
              .where((Tag tag) => tag.name
                  .toLowerCase()
                  .startsWith(textEditingValue.text.toLowerCase()))
              .toList();

          return options;
        },

        //
        displayStringForOption: (Tag option) => option.name,

        // on option select
        onSelected: (tag) {
          context.read<TagSelectorBloc>().add(AddTagEvent(tag));
          controller?.text = '';
          textFieldFocusNode?.unfocus();
        },

        //
        optionsViewBuilder: (context, onSelected, options) {
          return Align(
            alignment: Alignment.topLeft,
            child: Material(
              child: Container(
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  color: Theme.of(context).colorScheme.surface,
                ),
                constraints: BoxConstraints(
                  maxHeight: 200.h,
                  maxWidth: 320.w,
                ),
                child: ListView.builder(
                  padding: const EdgeInsets.all(10.0),
                  shrinkWrap: true,
                  itemCount: options.length,
                  itemBuilder: (context, index) {
                    final option = options.elementAt(index);

                    return GestureDetector(
                      onTap: () {
                        onSelected(option);
                      },
                      child: ListTile(
                        hoverColor: AppColors.gray400,
                        title: Text(option.name,
                            style: Theme.of(context).textTheme.bodyMedium),
                      ),
                    );
                  },
                ),
              ),
            ),
          );
        },
        fieldViewBuilder:
            (context, textEditingController, focusNode, onFieldSubmitted) {
          controller = textEditingController;
          textFieldFocusNode = focusNode;

          return CustomTextField(
            controller: textEditingController,
            focusNode: focusNode,
            hintText: 'Add tags',
          );
        });
  }
}
