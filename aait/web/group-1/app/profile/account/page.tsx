'use client'

import React, { useState } from 'react';
import Image from 'next/image';
import { useChangePasswordMutation } from '@/store/features/user/userApi';
import { toast } from 'react-toastify';

export default function Page() {
  const [changePassword] = useChangePasswordMutation()
  const [oldPassword, setOldPassword] = useState('')
  const [newPassword, setNewPassword] = useState('')
  const [confirmPass, setConfirmPass] = useState('')

  const handleSaveChanges = () => {
    if(newPassword !== confirmPass) {
      toast.error('Passwords are not matching')
      return
    }
    changePassword({"oldPassword": oldPassword, "newPassword": newPassword})
    toast.success("Password changed successfuly")

  }


  return (
    <div className='flex flex-col space-y-16 font-montserrat'>
      <div className='flex justify-between'>
        <div>
          <h3 className='text-[13px] text-[#5D5D5D] font-semibold'>Manage Your Account</h3>
          <p className='text-[10px] text-[#868686] font-light'>You can change your password here</p>
        </div>
        <button 
          className='text-[10px] font-semibold bg-[#264FAD] rounded-md text-white px-12 py-2'
          onClick={handleSaveChanges}
        >
          Save Changes
        </button>
      </div>
      <form className='grid grid-cols-3 place-items-start items-center text-[11px] font-poppins w-full max-w-md mx-auto gap-y-5'>
        <label className='col-span-1 font-semibold text-[#565656]'>Current Password</label>
        <div className='col-span-2 flex justify-between items-center py-3 px-5 rounded-lg bg-[#EFF3F9] w-full'>
          <input
            type="password"
            className='focus:outline-none bg-[#EFF3F9]'
            placeholder='Enter your current password'
            onChange={(e) => setOldPassword(e.target.value)}
            />
          <Image
            src='/images/toggle-password-status.png'
            width={ 12 }
            height={ 12 }
            alt=' toggle password visiblity'
            className=''
          />
        </div>
        <label className='col-span-1 font-semibold text-[#565656]'>New Password</label>
        <div className='col-span-2 flex justify-between items-center py-3 px-5 rounded-lg bg-[#EFF3F9] w-full'>
          <input
            type="password"
            className='focus:outline-none bg-[#EFF3F9]'
            placeholder='Enter new password'
            onChange={(e) => setNewPassword(e.target.value)}
            />
          <Image
            src='/images/toggle-password-status.png'
            width={ 12 }
            height={ 12 }
            alt=' toggle password visiblity'
            className=''
          />
        </div>
        <label className='col-span-1 font-semibold text-[#565656]'>Confirm Password</label>
        <div className='col-span-2 flex justify-between items-center py-3 px-5 rounded-lg bg-[#EFF3F9] w-full'>
          <input
            type="password"
            className='focus:outline-none bg-[#EFF3F9]'
            placeholder='Confirm new password'
            onChange={(e) => setConfirmPass(e.target.value)}
            />
          <Image
            src='/images/toggle-password-status.png'
            width={ 12 }
            height={ 12 }
            alt=' toggle password visiblity'
            className=''
          />
        </div>
      </form>
    </div>
  );
}


