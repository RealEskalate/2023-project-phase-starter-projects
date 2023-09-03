import React from 'react';
import Image from 'next/image';
import Link from 'next/link';


export default function Footer() {
  // When the social media links are available then I can make an object of links together with their icons
  const socialIcons: string[] = [ 'facebook', 'twitter', 'instagram', 'linkedin', 'youtube' ].map((icon) => `/images/social-icons/${icon}.png`);

  return (
    <footer className='border-t mt-32 h-[450px] flex flex-col justify-center space-y-10 font-montserrat'>
      <div className='grid grid-cols-5 items-center justify-center gap-5'>
        <div className='col-span-1 h-full flex justify-center items-center'>
          <Image
            src='/images/rafiki.png'
            alt='Rafiki'
            width={ 200 }
            height={ 180 }
          />
        </div>
        <div className='col-span-1 flex flex-col justify-center items-start space-y-10 h-full'>
          <p className='font-bold text-xl'>Get involved in improving tech education in Africa!</p>
          <button className='text-white px-20 py-3 bg-blue-800 rounded-md text-shadow'>Support Us</button>
        </div>
        <div className='col-span-1'>
          <h3 className='font-bold mb-[40px]'>Links</h3>
          <ul className='flex flex-col space-y-[32px]'>
            <li>
              <Link href='/' >Home</Link>
            </li>
            <li>
              <Link href='/success-stories' >Success Stories</Link>
            </li>
            <li>
              <Link href='/about' >About us</Link>
            </li>
            <li>
              <Link href='/' >Get Involved</Link>
            </li>
          </ul>
        </div>
        <div className='col-span-1'>
          <h3 className='font-bold mb-[40px]'>Teams</h3>
          <ul className='flex flex-col space-y-[32px]'>
            <li>
              <Link href='/' >Board Members</Link>
            </li>
            <li>
              <Link href='/' >Advisors/Mentors</Link>
            </li>
            <li>
              <Link href='/' >Executives</Link>
            </li>
            <li>
              <Link href='/' >Staffs</Link>
            </li>
          </ul>
        </div>
        <div className='col-span-1'>
          <h3 className='font-bold mb-[40px]'>Blogs</h3>
          <ul className='flex flex-col space-y-[32px]'>
            <li>
              <Link href='/'>Recent Blogs</Link>
            </li>
            <li>
              <Link href='/blog/addBlog'>New Blog</Link>
            </li>
          </ul>
        </div>
      </div>
      <div className='flex justify-between mx-20 py-10 border-t'>
        <div>
          <p className='font-light text-md'>© 2020 Africa to Silicon Valley, Inc. All right reserved.</p>
        </div>
        <div className='flex space-x-[37px] justify-center items-center'>
          <ul className='flex justify-center items-center space-x-[37px]'>
            {
              socialIcons.map(icon => {
                return (
                  <li key={ icon }>
                    <Image
                      src={ icon }
                      alt='Social Media Icons'
                      width={ 25 }
                      height={ 25 }
                    />
                  </li>
                );
              })
            }
          </ul>
        </div> { /** Social Media Icons */ }
      </div>
    </footer>
  );
}
