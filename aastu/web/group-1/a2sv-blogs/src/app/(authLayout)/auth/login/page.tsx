"use client";
import { useAuth } from "@/hooks/useAuth";
import { resetAuth } from "@/lib/redux/slices/authSlice";
import Image from "next/image";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
export default function page() {
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const {
    loginHandler,
    auth: { isAuthenticated, isLoading, error },
  } = useAuth();

  const router = useRouter();
  const dispatch = useDispatch();

  // re-route to home page if authenticated
  useEffect(() => {
    if (isAuthenticated) {
      router.replace("/");
    }
  }, [isAuthenticated]);
  const handleSubmit = (ev: any) => {
    ev.preventDefault();
    loginHandler({ email, password });
  };
  return (
    <div className="h-screen ">
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
                <span>Welcome </span>
                <br />
                <span>Back</span>
              </h1>
              <p className="text-xl text-text-content max-w-[26ch]">
                Login to receive blogs and learn more about A2SV
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
                <span className="text-primary ">Please sign in </span>
                to your account
              </h4>
              {error && (
                <div className="w-full bg-red-400 text-white rounded-lg py-1 flex items-center justify-center space-x-2">
                  <Image
                    src="/images/sign-error.svg"
                    width={20}
                    height={20}
                    alt="error sign"
                    className="object-contain cursor-pointer"
                    onClick={() => dispatch(resetAuth())}
                  />
                  <p>
                    {error?.status === "FETCH_ERROR"
                      ? "Network Error"
                      : error?.data.message}
                  </p>
                </div>
              )}
              <form
                action="POST"
                className="py-4 flex flex-col"
                onSubmit={handleSubmit}
              >
                <input
                  placeholder="Email"
                  name="email"
                  className="rounded-lg focus:outline-none px-3 py-2 border border-neutral-200 my-3 bg-slate-100"
                  required
                  type="text"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
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
                <div className="mb-4 flex justify-end">
                  <p>
                    <Link
                      href="/auth/forgot-password"
                      className="text-sm font-normal text-primary"
                    >
                      Forgot Password?
                    </Link>
                  </p>
                </div>
                <button
                  type="submit"
                  className="bg-primary shadow text-white py-2 rounded-lg mt-3 hover:shadow-primary transition-shadow ease-in-out"
                >
                  {isLoading ? <span>Processing ...</span> : <span>Login</span>}
                </button>
                <div className="flex items-center justify-center flex-wrap mt-5">
                  <h3 className="text-sm font-normal">
                    Don't have an account?
                  </h3>

                  <Link href="/auth/signup">
                    <h3 className="pl-2 text-primary text-base">Sign up</h3>
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
