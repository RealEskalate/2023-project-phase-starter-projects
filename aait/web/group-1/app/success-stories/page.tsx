import React from 'react';
import Image from 'next/image';
import Link from 'next/link';
import Story from "@/components/success-stories/Story";
import { SuccessStory } from "@/types/story";

export default async function Page() {
  const response = await fetch('https://a2sv-backend.onrender.com/api/success-stories');
  const allData: SuccessStory[] = await response.json();

  const partners: string[] = [
    'Google',
    'Palantir',
    'InstaDeep',
    'Meta',
    'Databricks',
    'Linkedin'
  ].map(partner => `/images/partners/${ partner }.png`);

  const socialIcons = [
    'facebook',
    'linkedin',
    'telegram',
    'twitter',
  ].map(icon => `/images/success-social-icons/${ icon }.png`);

  return (
    <div className='flex flex-col px-[100px] space-y-32'>

      <div className='text-center font-poppins mb-[60px]'>
        <h2 className='text-[35px] font-semibold mb-[25px]'>Impact Stories</h2>
        <p className='text-[25px] px-[270px]'>Behind every success is a story. Learn about the stories of A2SVians</p>
        <span></span>
      </div>

      <div className='flex flex-col space-y-20'>
        {
          allData.map(data => <Story data={ data }/>)
        }
      </div>
      <div>
        <h1 className='text-center text-4xl text-[#363636] font-dmSans mb-20'>Current Interview Partners</h1>
        <div className='flex justify-center items-center mt-5'>
          {
            partners.slice(0, 4).map(partner => {
              return (
                <Image
                  src={ partner }
                  width={ 250 }
                  height={ 60 }
                  alt={ partner }
                />
              )
            })
          }
        </div>
        <div className='flex justify-evenly items-center px-[400px]'>
          {
            partners.slice(4).map(partner => {
              return (
                <Image
                  src={ partner }
                  width={ 250 }
                  height={ 60 }
                  alt={ partner }
                />
              )
            })
          }
        </div>
      </div>
      <div className='font-poppins grid grid-cols-4 h-[360px] space-x-10'>
        <div className='col-span-1 mt-20'>
          <Image
            className='pt-3'
            src='/images/logo.png'
            width={ 150 }
            height={ 40 }
            alt='A2SV Main Logo'
          />
          <div className='text-gray-500 mt-[100px] text-sm'>
            <p>© Copyright 2023 A2SV Foundation.</p>
            <p>Terms of service | Privacy Policy</p>
          </div>
        </div>

        <div className='col-span-1 mt-20'>
          <h1 className='text-[18px] mb-[14px] font-semibold'>Our Teams</h1>
          <ul className='flex flex-col space-y-[16px] text-gray-500 text-sm'>
            <li>
              <Link href='/'>Advisors</Link>
            </li>
            <li>
              <Link href='/'>Board Members</Link>
            </li>
            <li>
              <Link href='/'>Executives</Link>
            </li>
            <li>
              <Link href='/'>Groups</Link>
            </li>
          </ul>
        </div>
        <div className='col-span-1 mt-20'>
          <h1 className='text-[18px] mb-[14px] font-semibold'>Our Teams</h1>
          <ul className='flex flex-col space-y-[16px] text-gray-500 text-sm'>
            <li>
              <Link href='/'>Donate</Link>
            </li>
            <li>
              <Link href='/'>Get involved</Link>
            </li>
            <li>
              <Link href='/'>About us</Link>
            </li>
          </ul>
        </div>
        <div className='col-span-1 mt-20'>
          <div>
            <h3 className='mb-5 text-[18px] font-semibold'>Get in touch</h3>
            <div className='text-gray-500 text-sm'>
              <p>Questions or feedback?</p>
              <p>we would like to hear from you</p>
            </div>
          </div>
          <div className='mt-5'>
            <ul className='flex flex-row justify-start space-x-5'>
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
          </div>
        </div>

      </div>
    </div>
  )
}
