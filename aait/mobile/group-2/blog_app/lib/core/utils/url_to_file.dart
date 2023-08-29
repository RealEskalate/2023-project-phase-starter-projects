import 'dart:io';
import 'dart:math';

import 'package:dartz/dartz.dart';
import 'package:http/http.dart' as http;
import 'package:path_provider/path_provider.dart';

import '../error/failure.dart';

Future<Either<Failure, File>> urlToFile(String imageUrl) async {
  try {
    final rng = Random();

    Directory tempDir = await getTemporaryDirectory();

    String tempPath = tempDir.path;

    File file = File('$tempPath${rng.nextInt(100)}');

    http.Response response = await http.get(Uri.parse(imageUrl));

    await file.writeAsBytes(response.bodyBytes);

    return Right(file);
  } catch (e) {
    return Left(ServerFailure());
  }
}
