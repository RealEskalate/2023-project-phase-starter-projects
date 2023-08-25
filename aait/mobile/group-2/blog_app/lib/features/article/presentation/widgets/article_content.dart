import 'package:flutter/widgets.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ArticleContent extends StatelessWidget {
  final List<String> paragraphs;

  const ArticleContent({super.key, required this.paragraphs});

  List<Widget> _buildParagraphs() {
    final List<Widget> widgets = [];

    for (final paragraph in paragraphs) {
      widgets.add(
        Text(
          paragraph,
        ),
      );
      widgets.add(SizedBox(height: 25.h));
    }

    return widgets;
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w, vertical: 30.h),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: _buildParagraphs(),
      ),
    );
  }
}
