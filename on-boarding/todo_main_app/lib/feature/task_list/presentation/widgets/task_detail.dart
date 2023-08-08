import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:todo_main_app/core/usecases/usescases.dart';
import 'package:todo_main_app/feature/task_list/domain/entities/task_list.dart';
import 'package:todo_main_app/feature/task_list/domain/usecases/view_all_tasks_usecase.dart';
import 'package:todo_main_app/feature/task_list/domain/usecases/view_task.dart';

class TaskDetail extends StatefulWidget {
  final ViewAllTasksUsecase viewAllTasksUsecase;
  final int taskId;

  const TaskDetail(
      {super.key, required this.taskId, required this.viewAllTasksUsecase});

  @override
  State<TaskDetail> createState() => _TaskDetailState();
}

class _TaskDetailState extends State<TaskDetail> {
  DateTime selectedDate = DateTime.now();
  late ViewTaskUsecase viewTaskUsecase;
  late Task task;
  //  List<Task> tasks = [
  //   Task(
  //     id: 0,
  //     title: 'Todo App UI Design',
  //     description:
  //         'Design a UI/UX for mobile app. We can use figma or Adobe for designing the UI.',
  //     dueDate: DateTime.now(),
  //     isCompleted: false,
  //   ),
  //   Task(
  //     id: 1,
  //     title: 'Attending Study Session',
  //     description: 'Attend the study session at 8:00 PM.',
  //     dueDate: DateTime.now(),
  //     isCompleted: false,
  //   ),
  //   Task(
  //     id: 2,
  //     title: 'View Candidates',
  //     description:
  //         'View the candidates for the job opening and then shortlist them.',
  //     dueDate: DateTime.now(),
  //     isCompleted: false,
  //   ),
  //   Task(
  //     id: 3,
  //     title: 'Football Match',
  //     description: 'Watching the football match at 9:00 PM with friends.',
  //     dueDate: DateTime.now(),
  //     isCompleted: true,
  //   ),
  // ];

  @override
  void initState() {
    super.initState();
    fetchTask();
  }

  Future<void> fetchTask() async {
    final tasks = await widget.viewAllTasksUsecase.call(NoParams());
    task = tasks.firstWhere((t) => t.id == widget.taskId);
    setState(() {});
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: selectedDate,
      firstDate: DateTime(2000),
      lastDate: DateTime(2101),
    );
    if (picked != null && picked != selectedDate) {
      setState(() {
        selectedDate = picked;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Task Detail'),
        leading: IconButton(
          icon: const Icon(Icons.arrow_back_ios),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
        actions: [
          IconButton(
            icon: const Icon(Icons.more_vert),
            onPressed: () {},
          ),
        ],
        centerTitle: true,
      ),
      body: ListView(
        children: <Widget>[
          Image.asset(
            'assets/images/task_img2.png',
            height: 200,
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
                hintText: task.title,
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
                hintText: task.description,
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
              'Due Date',
              style: TextStyle(
                fontSize: 16,
                color: Color.fromRGBO(238, 111, 87, 1),
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Container(
            height: 5,
          ),
          Card(
            surfaceTintColor: const Color.fromARGB(255, 255, 251, 251),
            elevation: 4,
            shadowColor: const Color.fromRGBO(149, 157, 165, 0.2),
            margin: const EdgeInsets.symmetric(horizontal: 10),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 20, horizontal: 20),
              child: Row(
                children: <Widget>[
                  Expanded(
                    child: Text(
                      DateFormat('MMM d, yyyy').format(selectedDate),
                      style: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  // Date selector icon
                  GestureDetector(
                    onTap: () => _selectDate(context),
                    child: const Icon(
                      key: Key('date_picker_icon'),
                      Icons.date_range,
                      size: 24,
                      color: Color.fromRGBO(238, 111, 87, 1),
                    ),
                  ),
                ],
              ),
            ),
          ),
          Container(
            height: 15,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20, right: 20),
            child: ElevatedButton(
              onPressed: () async {
                await viewTaskUsecase.updateTaskCompletionStatus(task.id, true);
                Navigator.pop(context); // Navigate back to the previous screen
              },
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color.fromRGBO(238, 111, 87, 1),
                minimumSize: const Size(150, 50),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(5),
                ),
              ),
              child: const Text(
                'Mark as Completed',
                style: TextStyle(
                  fontSize: 17,
                  fontWeight: FontWeight.bold,
                  color: Colors.white,
                ),
              ),
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
