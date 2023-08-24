import 'package:http/http.dart' as http;

import '../constants/constants.dart';

typedef KeyValue = Map<String, dynamic>;
typedef Headers = Map<String, String>;

class CustomClient {
  static String baseUrl = apiBaseUrl;

  final http.Client client;
  String? _authToken;

  CustomClient(this.client);

  set authToken(String? value) {
    _authToken = value;
  }

  Future<http.Response> get(String url, {Headers headers = const {}}) async {
    Headers headersWithAuth = {
      ...headers,
      if (_authToken != null) 'Authorization': 'Bearer $_authToken'
    };

    return client.get(Uri.parse(apiBaseUrl + url), headers: headersWithAuth);
  }

  Future<http.Response> post(String url,
      {required KeyValue body, Headers headers = const {}}) async {
    Headers headersWithAuth = {
      ...headers,
      if (_authToken != null) 'Authorization': 'Bearer $_authToken'
    };

    return client.post(Uri.parse(apiBaseUrl + url),
        body: body, headers: headersWithAuth);
  }

  Future<http.Response> put(String url,
      {required KeyValue body, Headers headers = const {}}) async {
    Headers headersWithAuth = {
      ...headers,
      if (_authToken != null) 'Authorization': 'Bearer $_authToken'
    };
    return client.put(Uri.parse(apiBaseUrl + url),
        body: body, headers: headersWithAuth);
  }

  Future<http.Response> delete(String url,
      {Headers headers = const {}}) async {
    Headers headersWithAuth = {
      ...headers,
      if (_authToken != null) 'Authorization': 'Bearer $_authToken'
    };
    return client.delete(Uri.parse(apiBaseUrl + url), headers: headersWithAuth);
  }
}
