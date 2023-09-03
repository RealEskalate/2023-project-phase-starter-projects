"use client";
import Link from "next/link";
import React, { useState } from "react";
import AccountSetting from "./accountsetting/page";
import PersonalInformation from "./personalinformation/page";
import MyBlogs from "./myblogs/page";

const Profile = () => {
  const [val, setVal] = useState<number>(0);
  const [isActive, setIsActive] = useState<number>(0);

  return (
    <>
      <section className="w-[98%] font-Montserrat mx-auto p-2 m-2 ">
        <div className="border-b-2 ">
          <p className="text-lg font-bold">Profile</p>

          <div className="flex justify-between">
            <div className="flex justify-center items-center gap-5">
              <Link
                onFocus={() => setIsActive(0)}
                href={"#"}
                onClick={() => setVal(0)}
                className={`${
                  isActive === 0 ? "border-primary text-primary border-b-4" : ""
                } font-semibold px-4 py-3  rounded-sm`}
              >
                Personal Information
              </Link>

              <Link
                onFocus={() => setIsActive(1)}
                href={"#"}
                onClick={() => setVal(1)}
                className={`${
                  isActive === 1 ? "border-primary text-primary border-b-4" : ""
                } font-semibold px-4 py-3  rounded-sm`}
              >
                My Blogs
              </Link>

              <Link
                onFocus={() => setIsActive(2)}
                href={"#"}
                onClick={() => setVal(2)}
                className={`${
                  isActive === 2 ? "border-primary text-primary border-b-4" : ""
                } font-semibold px-4 py-3 rounded-sm  `}
              >
                Account Setting
              </Link>
            </div>

            <Link
              href={"/blogs/create"}
              className="  font-bold  bg-primary text-white px-10 py-1 rounded-lg mb-1 flex items-center"
            >
              New Blog
            </Link>
          </div>
        </div>

        {val === 0 && <PersonalInformation />}
        {val === 1 && <MyBlogs />}
        {val === 2 && <AccountSetting />}
      </section>
    </>
  );
};

export default Profile;
