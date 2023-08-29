import 'package:blog_app/core/util/image_converter.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:image_picker/image_picker.dart';

class ImageSheet {
  Future<XFile?> show(BuildContext context) async {
    return showModalBottomSheet<XFile?>(
        context: context,
        builder: (context) {
          return Container(
            padding: EdgeInsets.symmetric(horizontal: 20.w, vertical: 20.h),
            child: Column(
              children: [
                Text(
                  'Upload Picture',
                  style: TextStyle(fontSize: 18, fontWeight: FontWeight.w500),
                ),
                SizedBox(
                  height: 20.h,
                ),
                ListTile(
                  leading: Icon(Icons.camera_alt_outlined),
                  title: Text('Take a Photo'),
                  onTap: () async {
                    final chosenImage =
                        await ImageConverter().pickImageFromCamera();
                    Navigator.pop(context, chosenImage);
                  },
                ),
                ListTile(
                  leading: Icon(Icons.photo_library),
                  title: Text('Choose from gallery'),
                  onTap: () async {
                    final chosenImage =
                        await ImageConverter().pickImageFromGallery();
                    Navigator.pop(context, chosenImage);
                  },
                ),
                SizedBox(
                  height: 20.h,
                ),
                TextButton(
                  onPressed: () {
                    Navigator.pop(context);
                  },
                  child: Text('Cancel'),
                )
              ],
            ),
          );
        });
  }
}
