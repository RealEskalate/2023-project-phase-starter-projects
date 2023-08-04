# TODO APP

A TODO List App for A2SV 2023 Project Phase Learning Track

## Screenshot Demo

<div style="display: flex; flex-direction: row;">
  <img src="screenshot/image1.jpg" alt="Mobile App Screenshot" width="180" />
  <img src="screenshot/image2.jpg" alt="Mobile App Screenshot" width="180" />
  <img src="screenshot/image3.jpg" alt="Mobile App Screenshot" width="180" />
  <img src="screenshot/image4.jpg" alt="Mobile App Screenshot" width="180" />
</div>



## Folder Stracture

- lib/core  -- utilities and tools
- lib/feature  -- design and Ui pages
    - /add_task 
    - /home_screen
    - /task_detail
- main.dart  --  main starter file

## Updates

### Aug 4, 2023

- Implemented Named Navigation:
  ```dart
   routes: {
        '/addTask': (context) => const AddTask(),
        '/home': (context) => const HomePage(),
        '/taskDetail': (context) => const TaskDetail(title: ""),
      },

- Handling Navigation Events:
  ```dart
  leading: IconButton(
          icon: const Icon(Icons.arrow_back_ios),
          onPressed: () {
            // Navigate back to the home screen when the button is pressed
            Navigator.popUntil(context, ModalRoute.withName('/home'));
          },
        ),

- Implemented Passing data in Navigation:
  ```dart
   onTap: () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => const TaskDetail(title: "UI/UX App Design"),
                ),
              );
            },

- Implemented Animation between Navigation:
    ```dart
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

