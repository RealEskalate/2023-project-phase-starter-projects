import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/bloc.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class TaskDetail extends StatefulWidget {
  final int taskId;
  final TodoBloc todoBloc;

  const TaskDetail({Key? key, required this.taskId, required this.todoBloc})
      : super(key: key);

  @override
  State<TaskDetail> createState() => _TaskDetailState();
}

class _TaskDetailState extends State<TaskDetail> {
  DateTime selectedDate = DateTime.now();
  late Todo task;
  late final TodoBloc _todoBloc; // Add this

  @override
  void initState() {
    super.initState();
    _todoBloc = widget.todoBloc; // Get the TodoBloc from the context
    _fetchTask();
  }

  Future<void> _fetchTask() async {
    _todoBloc
        .add(GetSingleTaskEvent(widget.taskId)); // Dispatch GetSingleTaskEvent
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
      body: BlocBuilder<TodoBloc, TodoState>(
        builder: (context, state) {
          if (state is LoadedSingleTaskState) {
            task = state.task;
            return ListView(
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
                            color: Color.fromARGB(255, 255, 248, 250),
                            width: 1),
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
                            color: Color.fromARGB(255, 255, 248, 250),
                            width: 1),
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
                    padding: const EdgeInsets.symmetric(
                        vertical: 20, horizontal: 20),
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
                      Navigator.pop(context);
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
            );
          } else {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }
        },
      ),
    );
  }
}
