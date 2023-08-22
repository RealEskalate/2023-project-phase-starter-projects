import 'package:blog_application/features/blog/presentation/bloc/create_task/create_task_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class CreateTaskScreen extends StatelessWidget {
  CreateTaskScreen({super.key});
  final ScrollController? _scrollController = ScrollController();
  TextEditingController titleController = TextEditingController();
  TextEditingController subtitleController = TextEditingController();
  TextEditingController tagController = TextEditingController();
  TextEditingController contentController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    bool keyboardIsOpen = MediaQuery.of(context).viewInsets.bottom != 0;

    return BlocProvider(
      create: (context) => CreateTaskCubit(),
      child: Scaffold(
        backgroundColor: Colors.white,
        appBar: AppBar(
            backgroundColor: Colors.white,
            centerTitle: true,
            leading: Container(
              padding: EdgeInsets.all(8.0),
              child: IconButton(
                  style: ButtonStyle(
                      padding:
                          MaterialStateProperty.all(const EdgeInsets.all(6.0)),
                      minimumSize: MaterialStateProperty.all(const Size(0, 0)),
                      backgroundColor:
                          MaterialStateProperty.all(const Color(0xFFE9EBF0)),
                      shape: MaterialStateProperty.all(
                          const RoundedRectangleBorder(
                        borderRadius: BorderRadius.all(Radius.circular(8.0)),
                      ))),
                  icon: const Icon(Icons.arrow_back_ios_new),
                  onPressed: () => Navigator.of(context).pop()),
            ),
            title: const Text('New Article')),
        body: SingleChildScrollView(
          controller: _scrollController,
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 24.0),
            child: BlocBuilder<CreateTaskCubit, CreateTaskState>(
                builder: (context, state) {
              inputDecoration(String val, [String? error]) => InputDecoration(
                    errorText: error,
                    hintText: val,
                    hintStyle: const TextStyle(
                      color: Color(0xFF969DA4),
                      fontSize: 19,
                      fontWeight: FontWeight.w300,
                    ),
                  );
              var contentFieldDecoration = InputDecoration(
                  errorText: state.content.error?.message,
                  filled: true,
                  fillColor: const Color(0xFFF8FAFF),
                  hintText: 'Add Content',
                  hintStyle: const TextStyle(
                    color: Color(0xFF969DA4),
                    fontSize: 19,
                    fontWeight: FontWeight.w300,
                  ),
                  border: const OutlineInputBorder(
                    borderRadius: BorderRadius.all(Radius.circular(10)),
                  ));
              return Form(
                child: Container(
                  height: MediaQuery.of(context).size.height * 0.8,
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const SizedBox(
                        height: 40,
                      ),
                      TextFormField(
                        key: const Key("add_title"),
                        onChanged: (val) {
                          context.read<CreateTaskCubit>().titleChanged(val);
                        },
                        controller: titleController,
                        decoration: inputDecoration(
                            "Add Title", state.title.error?.message),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      TextFormField(
                        key: const Key('add_subtitle'),
                        controller: subtitleController,
                        onChanged: (val) {
                          context.read<CreateTaskCubit>().subtitleChanged(val);
                        },
                        decoration: inputDecoration(
                            "Add Subtitle", state.subtitle.error?.message),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      Row(
                        children: [
                          Expanded(
                            child: TextFormField(
                              controller: tagController,
                              onChanged: (val) {
                                context.read<CreateTaskCubit>().tagChanged(val);
                              },
                              key: const Key("add_tag"),
                              decoration: inputDecoration("Add Tag"),
                            ),
                          ),
                          IconButton(
                              iconSize: 36,
                              color: Theme.of(context).colorScheme.primary,
                              icon: const Icon(Icons.add_circle_outline),
                              onPressed: () {
                                context.read<CreateTaskCubit>().addTag();
                                tagController.text = '';
                              })
                        ],
                      ),
                      const Text(
                        'add as many tags as you want',
                        textAlign: TextAlign.start,
                        style: TextStyle(
                          color: Color(0xFF969DA4),
                          fontSize: 11,
                          fontWeight: FontWeight.w300,
                        ),
                      ),
                      Column(children: [
                        Wrap(
                          children: [
                            ...state.tags.map((tag) {
                              return TagChip(
                                title: tag,
                                onDelete: () {
                                  context
                                      .read<CreateTaskCubit>()
                                      .removeTag(state.tags.indexOf(tag));
                                },
                              );
                            })
                          ],
                        ),
                      ]),
                      const SizedBox(
                        height: 50,
                      ),
                      Expanded(
                        flex: 2,
                        child: TextFormField(
                          onChanged: (val) {
                            context.read<CreateTaskCubit>().contentChanged(val);
                          },
                          textAlignVertical: TextAlignVertical.top,
                          expands: true,
                          minLines: null,
                          keyboardType: TextInputType.multiline,
                          maxLines: null,
                          decoration: contentFieldDecoration,
                        ),
                      )
                    ],
                  ),
                ),
              );
            }),
          ),
        ),
        floatingActionButton: Visibility(
          visible: !keyboardIsOpen,
          child: FilledButton(
              onPressed: () {
                context.read<CreateTaskCubit>().publish();
              },
              child: const Text('publish',
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15))),
        ),
        floatingActionButtonLocation: FloatingActionButtonLocation.centerFloat,
      ),
    );
  }
}

class TagChip extends StatelessWidget {
  String title;
  // define a function variable onDelete
  final void Function()? onDelete;
  TagChip({
    super.key,
    required this.title,
    required this.onDelete,
  });

  @override
  Widget build(BuildContext context) {
    return Chip(
      labelStyle: TextStyle(color: Theme.of(context).colorScheme.primary),
      side: BorderSide(width: 2, color: Theme.of(context).colorScheme.primary),
      label: Text(title),
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(75),
      ),
      deleteIcon: Icon(
        Icons.close,
        color: Theme.of(context).colorScheme.primary,
      ),
      onDeleted: onDelete,
    );
  }
}
