import 'package:todo_main_app/features/todo/presentation/pages/task_list.dart';
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
            const SizedBox(height: 100),
            Container(
              margin: const EdgeInsets.only(left: 25, right: 25, top: 30),
              child: ElevatedButton(
                onPressed: () {
                  // Navigate to Home Screen with custom animation
                  Navigator.push(
                    context,
                    CustomPageRoute(page: TaskListRoute()),
                  );
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: const Color.fromARGB(255, 124, 122, 223),
                  minimumSize: const Size(150, 50),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(5),
                  ),
                ),
                child: const Text(
                  'Get Started',
                  style: TextStyle(
                    fontSize: 17,
                    fontWeight: FontWeight.bold,
                    color: Colors.white,
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

// Navigation Animation
class CustomPageRoute<T> extends PageRouteBuilder<T> {
  final Widget page;

  CustomPageRoute({required this.page})
      : super(
          transitionDuration: const Duration(milliseconds: 500),
          pageBuilder: (context, animation, secondaryAnimation) => page,
          transitionsBuilder: (context, animation, secondaryAnimation, child) {
            var begin = const Offset(1.0, 0.0);
            var end = Offset.zero;

            var tween = Tween(begin: begin, end: end);
            var offsetAnimation = animation.drive(tween);
            return SlideTransition(
              position: offsetAnimation,
              child: child,
            );
          },
        );
}
