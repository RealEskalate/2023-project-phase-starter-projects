import React from 'react';
import Card from '@/components/profile/Card';

export default function Page() {
  return (
    <div className='px-[100px] flex flex-col space-y-5 font-montserrat'>
      <h1 className='text-[22px] font-semibold'>Profile</h1>
      <div className='flex justify-between items-center text-md'>
        <div className='flex space-x-10 text-[12px] text-[#494949] font-semibold'>
          <h3>Personal Information</h3>
          <h3 className='border-b-2'>My Blogs</h3>
          <h3>Account Setting</h3>
        </div>
        <button className='text-[10px] font-semibold bg-[#264FAD] rounded-md text-white px-12 py-2'>New Blog</button>
      </div>
      <div>
        <h3 className='text-[13px] text-[#5D5D5D] font-semibold'>Manage Blogs</h3>
        <p className='text-[10px] text-[#868686] font-light'>Edit, Delete and View the status of your blogs</p>
      </div>
      <div className='grid grid-cols-4 gap-20'>
        {Array.from({ length: 8 }).map((_, index) => (
          <div key={index} className=''>
            <Card />
          </div>
        ))}
      </div>
    </div>
  );
}
