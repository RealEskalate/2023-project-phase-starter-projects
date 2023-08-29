"use client"

import { useRouter } from "next/navigation"
import Image from 'next/image'

import SignupForm from "@/components/signin-and-signup/SignupForm";

const SignupPage = () => {
    const router = useRouter()

    return (
        <section className="font-login w-full grid grid-cols-1 md:grid-cols-2 px-14 bg-gray-100 py-16">
            <div className="flex flex-col bg-white">
                <img className="w-36 py-6 px-8" src="/images/A2SVLogo.png" alt="A2SV logo" />
                <div className="grid grid-cols-2 place-items-center">
                    <Image className="h-full" width={40} height={40} src="/images/blog/signupAndLoginAvatar.png" alt="cartoon avatar" />
                    <div className="flex flex-col self-center p-2">
                        <h2
                            className="text-form-gray-primary font-bold text-4xl mb-6"
                        >
                            Welcome to <br/>A2SV
                        </h2>
                        <p className="text-form-gray-primary font-light">
                            Register for free to receive blogs and learn more about A2SV
                        </p>
                    </div>
                </div>
            </div>

            <div className="relative bg-blue-800 md:px-20 px-4 py-32">
                <button
                    className="absolute top-0 right-0 mt-10 mr-10 text-white font-semibold text-sm"
                    onClick={() => router.push('/signin')}>
                    Sign in
                </button>
                <SignupForm />
            </div>
        </section>
    )
}
export default SignupPage