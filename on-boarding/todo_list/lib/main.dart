import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Todo List',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: Colors.white, secondary: const Color(0xffEE6F57)),
        useMaterial3: true,
      ),
      home: const MyHomePage(title: 'Todo List'),
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
        title: const Text('Todo List'),
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
            'assets/img/task_img1.jpg',
            height: 250,
          ),
          Container(
            height: 10,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20),
            alignment: Alignment.centerLeft,
            child: const Text(
              'Tasks List',
              style: TextStyle(
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          Card(
            surfaceTintColor: Colors.white,
            color: Colors.white,
            elevation: 4,
            shadowColor: const Color.fromRGBO(149, 157, 165, 0.2),
            margin: const EdgeInsets.only(left: 10, right: 10),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 10),
              child: Row(
                children: <Widget>[
                  Container(
                    margin: const EdgeInsets.only(left: 20, right: 20),
                    child: const Text(
                      'U',
                      style: TextStyle(
                        fontSize: 25,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  const SizedBox(
                      width:
                          10), // Use SizedBox instead of Container for spacing
                  const Expanded(
                    // Use Expanded to take remaining space in the row
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Text(
                          'UI/UX App Design',
                          style: TextStyle(
                            fontSize: 16,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ],
                    ),
                  ),
                  const Spacer(),
                  Container(
                    margin: const EdgeInsets.only(right: 5, bottom: 20),
                    child: const Text(
                      'Aug 3, 2023',
                      style: TextStyle(
                        fontSize: 15,
                      ),
                    ),
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.end,
                    children: <Widget>[
                      Container(
                        margin: const EdgeInsets.only(right: 3),
                        width: 2,
                        height: 50,
                        color: const Color(0xffEE6F57),
                      ),
                    ],
                  ),
                  const SizedBox(
                      width:
                          10), // Add some spacing to the right of the last widget
                ],
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          Card(
            surfaceTintColor: Colors.white,
            color: Colors.white,
            elevation: 4,
            shadowColor: const Color.fromRGBO(149, 157, 165, 0.2),
            margin: const EdgeInsets.only(left: 10, right: 10),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 10),
              child: Row(
                children: <Widget>[
                  Container(
                    margin: const EdgeInsets.only(left: 20, right: 20),
                    child: const Text(
                      'U',
                      style: TextStyle(
                        fontSize: 25,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  const SizedBox(
                      width:
                          10), // Use SizedBox instead of Container for spacing
                  const Expanded(
                    // Use Expanded to take remaining space in the row
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Text(
                          'UI/UX App Design',
                          style: TextStyle(
                            fontSize: 16,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ],
                    ),
                  ),
                  const Spacer(),
                  Container(
                    margin: const EdgeInsets.only(right: 5, bottom: 20),
                    child: const Text(
                      'Aug 3, 2023',
                      style: TextStyle(
                        fontSize: 15,
                      ),
                    ),
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.end,
                    children: <Widget>[
                      Container(
                        margin: const EdgeInsets.only(right: 3),
                        width: 2,
                        height: 50,
                        color: const Color.fromARGB(255, 12, 196, 27),
                      ),
                    ],
                  ),
                  const SizedBox(
                      width:
                          10), // Add some spacing to the right of the last widget
                ],
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          Card(
            surfaceTintColor: Colors.white,
            color: Colors.white,
            elevation: 4,
            shadowColor: const Color.fromRGBO(149, 157, 165, 0.2),
            margin: const EdgeInsets.only(left: 10, right: 10),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 10),
              child: Row(
                children: <Widget>[
                  Container(
                    margin: const EdgeInsets.only(left: 20, right: 20),
                    child: const Text(
                      'V',
                      style: TextStyle(
                        fontSize: 25,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  const SizedBox(
                      width:
                          10), // Use SizedBox instead of Container for spacing
                  const Expanded(
                    // Use Expanded to take remaining space in the row
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Text(
                          'View Candidates',
                          style: TextStyle(
                            fontSize: 16,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ],
                    ),
                  ),
                  const Spacer(),
                  Container(
                    margin: const EdgeInsets.only(right: 5, bottom: 20),
                    child: const Text(
                      'Aug 3, 2023',
                      style: TextStyle(
                        fontSize: 15,
                      ),
                    ),
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.end,
                    children: <Widget>[
                      Container(
                        margin: const EdgeInsets.only(right: 3),
                        width: 2,
                        height: 50,
                        color: const Color.fromARGB(255, 238, 185, 10),
                      ),
                    ],
                  ),
                  const SizedBox(
                      width:
                          10), // Add some spacing to the right of the last widget
                ],
              ),
            ),
          ),
          Container(
            height: 10,
          ),
          Card(
            surfaceTintColor: Colors.white,
            color: Colors.white,
            elevation: 4,
            shadowColor: const Color.fromRGBO(149, 157, 165, 0.2),
            margin: const EdgeInsets.only(left: 10, right: 10),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 10),
              child: Row(
                children: <Widget>[
                  Container(
                    margin: const EdgeInsets.only(left: 20, right: 20),
                    child: const Text(
                      'F',
                      style: TextStyle(
                        fontSize: 25,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  const SizedBox(
                      width:
                          10), // Use SizedBox instead of Container for spacing
                  const Expanded(
                    // Use Expanded to take remaining space in the row
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Text(
                          'Football Drybling',
                          style: TextStyle(
                            fontSize: 16,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ],
                    ),
                  ),
                  const Spacer(),
                  Container(
                    margin: const EdgeInsets.only(right: 5, bottom: 20),
                    child: const Text(
                      'Aug 3, 2023',
                      style: TextStyle(
                        fontSize: 15,
                      ),
                    ),
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.end,
                    children: <Widget>[
                      Container(
                        margin: const EdgeInsets.only(right: 3),
                        width: 2,
                        height: 50,
                        color: const Color(0xffEE6F57),
                      ),
                    ],
                  ),
                  const SizedBox(
                      width:
                          10), // Add some spacing to the right of the last widget
                ],
              ),
            ),
          ),

          Container(
            height: 20,
          ),
          Container(
            margin: const EdgeInsets.only(left: 25, right: 25),
            child: ElevatedButton(
              onPressed: () {},
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color(0xffEE6F57),
                minimumSize: const Size(200, 50),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(10),
                ),
              ),
              child: const Text('Create Task',
                  style: TextStyle(
                      fontSize: 17,
                      fontWeight: FontWeight.bold,
                      color: Colors.white)),
            ),
          ),
        ],
      ),
    );
  }
}
