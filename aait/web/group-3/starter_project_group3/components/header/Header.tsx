// Import necessary components and modules
"use client";
import Image from "next/image";
import NavBar from "./NavBar";
import { useState } from "react";
import NavBarMobile from "./NavBarMobile";

// Define a functional component named Header
const Header : React.FC = () => {
  // State to control the mobile menu open/closed state
  const [isOpen, setIsOpen] = useState(false);

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
          <button className="text-login_color hidden nav_bar_screen:inline-block">
            Login
          </button>

          {/* Button with padding, background color, text color, and rounded corners */}
          <button className="p-3 bg-primary text-white rounded-lg hidden nav_bar_screen:inline-block">
            Donate
          </button>

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

// Export the Header component as the default export
export default Header;
