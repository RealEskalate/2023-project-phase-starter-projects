import 'dart:convert';
import 'dart:io';
import 'package:http_parser/http_parser.dart';

import 'package:blog_app/core/utils/constants.dart';
import 'package:blog_app/features/user_profile/data/models/user_model.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';
import 'package:mime/mime.dart';

import '../../domain/entities/user_entity.dart';

abstract class ProfileRemoteDataSource {
  Future<User> getUserInfo();
  Future<User> updateUserImage(User user);
}

class ProfileRemoteDataSourceImpl extends ProfileRemoteDataSource {
  @override
  Future<UserModel> getUserInfo() async {
    final String? token = await getToken();

    final response = await http.get(Uri.parse('$baseApi/user'),
        headers: {"Authorization": "Bearer $token"});

    final data = jsonDecode(response.body)["data"];

    final user = UserModel.fromJson(data);

    return user;
  }

  @override
  Future<User> updateUserImage(User user) async {
    var uri = Uri.parse('$baseApi/user/update/image');

    var request = http.MultipartRequest('PUT', uri);

    final String? token = await getToken();

    // Create a map for the headers
    Map<String, String> headers = {
      HttpHeaders.authorizationHeader:
          'Bearer $token', // Add your authentication token here
    };

    // Attach the headers to the request
    request.headers.addAll(headers);

    // Replace this with the actual path to your image file
    File imageFile = File(user.image!);
    final String fileType = MimeTypeResolver().lookup(imageFile.path) ?? "";

    // Attach the image file to the request
    request.files.add(http.MultipartFile(
        'photo', imageFile.readAsBytes().asStream(), imageFile.lengthSync(),
        filename: imageFile.path.split("/").last,
        contentType: MediaType.parse(fileType)));

    // Send the request and get the response
    var response = await request.send();

    if (response.statusCode == 200) {
      return user;
    } else {}
    throw ("Couldn't Upload image ${response.statusCode}");
  }

  Future<String?> getToken() async {
    final prefs = await SharedPreferences.getInstance();
    return prefs.getString('token');
  }
}
