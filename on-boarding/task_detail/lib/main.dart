import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Task Detail',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: Colors.white,
            secondary: Color.fromRGBO(255, 255, 255, 1)),
        useMaterial3: true,
      ),
      home: const MyHomePage(title: 'Task Detail'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});
  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Task Detail'),
        leading: IconButton(
          icon: const Icon(Icons.arrow_back_ios),
          onPressed: () {},
        ),
        actions: [
          IconButton(
            icon: const Icon(Icons.more_vert),
            onPressed: () {
              // Handle the action button press here
            },
          ),
        ],
        centerTitle: true,
      ),
      body: Column(
        children: <Widget>[
          // add image from asset
          Image.asset(
            'assets/images/task_img2.png',
            height: 250,
          ),
          Container(
            height: 10,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20),
            alignment: Alignment.centerLeft,
            child: const Text(
              'Title',
              style: TextStyle(
                fontSize: 17,
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20, right: 20),
            child: TextField(
              decoration: InputDecoration(
                filled: true,
                fillColor: const Color(0xffF1EEEE),
                border: OutlineInputBorder(
                  borderSide: BorderSide.none,
                  borderRadius: BorderRadius.circular(8),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: const BorderSide(
                      color: Color.fromARGB(255, 255, 248, 250), width: 1),
                  borderRadius: BorderRadius.circular(8),
                ),
                hintText: 'Enter Title',
              ),
              style: const TextStyle(
                fontSize: 17,
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20),
            alignment: Alignment.centerLeft,
            child: const Text(
              'Description',
              style: TextStyle(
                fontSize: 17,
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          // add text field
          Container(
            margin: const EdgeInsets.only(left: 20, right: 20),
            child: TextField(
              maxLines: 5,
              decoration: InputDecoration(
                filled: true,
                fillColor: const Color(0xffF1EEEE),
                border: OutlineInputBorder(
                  borderSide: BorderSide.none,
                  borderRadius: BorderRadius.circular(8),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: const BorderSide(
                      color: Color.fromARGB(255, 255, 248, 250), width: 1),
                  borderRadius: BorderRadius.circular(8),
                ),
                hintText: 'Enter Description',
              ),
              style: const TextStyle(
                fontSize: 17,
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20),
            alignment: Alignment.centerLeft,
            child: const Text(
              'Deadline',
              style: TextStyle(
                fontSize: 17,
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          // add date picker
          Container(
            margin: const EdgeInsets.only(left: 20, right: 20),
            child: TextField(
              decoration: InputDecoration(
                filled: true,
                fillColor: const Color(0xffF1EEEE),
                border: OutlineInputBorder(
                  borderSide: BorderSide.none,
                  borderRadius: BorderRadius.circular(8),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: const BorderSide(
                      color: Color.fromARGB(255, 255, 248, 250), width: 1),
                  borderRadius: BorderRadius.circular(8),
                ),
                hintText: 'Enter Deadline',
              ),
              style: const TextStyle(
                fontSize: 17,
              ),
            ),
          ),
        ],
      ),
    );
  }
}
