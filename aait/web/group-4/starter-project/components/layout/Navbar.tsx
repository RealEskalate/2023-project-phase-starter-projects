"use client";

import { usePathname } from "next/navigation";
import { useState } from "react";
import Image from "next/image";
import NavMenu from "./NavMenu";

export default function Navbar() {
  const [nav, setNav] = useState(false);

  const pathname = usePathname();

  const loginDonateBtn = (
    <div className={`flex text-[16px] font-bold gap-8  justify-center `}>
      <button className="rounded-lg border-none bg-none">Login</button>
      <button className="px-5 py-3 rounded-lg border-none bg-blue-800 text-white">
        Donate
      </button>
    </div>
  );

  return (
    <>
      <div className="px-6 py-4 w-full h-[100] flex justify-between items-center font-{montserrat} ">
        <div className="w-32 md:w-fit">
          <Image
            src="/images/common/logo.png"
            alt="Logo"
            objectFit="cover"
            width={200}
            height={50}
          />
        </div>
        <div className="flex relative justify-between text-gunmetal-gray md:w-fit">
          <nav className="lg-1:flex hidden flex-col lg-1:flex-row gap-10 font-semibold text-xl">
            <NavMenu/>
          </nav>
          <Image
            onClick={() => setNav(!nav)}
            className="block lg-1:hidden w-10"
            src={"/images/common/menubar.png"}
            alt={"Menu-bar"}
            width={50}
            height={50}
          />
        </div>

        <div className="hidden text-[16px] font-bold gap-8 lg-1:flex">
          <button className="rounded-lg border-none bg-none">Login</button>
          <button className="px-5 py-3 rounded-lg border-none bg-blue-800 text-white">
            Donate
          </button>
        </div>
      </div>
      {/* Mobile menu */}
      <nav
        className={`flex ${
          nav ? "flex-col" : "hidden"
        } gap-4 items-center text-[#565656] text-xl lg-1:hidden`}
      >
        <NavMenu/>
        {loginDonateBtn}
      </nav>
    </>
  );
}
