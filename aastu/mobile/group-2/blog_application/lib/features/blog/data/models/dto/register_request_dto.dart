class RegisterRequestDto {
  String? bio;
  String? fullName;
  String? email;
  int? password;
  String? expertise;

  RegisterRequestDto(
      {this.bio, this.fullName, this.email, this.password, this.expertise});

  RegisterRequestDto.fromJson(Map<String, dynamic> json) {
    bio = json['bio'];
    fullName = json['fullName'];
    email = json['email'];
    password = json['password'];
    expertise = json['expertise'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['bio'] = this.bio;
    data['fullName'] = this.fullName;
    data['email'] = this.email;
    data['password'] = this.password;
    data['expertise'] = this.expertise;
    return data;
  }
}