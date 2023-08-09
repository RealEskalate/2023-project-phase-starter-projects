import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:todo_main_app/feature/todo/domain/usecases/view_all_tasks_usecase.dart';
import 'package:todo_main_app/feature/todo/presentation/widgets/task_detail.dart';

class SingleListCard extends StatelessWidget {
  final int id;
  final String title;
  final String description;
  final DateTime selectedDate;
  final bool isCompleted;
  final Function(DateTime) onDateSelected;

  const SingleListCard({
    Key? key,
    required this.id,
    required this.title,
    required this.description,
    required this.selectedDate,
    required this.isCompleted,
    required this.onDateSelected,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => TaskDetail(
              taskId: id,
            ),
          ),
        );
      },
      child: Card(
        surfaceTintColor: Colors.white,
        color: Colors.white,
        elevation: 4,
        shadowColor: const Color.fromRGBO(149, 157, 165, 0.2),
        margin: const EdgeInsets.only(left: 10, right: 10, bottom: 10),
        child: Padding(
          padding: const EdgeInsets.symmetric(vertical: 10),
          child: Row(
            children: <Widget>[
              Container(
                margin: const EdgeInsets.only(left: 20, right: 20),
                child: Text(
                  title[0].toUpperCase(),
                  style: const TextStyle(
                    fontSize: 25,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              const SizedBox(width: 10),

              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    Text(
                      title,
                      style: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ],
                ),
              ),
              const Spacer(),
              Container(
                margin: const EdgeInsets.only(right: 5, bottom: 20),
                child: Text(
                  DateFormat('MMM d, yyyy').format(selectedDate),
                  style: const TextStyle(
                    fontSize: 15,
                  ),
                ),
              ),
              Column(
                crossAxisAlignment: CrossAxisAlignment.end,
                children: <Widget>[
                  Container(
                    margin: const EdgeInsets.only(right: 3),
                    width: 2,
                    height: 50,
                    color: isCompleted ? Colors.red : Colors.green,
                  ),
                ],
              ),

              const SizedBox(
                  width:
                      10), // Add some spacing to the right of the last widget
            ],
          ),
        ),
      ),
    );
  }
}
