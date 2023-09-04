import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:http_parser/http_parser.dart';

import '../../../../core/constants/constants.dart';
import '../../../../core/error/exception.dart';
import '../../domain/entities/user_data.dart';
import '../models/user_data_model.dart';
import 'user_remote_data_source.dart';

class UserRemoteDataSourceImpl implements UserRemoteDataSource {
  final http.Client client;

  UserRemoteDataSourceImpl({required this.client});

  @override
  Future<UserData> getUserData(String token) async {
    final http.Response response =
        await client.get(Uri.parse('${apiBaseUrl}user'), headers: {
      'Authorization': 'Bearer $token',
    });

    if (response.statusCode == 200) {
      try {
        return UserDataModel.fromJson(jsonDecode(response.body)['data']);
      } catch (e) {
        throw const ServerException();
      }
    } else {
      throw const ServerException();
    }
  }

  @override
  Future<UserData> updateUserPhoto(String token, String imagePath) async {
    final Map<String, String> headers = {
      'Authorization': 'Bearer $token',
    };

    final request = http.MultipartRequest(
        'PUT', Uri.parse('${apiBaseUrl}user/update/image'));
    request.headers.addAll(headers);

    print(Uri.parse('${apiBaseUrl}user/update/image'));
    // final imageBytes = await File(imagePath).readAsBytes();

    request.files.add(
      await http.MultipartFile.fromPath(
        'photo',
        imagePath,
        contentType: MediaType('image', 'jpeg'),
      ),
    );

    try {
      final response = await request.send();

      if (response.statusCode == 200) {
        final responseString = await response.stream.bytesToString();

        return UserDataModel.fromJson(json.decode(responseString)['data']);
      } else {
        throw const ServerException();
      }
    } catch (e) {
      throw const ServerException();
    }
  }
}
