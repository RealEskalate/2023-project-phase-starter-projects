'use client'
import React, { useRef, useState, useEffect } from 'react';
import Image from 'next/image';
import { useEditProfileMutation } from '@/store/features/user/userApi';
import { getCurrUser } from '@/utils/authHelpers';
import { toast } from 'react-toastify';

const currUser = getCurrUser()
async function fetchImageAndCreateFile(profileURL: string) {
  try {
    const response = await fetch(profileURL);
    const blob = await response.blob();
    return new File([blob], 'profile-picture.jpg', { type: 'image/jpeg' });
  } catch (error) {
    return null;
  }
}


export default function Page() {
  const trimmedName = currUser?.userName.trim()
  const [fName, lName] = trimmedName.split(/\s+/)
  const fileInputRef = useRef(null)
  const [firstName, setFirstName] = useState(fName || '')
  const [lastName, setLastName] = useState(lName || '')
  const [email, setEmail] = useState(currUser?.userEmail || '')
  const [photo, setPhoto] = useState<File | null>(null)

  useEffect(() => {
    if (currUser?.userProfile) {
      fetchImageAndCreateFile(currUser.userProfile).then((file) => {
        if (file) {
          setPhoto(file);
        }
      });
    }
  }, [currUser]);

  const [editProfile, {isError, isLoading, isSuccess}] = useEditProfileMutation()

  const handleDivClick = () => {
    if (fileInputRef.current) {
      fileInputRef.current.click();
    }
  };

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if(event.target.files) {
      const file = event.target.files[0];
      setPhoto(file)
    }
  }

  const handleSaveChanges = async (event: React.FormEvent) => {
    event.preventDefault()
    const newUserData = new FormData()
    newUserData.append("name", `${firstName} ${lastName}`)
    newUserData.append("email", email)
    if(photo) {
      newUserData.append("image", photo)
    }

    editProfile(newUserData)
    if(isSuccess) {
      toast.success('Profile updated successfuly')
    } else if(isError) {
      toast.error("Couldn't update profile")
    }
    
   
  }

  return (
    <div className='flex flex-col space-y-5 font-montserrat'>
      <div className='flex justify-between'>
        <div>
          <h3 className='text-[13px] text-[#5D5D5D] font-semibold'>Manage Personal Information</h3>
          <p className='text-[10px] text-[#868686] font-light'>Add all the required information about yourself</p>
        </div>
        <button 
          className='text-[10px] font-semibold bg-[#264FAD] active:bg-blue-500 rounded-md text-white px-12 py-2'
          onClick={handleSaveChanges}
        >
          Save Changes
        </button>
      </div>
      <div className='grid grid-cols-3 lg:pr-[300px] gap-10 text-[10px] md:text-[11px]'>
        <h4 className=' text-[#565656] font-semibold font-poppins col-span-1'>Name <span className='text-[#F64040]'>*</span></h4>
        <input
          type="text"
          className=" text-[#565656] font-semibold font-poppins col-span-1 border border-gray-300 rounded-lg py-2 px-3"
          value={firstName}
          onChange={(e) => setFirstName(e.target.value)}
          />
        <input
          type="text"
          className=" text-[#565656] font-semibold font-poppins col-span-1 border border-gray-300 rounded-lg py-2 px-3"
          value={lastName}
          onChange={(e) => setLastName(e.target.value)}
          />
        <h4 className=' text-[#565656] font-semibold font-poppins col-span-1'>Email <span className='text-[#F64040]'>*</span></h4>
        <input
          type="email"
          className=" text-[#565656] font-semibold font-poppins col-span-2 border border-gray-300 rounded-lg py-2 px-3"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          />
        <h4 className=' text-[#565656] font-semibold font-poppins col-span-1'>Your Photo <span className='text-[#F64040]'>*</span></h4>
        <div className='col-span-2 flex items-start justify-center md:justify-start space-x-0 md:space-x-16'>
          {
            photo && 
            <Image
                className='hidden md:block'
                src={photo ? URL.createObjectURL(photo) : currUser?.userProfile}
                width={ 50 }
                height={ 50 }
                alt='small profile image'
              />
          }
          <div 
            className='text-center border flex flex-col justify-center items-center border-gray-300 rounded-lg h-full px-10 py-12'
            onClick={handleDivClick}
          >
            <Image
              src='/images/file-upload-image.png'
              width={ 25 }
              height={ 25 }
              alt='file upload image'
            />
            <p className='text-[10px] font-semibold sm:text-[11px] text-[#858585]'> 
              <span className='text-[#565656]'>Clik to upload</span> or drag and drop
              SVG, PNG, JPG or GIF(max 800x400px)
            </p>
            <input
              type='file'
              ref={fileInputRef}
              className='hidden'
              onChange={handleFileChange}
            />
          </div>
        </div>
      </div>
    </div>
  );
}


