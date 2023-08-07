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
I'm using Flutter Clean Architecture and Bloc State Management 
- lib/core  -- utilities and tools
- lib/feature  -- design and Ui pages
    - /bloc 
    - /pages
    - /widgets
- main.dart  --  app starter file

## Updates

### Aug 7, 2023

- Widget Testing SetUp Implementation:
  ```yaml
  dev_dependencies:
  flutter_test:
    sdk: flutter

- Widget Test Task Creation:
  ```dart
  testWidgets('AddTask widget does not add task with empty name',
      (tester) async {
    await tester.pumpWidget(
      const MaterialApp(
        home: AddTask(),
      ),
    );

    final textFieldFinder = find.byKey(const Key('task_name_field'));
    final textField = tester.widget<TextField>(textFieldFinder);

    expect(textField.controller!.text.isEmpty, isTrue);
  });

- Widget Test Task Listing :
  ```dart
  testWidgets('AddTask widget displays UI elements correctly', (tester) async {
    await tester.pumpWidget(
      const MaterialApp(
        home: AddTask(),
      ),
    );

    // Test various UI elements' presence
    expect(find.text('Create New Task'), findsOneWidget);
    expect(find.text('Main Task Name'), findsOneWidget);
    expect(find.text('Due Date'), findsOneWidget);
    expect(find.text('Description'), findsOneWidget);
    expect(find.byType(TextField),
        findsNWidgets(2)); // Task name and Description fields
    expect(find.byType(ElevatedButton), findsOneWidget);
  });

- Widget Test Onboarding Page Navigation:
  ```dart
  testWidgets('Tapping Get Started navigates to the main page', (tester) async {
    await tester.pumpWidget(
      const MaterialApp(
        home: GetStartedRoute(),
      ),
    );

    // Find the Get Started button and tap it
    final getStartedButton = find.text('Get Started');
    await tester.tap(getStartedButton);
    await tester.pumpAndSettle();

    // Verify that the main To-Do list page is displayed
    expect(find.byType(HomePage), findsOneWidget);
  });

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

