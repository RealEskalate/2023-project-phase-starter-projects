"use client";
import React, { useState } from "react";
import Link from "next/link";
import Image from "next/image";
import { useRouter } from "next/navigation";
import { useAuth } from "@/hooks/useAuth";
import ProfileAvatar from "./ProfileAvatar";

export default function Nav() {
  const [openMenu, setOpenMenu] = useState<boolean>(false);
  const router = useRouter();
  const auth = useAuth().auth.isAuthenticated;
  const imageUrl = useAuth().auth.userProfile;

  const handleAuth = () => {
    if (auth) {
      router.push("/auth/profile");
    } else {
      router.push("/auth/login");
    }
  };

  const handleToggle = () => {
    setOpenMenu(!openMenu);
  };
  return (
    <nav className="bg-white fixed w-full z-50 top-0">
      <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto py-4 px-2">
        <Link href="/">
          <Image
            src="/images/a2sv-logo.svg"
            width={197}
            height={50}
            alt="Hero image"
            className="w-32 h-8"
          />
        </Link>
        <div className="flex lg:order-2 items-center">
          <div className="hidden content-end row-span-1 lg:flex lg:gap-0 lg:items-center">
            {auth ? (
              <div className=" translate-x-5 -translate-y-1">
                <ProfileAvatar imageUrl={imageUrl} />
              </div>
            ) : (
              <span
                onClick={() => router.push("/auth/login")}
                className={`text-[#3C3C3C] text-base font-semibold font-montserrat px-5 cursor-pointer`}
              >
                Login
              </span>
            )}
            <span>
              <button
                onClick={() => router.push("/")}
                className="border-2 rounded-xl  px-5 w-22 h-12 bg-primary text-white text-base font-semibold font-montserrat"
              >
                {" "}
                Donate{" "}
              </button>
            </span>
          </div>
          <button
            data-collapse-toggle="navbar-sticky"
            type="button"
            onClick={handleToggle}
            className="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg lg:hidden hover:bg-gray-100 lg focus:outline-none focus:ring-2"
            aria-controls="navbar-sticky"
            aria-expanded="false"
          >
            <span className="sr-only">Open main menu</span>
            <svg
              className="w-5 h-5"
              aria-hidden="true"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 17 14"
            >
              <path
                stroke="currentColor"
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth={2}
                d="M1 1h15M1 7h15M1 13h15"
              />
            </svg>
          </button>
        </div>
        <div
          className={`${
            openMenu ? "" : "hidden"
          } items-center justify-between w-full lg:flex lg:w-auto lg:order-1 lg:ml-10`}
          id="navbar-sticky"
        >
          <ul className="flex flex-col p-4 lg:p-0 mt-4 font-medium border  border-gray-100 rounded-lg  lg:flex-row lg:space-x-8 lg:mt-0 lg:border-0 lg:bg-white ">
            <li>
              <Link
                href="/"
                className="block py-2 pl-3 pr-4  rounded lg:bg-transparent  lg:p-0 lg:hover:bg-white text-[#3C3C3C] text-base hover:bg-gray-100  font-semibold font-montserrat"
                aria-current="page"
              >
                Home
              </Link>
            </li>
            <li>
              <Link
                href="/team"
                className="block py-2 pl-3 pr-4  rounded lg:bg-transparent  lg:p-0 lg:hover:bg-white  text-[#3C3C3C] text-base hover:bg-gray-100  font-semibold font-montserrat"
              >
                Team
              </Link>
            </li>
            <li>
              <Link
                href="/stories"
                className="block py-2 pl-3 pr-4  rounded lg:bg-transparent  lg:p-0 lg:hover:bg-white  text-[#3C3C3C] text-base hover:bg-gray-100 font-semibold font-montserrat"
              >
                Success Stories
              </Link>
            </li>
            <li>
              <Link
                href="/about"
                className="block py-2 pl-3 pr-4  rounded lg:bg-transparent   lg:hover:bg-white  lg:p-0  text-[#3C3C3C] text-base hover:bg-gray-100   font-semibold font-montserrat"
              >
                About
              </Link>
            </li>
            <li>
              <Link
                href="/blogs"
                className="block py-2 pl-3 pr-4  rounded lg:bg-transparent lg:hover:bg-white  lg:p-0  text-[#3C3C3C] text-base hover:bg-gray-100   font-semibold font-montserrat"
              >
                Blogs
              </Link>
            </li>
            <li>
              <Link
                href="#"
                className="block py-2 pl-3 pr-4  rounded lg:bg-transparent  lg:hover:bg-white  lg:p-0  text-[#3C3C3C] text-base hover:bg-gray-100  font-semibold font-montserrat"
              >
                Get Involved
              </Link>
            </li>
            <li>
              <Link
                href="#"
                className="lg:hidden block py-2 pl-3 pr-4 rounded text-[#3C3C3C] text-base font-semibold font-montserrat hover:bg-gray-100 lg:hover:bg-white   lg:p-0   "
              >
                Login
              </Link>
            </li>
            <li>
              <Link
                href="#"
                className="lg:hidden block py-2 pl-3 pr-4 rounded text-[#3C3C3C] text-base font-semibold font-montserrat hover:bg-gray-100 lg:hover:bg-white   lg:p-0   "
              >
                Donate
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}
