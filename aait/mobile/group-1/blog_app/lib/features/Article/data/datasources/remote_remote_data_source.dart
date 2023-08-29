import 'dart:convert';
import 'dart:io';

import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;
import '../../../../core/utils/constants.dart';
import '../models/article_model.dart';
import '../models/create_article_model.dart';
import 'package:http_parser/http_parser.dart';
import 'package:mime/mime.dart';

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> postArticle(CreateArticleModel articleModel);
  Future<ArticleModel> updateArticle(CreateArticleModel articleModel);
  Future<ArticleModel> getArticle(String id);
}

class ArticleRemoteDataSourceImpl extends ArticleRemoteDataSource {
  @override
  Future<ArticleModel> postArticle(CreateArticleModel articleModel) async {
    String? token = await getToken();
    final uri = Uri.parse('$baseApi/article');
    var request = http.MultipartRequest('POST', uri);

    Map<String, String> headers = {
      HttpHeaders.authorizationHeader:
          'Bearer $token', // Add your authentication token here
    };

    request.headers.addAll(headers);
    File imageFile = File(articleModel.image);
    final String fileType = MimeTypeResolver().lookup(imageFile.path) ?? "";

    request.files.add(http.MultipartFile(
        'photo', imageFile.readAsBytes().asStream(), imageFile.lengthSync(),
        filename: imageFile.path.split("/").last,
        contentType: MediaType.parse(fileType)));

    request.fields['title'] = articleModel.title;
    request.fields['subTitle'] = articleModel.subTitle;
    request.fields['tags'] = jsonEncode(articleModel.tags);
    request.fields['content'] = articleModel.content;
    request.fields['estimatedReadTime'] = articleModel.estimatedtime;

    var response = await request.send();

    if (response.statusCode == 200) {
      return articleModel as ArticleModel;
    }
    throw ("Couldn't Post Article ${response.statusCode}");
  }

  @override
  Future<ArticleModel> updateArticle(CreateArticleModel articleModel) async {
    String? token = await getToken();
    print("something wrong");
    if (articleModel.id == null) {
      throw ("Couldn't Post Article");
    }
    final id = articleModel.id;
    final uri = Uri.parse('$baseApi/article/$id');
    var request = http.MultipartRequest('PUT', uri);

    Map<String, String> headers = {
      HttpHeaders.authorizationHeader:
          'Bearer $token', // Add your authentication token here
    };

    request.headers.addAll(headers);
    File imageFile = File(articleModel.image);
    final String fileType = MimeTypeResolver().lookup(imageFile.path) ?? "";

    request.files.add(http.MultipartFile(
        'photo', imageFile.readAsBytes().asStream(), imageFile.lengthSync(),
        filename: imageFile.path.split("/").last,
        contentType: MediaType.parse(fileType)));

    request.fields['title'] = articleModel.title;
    request.fields['subTitle'] = articleModel.subTitle;
    request.fields['tags'] = jsonEncode(articleModel.tags);
    request.fields['content'] = articleModel.content;
    request.fields['estimatedReadTime'] = articleModel.estimatedtime;

    var response = await request.send();

    if (response.statusCode == 200) {
      return articleModel as ArticleModel;
    }
    throw ("Couldn't Post Article ${response.statusCode}");
  }

  @override
  Future<ArticleModel> getArticle(String id) async {
    final String? token = await getToken();
    final response = await http.get(Uri.parse('$baseApi/article/$id'),
        headers: {'Content-Type': 'application/json', "token": token!});

    return ArticleModel.fromJson(jsonDecode(response.body));
  }

  Future<String?> getToken() async {
    final prefs = await SharedPreferences.getInstance();
    return prefs.getString('token');
  }
}
