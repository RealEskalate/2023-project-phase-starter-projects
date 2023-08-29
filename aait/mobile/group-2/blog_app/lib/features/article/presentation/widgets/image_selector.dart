import 'dart:io';

import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class ImageSelector extends StatefulWidget {
  final void Function(XFile?)? onImageSelected;
  final XFile? image;

  const ImageSelector({super.key, this.onImageSelected, this.image});

  @override
  State<ImageSelector> createState() => _ImageSelectorState();
}

class _ImageSelectorState extends State<ImageSelector> {
  XFile? image;

  @override
  void initState() {
    setState(() {
      image = widget.image;
    });
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: _selectImage,
      child: image == null ? _showSelector() : Image.file(File(image!.path)),
    );
  }

  Widget _showSelector() {
    return Container(
      width: double.infinity,
      height: 80.h,
      decoration: BoxDecoration(
        border: Border.all(color: AppColors.gray200),
        borderRadius: BorderRadius.circular(11),
      ),
      child: const Center(
        child: Text('Add image'),
      ),
    );
  }

  void _selectImage() async {
    final picker = ImagePicker();

    final pickedFile = await picker.pickImage(source: ImageSource.gallery);

    setState(() {
      image = pickedFile;
      widget.onImageSelected?.call(pickedFile);
    });
  }
}
