import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/domain/usecases/delete_task.dart';
import 'package:todo_main_app/features/todo/domain/usecases/update_task.dart';
import 'dart:developer' as developer;
import 'package:todo_main_app/features/todo/presentation/bloc/bloc.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:todo_main_app/features/todo/presentation/widgets/task_not_found.dart';
import 'package:todo_main_app/injection.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_all_tasks.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_single_task.dart';

class TaskDetail extends StatefulWidget {
  final int taskId;

  const TaskDetail({Key? key, required this.taskId}) : super(key: key);

  @override
  State<TaskDetail> createState() => _TaskDetailState();
}

class _TaskDetailState extends State<TaskDetail> {
  DateTime selectedDate = DateTime.now();
  final TextEditingController titleController = TextEditingController();
  final TextEditingController descriptionController = TextEditingController();

  @override
  void initState() {
    super.initState();
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
            Navigator.pushReplacementNamed(context, '/home');
          },
        ),
        actions: [
          BlocProvider(
              create: (context) => TodoBloc(
                    getAllTasks: sl<GetAllTask>(),
                    getSingleTask: sl<GetSingleTask>(),
                    updateTask: sl<UpdateTask>(),
                    deleteTask: sl<DeleteTask>(),
                  )..add(GetSingleTaskEvent(widget.taskId)),
              child:
                  BlocBuilder<TodoBloc, TodoState>(builder: (context, state) {
                return IconButton(
                  icon: const Icon(Icons.delete),
                  onPressed: () {
                    if (state is LoadedSingleTaskState) {
                      final taskId = state.task.id;
                      context.read<TodoBloc>().add(DeleteTaskEvent(taskId));
                    }

                    ScaffoldMessenger.of(context).showSnackBar(
                      const SnackBar(
                        backgroundColor: Color.fromRGBO(0, 100, 0, 1),
                        content: Text(
                          'Task is deleted',
                          style: TextStyle(
                            color: Colors.white,
                          ),
                        ),
                      ),
                    );
                    Navigator.pushReplacementNamed(context, '/home');
                  },
                );
              })),
          BlocProvider(
              create: (context) => TodoBloc(
                    getAllTasks: sl<GetAllTask>(),
                    getSingleTask: sl<GetSingleTask>(),
                    updateTask: sl<UpdateTask>(),
                    deleteTask: sl<DeleteTask>(),
                  )..add(GetSingleTaskEvent(widget.taskId)),
              child:
                  BlocBuilder<TodoBloc, TodoState>(builder: (context, state) {
                return IconButton(
                  icon: const Icon(Icons.check),
                  onPressed: () {
                    final currentState = context.read<TodoBloc>().state;

                    if (currentState is LoadedSingleTaskState) {
                      final task = currentState.task;

                      final updatedTask = Todo(
                        id: task.id,
                        title: titleController.text,
                        description: descriptionController.text,
                        dueDate: task.dueDate,
                        isCompleted: task.isCompleted, // Mark task as completed
                      );

                      context.read<TodoBloc>().add(UpdateTaskEvent(
                            taskId: updatedTask.id,
                            updatedTitle: updatedTask.title,
                            updatedDescription: updatedTask.description,
                            updatedDueDate: updatedTask.dueDate,
                          ));

                      developer.log("Task is updated");
                      // show toast message
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(
                          backgroundColor: Color.fromRGBO(0, 100, 0, 1),
                          content: Text(
                            'Task is updated',
                            style: TextStyle(
                              color: Colors.white,
                            ),
                          ),
                        ),
                      );
                      Navigator.pushReplacementNamed(context, '/home');
                    }
                  },
                );
              }))
        ],
        centerTitle: true,
      ),
      body: buildBody(context),
    );
  }

  BlocProvider<TodoBloc> buildBody(BuildContext context) {
    return BlocProvider(
      create: (context) => TodoBloc(
        getAllTasks: sl<GetAllTask>(),
        getSingleTask: sl<GetSingleTask>(),
        updateTask: sl<UpdateTask>(),
        deleteTask: sl<DeleteTask>(),
      )..add(GetSingleTaskEvent(widget.taskId)),
      child: BlocBuilder<TodoBloc, TodoState>(builder: (context, state) {
        developer.log("Loading widget id ${widget.taskId}");
        developer.log("Current state is $state");

        if (state is LoadedSingleTaskState) {
          final task = state.task;
          titleController.text = task.title;
          descriptionController.text = task.description;
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
                  controller: titleController,
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
                  controller: descriptionController,
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
                  padding:
                      const EdgeInsets.symmetric(vertical: 20, horizontal: 20),
                  child: Row(
                    children: <Widget>[
                      Expanded(
                        child: Text(
                          DateFormat('dd MMMM yyyy').format(task.dueDate),
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
                    final currentState = context.read<TodoBloc>().state;

                    if (currentState is LoadedSingleTaskState) {
                      final task = currentState.task;

                      final updatedTask = Todo(
                        id: task.id,
                        title: titleController.text,
                        description: descriptionController.text,
                        dueDate: task.dueDate,
                        isCompleted: true, // Mark task as completed
                      );

                      context.read<TodoBloc>().add(UpdateTaskEvent(
                            taskId: updatedTask.id,
                            updatedTitle: updatedTask.title,
                            updatedDescription: updatedTask.description,
                            updatedDueDate: updatedTask.dueDate,
                          ));

                      developer.log("Task is updated");
                    }
                  },
                  style: ElevatedButton.styleFrom(
                    backgroundColor: state.task.isCompleted
                        ? Colors.grey
                        : const Color(0xffEE6F57),
                    minimumSize: const Size(150, 50),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(5),
                    ),
                  ),
                  child: Text(
                    state.task.isCompleted ? 'Completed' : 'Mark as Complete',
                    style: const TextStyle(
                      fontSize: 17,
                      fontWeight: FontWeight.bold,
                      color: Colors.white,
                    ),
                  ),
                ),
              ),
              Container(
                height: 20,
              )
            ],
          );
        } else if (state is LoadedSingleTaskState) {
          return const CircularProgressIndicator();
        } else {
          return taskNotFound();
        }
      }),
    );
  }

  @override
  void dispose() {
    // Dispose of the TextEditingController instances
    titleController.dispose();
    descriptionController.dispose();
    super.dispose();
  }
}
