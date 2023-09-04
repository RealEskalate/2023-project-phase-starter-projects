// Import necessary components and modules
"use client";
import Image from "next/image";
import NavBar from "./NavBar";
import { useEffect, useState } from "react";
import NavBarMobile from "./NavBarMobile";
import Link from "next/link";
import { authTypes } from "@/types/auth/authTypes";
import { useDispatch, useSelector } from "react-redux";
import { removeLogInStatus } from "@/store/user-Slice";

const Header: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);
  const dispath = useDispatch();
  const loginStatu = useSelector((state: any) => state.LogInState.status);

  const handleLogout = () => {
    if (typeof window !== "undefined") {
      localStorage.clear();
      dispath(removeLogInStatus());
      window.location.href = "/";
    }
  };

  // Function to toggle the mobile menu state
  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  return (
    <nav>
      {/* Header container with flex layout, padding, font bold, and background color */}
      <div className="header flex justify-between p-6 font-bold items-center bg-white max-[1150px]:text-xs">
        {/* A2SV logo */}
        <Image
          className="w-32 h-12 nav_bar_screen:w-auto nav_bar_screen:h-auto"
          objectFit="cover"
          src="/assets/A2SV_logo.svg"
          width={197}
          height={50}
          alt="A2SV logo"
        />

        {/* Include the NavBar component */}
        <NavBar />

        {/* Button container with gap, aligning items in a row */}
        <div className="button_contnet flex gap-7 items-center ">
          {/* Text for Login */}
          <>
            {!loginStatu && (
              <Link
                href={"/login"}
                className="text-login_color hidden nav_bar_screen:inline-block p-3 border-2 border-white rounded-lg hover:border-primary transition ease-in-out duration-200"
              >
                Login
              </Link>
            )}

            {/* Button with padding, background color, text color, and rounded corners */}
            {!loginStatu && (
              <Link
                href={"/register"}
                className="p-3 bg-primary text-white rounded-lg hidden nav_bar_screen:inline-block border-2 border-primary hover:bg-white hover:text-primary transition ease-in-out duration-200"
              >
                Register
              </Link>
            )}
            {loginStatu && (
              <button
                onClick={() => handleLogout()}
                className="p-3 bg-primary text-white rounded-lg hidden nav_bar_screen:inline-block"
              >
                Log Out
              </button>
            )}
          </>

          {/* hamburger icon */}
          <button
            className="p-3 bg-primary text-white rounded-lg nav_bar_screen:hidden"
            onClick={toggleMenu}
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              className="w-6 h-6"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5"
              />
            </svg>
          </button>
        </div>
      </div>

      {/* Mobile nav bar is displayed when hamburger icon is clicked */}
      <NavBarMobile isOpen={isOpen}>
        <div className="button_contnet flex gap-7 items-center">
          {/* Text for Login */}
          <span className="text-login_color">Login</span>

          {/* Button with padding, background color, text color, and rounded corners */}
          <button className="p-3 bg-primary text-white rounded-lg">
            Donate
          </button>
        </div>
      </NavBarMobile>
    </nav>
  );
};

export default Header;

export function checkLocalStorage(): boolean {
  let userString = null;
  let user: authTypes | null = null;
  if (typeof window !== "undefined") {
    userString = window.localStorage.getItem("user");
    user = userString ? JSON.parse(userString) : null;
  }
  if (user) return true;
  else return false;
}
