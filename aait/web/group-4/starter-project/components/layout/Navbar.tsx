"use client";

import { useEffect, useRef, useState } from "react";
import Image from "next/image";
import NavMenu from "./NavMenu";
import Link from "next/link";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "@/store";
import { logout, setUser } from "@/store/features/user/user-slice";



export default function Navbar() {


  let user = useSelector((state: RootState) => state.user.user);
  const dispatch = useDispatch<AppDispatch>();

  const ref = useRef<HTMLElement>(null);

  useEffect(() => {
    let user_ = localStorage.getItem("user");

    user = user_ ? JSON.parse(user_) : null;

    if (user) {
      dispatch(setUser(user));
    }
  }, []);
  const loginDonateBtn = (
    <div className={`flex text-[16px] font-bold gap-8  justify-center `}>
      {user ? (
        <>
          <button
            onClick={() => dispatch(logout())}
            className="rounded-lg border-none py-4 px-6 hover:bg-primary-color hover:text-white transition duration-300"
          >
            Logout
          </button>
          <Link href="/profile">
            <Image
              className="rounded-full "
              src={user.userProfile as string}
              alt="profile"
              width={65}
              height={65}
            />
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
          

          <a className="flex  justify-center items-center rounded-lg overflow-hidden">
          <button className=" h-full p-4 border-none  bg-primary-color text-white">
            Donate
            </button>
          </a>
        
        </>
      )}
    </div>
  );

  return (
    <>
      <div className="px-6 py-4 w-full h-[100] flex justify-between items-center font-{montserrat} ">
        <div className="w-12 md:w-fit">
        <Image
            src="/images/common/logo.png"
            alt="Logo"
            objectFit="cover"
            width={200}
            height={200}
          />
        </div>
        <div className="flex relative justify-between text-gunmetal-gray md:w-fit">
          <nav className="lg-1:flex hidden flex-col lg-1:flex-row gap-10 font-semibold text-xl">
            <NavMenu />
          </nav>
          <Image
            onClick={() => {
              ref.current?.classList.toggle("h-fit")
            }}
            className="block lg-1:hidden w-10"
            src={"/images/common/menubar.png"}
            alt={"Menu-bar"}
            width={50}
            height={50}
          />
        </div>

        <div className="hidden lg-1:block">{loginDonateBtn}</div>
      </div>
      {/* Mobile menu */}
      <nav
        ref={ref}
        style={{ transition: "height 0.7s linear" }}
        className="flex flex-col h-0 overflow-hidden gap-4 items-center text-[#565656] text-xl lg-1:hidden"
      >
        <div className="w-fit flex flex-col items-start gap-4">
          <NavMenu />
        </div>
        {loginDonateBtn}
      </nav>
    </>
  );
}
