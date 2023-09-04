/// Converts datetime to MMMM dd, yyyy format
String dateTimeToString(DateTime datetime) {
  const months = [
    'Jan',
    'Feb',
    'Mar',
    'April',
    'May',
    'June',
    'July',
    'Aug',
    'Sep',
    'Oct',
    'Nov',
    'Dec'
  ];

  return '${months[datetime.month - 1]} ${datetime.day}, ${datetime.year}';
}
