import 'package:blog_app/features/blog/presentation/widgets/blog_list_card.dart';
import 'package:blog_app/features/blog/presentation/widgets/home_app_bar.dart';
import 'package:flutter/material.dart';
import 'package:blog_app/core/utils/my_colors.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});
  @override
  HomeScreenState createState() => HomeScreenState();
}

class Blog {
  late String image;
  late String title;
  late String subtitle;
  late String date;
}

class HomeScreenState extends State<HomeScreen>
    with SingleTickerProviderStateMixin {
  TabController? _tabController;
  final TextEditingController inputController = TextEditingController();

  @override
  void initState() {
    _tabController = TabController(length: 4, vsync: this);
    super.initState();
  }

  @override
  void dispose() {
    _tabController!.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: getHomeAppBar(),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Card(
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(3),
              ),
              clipBehavior: Clip.antiAliasWithSaveLayer,
              elevation: 1,
              child: Row(
                children: <Widget>[
                  Container(
                    width: 10,
                  ),
                  Expanded(
                    child: TextField(
                      maxLines: 1,
                      controller: inputController,
                      style: TextStyle(color: Colors.grey[600], fontSize: 18),
                      keyboardType: TextInputType.text,
                      decoration: const InputDecoration(
                        border: InputBorder.none,
                        hintText: 'Search Locations',
                        hintStyle: TextStyle(fontSize: 16.0),
                      ),
                    ),
                  ),
                  IconButton(
                      icon: Icon(Icons.search, color: Colors.grey[600]),
                      onPressed: () {
                        inputController.clear();
                        setState(() {});
                      }),
                ],
              ),
            ),
          ),
          TabBar(
            indicatorSize: TabBarIndicatorSize.tab,
            isScrollable: true,
            indicatorPadding: const EdgeInsets.symmetric(vertical: 6),
            labelColor: Colors.white,
            unselectedLabelColor: MyColors.grey_60,
            indicator: BoxDecoration(
                color: Colors.lightGreen,
                borderRadius: BorderRadius.circular(20)),
            tabs: const [
              SizedBox(
                width: 70,
                child: Tab(text: "All"),
              ),
              SizedBox(
                width: 70,
                child: Tab(text: "Trending"),
              ),
              SizedBox(
                width: 70,
                child: Tab(text: "New"),
              ),
              SizedBox(
                width: 70,
                child: Tab(text: "Featured"),
              )
            ],
            controller: _tabController,
          ),
          ListView.builder(
            itemBuilder: (BuildContext context, int index) => const ItemTile(),
            itemCount: 3,
          ),
        ],
      ),
    );
  }
}
