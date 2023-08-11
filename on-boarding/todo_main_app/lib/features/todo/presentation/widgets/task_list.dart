import 'dart:developer';
import 'package:flutter/material.dart';
import 'package:todo_main_app/features/todo/domain/entities/task_list.dart';
import 'package:todo_main_app/features/todo/presentation/widgets/single_list_card.dart';

class TaskListRoute extends StatefulWidget {
  const TaskListRoute({Key? key}) : super(key: key);

  @override
  TaskListRouteState createState() => TaskListRouteState();
}

class TaskListRouteState extends State<TaskListRoute> {
  DateTime selectedDate = DateTime.now();
// Initialize with an empty list

  @override
  void initState() {
    super.initState();
  }

  // Loading Data From Array For Testing
  List<Task> sampleTasks = [
    Task(
      id: 0,
      title: 'Todo App UI Design',
      description:
          'Design a UI/UX for mobile app. We can use figma or Adobe for designing the UI.',
      dueDate: DateTime.now(),
      isCompleted: false,
    ),
    Task(
      id: 1,
      title: 'Attending Study Session',
      description: 'Attend the study session at 8:00 PM.',
      dueDate: DateTime.now(),
      isCompleted: false,
    ),
    Task(
      id: 2,
      title: 'View Candidates',
      description:
          'View the candidates for the job opening and then shortlist them.',
      dueDate: DateTime.now(),
      isCompleted: false,
    ),
    Task(
      id: 3,
      title: 'Football Match',
      description: 'Watching the football match at 9:00 PM with friends.',
      dueDate: DateTime.now(),
      isCompleted: true,
    ),
  ];

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
            onPressed: () {},
          ),
        ],
        centerTitle: true,
      ),
      body: Column(
        children: <Widget>[
          Image.asset(
            'assets/images/task_img1.jpg',
            height: 250,
          ),
          const SizedBox(height: 10),
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
          const SizedBox(height: 10),
          Expanded(
            child: ListView.builder(
              itemCount: sampleTasks.length,
              itemBuilder: (context, index) {
                return SingleListCard(
                  id: sampleTasks[index].id,
                  title: sampleTasks[index].title,
                  description: sampleTasks[index].description,
                  selectedDate: sampleTasks[index].dueDate,
                  isCompleted: sampleTasks[index].isCompleted,
                  onDateSelected: (DateTime date) {
                    setState(() {
                      selectedDate = date;
                    });
                  },
                );
              },
            ),
          ),
          Container(
            height: 10,
          ),
          Container(
            margin: const EdgeInsets.only(left: 25, right: 25),
            child: ElevatedButton(
              onPressed: () {
                // Navigate to AddTaskScreen when the button is pressed
                Navigator.pushNamed(context, '/addTask');
              },
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
          Container(
            height: 20,
          ),
        ],
      ),
    );
  }
}
