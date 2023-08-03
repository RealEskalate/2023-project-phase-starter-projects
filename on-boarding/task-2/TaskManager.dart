import "Task.dart";

class TaskManagement{
  List<Task> tasks = [];

  void addTask(title, description, deadline, status){
    Task task = new Task(title, description, deadline, status);
    tasks.add(task);
    
  }

  void deleteTask(title){
    
    for (var task in tasks) {
      if(task.title == title){
        tasks.remove(task);
      }
    }
  }

  void updateTask(title, newTtitle, newDescription, newDeadline, newStatus){
    
    for (var task in tasks) {
      if(task.title == title){
        task.title = newTtitle;
        task.description = newDescription;
        task.deadline = newDeadline;
        task.status = newStatus;
      }
    }
  }

  void showTask(){
   

    for (var task in tasks) {
      print(task.title);
      print(task.description);
      print(task.deadline);
      print(task.status);
    }
    
  }

  void showCopletedTask(){
    for (var task in tasks) {
      if(task.status == "completed"){
        print(task.title);
        print(task.description);
        print(task.deadline);
        print(task.status);
      }
    }
  }

  void showPendingTask(){
    for (var task in tasks) {
      if(task.status == "pending"){
        print(task.title);
        print(task.description);
        print(task.deadline);
        print(task.status);
      }
    }

  }
}

