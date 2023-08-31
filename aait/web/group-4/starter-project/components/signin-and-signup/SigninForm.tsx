"use client";

import { ChangeEvent, useState } from "react";
import { useRouter } from "next/navigation";
import { useDispatch } from "react-redux";

import { useLoginMutation } from "@/store/features/auth";
import TextField from "./TextField";
import { setUser } from "@/store/features/user/user-slice";
import { AppDispatch } from "@/store";
import { toast } from "react-toastify";
import { AiOutlineLoading3Quarters } from "react-icons/ai";

const fieldInfo: Array<Array<string>> = [
  ["text", "email", "Email"],
  ["password", "password", "Password"],
];

const SignInForm = () => {
  const router = useRouter();
  const [loginUser, loginResult] = useLoginMutation();
  const [formData, setFormData] = useState<{
    email: string;
    password: string;
  }>({
    email: "",
    password: "",
  });

  const dispatch = useDispatch<AppDispatch>();

  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSignin = async() => {
    const user = await loginUser(formData).unwrap()

    dispatch(setUser(user));

    toast("Logged in Successfully!", {
      type: "success",
    });

    router.push("/profile");
    if (loginResult.isError) {
      toast("Error during Login", {
        type: "error",
      });
    }
  };

  return (
    <div
      className={`${
        loginResult.isLoading && "blur"
      } flex flex-col text-left gap-6 bg-white text-gray-500 font-login border-0 rounded-lg md:px-14 px-10 pt-10 pb-10 w-full`}
    >
      {loginResult.isLoading && (
        <div className="absolute top-1/2 left-1/2 flex justify-center items-center">
          <AiOutlineLoading3Quarters className="w-20 h-20 animate-spin text-primary-color" />
        </div>
      )}

      <h2 className="text-4xl font-bold text-[#434343]">Login</h2>
      <p className="text-[#8A8A8A] text-xl mb-6">
        Hey, enter your details to sign in to your account
      </p>
      {fieldInfo.map((field) => (
        <TextField
          key={field[1]}
          type={field[0]}
          name={field[1]}
          id={field[1]}
          placeholder={field[2]}
          value={formData[`${field[1]}`]}
          onChange={handleInputChange}
        />
      ))}

      <button
        className="mt-8 rounded-lg border-0 p-4 bg-primary-color  text-white"
        onClick={handleSignin}
      >
        Sign in
      </button>
    </div>
  );
};

export default SignInForm;
