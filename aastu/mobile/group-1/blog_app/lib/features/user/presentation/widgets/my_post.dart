import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import '../widgets/post_list.dart';

class Myposts extends StatefulWidget {
  const Myposts({super.key});

  @override
  State<Myposts> createState() => _MypostsState();
}

class _MypostsState extends State<Myposts> {
  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width,
      // height: 200,

      decoration: const BoxDecoration(
        color: Colors.white, // Set your desired background color
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(20),
          topRight: Radius.circular(20),
        ),
        boxShadow: [
          BoxShadow(
            color: Color(0x0F5182FF),
            blurRadius: 30,
            offset: Offset(0, 10),
            spreadRadius: 0,
          ),
        ],
      ),

      child: Column(
        children: [
          const SizedBox(
            height: 10,
          ),
          Row(
            children: [
              const SizedBox(width: 20),
              const Text(
                "My Posts",
                style: TextStyle(
                  color: Color(0xFF1A1A1A),
                  fontWeight: FontWeight.w400,
                  fontFamily: 'Urbanist',
                  fontSize: 20,
                ),
              ),
              const Spacer(),
              IconButton(
                onPressed: () {},
                icon: const Stack(
                  children: [
                    FaIcon(FontAwesomeIcons.gripHorizontal,
                        size: 34,
                        color: Color.fromARGB(255, 95, 55, 252)), // Stroke icon
                    // FaIcon(FontAwesomeIcons.gripHorizontal,
                    //     size: 32,
                    //     color: const Color.fromARGB(
                    //         255, 255, 255, 255)), // Main icon
                  ],
                ),
              ),
              const Padding(
                padding: const EdgeInsets.only(right: 20.0, left: 16),
                child: Icon(
                  FontAwesomeIcons.gripLines,
                  color: Color.fromARGB(255, 96, 96, 96),
                  size: 30,
                ),
              ),
              // SizedBox(
              //   width: 20,
              // ),
            ],
          ),
          Expanded(
            child: ListView.builder(
              itemCount: blogs.length,
              itemBuilder: (context, index) {
                return BlogCards(index: index, object: blogs[index]);
              },
            ),
          ),
        ],
      ),
    );
  }
}
