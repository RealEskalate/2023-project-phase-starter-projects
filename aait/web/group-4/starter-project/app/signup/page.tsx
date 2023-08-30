"use client";

import { useRouter } from "next/navigation";
import Image from "next/image";

import SignupForm from "@/components/signin-and-signup/SignupForm";

const SignupPage = () => {
  const router = useRouter();

  return (
    <section className=" w-full grid grid-cols-1 md:grid-cols-2 px-14 bg-gray-100 py-16">
      <div className="flex flex-col bg-white">
        <img
          className="w-36 py-6 px-8"
          src="/images/blog/A2SVLogo.png"
          alt="A2SV logo"
        />
        <div className="grid grid-cols-2 place-items-center">
          <Image
            className="h-full"
            width={800}
            height={800}
            src="/images/blog/signupAndLoginAvatar.png"
            alt="cartoon avatar"
          />
          <div className="flex flex-col self-center p-2">
            <h2 className="text-form-gray-primary font-bold text-5xl mb-6 text-[#434343]">
              Welcome to <br />
              A2SV
            </h2>
            <p className="text-[#8A8A8A] text-xl font-light ">
              Register for free to receive blogs and learn more about A2SV
            </p>
          </div>
        </div>
      </div>

      <div className="relative bg-blue-800 md:px-20 px-4 py-32">
        <button
          onClick={() => router.push("/signin")}
          className="absolute top-0 right-0 mt-10 mr-10 p-4 text-lg rounded-lg text-white font-semibold text-[0.7rem] hover:bg-white hover:text-primary-color transition duration-500"
        >
          Sign in
        </button>
        <SignupForm />
      </div>
    </section>
  );
};
export default SignupPage;
