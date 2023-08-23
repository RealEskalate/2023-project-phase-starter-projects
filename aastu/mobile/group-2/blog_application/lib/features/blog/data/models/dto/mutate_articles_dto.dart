class MutateArticleResponse {
  bool? success;
  Date? date;

  MutateArticleResponse({this.success, this.date});

  MutateArticleResponse.fromJson(Map<String, dynamic> json) {
    success = json['success'];
    date = json['date'] != null ? new Date.fromJson(json['date']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['success'] = this.success;
    if (this.date != null) {
      data['date'] = this.date!.toJson();
    }
    return data;
  }
}

class Date {
  String? sId;
  List<String>? tags;
  String? content;
  String? title;
  String? subTitle;
  String? estimatedReadTime;
  String? user;
  String? image;
  String? imageCloudinaryPublicId;
  String? createdAt;
  int? iV;
  String? id;

  Date(
      {this.sId,
        this.tags,
        this.content,
        this.title,
        this.subTitle,
        this.estimatedReadTime,
        this.user,
        this.image,
        this.imageCloudinaryPublicId,
        this.createdAt,
        this.iV,
        this.id});

  Date.fromJson(Map<String, dynamic> json) {
    sId = json['_id'];
    tags = json['tags'].cast<String>();
    content = json['content'];
    title = json['title'];
    subTitle = json['subTitle'];
    estimatedReadTime = json['estimatedReadTime'];
    user = json['user'];
    image = json['image'];
    imageCloudinaryPublicId = json['imageCloudinaryPublicId'];
    createdAt = json['createdAt'];
    iV = json['__v'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['_id'] = this.sId;
    data['tags'] = this.tags;
    data['content'] = this.content;
    data['title'] = this.title;
    data['subTitle'] = this.subTitle;
    data['estimatedReadTime'] = this.estimatedReadTime;
    data['user'] = this.user;
    data['image'] = this.image;
    data['imageCloudinaryPublicId'] = this.imageCloudinaryPublicId;
    data['createdAt'] = this.createdAt;
    data['__v'] = this.iV;
    data['id'] = this.id;
    return data;
  }
}