import 'package:add_task/main.dart';
import 'package:flutter/material.dart';

class GetStartedRoute extends StatefulWidget {
  const GetStartedRoute({Key? key}) : super(key: key);

  @override
  GetStartedRouteState createState() => GetStartedRouteState();
}

class GetStartedRouteState extends State<GetStartedRoute> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 255, 213, 204),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Image.asset(
              'assets/images/getstarted.jpg',
              height: 400,
            ),
            const SizedBox(height: 40),
            Container(
              margin: const EdgeInsets.only(left: 25, right: 25),
              child: ElevatedButton(
                onPressed: () {
                  // navigate to GetStartedRoute
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const MyApp(),
                    ),
                  );
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: const Color.fromARGB(255, 124, 122, 223),
                  minimumSize: const Size(150, 50),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(0),
                  ),
                ),
                child: const Text('Get Started',
                    style: TextStyle(
                        fontSize: 17,
                        fontWeight: FontWeight.bold,
                        color: Colors.white)),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
