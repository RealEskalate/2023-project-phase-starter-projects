import React from 'react'
import AfricaMap from '@/assets/images/Africa flag.png'
import Image from 'next/image'

const HelpUs = () => {
  return (
    <section className='mt-16 bg-gradient-to-r from-primaryColor to-[#019CFA] w-full h-72 flex justify-center items-center relative'>
      <div className='flex flex-col items-center justify-center'>
        <Image
          src={AfricaMap}
          alt='Africa'
          className='absolute z-0'
        />

        <div className='relative z-10 flex flex-col justify-center items-center'>
          <p className='text-white text-lg md:text-2xl font-semibold font-secondaryFont mb-2'>Help us sustain our mission!</p>
          <button className='text-sm bg-white font-medium text-primaryColor px-10 py-2 rounded'>Support us</button>
        </div>
      </div>
    </section>
  )
}

export default HelpUs