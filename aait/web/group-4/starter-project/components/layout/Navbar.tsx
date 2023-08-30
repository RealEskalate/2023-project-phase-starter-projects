"use client";

import { usePathname } from "next/navigation";
import { useState } from "react";
import Image from "next/image";
import NavMenu from "./NavMenu";
import {MdAccountCircle} from "react-icons/md";
import Link from "next/link";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "@/store";
import { logout} from "@/store/features/user/user-slice";

export default function Navbar() {
  const [nav, setNav] = useState(false);

  const pathname = usePathname();
  const user = useSelector((state: RootState) => state.user.user);
  const dispatch = useDispatch();

  const loginDonateBtn = (
    <div className={`flex text-[16px] font-bold gap-8  justify-center `}>
      {user ? (
        <>
          <button
            onClick={() =>
              dispatch(
                logout()
                )
            }
            className="rounded-lg border-none py-4 px-6 hover:bg-primary-color hover:text-white transition duration-300"
          >
            Logout
          </button>
          <Link
            href="/profile"
          >
            <MdAccountCircle className="w-12 h-12  hover:text-primary-color transition duration-300"/>
          </Link>
        </>
      ) : (
        <>
          <Link
            href="/signin"
            className="rounded-lg border-none py-4 px-6 hover:bg-primary-color hover:text-white transition duration-300"
          >
            Login
          </Link>
          <a className="px-5 py-3 rounded-lg border-none bg-blue-800 text-white">
            Donate
          </a>
        </>
      )}
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
            <NavMenu />
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

        {loginDonateBtn}
      </div>
      {/* Mobile menu */}
      <nav
        className={`flex ${
          nav ? "flex-col" : "hidden"
        } gap-4 items-center text-[#565656] text-xl lg-1:hidden`}
      >
        <NavMenu />
        {loginDonateBtn}
      </nav>
    </>
  );
}
