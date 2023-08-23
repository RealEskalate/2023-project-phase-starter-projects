import Image from 'next/image'
import React from 'react'
import TeamImage from '../../public/images/team-work.svg'

const page = () => {
  return (
    <div>
      <div className="flex items-center">
        {/*team text section */}
        <div className="w-1/2 ml-16 flex flex-col gap-6 px-10">
            <div className="text-6xl font-extrabold uppercase">The team we’re</div>
            <div className="text-6xl font-extrabold uppercase">currently</div>
            <div className="text-6xl font-extrabold uppercase">working with</div>
            <p className='mt-10 text-xl text-gray-500'>
            Meet our development team is a small but highly skilled and
            experienced group of professionals. We have a talented mix of web
            developers, software engineers, project managers and quality
            assurance specialists who are passionate about developing
            exceptional products and services.
          </p>
        </div>

        {/* team image section */}
        <div className="w-1/2">
          <Image src={TeamImage} alt={"Team work"}/>
        </div>
      </div>
    </div>
  )
}

export default page