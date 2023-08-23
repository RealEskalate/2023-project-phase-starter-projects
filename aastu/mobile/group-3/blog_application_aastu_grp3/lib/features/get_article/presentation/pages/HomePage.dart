
import 'package:blog_application_aastu_grp3/features/get_article/presentation/pages/ArticlePage.dart';
import 'package:flutter/material.dart';

class MyHomePage extends StatelessWidget {
  const MyHomePage({super.key});
  @override
  Widget build(BuildContext context) {
    List tabsTitle = ["All", "Sport", 'Tech', "politics"];

    List blog = [
      {
        "title": "STUDETNTS SHOULD WORK ON IMPROVING THERE WRITING SKILL",
        "writer": "by John Doe",
        "date": "Jan 12,2023",
      },
    ];

    void navigate() {
      Navigator.push(context, MaterialPageRoute(builder: (ctx){
        return const ArticlePage();
      }));
    }

    return Scaffold(
      appBar: _appBar,
      body: _body(tabsTitle, blog, navigate),
      floatingActionButton: FloatingActionButton(
        onPressed: () {},
        child: const Icon(Icons.add),
      ),
    );
  }
}

AppBar _appBar = AppBar(
  elevation: 0,
  backgroundColor: Colors.transparent,
  title: Row(
    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
    crossAxisAlignment: CrossAxisAlignment.center,
    children: [
      IconButton(
        onPressed: () {},
        icon: const Icon(
          Icons.sort,
          size: 34,
        ),
      ),
      const Spacer(),
      const Text(
        'Welcome Back!',
        style: TextStyle(fontWeight: FontWeight.w600),
      ),
      const Spacer(),
      const CircleAvatar(
        radius: 25,
        backgroundColor: Colors.blue,
        // backgroundImage: AssetImage(assetName),
      ),
    ],
  ),
);

Widget _body(List tabsTitle, List blog, Function navigate) {
  return Padding(
    padding: const EdgeInsets.symmetric(horizontal: 20),
    child: Column(
      children: [
        const SizedBox(height: 20),
        Container(
          width: 500,
          height: 70,
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(15),
            boxShadow: const [
              BoxShadow(
                  color: Color(0xffb9b6b6),
                  blurStyle: BlurStyle.outer,
                  blurRadius: 5)
            ],
          ),
          child: Row(children: [
            const Expanded(
              child: Padding(
                padding: EdgeInsets.symmetric(horizontal: 7),
                child: TextField(
                  decoration: InputDecoration(
                    hintText: "Search and article . . .",
                    border: InputBorder.none,
                  ),
                ),
              ),
            ),
            Container(
              height: 70,
              width: 70,
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.circular(15),
              ),
              child: const Center(
                  child: Icon(
                Icons.search,
                color: Colors.white,
                size: 30,
              )),
            )
          ]),
        ),
        const SizedBox(height: 15),
        Center(
          child: SizedBox(
            height: 35,
            child: ListView.builder(
                scrollDirection: Axis.horizontal,
                itemCount: tabsTitle.length,
                itemBuilder: (context, index) {
                  return customButton(tabsTitle[index], false);
                }),
          ),
        ),
        const SizedBox(height: 20),
        Expanded(
          child: ListView.builder(
            itemCount: 7,
            itemBuilder: (context, index) {
              return blogTitle(
                  blog[0]["title"], blog[0]["writer"], blog[0]['date'], navigate);
            },
          ),
        ),
      ],
    ),
  );
}

Widget customButton(String text, bool active) {
  return Container(
    width: 80,
    margin: const EdgeInsets.symmetric(horizontal: 5),
    decoration: BoxDecoration(
      color: active ? Colors.blue : Colors.white,
      border: Border.all(color: Colors.blue, width: 2),
      borderRadius: BorderRadius.circular(20),
    ),
    child: Center(
      child: Text(
        text,
        style: TextStyle(color: active ? Colors.white : Colors.blue),
      ),
    ),
  );
}

Widget blogTitle(String title, String writer, String date, Function navigate) {
  return GestureDetector(
    onTap: (){
      navigate();
    },
    child: Container(
      height: 230,
      margin: const EdgeInsets.all(10),
      padding: const EdgeInsets.all(10),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(15),
      ),
      child: Column(children: [
        
        Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // image will go here
            ClipRRect(
              borderRadius: BorderRadius.circular(10),
              child: SizedBox(
                height: 160,
                width: 160,
                child: Image.network("https://picsum.photos/250?image=29"),
              ),
            ),
  
            // Title of the blog tile
            const SizedBox(width: 17),
            SizedBox(
              height: 180,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  SizedBox(
                    width: 150,
                    height: 100,
                    // Blog Title
                    child: Text(title, style: const TextStyle(fontSize: 18)),
                  ),
                  const Spacer(),
                  ElevatedButton(
                      onPressed: () {}, child: const Text('Education')),
                  const Spacer(),
                  Text(
                    writer,
                    style: const TextStyle(fontSize: 14),
                  ),
                ],
              ),
            )
          ],
        ),
        const Spacer(),
        Row(
          children: [const Spacer(), SizedBox(height: 20, child: Text(date))],
        )
      ]),
    ),
  );
}
