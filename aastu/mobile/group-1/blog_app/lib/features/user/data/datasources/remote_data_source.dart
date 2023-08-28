import 'dart:convert';
import 'dart:developer';
import 'package:blog_app/features/user/data/datasources/data_source_api.dart';
import 'package:blog_app/features/user/domain/entities/user.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart'; // Import SharedPreferences package

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

        // Check if the response has a 'token' key
        if (responseData.containsKey('token')) {
          final token = responseData['token'] as String;

          // Store token in SharedPreferences
          final prefs = await SharedPreferences.getInstance();
          prefs.setString('auth_token', token);

          log("token is saved: $token");
        }

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
  Future<User> getUser() async {
    final responseData = await _fetchUserData('user');
    try {
      final user = User.fromJson(responseData);

      return user;
    } catch (e) {
      log("Error fetching user: $e");
      throw Exception('An error occurred: $e');
    }
  }

  @override
  Future<void> updateProfilePhoto(
      String userId, String imageUrl, String imagePublicId) async {
    await _fetchData('user/$userId/update-profile-photo', {
      'imageUrl': imageUrl,
      'imageCloudinaryPublicId': imagePublicId,
    });
  }

  Future<String?> fetchAuthToken() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    String? authToken = prefs.getString('auth_token');
    return authToken;
  }

  Future<Map<String, dynamic>> _fetchUserData(String endpoint) async {
    log("User fetching: $baseUrl/$endpoint");
    String? authToken = await fetchAuthToken();

    try {
      final response = await http.get(
        Uri.parse('$baseUrl/$endpoint'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $authToken', // Add the token to the headers
        },
      );

      final responseData = json.decode(response.body) as Map<String, dynamic>;

      if (response.statusCode == 200 && responseData['success'] == true) {
        log("User fetched: $responseData");
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
}
