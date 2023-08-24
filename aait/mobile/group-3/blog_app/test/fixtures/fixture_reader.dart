import 'dart:io';

String fixtures(String fileName) {
  return File('test/fixtures/$fileName').readAsStringSync();
}