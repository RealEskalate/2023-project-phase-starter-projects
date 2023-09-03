"use client";

import { useEffect, useState } from "react";
import Link from "next/link";
import { useRegisterUserMutation } from "@/store/features/auth/auth-api";
import { useRouter } from "next/navigation";
import Cookies from "js-cookie";

const SignUp = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const [nameError, setNameError] = useState(" ");
  const [emailError, setEmailError] = useState(" ");
  const [passwordError, setPasswordError] = useState(" ");
  const [hasValidationError, setValidationError] = useState(true);
  const [formError, setFormError] = useState("");

  const [registerUser, { isLoading, error, isError }] =
    useRegisterUserMutation();

  const router = useRouter();

  const validateError = () => {
    if (nameError || emailError || passwordError) {
      setValidationError(true);
    } else {
      setValidationError(false);
    }
  };

  const handleNameInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    setName(e.target.value);
  };

  const handleEmailInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  };

  const handlePasswordInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  };

  const handleRegisterUser = async (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    if (!hasValidationError) {
      let res = await registerUser({ name, email, password });
      if ("error" in res) {
        if ("status" in res.error) {
          let errorData = res.error.data as { message: string };
          setFormError(errorData.message);
        } else {
          setFormError(res.error.message!);
        }
      } else {
        const currUser = {
          user: res.data.userId,
          userName: name,
          userRole: "user",
          userEmail: email,
          userProfile:
            "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
          token: res.data.token,
        };
        Cookies.set("user", JSON.stringify(currUser), {
          expires: 7,
          path: "/",
          sameSite: "none",
          secure: true,
        });
        router.push("/");
      }
    }
  };

  useEffect(()=>{
    if (/\S+@\S+\.\S+/.test(email)) {
      setEmailError("");
    } else {
      setEmailError("not valid email");
    }

  },[email])

  useEffect(()=>{
    if (password.length < 6) {
      setPasswordError("password must be atleast 6 characters");
    } else {
      setPasswordError("");
    }
  },[password])

  useEffect(()=>{
    if (name.length < 3) {
      setNameError("name must be atleast 3 characters");
    } else {
      setNameError("");
    }
  },[name])

  useEffect(()=>{
    validateError()
  },[nameError,passwordError,emailError])
  
  return (
    <main className="flex w-full mt-24">
      <div className="hidden md:block w-1/2 pl-12">
        <img
          src="./images/signup/a2sv-logo.svg"
          alt="a2sv logo"
          className="m-8"
        />
        <div className="flex items-start justify-center w-max">
          <img
            src="./images/signup/person.svg"
            alt="person illustration"
            className="w-80 my-16"
          />
          <div className="mt-48">
            <h2 className="font-poppins text-6xl font-bold text-gray-800 w-64">
              Welcome to A2SV
            </h2>
            <p className="text-wrap text-gray-600 w-72">
              Register for free to receive blogs and learn more about A2SV
            </p>
          </div>
        </div>
      </div>
      <div className="flex flex-col items-center w-full md:w-1/2 bg-primary p-10 pb-32">
        <Link
          href="/signin"
          className="text-white text-right px-10 w-full font-semibold"
        >
          Sign in
        </Link>
        <div className="bg-white rounded-lg h-full w-96 px-16 py-16 mt-16 mx-32">
          <h1 className="text-4xl font-poppins font-semibold text-gray-800 mb-3">
            Sign up
          </h1>
          <p className="text-gray-500 mb-8">Hey, Enter details to sign up</p>
          <form action="" className="flex flex-col h-full">
            <div className="relative">
              {nameError && (
                <p className="text-sm text-red-600 absolute -top-6">
                  {nameError}
                </p>
              )}
              <input
                type="text"
                value={name}
                placeholder="Full Name"
                className="h-12 mb-5 bg-gray-200 rounded p-2 w-full"
                onChange={handleNameInput}
              />
            </div>
            <div className="relative">
              {emailError && (
                <p className="text-sm text-red-600 absolute -top-6">
                  {emailError}
                </p>
              )}
              <input
                type="text"
                value={email}
                placeholder="Email address"
                className="h-12 mb-5 bg-gray-200 rounded p-2 w-full"
                onChange={handleEmailInput}
              />
            </div>
            <div className="relative">
              {passwordError && (
                <p className="text-sm text-red-600 absolute -top-6">
                  {passwordError}
                </p>
              )}
              <input
                type="password"
                value={password}
                placeholder="Password"
                className="h-12 mb-10 bg-gray-200 rounded p-2 w-full"
                onChange={handlePasswordInput}
              />
            </div>
            <div className="relative">
              {formError && (
                <p className="text-sm text-red-600 absolute -top-6">
                  {formError}
                </p>
              )}
              <button
                className={`${
                  hasValidationError || isLoading ? "bg-gray-500" : "bg-primary"
                } font-semibold h-12 mb-5 rounded text-white w-full`}
                disabled={isLoading || hasValidationError}
                onClick={handleRegisterUser}
              >
                Sign up
              </button>
            </div>
          </form>
        </div>
      </div>
    </main>
  );
};

export default SignUp;
