import '../../../domain/entities/todo.dart';
import '../todo_state.dart';

class LoadedSingleTaskState extends TodoState {
  final Todo task;

  const LoadedSingleTaskState(this.task);

  @override
  List<Object> get props => [task];
}
// delete task state

class DeletedTaskState extends TodoState {
  @override
  List<Object> get props => [];
}
