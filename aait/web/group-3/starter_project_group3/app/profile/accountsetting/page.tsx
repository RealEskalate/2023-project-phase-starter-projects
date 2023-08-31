"use client";
import Toast from "@/components/toast-Messages/toast-message";
import { usePasswordResetMutation } from "@/store/features/auth";
import Image from "next/image";
import { useRouter } from "next/navigation";
import React, { useState } from "react";

const AccountSetting = () => {
  const router = useRouter();
  const [currentPassword, setcurrentPassword] = useState("");
  const [newPassword, setnewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errorMessage, seterrorMessage] = useState("");
  const [showToast, setshowToast] = useState(false);

  const [passwordReset, { isLoading, isError, data }] =
    usePasswordResetMutation();

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    passwordReset({
      oldPassword: currentPassword,
      newPassword: confirmPassword,
    })
      .unwrap()
      .then((response) => {
        setshowToast(true);
        router.push("/");
      })
      .catch((err) => {
        console.error("password change error", err);
      });
  };

  return (
    <form onSubmit={handleSubmit}>
      {showToast && <Toast message="password updated succesfully." isError={false} />}
      <div className=" py-10 text-blog_list_sub_text_color flex justify-between items-center ">
        <p>
          <p className="text-xl  font-bold">Manage Personal Information</p>
          <p className="text-sm font-medium">
            Add all the required information about yourself
          </p>
        </p>
        <button
          type="submit"
          className="px-8 py-2 mr-10 text-white bg-primary rounded-md font-semibold"
        >
          {isLoading ? "Procesessing" : " Save Changes"}
        </button>
      </div>
      <hr className="py-1" />

      <div className="  p-6 py-20 w-7/12 mx-auto ">
        {/* current password */}
        <div className="py-5 flex p-1 justify-between items-center">
          {/* label */}
          <label
            htmlFor="current-password"
            className="w-3/12 text-nav_text_color font-bold "
          >
            Current Password
          </label>

          {/* input and hide&show image  */}
          <div className="w-9/12 rounded-lg bg-[#EFF3F9] flex justify-between  items-center p-2 px-8">
            <input
              placeholder="Enter you current password"
              type="password"
              name="current-password"
              value={currentPassword}
              onChange={(e) => setcurrentPassword(e.target.value)}
              id="current-password"
              className="text-sm outline:none focus:outline-none rounded-md border-none w-9/12  text-[#767676B2] font-bold p-2 px-4 bg-[#EFF3F9]"
            />
            <Image
              alt="show password image "
              src={"/assets/password-hide.svg"}
              className="cursor-pointer"
              width={25}
              height={25}
            />
          </div>
        </div>

        {/* new password */}
        <div className=" py-5 flex p-1 justify-between items-center">
          {/* label */}
          <label
            htmlFor="current-password"
            className="w-3/12 text-nav_text_color font-bold "
          >
            New Password
          </label>

          {/* input and hide&show image  */}
          <div className="w-9/12 rounded-lg bg-[#EFF3F9] flex justify-between  items-center p-2 px-8">
            <input
              placeholder="Enter new password"
              type="password"
              value={newPassword}
              onChange={(e) => setnewPassword(e.target.value)}
              name="current-password"
              id="current-password"
              className="text-sm outline:none focus:outline-none rounded-md border-none w-9/12  text-[#767676B2] font-bold p-2 px-4 bg-[#EFF3F9]"
            />
            <Image
              alt="show password image "
              src={"/assets/password-hide.svg"}
              className="cursor-pointer"
              width={25}
              height={25}
            />
          </div>
        </div>

        {/* confirm password*/}
        <div className="py-5 flex p-1 justify-between items-center">
          {/* label */}
          <label
            htmlFor="current-password"
            className="w-3/12 text-nav_text_color font-bold "
          >
            Confirm Password
          </label>

          {/* input and hide&show image  */}
          <div className="w-9/12 rounded-lg bg-[#EFF3F9] flex justify-between  items-center p-2 px-8">
            <input
              placeholder="Confirm new password"
              type="password"
              name="current-password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              id="current-password"
              className="text-sm outline:none focus:outline-none rounded-md border-none w-9/12  text-[#767676B2] font-bold p-2 px-4 bg-[#EFF3F9]"
            />
            <Image
              alt="show password image "
              src={"/assets/password-hide.svg"}
              className="cursor-pointer"
              width={25}
              height={25}
            />
          </div>
        </div>
        {isError ? errorMessage : ""}
      </div>
    </form>
  );
};

export default AccountSetting;
