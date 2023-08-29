"use client";
import { authTypes } from "@/types/auth/authTypes";
import Image from "next/image";
import Link from "next/link";
import React, { useEffect, useState } from "react";

const PersonalInformation = () => {
  const [name, setName] = useState("");
  const [FatherName, setFatherName] = useState("");
  const [email, setemail] = useState("");
  const [image, setimage] = useState("");

  useEffect(() => {
    const userString = localStorage.getItem("user");
    const user: authTypes | null = userString ? JSON.parse(userString) : null;
    if (user) {
      const [firstName, lastName] = user.userName.split(" ");
      setName(firstName);
      setFatherName(lastName);
      setemail(user.userEmail);
    }
  });

  return (
    <div className="mb-32">
      <div className=" py-10 text-blog_list_sub_text_color flex justify-between items-center ">
        <p>
          <p className="text-xl  font-bold">Manage Personal Information</p>
          <p className="text-sm">
            Add all the required information about yourself
          </p>
        </p>
        <Link
          href={""}
          className="px-8 py-2 mr-10 text-white bg-primary rounded-md font-semibold"
        >
          Save Changes
        </Link>
      </div>
      <hr className="py-1" />

      <form className=" ">
        {/* name */}

        <div className="mb-4 w-7/12   py-8 text-blog_icons_text_color  flex items-center justify-between">
          <label htmlFor="name" className="block font-semibold">
            Name <span className="text-[red]"> *</span>
          </label>

          <div className="w-9/12  flex justify-around  ">
            <input
              type="text"
              id="name"
              name="name"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="mt-1 px-4 py-2 outline-none border font-semibold text-nav_text_color  rounded-md "
              required
            />
            <input
              type="text"
              id="fatherName"
              name="fatherName"
              value={FatherName}
              onChange={(e) => setFatherName(e.target.value)}
              className="mt-1 px-4 py-2 outline-none border font-semibold text-nav_text_color  rounded-md "
              required
            />
          </div>
        </div>
        <hr />

        {/* email */}
        <div className="mb-4  w-7/12 py-8 text-blog_icons_text_color font-semibold  flex justify-between items-center">
          <label htmlFor="email" className="block ">
            Email <span className="text-[red]"> *</span>
          </label>

          <div className=" w-9/12  flex justify-start items-center">
            <input
              type="email"
              id="email"
              name="email"
              value={email}
              onChange={(e) => setemail(e.target.value)}
              className=" px-4 outline-none w-11/12 mx-auto py-2 border font-semibold text-nav_text_color rounded-md  "
              required
            />
          </div>
        </div>
        <hr />

        {/* your photo */}
        <div className="pb-6 py-10 w-7/12  flex justify-between  font-semibold text-blog_icons_text_color">
          <label htmlFor="image">
            Your Photo <span className="text-[red]"> *</span>
          </label>
          <div className=" w-9/12   flex justify-around items-start">
            <div className="w-1/12 ">
              <Image
                width={50}
                height={50}
                src={"/assets/photoPlaceHolder.svg"}
                alt="alternative image"
              />
            </div>
            <div className="py-1  w-10/12 m-1 ">
              <label
                className="border-[2px] cursor-pointer border-[#D2D2D2] rounded-lg  mx-1 py-8  h-fit flex justify-center flex-col items-center"
                htmlFor="image"
              >
                <Image
                  width={30}
                  height={30}
                  src={"/assets/photoUPloadedIcon.svg"}
                  alt="alternative image"
                />

                <div className="text-[#858585] text-sm">
                  <p className="">
                    <span className="font-bold text-nav_text_color">
                      Click to upload
                    </span>
                    or drag and drop
                  </p>
                  <p className=""> SVG, PNG, JPG or GIF(max800x400px) </p>
                </div>
              </label>
              <input
                type="file"
                id="image"
                name="image"
                accept="image/*"
                className="outline hidden "
                required
              />
            </div>
          </div>
        </div>
      </form>
    </div>
  );
};

export default PersonalInformation;
