class ServerException implements  Exception{
  final int statusCode;

  ServerException({required this.statusCode});
}
class CacheException implements Exception{}
class NetworkConnectionException implements Exception{}
class EmailAndPasswordNotMatchException implements Exception{}
