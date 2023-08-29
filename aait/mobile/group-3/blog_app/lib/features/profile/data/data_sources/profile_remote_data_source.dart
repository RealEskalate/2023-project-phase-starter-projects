import 'dart:convert';
import 'dart:io';

import 'package:blog_app/core/error/exception.dart';
import 'package:blog_app/features/profile/data/models/profile_model.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:http/http.dart' as http;
import 'package:http_parser/http_parser.dart';
import 'package:mime/mime.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:image_picker/image_picker.dart';

abstract class ProfileRemoteDataSource {
  Future<Profile> getProfile();
  Future<Profile> updateProfilePicture(XFile photoFile);
}

class ProfileRemoteDataSourceImpl implements ProfileRemoteDataSource {
  // final token =
  //     "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0ZTg0ZDg3YWMyNDQ1NjZjNzcyNjA1MCIsImlhdCI6MTY5Mjk3MjAzMiwiZXhwIjoxNjk1NTY0MDMyfQ.SgdYuy3wvMEsDFhL_vs-e77s2D7txtMGUw5ew2hD-jI";
  final http.Client client;
  final String url = 'https://blog-api-4z3m.onrender.com/api/v1/user';
  ProfileRemoteDataSourceImpl({required this.client});
  @override
  Future<Profile> getProfile() async {
    final token =await getStoredToken();
    final result = await client
        .get(Uri.parse(url), headers: {"Authorization": "Bearer $token"});
    if (result.statusCode == 200) {
      final jsonResponse = jsonDecode(result.body);
      final ProfileModel profile = ProfileModel.fromJson(jsonResponse);
      return profile;
    } else {
      throw ServerException(
        statusCode: 400,
        message: "Could not connect to the internet",
      );
    }
  }

  @override
  Future<Profile> updateProfilePicture(XFile photoXFile) async {
    final token = await getStoredToken();
    final photoFile = File(photoXFile.path);
    final String updateUrl = url + '/update/image';
    final String mimeType = lookupMimeType(photoFile.path)!;

    var request = http.MultipartRequest('PUT', Uri.parse(updateUrl));
    request.headers['Authorization'] = 'Bearer $token';
    request.headers['Content-Type'] = 'multipart/form-data';

    request.files.add(
      await http.MultipartFile.fromBytes(
        'photo',
        photoFile.readAsBytesSync(),
        filename: photoFile.path,
        contentType: MediaType.parse(mimeType),
      ),
    );
    final response = await request.send();
    if (response.statusCode == 200) {
      final http.Response result = await http.Response.fromStream(response);
      final jsonResponse = jsonDecode(result.body);
      final profile = await getProfile();
      final updatedProfile =
          profile.copyWith(imageName: jsonResponse["data"]["image"]);
      return updatedProfile;
    } else {
      final result = await http.Response.fromStream(response);
      print(result.body);
      print(response.statusCode);
      throw ServerException(
        statusCode: 400,
        message: "Could not successfully upadte profile picture",
      );
    }
  }

  Future<String> getStoredToken() async {
    final SharedPreferences pref = await SharedPreferences.getInstance();
    final String token = pref.getString('token')!;
    return token;
  }
}
