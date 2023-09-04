"use client";

import { ChangeEvent, useEffect, useState } from "react";
import { useLoginMutation } from "@/store/auth/authApi";

import TextField from "../signup/TextField";
import { useRouter } from "next/navigation";
import { toast } from "react-toastify";

const fieldInfo: Array<Array<string>> = [
  ["text", "email", "Email"],
  ["password", "password", "Password"],
];

const SignInForm = () => {
  const router = useRouter();
  const [login, { isLoading, data, isError, isSuccess, error }] =
    useLoginMutation();
  const [credentials, setCredentials] = useState({
    email: "",
    password: "",
  });

  const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setCredentials((prevData) => ({ ...prevData, [name]: value }));
  };
  
  useEffect(() => {
    if (isSuccess) {
      localStorage.setItem("user", JSON.stringify(data));
      toast.success("Signed in successfully");
      router.push("/");
      window.location.reload()
    }
    if (error) {
      if ("status" in error) {
        const errMsg =
          "error" in error ? error.error : JSON.stringify(error?.data?.message);

        toast.error(errMsg || 'Unable to signin');
      }
    }
  }, [isError, isSuccess, data, error])

  const handleSignin = async (e) => {
    e.preventDefault();
    if (!credentials.email || !credentials.password) {
      toast.error("Please fill all fields");
      return
    }
    login(credentials);
  };

  return (
    <div className="flex flex-col text-left gap-3.5 bg-white text-white border rounded-lg p-10 w-96">
      <h2 className="text-form-gray-primary font-semibold text-3xl">Login</h2>
      <p className="text-form-gray-primary font-light mb-6">
        Hey, enter your details to sign in to your account
      </p>
      {fieldInfo.map((field) => (
        <TextField
          key={field[1]}
          type={field[0]}
          name={field[1]}
          id={field[1]}
          placeholder={field[2]}
          value={credentials[field[1]]}
          onChange={(e) => handleInputChange(e)}
        />
      ))}
      <button
        className={`btn-blue ${
          isLoading ? "opacity-60" : ""
        } py-3 px-6 mt-6 text-sm font-semibold`}
        type="button"
        onClick={(e) => handleSignin(e)}
        disabled={isLoading}
      >
        {isLoading ? "Signing in..." : "Sign in"}
      </button>
    </div>
  );
};

export default SignInForm;
