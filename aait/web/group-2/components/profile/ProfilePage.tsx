"use client";
import { useEffect, useState } from "react";
import PasswordForm from "./PasswordForm";
import PersonalInfo from "./PersonalInfo";
import MyBlogs from "../blog/MyBlogs";

export default function ProfilePage() {
  const components = [<PersonalInfo />, <MyBlogs/>,<PasswordForm />];
  const [component, setComponent] = useState(2);
  const activeClass =
    "border-b-2 h-22 border-spacing-4 outline-offset-4 border-blue-600  outline-sky-600 text-blue-600 decoration-sky-600 font-semibold";
  return (
    <div className="m-10">
      <p className="text-4xl font-bold mx-5">Profile</p>
      <div className="flex border-b border-slate-100">
        <p
          onClick={() => setComponent(1)}
          className={`mx-5 cursor-pointer py-4 ${
            component == 1 ? `${activeClass}` : "text-black"
          } `}
        >
          Personal Information
        </p>
        <p
          onClick={() => setComponent(2)}
          className={`mx-5 cursor-pointer py-4 ${
            component == 2 ? `${activeClass}` : "text-black"
          } `}
        >
          My blogs
        </p>
        <p
          onClick={() => setComponent(3)}
          className={`mx-5 cursor-pointer py-4 ${
            component == 3 ? `${activeClass}` : "text-black"
          } `}
        >
          Account Setting
        </p>
      </div>
      {/* <hr /> */}
      <div>{components[component - 1]}</div>
    </div>
  );
}
