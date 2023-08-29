import React from 'react';
import AfricaMap from '@/assets/images/Africa flag.png';
import Image from 'next/image';

const HelpUs = () => {
  return (
    <section className="transition-colors ease-linear my-10 md:mt-16 bg-gradient-to-r from-primaryColor to-[#019CFA] w-full h-64 md:h-72 flex justify-center items-center relative dark:to-dark-backgroundLight dark:from-[#113774]">
      <div className="transition-colors ease-linear flex flex-col items-center justify-center">
        <Image
          src={AfricaMap}
          alt="Africa"
          className="transition-colors ease-linear absolute z-0"
        />

        <div className="transition-colors ease-linear relative z-10 flex flex-col justify-center items-center">
          <p className="transition-colors ease-linear text-white text-lg md:text-2xl font-semibold font-secondaryFont mb-2">
            Help us sustain our mission!
          </p>
          <button className="transition-colors ease-linear text-sm bg-white font-medium text-primaryColor px-10 py-2 rounded">
            Support us
          </button>
        </div>
      </div>
    </section>
  );
};

export default HelpUs;
