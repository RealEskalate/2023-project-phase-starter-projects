"use client"

import { useRouter } from "next/navigation"
import Image from 'next/image'

import SigninForm from "@/components/signin-and-signup/SigninForm";
const SignInPage = () => {
    const router = useRouter()
    return (
        <section className="font-login w-full grid grid-cols-1 md:grid-cols-2 md:px-14 px-4 bg-gray-100 py-16" >
            <div className="flex flex-col bg-white">
                <Image className="w-36 py-6 px-8" width={30} height={30} src="/images/blog/A2SVLogo.png" alt="A2SV logo" />
                <div className="grid grid-cols-2 place-items-center">
                    <Image className="h-full" width={40} height={40} src="/images/blog/signupAndLoginAvatar.png" alt="cartoon avatar" />
                    <div className="flex flex-col self-center p-2">
                        <h2
                            className="text-form-gray-primary font-extrabold text-4xl mb-6"
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
                <button className="absolute top-0 right-0 mt-10 mr-10 text-white font-semibold text-[0.7rem]" onClick={() => router.push('/signup')}>
                    Sign up
                </button>
                <SigninForm />
            </div>
        </section>
    )
}

export default SignInPage