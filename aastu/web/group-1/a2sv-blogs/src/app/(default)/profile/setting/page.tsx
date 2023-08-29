"use client";

import ErrorAlert from "@/components/common/ErrorAlert";
import SuccessAlert from "@/components/common/SuccessAlert";
import { useAuth } from "@/hooks/useAuth";
import classNames from "classnames";
import { useState } from "react";

export default function page() {
  const [oldPassword, setOldPassword] = useState<string>("");
  const [newPassword, setNewPassword] = useState<string>("");
  const [confirmPassword, setConfirmPassword] = useState<string>("");
  const [isEditing, setIsEditing] = useState<boolean>(false);

  const [isProcessing, setIsProcessing] = useState<boolean>(false);
  const [isSuccess, setIsSuccess] = useState<boolean>(false);
  const [isError, setIsError] = useState<boolean>(false);
  const [alertMessage, setAlertMessage] = useState<string>("");

  const { changePasswordHandler } = useAuth();

  const handleSave = () => {
    try {
      setIsProcessing(true);
      if (confirmPassword !== newPassword) {
        setAlertMessage("Password must match");
        setIsError(true);
        setIsProcessing(false);
        setTimeout(() => {
          setIsError(false);
        }, 2000);
        return;
      }

      changePasswordHandler({ oldPassword, newPassword }).then((res: any) => {
        setIsProcessing(false);
        if (res.error) {
          setAlertMessage("Invalid Password, try again");
          setIsError(true);
          setTimeout(() => {
            setIsError(false);
          }, 2000);
        } else {
          setNewPassword("");
          setOldPassword("");
          setIsEditing(false);
          setIsSuccess(true);
          setAlertMessage("Successfully changed password");

          setTimeout(() => {
            setIsSuccess(false);
          }, 2000);
        }
      });
    } catch (error) {}
  };

  return (
    <section className="mt-4">
      {isSuccess && <SuccessAlert message={alertMessage} />}
      {isError && <ErrorAlert message={alertMessage} />}
      <div className="text-text-header-2 space-y-1 mt-5 flex flex-col md:flex-row md:justify-between md:items-center">
        <div className="space-y-2">
          <h1 className="sm:text-lg font-bold text-text-header-2">
            Manage Your Account
          </h1>
          <p className="text-sm max-w-[20ch] text-text-content">
            You can change your password here
          </p>
        </div>
        <div className="flex justify-between md:mt-0 mt-5 space-x-3">
          {!isEditing ? (
            <button
              className="px-3 py-1 bg-secondary text-white rounded"
              onClick={() => setIsEditing(true)}
            >
              Edit
            </button>
          ) : (
            <button
              className="px-3 py-1 bg-secondary text-white rounded"
              onClick={() => setIsEditing(false)}
            >
              Cancel
            </button>
          )}
          <button
            className={classNames("px-3 py-1 bg-primary text-white rounded", {
              "bg-slate-500": !isEditing,
            })}
            disabled={!isEditing}
            onClick={handleSave}
          >
            {isProcessing ? (
              <span>Processing ...</span>
            ) : (
              <span> Save Changes</span>
            )}
          </button>
        </div>
      </div>
      <div className="h-full">
        <div className="lg:w-2/5 w-full mx-auto mt-20">
          <div className="mt-5 grid grid-cols-6 items-center">
            <label
              htmlFor="password"
              className="text-sm text-text-content col-span-2"
            >
              Current Password
            </label>
            <input
              type="password"
              id="current_password"
              placeholder="Enter your current password"
              className="col-span-4 border border-neutral-200 focus:outline-none rounded px-3 py-2 mx-2 mt-1 placeholder:text-sm"
              value={oldPassword}
              disabled={!isEditing}
              onChange={(e) => setOldPassword(e.target.value)}
              required
            />
          </div>
          <div className="mt-5 grid grid-cols-6 items-center">
            <label
              htmlFor="password"
              className="text-sm text-text-content col-span-2"
            >
              New Password
            </label>
            <input
              type="password"
              id="password"
              placeholder="Enter new password"
              className="col-span-4 border border-neutral-200 focus:outline-none rounded px-3 py-2 mx-2 mt-1 placeholder:text-sm"
              value={newPassword}
              disabled={!isEditing}
              onChange={(e) => setNewPassword(e.target.value)}
              required
            />
          </div>
          <div className="mt-5 grid grid-cols-6 items-center">
            <label
              htmlFor="password"
              className="text-sm text-text-content col-span-2"
            >
              Confirm Password
            </label>
            <input
              type="password"
              id="confirm_password"
              placeholder="Confirm password"
              className="col-span-4 border border-neutral-200 focus:outline-none rounded px-3 py-2 mx-2 mt-1 placeholder:text-sm"
              value={confirmPassword}
              disabled={!isEditing}
              onChange={(e) => setConfirmPassword(e.target.value)}
              required
            />
          </div>
        </div>
      </div>
    </section>
  );
}
