/// Converts datetime to MMMM dd, yyyy format
String dateTimeToString(DateTime datetime) {
  const months = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December'
  ];

  return '${months[datetime.month - 1]} ${datetime.day}, ${datetime.year}';
}
