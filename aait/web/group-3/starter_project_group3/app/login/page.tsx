"use client";
import Footer from "@/components/footer/Footer";
import { useLoginMutation } from "@/store/features/auth";
import { authTypes } from "@/types/auth/authTypes";
import React, { useEffect, useState } from "react";

const LogIn: React.FC = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, seterrorMessage] = useState("");

  const [login, { isLoading, isError, data }] = useLoginMutation();

  const handleLogin = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault(); 
    login({ email, password })
      .unwrap()
      .then((response: any) => {
        console.log("log in success", response);
        localStorage.setItem("user", JSON.stringify(response));
        window.location.href = "/";
      })
      .catch((err) => {
        seterrorMessage(err.data.message);
        console.error("Login error", err);
      });
  };

  // useEffect(() => {
  //   const userString = localStorage.getItem("user");
  //   const user: authTypes | null = userString ? JSON.parse(userString) : null;
  //   console.log(user?.token);

  // }, []);

  return (
    <>
      <div className="flex flex-col items-center justify-center py-10 w-8/12 mx-auto rounded-lg my-10 font-Montserrat bg-gray-100">
        <div className=" p-8 rounded">
          <h2 className="text-2xl font-bold text-nav_text_color mb-4">Login</h2>
          <form onSubmit={handleLogin}>
            <div className="mb-4">
              <label
                htmlFor="email"
                className="block text-gray-700 font-medium mb-2"
              >
                Email
              </label>
              <input
                type="email"
                id="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your email"
              />
            </div>
            <div className="mb-4">
              <label
                htmlFor="password"
                className="block text-gray-700 font-medium mb-2"
              >
                Password
              </label>
              <input
                type="password"
                id="password"
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
            <button
              type="submit"
              disabled={isLoading}
              className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:bg-blue-600"
            >
              {isLoading ? "Logging in..." : "Log In"}
            </button>
            {isError ? errorMessage : ""}
          </form>
        </div>
      </div>

      <Footer />
    </>
  );
};

export default LogIn;