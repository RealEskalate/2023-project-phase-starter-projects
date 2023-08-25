"use client"

import Image from "next/image";
import loginIcon from '@/assets/images/loginIcon.svg';
import A2SVLogo from '@/assets/images/Group 39.svg';
import { useForm, SubmitHandler } from "react-hook-form";
import { useRouter } from "next/navigation";
import { useLoginMutation } from "@/lib/redux/slices/usersApi";
import { useState } from "react";
import {CgDanger} from 'react-icons/cg'
type Inputs = {
    email: string,
    password: string,
};
const Login = () => {
    const [loginError,setLoginError] = useState(false)
    const router = useRouter()
    if (localStorage.getItem("login")) {
        router.push('/')
        return <></>
    } else {

    }

    const [loginUser] = useLoginMutation()

    const { register, handleSubmit, watch, formState: { errors } } = useForm<Inputs>();
    const onSubmit: SubmitHandler<Inputs> = async (data) => {
        try {
            const loginData = await loginUser(data).unwrap()
            if (loginData) {
                localStorage.setItem("login", JSON.stringify({...loginData}))
            }
        } catch (e) {
            setLoginError(true)
        }


    }
    return (
        <div className="flex flex-wrap h-[550px]">
            <div className="hidden md:flex w-1/2 justify-center items-center">
                <Image src={loginIcon} alt="Login illustration" height={350} />
            </div>
            <div className="w-full md:w-1/2 flex justify-center items-center">
                <div className="bg-slate-100">
                    <form method="post" className="flex flex-col gap-6 w-96 p-6" onSubmit={handleSubmit(onSubmit)}>
                        <div className="flex justify-center">
                            <div className="w-1/2">
                                <Image src={A2SVLogo} alt="A2SV Logo" />
                            </div>
                        </div>
                        { loginError && <div className='text-base font-semibold text-white bg-red-600 rounded-md p-2'>
                           <CgDanger className='text-xl m-2 inline-block' /> 
                            <span>Incorrect username or password</span> 
                        </div>}
                        <div className="w-full">
                            <div className="text-xs text-red-900">
                                {errors.email && <span>This field is required</span>}
                            </div>
                            <input type="text" {...register("email", { required: true })} placeholder="Email" className="w-full px-2 py-2 border border-slate-600 font-primaryFont" />
                        </div>

                        <div className="w-full">
                            <div className="text-xs text-red-900 ox">
                                {errors.password && <span>This field is required</span>}
                            </div>
                            <input type="password" {...register("password", { required: true })} placeholder="Password" className={`border border-slate-600 ${errors.password && 'border-red-900'} px-2 py-2 w-full font-primaryFont`} />
                        </div>

                        <div className="flex justify-center">
                            <button className='mt-6 w-32 bg-primaryColor py-1 text-white text-l font-medium font-secondaryFont rounded-xl'>Login</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}



export default Login