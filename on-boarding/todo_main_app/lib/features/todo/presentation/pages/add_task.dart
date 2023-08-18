import 'dart:developer' as developer;
import 'package:intl/intl.dart';
import 'package:flutter/material.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/domain/repositories/todo_repository.dart';
import 'package:todo_main_app/features/todo/domain/usecases/create_task.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/bloc.dart';
import 'package:todo_main_app/injection.dart';

class AddTask extends StatefulWidget {
  final TodoBloc todoBloc; // Pass the TodoBloc as a parameter
  const AddTask({Key? key, required this.todoBloc}) : super(key: key);

  @override
  State<AddTask> createState() => _AddTaskState();
}

class _AddTaskState extends State<AddTask> {
  TextEditingController taskNameController = TextEditingController();
  TextEditingController descriptionController = TextEditingController();
  DateTime selectedDate = DateTime.now();
  late final TodoBloc _todoBloc;
  late final CreateTask _createTask;

  @override
  void initState() {
    super.initState();
    _todoBloc = widget.todoBloc;
    _createTask = CreateTask(sl<TodoRepository>());
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
        title: const Text(''),
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
          Container(
            alignment: Alignment.center,
            child: const Text(
              'Create New Task',
              style: TextStyle(
                fontSize: 25,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          const Divider(
            color: Color.fromARGB(255, 243, 243, 243),
            height: 20,
            thickness: 1,
          ),
          Container(
            height: 5,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20),
            alignment: Alignment.centerLeft,
            child: const Text(
              'Main Task Name',
              style: TextStyle(
                fontSize: 16,
                color: Color.fromRGBO(238, 111, 87, 1),
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Container(
            height: 8,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20, right: 20),
            child: TextField(
              controller: taskNameController,
              key: const Key('task_name_field'),
              decoration: InputDecoration(
                filled: true,
                fillColor: const Color.fromARGB(255, 255, 255, 255),
                border: OutlineInputBorder(
                  borderSide: BorderSide.none,
                  borderRadius: BorderRadius.circular(8),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: const BorderSide(
                      color: Color.fromARGB(255, 255, 248, 250), width: 1),
                  borderRadius: BorderRadius.circular(8),
                ),
                hintText: "Enter Task Name",
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
            height: 8,
          ),
          Card(
            surfaceTintColor: Colors.white,
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
            height: 10,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20),
            alignment: Alignment.centerLeft,
            child: const Text(
              'Description',
              style: TextStyle(
                fontSize: 16,
                color: Color.fromRGBO(238, 111, 87, 1),
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Container(
            height: 8,
          ),
          Container(
            margin: const EdgeInsets.only(left: 20, right: 20),
            child: TextField(
              controller: descriptionController,
              maxLines: 4,
              decoration: InputDecoration(
                filled: true,
                fillColor: const Color.fromARGB(255, 255, 255, 255),
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
            height: 30,
          ),
          Container(
            margin: const EdgeInsets.only(left: 25, right: 25),
            child: ElevatedButton(
              key: const Key('add_task_button'),
              onPressed: () async {
                final newTask = Todo(
                  id: 0,
                  title: taskNameController.text,
                  description: descriptionController.text,
                  dueDate: selectedDate,
                  isCompleted: false,
                );

                final createTaskResult =
                    await _createTask(CreateTaskParams(task: newTask));

                createTaskResult.fold(
                  (failure) {
                    // Handle failure
                    // Show snack bar with red background
                    SnackBar snackBar = SnackBar(
                      content: Text(failure.toString()),
                      duration: const Duration(seconds: 2),
                      backgroundColor: const Color(0xffEE6F57),
                    );
                    ScaffoldMessenger.of(context).showSnackBar(snackBar);
                  },
                  (task) {
                    // Task created successfully
                    developer.log('Task created: $task.id');
                    _todoBloc.add(const LoadAllTasksEvent());

                    SnackBar snackBar = const SnackBar(
                      content: Text('Task created successfully'),
                      duration: Duration(seconds: 2),
                      backgroundColor: Color(0xff4BB543),
                    );
                    ScaffoldMessenger.of(context).showSnackBar(snackBar);

                    Navigator.pushReplacementNamed(context, '/home');
                  },
                );
              },
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color(0xffEE6F57),
                minimumSize: const Size(150, 50),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(30),
                ),
              ),
              child: const Text('Add Task',
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

  @override
  void dispose() {
    _todoBloc.close(); // Close the TodoBloc
    taskNameController.dispose();
    descriptionController.dispose();
    super.dispose();
  }
}
