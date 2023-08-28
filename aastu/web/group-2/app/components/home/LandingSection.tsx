'use client';
import Image from 'next/image';
import React, { useEffect, useState } from 'react';
import landingImage from '@/assets/images/LandingPageGridImage.png';
import { BsArrowRightShort } from 'react-icons/bs';
import Link from 'next/link';

const LandingSection = () => {
  const [loggedIn, setLoggedIn] = useState(false);

  useEffect(() => {
    if (localStorage.getItem('login')) {
      setLoggedIn(true);
    }
  }, []);

  return (
    <section className="font-primaryFont mx-5 my-10 md:mx-10 md:my-20">
      <div className="grid grid-cols-1 md:grid-cols-2 md:grid-rows-1 md:gap-4 gap-y-12">
        <div className="flex flex-col justify-start items-center space-y-10">
          <h1 className="text-4xl md:text-5xl font-extrabold lg:w-3/4 text-center md:text-left">
            <span className="text-secondaryColor">African to</span>{' '}
            <span className="text-primaryColor">Silicon Valley</span>
          </h1>
          <p className="text-center sm:!leading-10 md:text-left text-xl md:text-2xl text-[#424242] lg:w-3/4 mt-2 md:mt-2.5">
            A2SV up-skills high-potential university students, connects them with opportunities at
            top tech companies
          </p>
          <div className="flex w-full lg:w-3/4 justify-center md:justify-start gap-4 mt-8">
            {loggedIn ? (
              <Link
                href="/profile"
                className="border-solid text-sm md:text-base border-primaryColor border-2 rounded-md px-2 lg:px-10 py-1 md:py-3 text-primaryColor font-medium"
              >
                My profile
              </Link>
            ) : (
              <Link
                href="/login"
                className="border-solid text-sm md:text-base border-primaryColor border-2 rounded-md px-6 lg:px-10 py-2 md:py-3 text-primaryColor font-medium"
              >
                Get started
              </Link>
            )}

            <Link
              href="/donate"
              className="flex items-center text-sm md:text-base uppercase text-white bg-primaryColor rounded-md py-1.5 font-medium px-6"
            >
              Support us <BsArrowRightShort className="ml-1" />
            </Link>
          </div>
        </div>
        <div className="flex justify-center items-start px-4 sm:px-10">
          <Image src={landingImage} alt="Landing image" />
        </div>
      </div>
    </section>
  );
};

export default LandingSection;
