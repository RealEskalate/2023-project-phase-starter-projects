import 'dart:developer';
import 'package:flutter/material.dart'; // Make sure to import the correct Task class
import 'package:todo_main_app/core/usecases/usescases.dart';
import 'package:todo_main_app/feature/todo/domain/entities/task_list.dart';
import 'package:todo_main_app/feature/todo/domain/repositories/task_repository_impl.dart';
import 'package:todo_main_app/feature/todo/domain/usecases/view_all_tasks_usecase.dart';
import 'package:todo_main_app/feature/todo/presentation/widgets/single_list_card.dart';

class TaskListRoute extends StatefulWidget {
  const TaskListRoute({Key? key}) : super(key: key);

  @override
  TaskListRouteState createState() => TaskListRouteState();
}

class TaskListRouteState extends State<TaskListRoute> {
  DateTime selectedDate = DateTime.now();
  late ViewAllTasksUsecase viewAllTasksUsecase;

  final TaskRepositoryImpl taskRepository =
      TaskRepositoryImpl(); // Create an instance of TaskRepository
  List<Task> sampleTasks = []; // Initialize with an empty list

  @override
  void initState() {
    super.initState();
    viewAllTasksUsecase = ViewAllTasksUsecase(taskRepository);
    loadTasks(); // Call a method to load tasks from the use case
  }

  Future<void> loadTasks() async {
    final tasksEither = await viewAllTasksUsecase(NoParams());

    tasksEither.fold(
      (failure) {
        // Handle failure here (e.g., show an error message)
        log("Error: ${failure.message}");
      },
      (tasks) {
        setState(() {
          sampleTasks = tasks.cast<Task>();
        });
      },
    );
  }

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
                  // passing viewAllTasksUsecase
                  viewAllTasksUsecase: viewAllTasksUsecase,
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
