import { Profile } from '@/types/Profile'
import Image from 'next/image'
import Link from 'next/link'
import React from 'react'


const Card: React.FC<Profile> = ({ name, bio, department, socialMedia}) => {
  return (
    <div className='w-full shadow-md rounded-lg px-10'>
      <div className='flex flex-col items-center'>
        <div className='mt-5'>
          <Image src={'./images/pfp.svg'} alt={'member pic'} width={120} height={120}/>
        </div>
        <h1 className='mt-5 uppercase text-2xl font-extrabold tracking-wide' style={{ letterSpacing: '0.2em' }}>{name}</h1>
        <h1 className='mt-1 text-gray-600 uppercase text-lg font-semibold tracking-wider' style={{ letterSpacing: '0.2em' }}>{department}</h1>
        <div className='mt-5 text-gray-400 text-center'>
          {bio}
        </div>
        {socialMedia && <div className='w-full mt-10 p-4 border-t border-t-gray-200 flex justify-between'>
            <Link href={`https://${socialMedia.facebook}`}><Image src={'./images/facebook.svg'} alt={'facebook-logo'} width={30} height={30} className='hover:cursor-pointer'/></Link>
            <Link href={`https://${socialMedia.linkedin}`}><Image src={'./images/linkedin.svg'} alt={'linkedin-logo'} width={30} height={30} className='hover:cursor-pointer'/></Link>
            <Link href={`https://${socialMedia.instagram}`}><Image src={'./images/instagram.svg'} alt={'instagram-logo'} width={30} height={30} className='hover:cursor-pointer'/></Link>
        </div>}
      </div>
    </div>
  )
}

export default Card