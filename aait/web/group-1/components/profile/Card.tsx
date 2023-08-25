import React from 'react';
import Image from 'next/image';


const Card = () => {
  return (
    <div className='col-span-1 font-montserrat shadow-sm rounded-md w-80 max-w-[280px]'>
      <Image
        className='object-cover w-full'
        src='/images/test-card-image.png'
        alt='test card image'
        width={ 420 }
        height={ 300 }
      />

      <div className='px-5 flex flex-col items-start space-y-5 py-5'>

        <h4 className='text-gray-700 text-sm'>Design Liberalized Exchange Rate Management</h4>

        <div className='flex justify-start items-center space-x-3'>
          <Image
            className='rounded-full'
            src='/images/Image.png'
            alt='test avatar image'
            width={ 26 }
            height={ 26 }
          />
          <p className='text-[11px] text-[#B9B9C3] font-light'>by <span className='text-[#6E6B7B] font-semibold'>Fred Boone</span> | Jan 10, 2020</p>
        </div>

        <div className='flex items-center justify-start space-x-4'>
          <div className='text-[9px] px-4 py-2 font-semibold text-gray-400 rounded-full border bg-gray-200'>UI/UX</div>
          <div className='text-[9px] px-4 py-2 font-semibold text-gray-400 rounded-full border bg-gray-200'>DEVELOPMENT</div>
        </div>

        <div className='text-[11px] text-gray-500'>A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.</div>

        <div className='flex justify-between items-center w-full border-t pt-4 text-[12px]'>
          <div className='flex justify-start items-center space-x-1'>
            <Image
              className='w-[13px]'
              src='/images/test-pending.png'
              alt='pending image'
              width={ 20 }
              height={ 20 }
            />
            <span className='text-[#FF9F43] font-semibold'>Pending</span>
          </div>
          <div className='text-[#7367F0] font-semibold'>Read More</div>
        </div>

      </div>

    </div>
  )
}

export default Card;
