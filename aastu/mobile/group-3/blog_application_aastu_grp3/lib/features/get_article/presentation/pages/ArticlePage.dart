import 'package:flutter/material.dart';

class ArticlePage extends StatelessWidget {
  const ArticlePage({super.key});

  @override
  Widget build(BuildContext context) {
    String text =
        """ That marked a turnaround from last year, when the social network reported a decline in users for the first time. The drop wiped billions from the firm's market value. Since executives disclosed the fall in February, the firm's share price has nearly halved. But shares jumped 19% in after-hours trade on Wednesday.
        That marked a turnaround from last year, when the social network reported a decline in users for the first time. The drop wiped billions from the firm's market value. Since executives disclosed the fall in February, the firm's share price has nearly halved. But shares jumped 19% in after-hours trade on Wednesday.
        That marked a turnaround from last year, when the social network reported a decline in users for the first time. The drop wiped billions from the firm's market value. Since executives disclosed the fall in February, the firm's share price has nearly halved. But shares jumped 19% in after-hours trade on Wednesday.
""";
    double deviceWidth = MediaQuery.sizeOf(context).width;
    return Scaffold(
      appBar: _appBar,
      body: _articleBody(text, deviceWidth),
      floatingActionButton: Padding(
        padding: const EdgeInsets.all(8.0),
        child: GestureDetector(
          onTap: () {},
          child: DecoratedBox(
            decoration: BoxDecoration(
              color: Colors.blue,
              borderRadius: BorderRadius.circular(15),
            ),
            child: const SizedBox(
              width: 70,
              height: 50,
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Text(
                    '2.5k',
                    style: TextStyle(color: Colors.white),
                  ),
                  Icon(
                    Icons.thumb_up_alt,
                    color: Colors.white,
                  )
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}

AppBar _appBar = AppBar(
  automaticallyImplyLeading: false,
  title: Row(
    mainAxisAlignment: MainAxisAlignment.spaceBetween,
    children: [
      IconButton(
        icon: const Icon(
          Icons.arrow_back_ios_new_rounded,
          size: 32,
        ),
        onPressed: () {},
      ),
      IconButton(
          onPressed: () {},
          icon: const Icon(
            Icons.more_horiz,
            size: 32,
          ))
    ],
  ),
);

Widget _articleBody(String text, double deviceWidth) {
  return Column(
    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
    children: [
      Padding(
        padding: const EdgeInsets.symmetric(horizontal: 30),
        child: Column(
          children: [
            const SizedBox(
              height: 80,
              child: Text(
                "Four Things Everyone Needs To Know",
                style: TextStyle(
                  fontSize: 28,
                  fontWeight: FontWeight.w600,
                  color: Color(0xff0d253c),
                ),
              ),
            ),
            ListTile(
              leading: ClipRRect(
                borderRadius: BorderRadius.circular(15),
                child: SizedBox(
                  height: 50,
                  width: 50,
                  child: Image.network("https://picsum.photos/500?image=29",
                      fit: BoxFit.cover),
                ),
              ),
              title: const Text('Richard Gervain'),
              subtitle: const Text('2m ago',
                  style: TextStyle(
                      color: Colors.grey, fontWeight: FontWeight.w600)),
              trailing: IconButton(
                icon: const Icon(Icons.bookmark_border_outlined),
                onPressed: () {},
              ),
            ),
            const SizedBox(height: 5)
          ],
        ),
      ),
      Expanded(
        child: ListView(
          children: [
            ClipRRect(
              borderRadius: const BorderRadius.only(
                  topLeft: Radius.circular(15), topRight: Radius.circular(15)),
              child: SizedBox(
                height: 219,
                width: deviceWidth,
                child: Image.network("https://picsum.photos/500?image=29",
                    fit: BoxFit.cover),
              ),
            ),
            const SizedBox(
              height: 10,
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 25),
              child: Text(
                text,
                style: const TextStyle(fontSize: 16),
              ),
            )
          ],
        ),
      ),
    ],
  );
}
