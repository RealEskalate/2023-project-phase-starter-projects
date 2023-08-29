class ArticleRequest {
  String? queryString;
  List tags;
  ArticleRequest({this.queryString = "", this.tags = const []});

  Map<String, dynamic> toJson() {
    return {
      "tags": this.tags,
      "searchParams": this.queryString
    };
  }
}
