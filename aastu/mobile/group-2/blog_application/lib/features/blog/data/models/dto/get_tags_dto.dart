class GetTagsResponseDto {
  bool? success;
  List<String>? tags;

  GetTagsResponseDto({this.success, this.tags});

  GetTagsResponseDto.fromJson(Map<String, dynamic> json) {
    success = json['success'];
    tags = json['tags'].cast<String>();
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['success'] = this.success;
    data['tags'] = this.tags;
    return data;
  }
}