"use client";

import { ChangeEvent, useState } from "react";
import { useRouter } from "next/navigation";
import { useDispatch, useSelector } from "react-redux";

import { useLoginMutation } from "@/store/features/auth";
import TextField from "./TextField";
import { setUser } from "@/store/features/user/user-slice";
import { AppDispatch, RootState } from "@/store";
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
  const message = useSelector((state: RootState) => state.user.message);
  const dispatch = useDispatch<AppDispatch>();

  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSignin = () => {
    loginUser(formData);

    if (loginResult.isSuccess) {
      const result = loginResult.data;
      dispatch(setUser(result));

      toast(message);
      router.push("/profile")

    }
    else if(loginResult.isError){
        toast("Error during Login", {
            type: "error"
        })
    }
  };

  return (
    <div className=" relative flex flex-col text-left gap-6 bg-white text-gray-500 font-login border-0 rounded-lg md:px-14 px-10 pt-10 pb-10 w-full">
      {loginResult.isLoading && (
        <div className="absolute top-1/2 left-1/2 flex justify-center items-center">
          <AiOutlineLoading3Quarters className="w-20 h-20 animate-spin text-primary-color" />
        </div>
      )}

      <h2 className="text-[1.5rem] font-bold text-black">Login</h2>
      <p className="text-[0.9] mb-6">
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
        disabled={loginResult.isLoading}
        className="bg-blue-800 mt-8 rounded-md border-0 text-white py-2"
        onClick={handleSignin}
      >
        Sign in
      </button>
    </div>
  );
};

export default SignInForm;
