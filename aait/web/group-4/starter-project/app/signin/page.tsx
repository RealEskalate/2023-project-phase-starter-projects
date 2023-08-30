"use client"

import { useRouter } from "next/navigation"
import Image from 'next/image'

import SigninForm from "@/components/signin-and-signup/SigninForm";
const SignInPage = () => {
    const router = useRouter()
    return (
        <section className="font-login w-full grid grid-cols-1 md:grid-cols-2 md:px-14 px-4 bg-gray-100 py-16 text-xl" >
            <div className="flex flex-col bg-white">
                <Image className="w-36 py-6 px-8" width={100} height={100} src="/images/blog/A2SVLogo.png" alt="A2SV logo" />
                <div className="grid grid-cols-2 place-items-center">
                    <Image className="h-full" width={800} height={100} src="/images/blog/signupAndLoginAvatar.png" alt="cartoon avatar" />
                    <div className="flex flex-col self-center p-2">
                        <h2
                           className="text-form-gray-primary font-bold text-5xl mb-6 text-[#434343]"
                        >
                            Welcome <br/>Back
                        </h2>
                        <p className="text-form-gray-primary font-light">
                            Login to receive blogs <br/>and learn more about A2SV
                        </p>
                    </div>
                </div>
            </div>

            <div className="relative font-login bg-blue-800 md:px-20 px-4 py-32">
                <button className="absolute top-0 right-0 mt-10 mr-10 p-4 text-lg rounded-lg text-white font-semibold text-[0.7rem] hover:bg-white hover:text-primary-color transition duration-500" onClick={() => router.push('/signup')}>
                    Sign up
                </button>
                <SigninForm />
            </div>
        </section>
    )
}

export default SignInPage