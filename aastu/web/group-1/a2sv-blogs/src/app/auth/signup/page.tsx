"use client";
import { useAuth } from "@/hooks/useAuth";
import Image from "next/image";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState } from "react";

export default function page() {
  const [email, setEmail] = useState<string>("");
  const [name, setName] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const {
    auth: { isAuthenticated, error, isLoading },
    signupHandler,
  } = useAuth();

  const router = useRouter();

  const handleSubmit = (ev: any) => {
    ev.preventDefault();
    signupHandler({ email, name, password });
    if (isAuthenticated) {
      router.replace("/");
    }
  };
  return (
    <div className="h-screen">
      <div className="grid lg:grid-cols-2 grid-cols-1 h-full">
        <div className="bg-gradient-to-br from-primary to-secondary w-full h-full hidden lg:flex lg:justify-center lg:items-center">
          <Image
            src="/images/login-illustration.svg"
            width={500}
            height={300}
            alt="Login Illustration"
            className="w-4/5 object-contain"
          />
        </div>
        <div className="flex justify-center items-center h-full lg:px-0 px-10">
          <div className="align-center d-flex">
            <div className="mt-8">
              <div className="py-8 flex justify-center items-center">
                <Image
                  width={100}
                  height={50}
                  src="/images/a2sv-logo.svg"
                  alt="A2SV Logo"
                ></Image>
              </div>
              <h4 className="text-3xl mb-4 font-semibold">
                <span className="text-primary ">Please register </span>
                into the system!
              </h4>
              <form className="py-4 flex flex-col" onSubmit={handleSubmit}>
                <input
                  type="email"
                  placeholder="Email"
                  name="email"
                  className="rounded-lg focus:outline-none px-3 py-2 border border-neutral-200 my-3 bg-slate-100"
                  required
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                />
                <input
                  type="text"
                  id="username"
                  placeholder="Username"
                  name="username"
                  className="rounded-lg focus:outline-none px-3 py-2 border border-neutral-200 my-3 bg-slate-100"
                  required
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                />
                <input
                  type="password"
                  id="password"
                  placeholder="Password"
                  name="password"
                  className="rounded-lg focus:outline-none px-3 py-2 border border-neutral-200 my-3 bg-slate-100"
                  required
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />

                <button
                  className="bg-primary shadow text-white py-2 rounded-lg mt-3 hover:shadow-primary transition-shadow ease-in-out"
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <span>Processing ...</span>
                  ) : (
                    <span>Sign Up</span>
                  )}
                </button>
                <div className="flex items-center justify-center flex-wrap mt-5">
                  <h3 className="text-sm font-normal">
                    Already have an account?
                  </h3>

                  <Link href="/auth/login">
                    <h3 className="pl-2 text-primary text-base">Login</h3>
                  </Link>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
