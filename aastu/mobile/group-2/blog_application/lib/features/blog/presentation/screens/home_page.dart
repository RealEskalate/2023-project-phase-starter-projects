import 'package:blog_application/features/blog/presentation/widgets/custom_input_field.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

import '../widgets/article_card.dart';
import '../widgets/customized_button.dart';
import '../widgets/filter_tag_chip.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: Container(
          padding: const EdgeInsets.all(14),
          child: SvgPicture.asset(
            'assets/icons/Vector.svg',
            width: 20,
            height: 10,
          ),
        ),
        title: const Text(
          'Welcome Back!',
          style: TextStyle(
            fontSize: 27,
            fontWeight: FontWeight.w600,
          ),
        ),
        actions: const [
          CircleAvatar(
            backgroundImage: AssetImage('assets/images/photocv.jpg'),
          )
        ],
      ),
      floatingActionButton: const CustomizedButton(
        icon: Icon(Icons.add),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Container(
          decoration: ShapeDecoration(
            color: const Color(0xFFF8FAFF),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(30),
            ),
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.end,
            children: [
              const CustomInputField(),
              const SizedBox(
                height: 20,
              ),
              const Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  FilterTagChip(
                    name: 'All',
                    selected: true,
                  ),
                  FilterTagChip(
                    name: 'Sports',
                    selected: false,
                  ),
                  FilterTagChip(
                    name: 'Tech',
                    selected: false,
                  ),
                  FilterTagChip(
                    name: 'Politics',
                    selected: false,
                  ),
                ],
              ),
              const SizedBox(
                height: 20,
              ),
              Expanded(
                child: SingleChildScrollView(
                  child: Column(
                    children: [
                      ListView.builder(
                        shrinkWrap: true,
                        physics: const NeverScrollableScrollPhysics(),
                        itemCount:1,
                        itemBuilder: (context, index) {
                          return GestureDetector(
                            onTap: () {},
                            child: const Column(
                              children: [
                                ArticleCard(
                                  author: 'Joe Doe',
                                  date: 'Jan 12, 2020',
                                  tag: 'Education',
                                  title:
                                      'STUDENTS SHOULD WORK ON IMPROVING THEIR WRITING SKILLS',
                                ),
                                SizedBox(height: 20),
                              ],
                            ),
                          );
                        },
                      ),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
