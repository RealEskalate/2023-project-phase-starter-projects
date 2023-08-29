"use client";
import { useAuth } from "@/hooks/useAuth";
import Image from "next/image";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";

export default function page() {
  const [email, setEmail] = useState<string>("");
  const [name, setName] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const {
    auth: { isAuthenticated, error, isLoading },
    signupHandler,
  } = useAuth();

  const router = useRouter();

  // re-route to home page if authentication
  useEffect(() => {
    if (isAuthenticated) {
      router.replace("/");
    }
  }, [isAuthenticated]);

  const handleSubmit = (ev: any) => {
    ev.preventDefault();
    signupHandler({ email, name, password });
  };
  return (
    <div className="h-screen overflow-hidden">
      <div className="grid lg:grid-cols-2 grid-cols-1 h-full">
        <div className="bg-gradient-to-br w-full h-full hidden lg:flex lg:flex-col lg:justify-center lg:items-center">
          <div className="self-start p-5">
            <Image
              src="/images/dark-a2sv.svg"
              width={150}
              height={50}
              alt="A2SV Logo"
            ></Image>
          </div>
          <div className="flex items-center">
            <Image
              src="/images/Saly-14person.svg"
              width={400}
              height={823}
              alt="Login Illustration"
              className="object-contain"
            />
            <div className="-ml-16 space-y-6">
              <h1 className="text-5xl  font-bold text-text-header-1">
                <span>Welcome to </span>
                <br />
                <span>A2SV</span>
              </h1>
              <p className="text-xl text-text-content">
                Register for free to receive blogs and learn more about A2SV
              </p>
            </div>
          </div>
        </div>
        <div className="flex justify-center items-center h-full lg:px-0 px-10 bg-primary">
          <div className="align-center d-flex bg-white p-8 rounded-xl">
            <div>
              <div className="py-8 flex justify-center items-center">
                <Image
                  width={200}
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
