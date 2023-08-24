class ValueConverter{
  String formatDate(DateTime createdAt){ 
    final difference = DateTime.now().difference(createdAt);
    if (difference.inMinutes < 1) {
      return '${difference.inSeconds}sec ago';
    } else if (difference.inHours < 1) {
      return '${difference.inMinutes}mins ago';
    } else if (difference.inDays < 1) {
      return '${difference.inHours}hr ago';
    } else{
      return '${difference.inDays}days ago';
    }
  }
}