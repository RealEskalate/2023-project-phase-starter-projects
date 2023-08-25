class User {
  String? fullName;
  String? email;
  String? password;
  String? expertise;
  String? bio;
  String? sId;
  String? createdAt;
  int? iV;
  String? id;

  User(
      {this.fullName,
      this.email,
      this.password,
      this.expertise,
      this.bio,
      this.sId,
      this.createdAt,
      this.iV,
      this.id});

  User.fromJson(Map<String, dynamic> json) {
    fullName = json['fullName'];
    email = json['email'];
    password = json['password'];
    expertise = json['expertise'];
    bio = json['bio'];
    sId = json['_id'];
    createdAt = json['createdAt'];
    iV = json['__v'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['fullName'] = this.fullName;
    data['email'] = this.email;
    data['password'] = this.password;
    data['expertise'] = this.expertise;
    data['bio'] = this.bio;
    data['_id'] = this.sId;
    data['createdAt'] = this.createdAt;
    data['__v'] = this.iV;
    data['id'] = this.id;
    return data;
  }
}
