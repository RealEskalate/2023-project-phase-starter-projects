"use client";

import { ChangeEvent, useState } from "react";
import { useRegisterMutation } from "@/store/features/auth";
import TextField from "./TextField";
import { toast } from "react-toastify";
import { useRouter } from "next/navigation";
import { RegisterInputData } from "@/types/user/user";

const fieldInfo: Array<Array<string>> = [
  ["text", "name", "Full Name"],
  ["text", "email", "Email"],
  ["password", "password", "Password"],
];


const SignupForm = () => {
  const [formData, setFormData] = useState<RegisterInputData>({
    email: "",
    password: "",
    name: "",
  });

  const router = useRouter();

  const [registerUser, registerResult] = useRegisterMutation();

  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSignup = async () => {
    try {
      await registerUser(formData).unwrap();

      toast("Registered Successfully", {
        type: "success",
      });
      router.push("/signin");
    } catch (error: any) {
      if (error.status === 400) {
        let errorMessage = error.data.message.split(",");
        errorMessage = errorMessage.splice(1, errorMessage.length);
        console.log(errorMessage);

        errorMessage.forEach((message: string) =>
          toast(message, {
            type: "error",
          })
        );
      } else if (error.status === "FETCH_ERROR") {
        toast("Please check your internet connection", {
          type: "error",
        });
      }
      else{
        toast("Error during Sign up", {
          type: "error",
        });
      }
    }
  };

  return (
    <>
      <div
        className={`${
          registerResult.isLoading ? "animate-pulse " : ""
        } flex flex-col text-left gap-6 bg-white text-gray-500 font-login border-0 rounded-lg md:px-14 px-10 pt-10 pb-10 w-full`}
      >
        <h2 className="text-4xl font-bold text-[#434343]">Sign Up</h2>
        <p className="text-[0.9] mb-6 text-[#434343]">
          Hey, enter your detail to sign up
        </p>
        {fieldInfo.map((field) => (
          <TextField
            key={field[1]}
            type={field[0]}
            name={field[1]}
            id={field[1]}
            placeholder={field[2]}
            value={formData[`${fieldInfo[1]}` as keyof RegisterInputData]}
            onChange={handleInputChange}
          />
        ))}
        <button
          className="bg-primary-color hover:bg-blue-900 mt-8 rounded-md border-0 text-white py-4"
          onClick={handleSignup}
          disabled={registerResult.isLoading}
        >
          Sign up
        </button>
      </div>
    </>
  );
};

export default SignupForm;
