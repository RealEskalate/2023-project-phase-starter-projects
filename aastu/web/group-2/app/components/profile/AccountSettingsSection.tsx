'use client';

import { useEditPasswordMutation } from '@/lib/redux/slices/usersApi';
import React, { useState } from 'react';
import { CgDanger } from 'react-icons/cg';
import { AiOutlineLoading3Quarters } from 'react-icons/ai';
import Toast from '../Toast';

const AccountSettingsSection = () => {
  const [passwordMatch, setPasswordMatch] = useState(false);
  const [emptyFields, setEmptyFields] = useState(false);
  const [currentPassword, setCurrentPassword] = useState('');
  const [newPassword, setNewPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [success, setSuccess] = useState(false);
  const [open, setOpen] = useState(false);

  const [editPassword, { isLoading, isSuccess }] = useEditPasswordMutation();

  const handleSaveChange = async (e: any) => {
    e.preventDefault();

    if (!currentPassword.length || !newPassword.length || !confirmPassword.length) {
      setEmptyFields(true);
      setOpen(true);
    } else if (newPassword !== confirmPassword) {
      setPasswordMatch(true);
      setOpen(true);
    } else {
      const passwords = {
        oldPassword: currentPassword,
        newPassword,
      };

      try {
        const res = await editPassword(passwords).unwrap();
        console.log('hi', res);

        if (res.message === 'Password updated successfully') {
          setSuccess(true);
          setOpen(true);
        }
      } catch (error) {
        console.log(error);
        alert('Invalid old password.');
      } finally {
        setCurrentPassword('');
        setConfirmPassword('');
        setNewPassword('');
      }
    }
  };

  return (
    <section className="dark:text-dark-textColor-50">
      <div className="flex flex-col items-center gap-4 md:flex-row md:justify-between py-2 border-b-2 border-[#EFEFEF] dark:border-dark-textColor-50 mb-7 px-4">
        <div className=" font-secondaryFont">
          <h3 className="font-semibold text-textColor-200 text-lg text-center md:text-left md:text-lg dark:text-dark-textColor-100">
            Manage Your Account
          </h3>
          <p className="font-medium text-textColor-50 text-base dark:text-dark-textColor-50 ">
            You can change your password here
          </p>
        </div>
        <div className=" flex items-center">
          <button
            onClick={handleSaveChange}
            className="bg-primaryColor text-white font-secondaryFont font-semibold rounded-lg px-4 py-1 md:px-8 md:py-2
            hover:scale-95 transition-all ease-linear hover:bg-blue-900 disabled:bg-neutral-300 disabled:text-neutral-500 flex gap-2 items-center"
            disabled={isLoading}
          >
            {isLoading && <AiOutlineLoading3Quarters className="animate-spin" />}
            {isLoading ? 'Saving' : 'Save Changes'}
          </button>
        </div>
      </div>
      <div>
        <form className="flex flex-col items-center gap-y-6 mt-16 md:mb-96 mb-20">
          {isSuccess && (
            <Toast
              type="success"
              message="You've successfully updated your password."
              open={open}
              setOpen={setOpen}
            />
          )}
          {passwordMatch && (
            <Toast type="error" message="Passwords do not match " open={open} setOpen={setOpen} />
          )}
          {emptyFields && (
            <Toast type="error" message="All fields are required" open={open} setOpen={setOpen} />
          )}
          <div className="flex flex-col items-start md:flex-row md:justify-between md:items-center md:gap-x-7 gap-y-3">
            <label
              htmlFor="currentPassword"
              className="font-semibold text-lg text-textColor-200 dark:text-dark-textColor-50"
            >
              Current Password
            </label>
            <input
              type="password"
              name="currentPassword"
              id="currentPassword"
              placeholder="Enter your current password"
              value={currentPassword}
              onChange={(e) => setCurrentPassword(e.target.value)}
              className="w-96 md:w-80 px-4 py-3 rounded-md md:ml-1 bg-gray-100 dark:bg-dark-backgroundLight"
            />
          </div>
          <div className="flex flex-col items-start md:flex-row md:justify-between md:items-center md:gap-x-7 gap-y-3">
            <label
              htmlFor="newPassword"
              className="font-semibold text-lg text-textColor-200 md:mr-5 dark:text-dark-textColor-50"
            >
              New Password
            </label>
            <input
              type="password"
              name="newPassword"
              id="newPassword"
              placeholder="Enter new password"
              value={newPassword}
              onChange={(e) => setNewPassword(e.target.value)}
              className="w-96 md:w-80 px-4 py-3 rounded-md md:ml-2 bg-gray-100 dark:bg-dark-backgroundLight"
            />
          </div>
          <div className="flex flex-col items-start md:flex-row md:justify-between md:items-center md:gap-x-7 gap-y-3">
            <label
              htmlFor="confirmPassword"
              className="font-semibold text-lg text-textColor-200 dark:text-dark-textColor-50"
            >
              Confirm Password
            </label>
            <input
              type="password"
              name="confirmPassword"
              id="confirmPassword"
              placeholder="Confirm new password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              className="w-96 md:w-80 px-4 py-3 rounded-md bg-gray-100 dark:bg-dark-backgroundLight"
            />
          </div>
        </form>
      </div>
    </section>
  );
};

export default AccountSettingsSection;
