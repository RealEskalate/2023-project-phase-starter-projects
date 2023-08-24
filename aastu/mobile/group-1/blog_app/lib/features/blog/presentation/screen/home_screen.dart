import 'package:flutter/material.dart';
import 'package:blog_app/features/blog/presentation/widgets/all.dart';
import 'package:blog_app/features/blog/presentation/widgets/politics.dart';
import 'package:blog_app/features/blog/presentation/widgets/sport.dart';
import 'package:blog_app/features/blog/presentation/widgets/tech.dart';

class Home extends StatefulWidget {
  const Home({super.key});

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  List<Widget> _room = <Widget>[
    const All(),
    const Sport(),
    const Tech(),
    const Politics(),
  ];
  var cats = ['All', 'Sports', 'Tech', 'Politics'];
  var scroll = ['1', '2', '3'];
  int _currentPage = 0;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromRGBO(248, 250, 255, 1),
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(
            Icons.sort,
            color: Colors.black,
            size: 45,
          ),
          onPressed: () {},
        ),
        backgroundColor: const Color.fromRGBO(248, 250, 255, 1),
        title: const Center(
          child: Text(
            "Welcome Back!",
            style: TextStyle(
              fontWeight: FontWeight.bold,
              color: Colors.black,
            ),
          ),
        ),
        toolbarHeight: 80,
        actions: [
          Padding(
              padding: const EdgeInsets.only(
                  left: 10, right: 10, top: 10, bottom: 30),
              child: GestureDetector(
                onTap: () {
                  Navigator.pushNamed(context, '/profile');
                },
                child: const CircleAvatar(
                  radius: 35,
                  backgroundImage: AssetImage("assets/images/doctor.jpg"),
                ),
              )),
        ],
      ),
      body: Container(
        padding: const EdgeInsets.only(
          left: 6,
          right: 6,
          bottom: 55,
        ),
        child: Column(
          children: [
            Container(
              padding:
                  const EdgeInsets.only(top: 0, right: 0, left: 10, bottom: 0),
              height: 50,
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(12),
              ),
              child: Row(
                children: [
                  Expanded(
                    child: TextField(
                      decoration: InputDecoration(
                          hintText: "Search and article...",
                          hintStyle: const TextStyle(
                              color: Color.fromRGBO(154, 148, 148, 1)),
                          border: InputBorder.none,
                          suffixIcon: Container(
                            width: 60,
                            height: 100,
                            decoration: BoxDecoration(
                              color: const Color.fromRGBO(102, 154, 255, 1),
                              borderRadius: BorderRadius.circular(12),
                            ),
                            child: IconButton(
                              icon: const Icon(Icons.search),
                              color: Colors.white,
                              onPressed: () {},
                            ),
                          )),
                    ),
                  ),
                  const Padding(padding: EdgeInsets.only(bottom: 10))
                ],
              ),
            ),
            Container(
              height: 70,
              child: ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: 4,
                  itemBuilder: (ctx, index) {
                    return Container(
                      // color: _currentPage == index?Color.fromRGBO(55, 106, 237, 1): null,
                      margin: const EdgeInsets.symmetric(
                          horizontal: 20, vertical: 20),
                      decoration: BoxDecoration(
                          color: _currentPage == index
                              ? const Color.fromRGBO(55, 106, 237, 1)
                              : null,
                          borderRadius: BorderRadius.circular(12),
                          border: Border.all(
                              color: const Color.fromRGBO(55, 106, 237, 1),
                              width: 2)),
                      child: TextButton(
                        onPressed: () {
                          setState(() {
                            _currentPage = index;
                            print(_currentPage);
                          });
                        },
                        child: Text(
                          cats[index],
                          style: TextStyle(
                              color: _currentPage == index
                                  ? Colors.white
                                  : const Color.fromRGBO(55, 106, 237, 1)),
                        ),
                      ),
                    );
                  }),
            ),
            Container(
              child: _room[_currentPage],
            )
          ],
        ),
      ),
    );
  }
}
