import 'package:flutter/material.dart';

void showError(BuildContext context, String message) {
  ScaffoldMessenger.of(context).showSnackBar(
    SnackBar(
        content: Text(message),
        backgroundColor: Theme.of(context).colorScheme.error),
  );
}

void showMessge(BuildContext context, String message) {
  ScaffoldMessenger.of(context).showSnackBar(
    SnackBar(
      content: Text(message),
    ),
  );
}

void showSuccess(BuildContext context, String message) {
  ScaffoldMessenger.of(context).showSnackBar(
    SnackBar(
        content: Text(message),
        backgroundColor: Theme.of(context).colorScheme.primary),
  );
}
