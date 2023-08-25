import 'dart:convert';
import 'dart:developer';
import 'package:blog_app/features/user/data/datasources/data_source_api.dart';
import 'package:http/http.dart' as http;

class UserApiDataSource implements UserRemoteDataSource {
  final String baseUrl;

  UserApiDataSource({required this.baseUrl});

  Future<Map<String, dynamic>> _fetchData(
      String endpoint, Map<String, dynamic> data) async {
    log("fetching: $baseUrl/$endpoint");
    try {
      log("My data: $data");
      final response = await http.post(
        Uri.parse('$baseUrl/$endpoint'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode(data),
      );

      final responseData = json.decode(response.body) as Map<String, dynamic>;

      if (response.statusCode == 200 && responseData['success'] == true) {
        log("fetched: $responseData");
        return responseData['data'];
      } else {
        log("error: $responseData");
        final errorMessage =
            responseData['message'] as String? ?? 'Unknown error';
        throw Exception(errorMessage);
      }
    } catch (e) {
      log("error:: $e");
      throw Exception('An error occurred: $e');
    }
  }

  @override
  Future<Map<String, dynamic>> registerUser(
      Map<String, dynamic> userData) async {
    return await _fetchData('user', userData);
  }

  @override
  Future<Map<String, dynamic>> loginUser(Map<String, dynamic> loginData) async {
    return await _fetchData('user/login', loginData);
  }

  @override
  Future<Map<String, dynamic>> getUser(String userId) async {
    return await _fetchData('user/$userId', {});
  }

  @override
  Future<void> updateProfilePhoto(
      String userId, String imageUrl, String imagePublicId) async {
    await _fetchData('user/$userId/update-profile-photo', {
      'imageUrl': imageUrl,
      'imageCloudinaryPublicId': imagePublicId,
    });
  }
}
