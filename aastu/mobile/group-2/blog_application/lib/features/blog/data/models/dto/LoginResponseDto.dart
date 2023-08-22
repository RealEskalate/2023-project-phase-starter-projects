
class Data {
  Data({
    this.id,
    this.fullName,
    this.email,
    this.password,
    this.expertise,
    this.bio,
    this.createdAt,
    this.v,
    this.image,
    this.imageCloudinaryPublicId,
    this.id,});

  Data.fromJson(dynamic json) {
    id = json['_id'];
    fullName = json['fullName'];
    email = json['email'];
    password = json['password'];
    expertise = json['expertise'];
    bio = json['bio'];
    createdAt = json['createdAt'];
    v = json['__v'];
    image = json['image'];
    imageCloudinaryPublicId = json['imageCloudinaryPublicId'];
    id = json['id'];
  }
  String id;
  String fullName;
  String email;
  String password;
  String expertise;
  String bio;
  String createdAt;
  int v;
  String image;
  String imageCloudinaryPublicId;
  String id;

  Map<String, dynamic> toJson() {
    final map = <String, dynamic>{};
    map['_id'] = id;
    map['fullName'] = fullName;
    map['email'] = email;
    map['password'] = password;
    map['expertise'] = expertise;
    map['bio'] = bio;
    map['createdAt'] = createdAt;
    map['__v'] = v;
    map['image'] = image;
    map['imageCloudinaryPublicId'] = imageCloudinaryPublicId;
    map['id'] = id;
    return map;
  }

}
class LoginResponseDto {
  LoginResponseDto({
      this.success, 
      this.data, 
      this.token,});

  LoginResponseDto.fromJson(dynamic json) {
    success = json['success'];
    data = json['data'] != null ? Data.fromJson(json['data']) : null;
    token = json['token'];
  }
  bool success;
  Data data;
  String token;

  Map<String, dynamic> toJson() {
    final map = <String, dynamic>{};
    map['success'] = success;
    if (data != null) {
      map['data'] = data.toJson();
    }
    map['token'] = token;
    return map;
  }

}