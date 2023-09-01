"use client";

import { useEffect, useState } from "react";
import Link from "next/link";
import { useLoginUserMutation } from "@/store/features/auth/auth-api";
import { useRouter } from "next/navigation";
import Cookies from "js-cookie";

const Signin = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [emailError, setEmailError] = useState(" ");
  const [passwordError, setPasswordError] = useState(" ");
  const [hasValidationError, setValidationError] = useState(true);
  const [formError, setFormError] = useState("");

  const [loginUser, { isLoading }] = useLoginUserMutation();

  const router = useRouter();

  const validateError = () => {
    if (emailError || passwordError) {
      setValidationError(true);
    } else {
      setValidationError(false);
    }
  };

  const passwordValidator = () => {
    if (password.length < 6) {
      setPasswordError("password must be atleast 6 characters");
    } else {
      setPasswordError("");
    }
  };

  const emailValidator = () => {
    if (/\S+@\S+\.\S+/.test(email)) {
      setEmailError("");
    } else {
      setEmailError("not valid email");
    }
  };
  const handleEmailInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  };

  const handlePasswordInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  };

  const handleLoginUser = async (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    if (!hasValidationError) {
      const res = await loginUser({ email, password });
      if ("error" in res) {
        if ("status" in res.error) {
          let errorData = res.error.data as { message: string };
          setFormError(errorData.message);
        } else {
          setFormError(res.error.message!);
        }
      } else {
        Cookies.set("user", JSON.stringify(res.data), {
          expires: 7,
          path: "/",
          sameSite: "none",
          secure: true,
        });
        router.push("/");
      }
    }
  };

  useEffect(() => {
    emailValidator();
  }, [email]);

  useEffect(() => {
    passwordValidator();
  }, [password]);

  useEffect(() => {
    validateError();
  }, [emailError, passwordError]);

  return (
    <main className="flex w-full mt-16">
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
              Welcome back
            </h2>
            <p className="text-wrap text-gray-600 w-72">
              Login to receive blogs and learn more about A2SV
            </p>
          </div>
        </div>
      </div>
      <div className="flex flex-col items-center w-full md:w-1/2 bg-primary p-10 pb-32 min-h-screen">
        <Link
          href="/signup"
          className="text-white text-right px-10 w-full font-semibold"
        >
          Sign up
        </Link>
        <div className="bg-white rounded-lg h-full w-96 px-16 py-16 mt-16 mx-32">
          <h1 className="text-4xl font-poppins font-semibold text-gray-800 mb-3">
            Login
          </h1>
          <p className="text-gray-500 mb-8 w-5/6">
            Hey, Enter details to sign in to your account
          </p>
          <form action="" className="flex flex-col h-full">
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
                onClick={handleLoginUser}
              >
                Login
              </button>
            </div>
          </form>
        </div>
      </div>
    </main>
  );
};

export default Signin;
