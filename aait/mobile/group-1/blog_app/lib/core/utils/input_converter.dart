import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:dartz/dartz.dart';


class InputConverter {
  Either<Failure, int> stringToUnsignedInteger(String str) {
    try {
      final integer = int.parse(str);
      if (integer < 0) throw const FormatException();
      return Right(integer);
    } on FormatException {
      return const Left(InvalidInputFailure(message: "Invalid input"));
    }
  }
}

class InvalidInputFailure extends Failure {
  final String message;

  const InvalidInputFailure({
    required this.message,
  }) : super();

  @override
  List<Object> get props => [message];
}