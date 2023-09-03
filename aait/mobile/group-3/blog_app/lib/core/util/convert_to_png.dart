import 'dart:io';
import 'package:image/image.dart';

File convertToPng(File img) {
  const String filepath = "assets\\images\\myimg.png";
  final decodedImg = decodeImage(img.readAsBytesSync());
  final imgFile = File(filepath);
  imgFile.writeAsBytesSync(encodePng(decodedImg!));
  return imgFile;
}
