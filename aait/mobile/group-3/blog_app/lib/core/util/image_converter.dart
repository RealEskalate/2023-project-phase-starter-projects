import 'package:image_picker/image_picker.dart';

class ImageConverter {
  Future<XFile?> pickImageFromGallery() async {
    final galleryImage =
        await ImagePicker().pickImage(source: ImageSource.gallery);
    return galleryImage;
  }

  Future<XFile?> pickImageFromCamera() async {
    final cameraImage =
        await ImagePicker().pickImage(source: ImageSource.camera);
    return cameraImage;
  }
}
