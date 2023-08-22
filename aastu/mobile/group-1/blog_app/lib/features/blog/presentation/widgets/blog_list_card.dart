import 'package:blog_app/core/utils/my_colors.dart';
import 'package:blog_app/core/utils/my_strings.dart';
import 'package:blog_app/core/utils/my_text.dart';
import 'package:flutter/material.dart';

class ItemTile extends StatelessWidget {
  const ItemTile({super.key});

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () {
        // onItemClick(object);
      },
      child: Container(
        height: 110,
        width: double.infinity,
        padding: const EdgeInsets.fromLTRB(15, 5, 15, 5),
        child: Column(
          children: <Widget>[
            Expanded(
              child: Row(
                children: <Widget>[
                  Card(
                      margin: const EdgeInsets.all(0),
                      elevation: 0,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(8),
                      ),
                      clipBehavior: Clip.antiAliasWithSaveLayer,
                      child: Image.asset("assets/images/user.jpg",
                          height: 100, width: 100, fit: BoxFit.cover)),
                  Container(width: 10),
                  Expanded(
                    child: Column(
                      children: <Widget>[
                        Text(MyStrings.short_lorem_ipsum,
                            maxLines: 3,
                            style: MyText.subhead(context)!.copyWith(
                                color: MyColors.grey_80,
                                fontWeight: FontWeight.w500)),
                        const Spacer(),
                        Row(
                          children: <Widget>[
                            Text(MyStrings.short_lorem_ipsum.toUpperCase(),
                                style: MyText.caption(context)!
                                    .copyWith(color: MyColors.grey_40)),
                            const Spacer(),
                            Text("12:00 PM",
                                style: MyText.caption(context)!
                                    .copyWith(color: MyColors.grey_40)),
                          ],
                        ),
                      ],
                    ),
                  )
                ],
              ),
            ),
            Container(height: 10),
            const Divider(height: 0)
          ],
        ),
      ),
    );
  }
}
