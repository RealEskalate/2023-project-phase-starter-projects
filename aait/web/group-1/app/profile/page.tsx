import React, { useState } from 'react';
import Image from 'next/image';


export default function Page() {
  return (
    <div className='flex flex-col space-y-5 font-montserrat'>
      <div className='flex justify-between'>
        <div>
          <h3 className='text-[13px] text-[#5D5D5D] font-semibold'>Manage Personal Information</h3>
          <p className='text-[10px] text-[#868686] font-light'>Add all the required information about yourself</p>
        </div>
        <button className='text-[10px] font-semibold bg-[#264FAD] rounded-md text-white px-12 py-2'>Save Changes</button>
      </div>
      <div className='grid grid-cols-3 lg:pr-[300px] gap-10 text-[10px] md:text-[11px]'>
        <h4 className=' text-[#565656] font-semibold font-poppins col-span-1'>Name <span className='text-[#F64040]'>*</span></h4>
        <input
          type="text"
          className=" text-[#565656] font-semibold font-poppins col-span-1 border border-gray-300 rounded-lg py-2 px-3"
          value='Yididiya'
          />
        <input
          type="text"
          className=" text-[#565656] font-semibold font-poppins col-span-1 border border-gray-300 rounded-lg py-2 px-3"
          value='Kebede'
          />
        <h4 className=' text-[#565656] font-semibold font-poppins col-span-1'>Email <span className='text-[#F64040]'>*</span></h4>
        <input
          type="email"
          className=" text-[#565656] font-semibold font-poppins col-span-2 border border-gray-300 rounded-lg py-2 px-3"
          value='yididiyakebede@gmail.com'
          />
        <h4 className=' text-[#565656] font-semibold font-poppins col-span-1'>Your Photo <span className='text-[#F64040]'>*</span></h4>
        <div className='col-span-2 flex items-start justify-center md:justify-start space-x-0 md:space-x-16'>
          <Image
              className='hidden md:block'
              src='/images/profile-image.png'
              width={ 50 }
              height={ 50 }
              alt='small profile image'
            />
          <div className='text-center border flex flex-col justify-center items-center border-gray-300 rounded-lg h-full px-10 py-12'>
            <Image
              src='/images/file-upload-image.png'
              width={ 25 }
              height={ 25 }
              alt='file upload image'
            />
            <p className='text-[10px] font-semibold sm:text-[11px] text-[#858585]'> <span className='text-[#565656]'>Clik to upload</span> or drag and drop SVG, PNG, JPG or GIF(max 800x400px)</p>
          </div>
        </div>
      </div>
    </div>
  );
}
