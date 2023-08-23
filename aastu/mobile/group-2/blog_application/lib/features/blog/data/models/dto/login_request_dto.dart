class LoginRequestDto {
  String email;
  String password;

  LoginRequestDto({
    required this.email,
    required this.password,
  });

  factory LoginRequestDto.fromJson(Map<String, dynamic> json) =>
      LoginRequestDto(
        email: json['email'],
        password: json['password'],
      );

  Map<String, dynamic> toJson() => {
        'email': email,
        'password': password,
      };
}