import React from 'react';
import Image from 'next/image';
import person1 from '@/assets/images/profiles/Abel Getahun.png';
import person2 from '@/assets/images/profiles/Aklile Seyoum.png';
import person3 from '@/assets/images/profiles/Mintesnot Markos.png';
import person4 from '@/assets/images/profiles/Naol Tamrat.png';
import person5 from '@/assets/images/profiles/Natanim Ashenafi.png';
import person6 from '@/assets/images/profiles/Solomon Abate.png';
import person7 from '@/assets/images/profiles/Wubshet Zeleke.png';

const ImpactStoriesSection = () => {
  return (
    <section className="transition-colors ease-linear  mt-8 flex flex-col justify-center items-center gap-y-12 my-10 md:mt-24">
      <h2 className="transition-colors ease-linear text-textColor-300 font-secondaryFont text-3xl font-bold dark:text-dark-textColor-100">
        Impact Stories
      </h2>

      <div className="transition-colors ease-linear grid grid-cols-1 lg:grid-cols-2 lg:grid-rows-1 lg:gap-x-32 gap-y-5 lg:gap-2 w-11/12 md:w-10/12">
        <div>
          <h3 className="transition-colors ease-linear font-semibold text-lg text-textColor-300 mb-1 md:mb-1.5 dark:text-dark-textColor-100">
            Abel Tsegaye
          </h3>
          <p className="transition-colors ease-linear text-base font-medium text-textColor-200 mb-3 md:mb-5 dark:text-dark-textColor-50">
            Software Engineer at Google
          </p>
          <p className="transition-colors ease-linear text-textColor-100 = font-normal md:text-left mb-6 md:mb-8 dark:text-dark-textColor-50">
            “ When I joined A2SV in 2019, I found the concept of data structures and algorithms
            quite challenging. A2SV's smooth learning process and dedicated team molded me to see
            the peak of my abilities. Through A2SV's effective education and continual support, I
            passed Google's internship interviews and attended a summer internship at Google in
            Amsterdam. However, the A2SV program and training is beyond technical education and
            interview preparation. As an A2SVian, I also learned the values of putting humanity
            first, giving back to our community, and utilizing teamwork with my colleagues, which I
            can now consider my big family. After completing three remarkable months at Google, I
            was offered a full-time position at Google's London office for 2022. “
          </p>

          <button className="transition-colors ease-linear text-sm text-white font-medium bg-primaryColor px-9 py-2.5 rounded">
            See more
          </button>
        </div>

        <div className="transition-colors ease-linear grid md:mx-auto grid-cols-4 md:grid-cols-3 md:grid-rows-3 lg:gap-4 md:gap-8 gap-4">
          <Image
            src={person1}
            alt="person 1"
            className="transition-colors ease-linear col-span-2 md:col-span-1 md:col-start-2 bg-black md:h-[30vw] lg:h-[13vw] h-[50vw] text-white  object-cover"
          />
          <Image
            src={person2}
            alt="person 1"
            className="transition-colors ease-linear col-span-2 md:col-span-1 md:col-start-3 md:row-start-2 md:h-[30vw] lg:h-[13vw] md:bg-black h-[50vw] text-white  md:-mt-24 object-cover"
          />
          <Image
            src={person3}
            alt="person 1"
            className="transition-colors ease-linear col-span-2 object-cover md:col-span-1 md:col-start-2 md:h-[30vw] lg:h-[13vw] md:row-start-2 md:bg-black h-[50vw] text-white"
          />

          <Image
            src={person4}
            alt="person 1"
            className="transition-colors ease-linear col-span-2 object-cover md:col-span-1 md:col-start-1 md:h-[30vw] lg:h-[13vw] md:row-start-2 md:bg-black h-[50vw] text-white md:-mt-24"
          />

          <Image
            src={person5}
            alt="person 1"
            className="transition-colors ease-linear col-span-2 object-cover md:col-span-1 md:row-start-3 md:h-[30vw] lg:h-[13vw] md:bg-black h-[50vw] text-white md:-mt-24"
          />

          <Image
            src={person6}
            alt="person 1"
            className="transition-colors ease-linear col-span-2 object-cover md:col-span-1 md:col-start-3 md:h-[30vw] lg:h-[13vw] md:row-start-3 md:bg-black h-[50vw] text-white  md:-mt-24"
          />

          <Image
            src={person7}
            alt="person 1"
            className="transition-colors ease-linear col-span-2 object-cover md:col-span-1 md:row-start-3 md:h-[30vw] lg:h-[13vw] col-start-2 md:bg-black h-[50vw] text-white "
          />
        </div>
      </div>
    </section>
  );
};

export default ImpactStoriesSection;
