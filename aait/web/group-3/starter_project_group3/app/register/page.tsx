"use client";
import Toast from "@/components/toast-Messages/toast-message";
import { useRegisterMutation } from "@/store/features/auth";
import { useRouter } from "next/navigation";
import React, { useState } from "react";

const Register: React.FC = () => {
  const router = useRouter();
  const [name, setName] = useState("");
  const [email, setemail] = useState("");
  const [password, setpassword] = useState("");
  const [errorMessage, seterrorMessage] = useState("");
  const [isLoggedIN, setisLoggedIN] = useState(false);

  const [register, { isLoading, isError, data }] = useRegisterMutation();

  const handleLogin = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault(); 
    register({ name, email, password })
      .unwrap()
      .then((response) => {
        if (typeof window !== 'undefined'){
        localStorage.setItem("user", JSON.stringify(response));
        router.push("/login");
        setisLoggedIN(true);}
      })
      .catch((err:any) => {
        seterrorMessage(err?.data?.message);
      });
  };

  return (
    <>
      {isLoggedIN && (
        <Toast message="Congratulations, Successfully registed, login here"  isError={false}/>
      )}

      <div className="flex flex-col items-center justify-center py-5 w-8/12 my-10 mx-auto rounded-lg font-Montserrat bg-gray-100">
        <div className=" p-8 rounded">
          <h2 className="text-2xl text-nav_text_color font-bold mb-4">
            Register
          </h2>
          <form onSubmit={handleLogin}>
            {/* name */}
            <div className="mb-4">
              <label
                htmlFor="name"
                className="block text-gray-700 font-medium mb-2"
              >
                Full Name
              </label>
              <input
                type="text"
                value={name}
                onChange={(e) => setName(e.target.value)}
                id="name"
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your name"
              />
            </div>

            {/* email */}
            <div className="mb-4">
              <label
                htmlFor="email"
                className="block text-gray-700 font-medium mb-2"
              >
                Email
              </label>
              <input
                type="email"
                value={email}
                onChange={(e) => setemail(e.target.value)}
                id="email"
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your email"
              />
            </div>

            {/* password */}
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
                value={password}
                onChange={(e) => setpassword(e.target.value)}
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your password"
              />
            </div>
            <button
              type="submit"
              className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:bg-blue-600"
            >
              {isLoading ? "Processessing" : "Sign Up"}
            </button>
            {isError && (<Toast message={errorMessage} isError={true}/>)}
          </form>
        </div>
      </div>
    </>
  );
};

export default Register;
