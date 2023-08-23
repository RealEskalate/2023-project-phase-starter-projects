import 'package:flutter/material.dart';
import 'package:blog_app/features/onboarding/widgets/login_widget.dart';
import 'package:blog_app/features/onboarding/widgets/SignUp_widget.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
  int activeIndex = 0;
 final List<Widget> AuthWidgets = [
   LoginWidget(),
   SignUpWidget()
 ];
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Stack(
              children: [
                Container(
                  width: double.infinity,
                  height: 300,
                  decoration: BoxDecoration(color: Colors.white),
                  child: Center(
                    child: Container(
                        width: 141,
                        height: 54,
                        margin: EdgeInsets.only(bottom: 50),
                        child: Image.asset('assets/images/A2SV Blue 2.png'),
                    ),
                  ),
                ),
                Positioned(
                  top: 200,
                  child: Container(
                    alignment: Alignment(0, 0),
                    width: MediaQuery.of(context).size.width,
                    height: 120,
                    decoration: BoxDecoration(
                      color: Color(0xFF376AED),
                      borderRadius: BorderRadius.only(
                        topLeft: Radius.circular(20),
                        topRight: Radius.circular(20),
                      ),
                    ),
                    child: Container(
                      margin: EdgeInsets.only(bottom: 40),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          TextButton(
                              onPressed: (){
                                setState(() {
                                   activeIndex = 0;
                                });
                              },
                              child: Text('LOGIN',
                              style: TextStyle(
                                color: activeIndex == 0 ? Colors.white : Colors.grey,
                                fontFamily:'Urbanist-Bold',
                                fontSize: 18
                              ),
                              )
                          ),
                          SizedBox(width: 50,),
                          TextButton(
                              onPressed: (){
                                setState(() {
                                  activeIndex = 1;
                                });
                              },
                              child: Text('SIGN UP',
                                style: TextStyle(
                                    color: activeIndex == 1 ? Colors.white : Colors.grey,
                                    fontFamily:'Urbanist-Bold',
                                    fontSize: 18
                                ),
                              )
                          ),
                        ],
                      ),
                    ),
                  ),
                ),
                Positioned(
                  top: 270,
                  child: Container(
                    alignment: Alignment(0, 0),
                    width: MediaQuery.of(context).size.width,
                    height: 200,
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.only(
                        topLeft: Radius.circular(20),
                        topRight: Radius.circular(20),
                      ),
                    ),
                  ),
                ),
              ],
            ),
            Container(
              child: AuthWidgets[activeIndex],
            ),
          ],
        ),
      ),
    );
  }
}
