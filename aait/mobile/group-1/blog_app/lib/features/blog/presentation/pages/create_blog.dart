import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../user_profile/presentation/bloc/profile_bloc.dart';

class CreateBlogPage extends StatefulWidget {
  const CreateBlogPage({super.key});

  @override
  State<CreateBlogPage> createState() => _CreateBlogPageState();
}

class _CreateBlogPageState extends State<CreateBlogPage> {
  @override
  void initState() {
    BlocProvider.of<ProfileBloc>(context).add(GetProfileInfo());
    super.initState();
  }

  List<String> tags = [
    "Sports",
    "Tech",
    "Politics",
    "Art",
    "Design",
    "Culture",
    "Production",
    "Others",
  ];
  // List<bool> selected = List.generate(tags.length, (index) => false);
  Map<String, bool> tagsMap = {
    "Sports": false,
    "Tech": false,
    "Politics": false,
    "Art": false,
    "Design": false,
    "Culture": false,
    "Production": false,
    "Others": false,
  };

  @override
  Widget build(BuildContext context) {
    bool tonalSelected = true;

    final formKey = GlobalKey<FormState>();

    final titleController = TextEditingController();
    final subTitleController = TextEditingController();
    final articleContent = TextEditingController();
    return Scaffold(
      body: BlocBuilder<ProfileBloc, ProfileState>(
        builder: (context, state) {
          if ((state is Loaded)) {
            return SafeArea(
              child: Container(
                padding: const EdgeInsets.all(25),
                height: MediaQuery.of(context).size.height,
                child: ListView(
                  children: [
                    Row(
                      children: [
                        IconButton.filledTonal(
                          isSelected: tonalSelected,
                          icon: const Icon(Icons.arrow_back_ios_new_rounded),
                          onPressed: () {
                            Navigator.of(context).pop();
                          },
                        ),
                        SizedBox(
                          width: MediaQuery.of(context).size.width * 0.1,
                        ),
                        const Text(
                          "New Article",
                          style: TextStyle(
                              fontSize: 23, fontWeight: FontWeight.w600),
                        ),
                      ],
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          vertical: 7, horizontal: 15),
                      child: TextFormField(
                        controller: titleController,
                        keyboardType: TextInputType.name,
                        decoration: const InputDecoration(
                          hintText: "Add title",
                          hintStyle: TextStyle(
                              color: Colors.grey,
                              fontSize: 20.0,
                              fontWeight: FontWeight.w300),
                        ),
                        style: const TextStyle(
                            color: Colors.black,
                            fontSize: 22.0,
                            fontWeight: FontWeight.w500),
                        validator: (String? name) {
                          if (name == null || name.isEmpty) {
                            return "Name can not be empty";
                          }
                          return null;
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          vertical: 7, horizontal: 15),
                      child: TextFormField(
                        controller: subTitleController,
                        keyboardType: TextInputType.name,
                        decoration: const InputDecoration(
                          hintText: "Add subtitle",
                          hintStyle: TextStyle(
                              color: Colors.grey,
                              fontSize: 20.0,
                              fontWeight: FontWeight.w300),
                        ),
                        style: const TextStyle(
                            color: Colors.black,
                            fontSize: 21.0,
                            fontWeight: FontWeight.w400),
                        validator: (String? name) {
                          if (name == null || name.isEmpty) {
                            return "Name can not be empty";
                          }
                          return null;
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          vertical: 7, horizontal: 15),
                      child: Wrap(
                          spacing: 8.0,
                          runSpacing: 4.0,
                          children: List.generate(tags.length, (index) {
                            return ChoiceChip(
                              label: Text(tags[index]),
                              selected: tagsMap[tags[index]]!,
                              onSelected: (isSelected) {
                                setState(() {
                                  tagsMap[tags[index]] = isSelected;
                                });
                              },
                              elevation: 0,
                              backgroundColor: tagsMap[tags[index]]!
                                  ? const Color(0xFF376AED)
                                  : Colors.grey[300],
                              selectedColor: const Color(0xFF376AED),
                              labelStyle: TextStyle(
                                color: tagsMap[tags[index]]!
                                    ? Colors.white
                                    : Colors.black,
                              ),
                            );
                          })),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          vertical: 7, horizontal: 15),
                      child: TextFormField(
                        controller: articleContent,
                        maxLines: 11,
                        keyboardType: TextInputType.name,
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(
                              borderRadius:
                                  BorderRadius.all(Radius.circular(10.0)),
                              borderSide:
                                  BorderSide(color: Colors.grey, width: 0)),
                          hintText: "article content",
                          hintStyle: TextStyle(
                              color: Colors.grey,
                              fontSize: 17.0,
                              fontWeight: FontWeight.w300),
                        ),
                        style: const TextStyle(
                            // Style for input text
                            color: Colors.black, // Color of input text
                            fontSize: 19.0,
                            fontWeight:
                                FontWeight.w400 // Font size of input text
                            ),
                        validator: (String? name) {
                          if (name == null || name.isEmpty) {
                            return "Name can not be empty";
                          }
                          return null;
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          vertical: 10, horizontal: 15),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          const SizedBox(),
                          ElevatedButton(
                            onPressed: () async {
                              final formValid =
                                  formKey.currentState?.validate();
                              if (formValid != null && !formValid) {
                                return;
                              }
                            },
                            style: ButtonStyle(
                              backgroundColor: MaterialStateProperty.all<Color>(
                                  const Color(0xFF376AED)),
                              shape: MaterialStateProperty.all<
                                  RoundedRectangleBorder>(
                                const RoundedRectangleBorder(
                                  borderRadius:
                                      BorderRadius.all(Radius.circular(50)),
                                ),
                              ),
                            ),
                            child: const Padding(
                              padding: EdgeInsets.symmetric(
                                  vertical: 8.0, horizontal: 15.0),
                              child: Text(
                                style: TextStyle(
                                    fontSize: 17, color: Colors.white),
                                "Publish",
                              ),
                            ),
                          ),
                          const SizedBox()
                        ],
                      ),
                    )
                  ],
                ),
              ),
            );
          } else if (state is Loading) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          } else {
            return Center(
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text("Error occured. Please try again later."),
                  IconButton(
                      onPressed: () {
                        Navigator.pop(context);
                      },
                      icon: Icon(Icons.arrow_back_ios_new_rounded))
                ],
              ),
            );
          }
        },
      ),
    );
  }
}
