import React from 'react';
import Card from '@/components/profile/Card';

export default function Page() {
  return (
    <div className='flex flex-col space-y-5 font-montserrat'>
      <div>
        <h3 className='text-[13px] text-[#5D5D5D] font-semibold'>Manage Blogs</h3>
        <p className='text-[10px] text-[#868686] font-light'>Edit, Delete and View the status of your blogs</p>
      </div>
      <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 place-items-center gap-4'>
        {Array.from({ length: 8 }).map((_, index) => (
          <div key={index} className=''>
            <Card />
          </div>
        ))}
      </div>
    </div>
  );
}
