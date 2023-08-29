"use client"

import SignInForm from "@/components/signin/SigninForm"
import { useRouter } from "next/navigation"

const SignInPage = () => {
  const router = useRouter()
  return (
    <section className="flex flex-row justify-center py-32">
      <div className="flex flex-col min-w-max">
        <img className="w-36 py-6 px-8" src="/images/signup/A2SVLogo.png" alt="A2SV logo" />
        <div className="flex flex-row">
          <img className="h-[500px]" src="/images/signup/signupAndLoginAvatar.png" alt="cartoon avatar" />
          <div className="flex flex-col self-center pr-14">
            <h2 
              className="text-form-gray-primary font-semibold text-4xl mb-6"
              >
              Welcome to <br/>A2SV
            </h2>
            <p className="text-form-gray-primary font-light">
              Login to receive blogs <br/>and learn more about A2SV
            </p>
          </div>
        </div>
      </div>

      <div className="relative font-poppins flex flex-col justify-center items-center bg-blue-first px-20 py-32">
        <button className="absolute top-0 right-0 mt-10 mr-10 text-white font-semibold text-sm" onClick={() => router.push('/signup')}>
          Sign up
        </button>
        <SignInForm />
      </div>
    </section>
  )
}

export default SignInPage