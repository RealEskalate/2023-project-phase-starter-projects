import 'package:blog_app/features/user/presentation/pages/login.dart';
import 'package:flutter/material.dart';

class SignUpWidget extends StatefulWidget {
  const SignUpWidget({Key? key}) : super(key: key);

  @override
  State<SignUpWidget> createState() => _SignUpWidgetState();
}

class _SignUpWidgetState extends State<SignUpWidget> {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();

  @override
  void dispose() {
    super.dispose();
    _usernameController.dispose();
    _passwordController.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
        padding: EdgeInsets.symmetric(horizontal: 25),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const Text('Welcome',
              style: TextStyle(
                  color: Color(0xFF0D253C),
                  fontFamily:'Urbanist-Regular',
                  fontSize: 30
              ),
            ),
            const Text('Provide Credentials to SignUp',
              style: TextStyle(
                color: Color(0xFF2D4379),
                fontFamily:'Urbanist-Bold',
                fontSize: 20,
              ),
            ),
            SizedBox(
              height: 10,
            ),
            TextField(
              controller: _usernameController,
              decoration: InputDecoration(
                labelText: 'Username',
                labelStyle: TextStyle(
                  color: Color(0xFF2D4379),
                  fontFamily:'Urbanist-Light',
                  fontSize: 18,
                ),
              ),
            ),
            TextField(
              controller: _passwordController,
              obscureText: true,
              decoration: InputDecoration(
                labelText: 'Password',
                labelStyle: TextStyle(
                  color: Color(0xFF2D4379),
                  fontFamily:'Urbanist-Light',
                  fontSize: 18,
                ),
              ),
            ),
            SizedBox(height: 100,),
            //Login button
            Center(
              child: SizedBox(
                height: 60,
                width: 295,
                child: ElevatedButton(
                  onPressed: () {},
                  style: ElevatedButton.styleFrom(
                      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
                      backgroundColor: Color(0xFF376AED)
                  ),
                  child: Text('SIGNUP',
                    style: TextStyle(
                        color: Colors.white,
                        fontFamily:'Urbanist-Bold',
                        fontSize: 16
                    ),
                  ),
                ),
              ),
            ),

            Center(
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text('Have an account?',
                    style: TextStyle(
                        color: Color(0xFF2D4379),
                        fontFamily: 'Urbanist-Bold',
                        fontSize: 14
                    ),
                  ),
                  TextButton(
                      onPressed: (){
                        setState(() {
                          Navigator.pushReplacement(
                            context,
                            MaterialPageRoute(builder: (context) => Login()), // Replace MainPage with your desired page
                          );
                        });
                      },
                      child: const Text('Login',
                        style: TextStyle(
                            color: Color(0xFF376AED),
                            fontFamily: 'Urbanist-Regular',
                            fontSize: 14
                        ),
                      )
                  ),
                ],
              ),
            ),
          ],
        )
    );
  }
}
