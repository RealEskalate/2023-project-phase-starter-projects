import 'dart:convert';

import 'package:http/http.dart' as http;

class RemoteDataSource {
  final String baseUrl;

  RemoteDataSource(this.baseUrl);

  Future<Map<String, dynamic>> fetchData(String endpoint) async {
    final response = await http.get(Uri.parse('$baseUrl/$endpoint'));
    if (response.statusCode == 200) {
      return json.decode(response.body);
    } else {
      throw Exception('Failed to load data');
    }
  }
}
