import 'package:blog_app/core/util/value_converter.dart';
import 'package:flutter_test/flutter_test.dart';

void main() {
  late ValueConverter valueConverter;

  setUp(() {
    valueConverter = ValueConverter();
  });

  test("Should return a valid string when given a valid DateTime", () async {
    final tHour = 1;
    final tResult = '${tHour}hr ago';
    final result = valueConverter
        .formatDate(DateTime.now().subtract(Duration(hours: tHour)));
    expect(result, equals(tResult));
  });
}
