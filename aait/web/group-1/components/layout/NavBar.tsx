"use client";

import Image from "next/image";
import React, { useState } from "react";
import A2SVLogo from "../../public/images/A2SV.svg";
import { LinkItems } from "./LinkItems";
import Link from "next/link";
import { useRouter } from "next/navigation";

interface NavItems {
  link: string;
  name: string;
}

export const NavBar = () => {
  const router = useRouter()
  const [isMenuToggled, setIsMenuToggled] = useState<boolean>(false);

  const navItems: NavItems[] = [
    {
      link: "/",
      name: "home",
    },
    {
      link: "/teams",
      name: "teams",
    },
    {
      link: "/success-stories",
      name: "success stories",
    },
    {
      link: "/about",
      name: "about us",
    },
    {
      link: "/blogs",
      name: "blogs",
    },
    {
      link: "/signup",
      name: "get involved",
    },
  ];

  return (
    <div className="w-full py-8 px-6 bg-white">
      {/* Desktop view */}
      <div className="hidden md:flex justify-between items-center font-montserrat">
        {/* logo section */}
        <div>
          <Image src={A2SVLogo} alt="A2SV logo" width={120} height={50} />
        </div>

        {/* Navigation section */}
        <div className="flex gap-6">
          {navItems.map((nav: NavItems) => (
            <LinkItems key={nav.name} name={nav.name} link={nav.link} />
          ))}
        </div>

        {/* login signup section */}
        <div className="flex gap-2">
          <Link href={'/signin'} className="btn">Login</Link>
          <button 
            className="btn bg-blue-800 text-white"
            onClick={() => router.push('/profile')}
            >
              Profile
          </button>
        </div>
      </div>

      {/* Mobile view */}
      <div className="flex md:hidden justify-between font-montserrat">
        {/* logo section */}
        <div>
          <Image src={A2SVLogo} alt="A2SV logo" width={120} height={50} />
        </div>

        <div className="flex flex-col items-end relative">
          <button onClick={() => setIsMenuToggled(!isMenuToggled)}>
            <Image src={"./images/burger.svg"} alt="" width={40} height={40} />
          </button>

          {/* Navigation section */}
          {isMenuToggled && (
            <div className="flex flex-col w-36 items-center space-y-1 absolute top-10 right-0 bg-blue-100 shadow-lg">
              {navItems.map((nav: NavItems) => (
                <LinkItems key={nav.name} name={nav.name} link={nav.link} />
              ))}
              <button className="btn">Login</button>
              <button className="btn">Donate</button>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};
