export function formatDate(dateString: string): string {
  const date = new Date(dateString);

  const options: Intl.DateTimeFormatOptions = { year: 'numeric', month: 'short', day: 'numeric' };
  const dateFormatted = date.toLocaleDateString('en-US', options);
  return dateFormatted;
}