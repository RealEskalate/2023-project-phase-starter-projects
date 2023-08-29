"use client";
import { useState } from "react";
import { IoMdEyeOff, IoMdEye } from "react-icons/io";

const AccountSetting = () => {
  const [currPassword, setCurrPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [showCurrPassword, setShowCurrPassword] = useState(false);  // To control visibility of the current password field
  const [showNewPassword, setShowNewPassword] = useState(false);  // To control visibility of the new password field
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);  // To control visibility of the confirm password field


  return (
    <form className="flex flex-col justify-center items-center py-12 w-full">
      <div className="md:flex md:items-center mb-6 w-1/2">
        <div className="md:w-1/3">
          <label
            className="block text-[#565656] font-bold md:text-right mb-1 md:mb-0 pr-4"
            htmlFor="current"
          >
            Current Password
          </label>
        </div>
        <div className="md:w-1/2 relative">
          <input
            className="relative bg-[#EFF3F9] appearance-none rounded-lg w-full p-4"
            placeholder="Enter your current password"
            id="current"
            type={showCurrPassword? "text" : "password"}
            value={currPassword}
            onChange={(e) => setCurrPassword(e.target.value)}
          />
          {showCurrPassword && <IoMdEye className="absolute top-1/3 right-3.5 w-6 h-6 text-[#B7B7B7] cursor-pointer" onClick={(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => setShowCurrPassword(false)} />}
          {!showCurrPassword && <IoMdEyeOff className="absolute top-1/3 right-3.5 w-6 h-6 text-[#B7B7B7] cursor-pointer" onClick={(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => setShowCurrPassword(true)} />}
        </div>
      </div>

      <div className="md:flex md:items-center mb-6 w-1/2">
        <div className="md:w-1/3">
          <label
            className="block text-[#565656] font-bold md:text-right mb-1 md:mb-0 pr-4"
            htmlFor="new"
          >
            New Password
          </label>
        </div>
        <div className="md:w-1/2 relative">
          <input
            className="relative bg-[#EFF3F9] appearance-none rounded-lg w-full p-4"
            placeholder="Enter new password"
            id="new"
            type={showNewPassword? "text" : "password"}
            value={newPassword}
            onChange={(e) => setNewPassword(e.target.value)}
          />
          {showNewPassword && <IoMdEye className="absolute top-1/3 right-3.5 w-6 h-6 text-[#B7B7B7] cursor-pointer" onClick={(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => setShowNewPassword(false)} />}
          {!showNewPassword && <IoMdEyeOff className="absolute top-1/3 right-3.5 w-6 h-6 text-[#B7B7B7] cursor-pointer" onClick={(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => setShowNewPassword(true)} />}

        </div>
      </div>
      <div className="md:flex md:items-center mb-6 w-1/2">
        <div className="md:w-1/3">
          <label
            className="block text-[#565656] font-bold md:text-right mb-1 md:mb-0 pr-4"
            htmlFor="confirm"
          >
            Confirm Password
          </label>
        </div>
        <div className="md:w-1/2 relative">
          <input
            className="relative bg-[#EFF3F9] appearance-none rounded-lg w-full p-4"
            placeholder="Confirm new password"
            id="confirm"
            type={showConfirmPassword? "text" : "password"}
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
          {showConfirmPassword && <IoMdEye className="absolute top-1/3 right-3.5 w-6 h-6 text-[#B7B7B7] cursor-pointer" onClick={(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => setShowConfirmPassword(false)} />}
          {!showConfirmPassword && <IoMdEyeOff className="absolute top-1/3 right-3.5 w-6 h-6 text-[#B7B7B7] cursor-pointer" onClick={(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => setShowConfirmPassword(true)} />}

        </div>
      </div>
    </form>
  );
};

export default AccountSetting;
