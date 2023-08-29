"use client"

import { ChangeEvent, useState, } from "react"
import {useDispatch} from "react-redux";

import {useRegisterUserMutation} from "@/store/auth/authApi";
import {AppDispatch} from "@/store";
import TextField from "./TextField"
import {RegisterResponseData} from "@/user";
import {setState} from "@/store/auth/authSlice";

const fieldInfo: Array<Array<string>> = [
    ["text", "name", "Full Name"],
    ["text", "email", "Email"],
    ["password", "password", "Password"]
]

const SignupForm = () => {
    const [formData, setFormData] = useState<{
        email: string;
        password: string;
        name: string;
    }>({
        email: '',
        password: '',
        name: '',
    });
    const dispatch = useDispatch<AppDispatch>();

    const [registerUser, registerResult] = useRegisterUserMutation();

    const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({
            ...prevFormData,
            [name]: value,
        }));
    };

    const handleSignup = async () => {
        console.log(formData)
        const response = await registerUser(formData);
    }

    return (
        <div className="flex flex-col text-left gap-6 bg-white text-gray-500 font-login border-0 rounded-lg md:px-14 px-10 pt-10 pb-10 w-full">

            {
                registerResult.isLoading?<div className="absolute top-0 flex justify-center items-center">
                    <div
                        className="inline-block h-60 w-60 animate-spin rounded-full border-8 border-solid border-current border-r-transparent align-[-0.125em] motion-reduce:animate-[spin_1.5s_linear_infinite]"
                        role="status">
                  <span
                      className="!absolute !-m-px !h-px !w-px !overflow-hidden !whitespace-nowrap !border-0 !p-0 ![clip:rect(0,0,0,0)]"
                  >Loading...</span>
                    </div>
                </div>:<></>
            }

            {
                registerResult.error?
                    <div className="absolute top-0 -mt-20 text-2xl bg-red-400 text-white" style={{backgroundColor:"red", padding:"20px", borderRadius: "10px"}}>
                        Error on Registering user
                    </div>:<></>
            }
            {
                registerResult.isSuccess?
                    <div className="absolute top-0 -mt-20 text-2xl bg-red-400 text-white" style={{backgroundColor:"green", padding:"20px", borderRadius: "10px"}}>
                        Registration successful
                    </div>:<></>
            }

            <h2 className="text-[1.5rem] font-bold text-black">Register</h2>
            <p className="text-[0.9] mb-6">Hey, enter your detail to sign up
            </p>
            {fieldInfo.map((field) => (
                <TextField
                    key={field[1]}
                    type={field[0]}
                    name={field[1]}
                    id={field[1]}
                    placeholder={field[1]}
                    value={formData[`${fieldInfo[1]}`]}
                    onChange={handleInputChange}
                />
            ))}
            <button className="bg-blue-800 mt-8 rounded-md border-0 text-white py-2" onClick={handleSignup} >
                Sign up
            </button>
        </div>
    )
}



export default SignupForm;