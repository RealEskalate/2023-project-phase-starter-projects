import 'TaskManager.dart';
import 'dart:io';
void main(){
 

  TaskManagement taskManagement = new TaskManagement();
  while(true){
    print("1. Add Task");
    print("2. Delete Task");
    print("3. Update Task");
    print("4. Show Task");
    print("5. Show Completed Task");
    print("6. Show Pending Task");
    print("7. Exit");
    print("Enter your choice: ");
    String? choice1 = (stdin.readLineSync());
    int choice = int.parse(choice1!);
    if(choice == 1){
      print("Enter title: ");
      String? title = stdin.readLineSync();
      print("Enter description: ");
      String? description = stdin.readLineSync();
      print("Enter deadline: ");
      String? deadline = stdin.readLineSync();
      print("Enter status: ");

      String? status = (stdin.readLineSync());
      taskManagement.addTask(title, description, deadline, status);
    }
    else if(choice == 2){
      print("Enter title: ");
      String? title = stdin.readLineSync();
      taskManagement.deleteTask(title);
    }
    else if(choice == 3){
      print("Enter title: ");
      String? title = stdin.readLineSync();
      print("Enter new title: ");
      String? newTitle = stdin.readLineSync();
      print("Enter new description: ");
      String? newDescription = stdin.readLineSync();
      print("Enter new deadline: ");
      String? newDeadline = stdin.readLineSync();
      print("Enter new status: ");
      String? newStatus = stdin.readLineSync();
      taskManagement.updateTask(title, newTitle, newDescription, newDeadline, newStatus);
    }
    else if(choice == 4){
      taskManagement.showTask();
    }
    else if(choice == 5){
      taskManagement.showCopletedTask();
    }
    else if(choice == 6){
      taskManagement.showPendingTask();
    }
    else if(choice == 7){
      break;
    }
    else{
      print("Invalid choice");
    }
  }

}