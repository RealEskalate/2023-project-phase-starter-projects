String calculateEstimatedReadTime(String content) {
  // Average reading speed in words per minute
  final wordsPerMinute = 200;

  // Calculate the number of words in the content
  final words = content.split(' ');

  // Calculate the estimated read time
  final readTimeInMinutes = (words.length / wordsPerMinute).ceil();

  // Return the estimated read time as a formatted string
  return '$readTimeInMinutes min';
}
