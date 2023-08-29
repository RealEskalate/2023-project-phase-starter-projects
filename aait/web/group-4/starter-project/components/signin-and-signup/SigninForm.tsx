"use client"

import { ChangeEvent, useState } from "react"
import { useRouter } from "next/navigation"
import {useDispatch} from "react-redux";

import {useLoginUserMutation} from "@/store/auth/authApi";
import TextField from "./TextField"
import {setState} from "@/store/auth/authSlice";
import {AppDispatch} from "@/store";

const fieldInfo: Array<Array<string>> = [
    ["text", "email", "Email"],
    ["password", "password", "Password"]
]

const SignInForm = () => {
    const router = useRouter()
    const [loginUser, loginResult] = useLoginUserMutation();
    const [formData, setFormData] = useState<{
        email: string;
        password: string;
    }>({
        email: '',
        password: '',
    });
    const dispatch = useDispatch<AppDispatch>()

    const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({
            ...prevFormData,
            [name]: value,
        }));
    };

    const handleSignin = () => {
        loginUser(formData);
        if (loginResult.isSuccess){
            const result = loginResult.data;
            dispatch(setState({
                token: result.token,
                userId: result.user,
                name: result.userName,
                email: result.userEmail,
            }))
        }
    }


    return (
        <div className=" relative flex flex-col text-left gap-6 bg-white text-gray-500 font-login border-0 rounded-lg md:px-14 px-10 pt-10 pb-10 w-full">

            {
                loginResult.isLoading?<div className="absolute top-0 flex justify-center items-center">
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
                loginResult.error?
                    <div className="absolute top-0 -mt-20 text-2xl bg-red-400 text-white" style={{backgroundColor:"red", padding:"20px", borderRadius: "10px"}}>
                        Could not login check your password
                    </div>:<></>
            }
            {
                loginResult.isSuccess?
                    <div className="absolute top-0 -mt-20 text-2xl bg-red-400 text-white" style={{backgroundColor:"green", padding:"20px", borderRadius: "10px"}}>
                        Login successful
                    </div>:<></>
            }

            <h2 className="text-[1.5rem] font-bold text-black">Login</h2>
            <p className="text-[0.9] mb-6">Hey, enter your details to sign in to your account</p>
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
            <button disabled={loginResult.isLoading} className="bg-blue-800 mt-8 rounded-md border-0 text-white py-2" onClick={handleSignin} >
                Sign in
            </button>
        </div>
    )
}



export default SignInForm