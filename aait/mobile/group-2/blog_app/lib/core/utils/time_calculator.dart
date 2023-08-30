Duration estimatedReadTimeCalculator(String content) {
  final words = content.split(' ');
  final wordCount = words.length;
  final readTime = wordCount / 200;
  return Duration(minutes: readTime.toInt());
}

Duration timePassedCalculator(DateTime dateTime) {
  final now = DateTime.now();
  final difference = now.difference(dateTime);
  return difference;
}

String timePassedFormatter(Duration duration) {
  if (duration.inSeconds < 60) {
    return '${duration.inSeconds} seconds ago';
  } else if (duration.inMinutes < 60) {
    return '${duration.inMinutes} minutes ago';
  } else if (duration.inHours < 24) {
    return '${duration.inHours} hours ago';
  } else if (duration.inDays < 7) {
    return '${duration.inDays} days ago';
  } else if (duration.inDays < 30) {
    return '${duration.inDays ~/ 7} weeks ago';
  } else if (duration.inDays < 365) {
    return '${duration.inDays ~/ 30} months ago';
  } else {
    return '${duration.inDays ~/ 365} years ago';
  }
}
