import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_all_tasks.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_single_task.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/bloc.dart';
import 'package:todo_main_app/features/todo/presentation/widgets/single_list_card.dart';
import 'package:todo_main_app/injection.dart';

class TaskListRoute extends StatelessWidget {
  const TaskListRoute({super.key});

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
      body: SingleChildScrollView(
        child: buildBody(context),
      ),
    );
  }

  BlocProvider<TodoBloc> buildBody(BuildContext context) {
    return BlocProvider(
      create: (context) => TodoBloc(
        getAllTasks: sl<GetAllTask>(),
        getSingleTask: sl<GetSingleTask>(),
      )..add(const LoadAllTasksEvent()),
      child: Column(
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
          BlocBuilder<TodoBloc, TodoState>(
            builder: (context, state) {
              if (state is LoadedAllTasksState) {
                final tasks = state.tasks; // Use tasks from the state

                return ListView.builder(
                  shrinkWrap: true, // Add this line to allow ListView to shrink
                  physics: NeverScrollableScrollPhysics(), // Disable scrolling
                  itemCount: tasks.length,
                  itemBuilder: (context, index) {
                    final task =
                        tasks[index]; // Get the task for the current index

                    return SingleListCard(
                      id: task.id,
                      title: task.title,
                      description: task.description,
                      selectedDate: task.dueDate,
                      isCompleted: task.isCompleted,
                      onDateSelected: (DateTime date) {
                        // Your date selection logic
                      },
                    );
                  },
                );
              } else {
                // Handle other states if needed
                return const SizedBox.shrink();
              }
            },
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
