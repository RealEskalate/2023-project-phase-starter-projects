'use client';
import Image from 'next/image';
import teamsIcon from '@/assets/images/teamLanding.png';
import profilePic from '@/assets/images/profile.png';
import faceBookIcon from '@/assets/images/facebook.svg';
import linkedInIcon from '@/assets/images/linkedin.svg';
import instagramIcon from '@/assets/images/instagram.svg';
import { useState } from 'react';

const Section1 = () => {
  return (
    <div className="px-4 flex justify-center">
      <div className="grid grid-cols-1 md:grid-cols-2 mt-8 md:mt-40">
        <div className="w-full xl:w-[400px] mr-14">
          <h1 className="font-primaryFont text-3xl md:text-[40px] font-bold text-[#2B2A35]transition-colors ease-linear dark:text-dark-textColor-100">
            The team we’re currently working with
          </h1>
          <p className="font-secondaryFont mt-10 text-base md:text-xl leading-8transition-colors ease-linear dark:text-dark-textColor-50">
            Meet our development team is a small but highly skilled and experienced group of
            professionals. We have a talented mix of web developers, software engineers, project
            managers and quality assurance specialists who are passionate about developing
            exceptional products and services.
          </p>
        </div>
        <div className="flex flex-col gap-10 xl:w-[600px] mt-20 xl:mt-[-20px]">
          <Image src={teamsIcon} alt="teams landing" />
        </div>
      </div>
    </div>
  );
};

type profile = {
  name: string;
  occupation: string;
  description: string;
};
const ProfileCard = ({ name, occupation, description }: profile) => {
  return (
    <div className="w-full h-auto pb-10 shadow px-4 lg:px-8 md:px-14 mt-20  dark:bg-dark-backgroundLight dark:text-dark-textColor-100 hover:shadow-lg cursor-pointer dark:hover:shadow dark:hover:shadow-slate-700 transition-all ease-linear">
      <div className="flex justify-center w-full">
        <div className="rounded-full bg-gray-200 p-2 overflow-hidden flex justify-center items-center">
          <Image src={profilePic} alt="proflie picture" height={150} />
        </div>
      </div>
      <div>
        <h1 className="flex justify-center mt-4 font-primaryFont text-3xl tracking-widest font-bold">
          {name}
        </h1>
        <h2 className="flex w-full justify-center text-xl font-secondaryFont font-bold mt-2transition-colors ease-linear dark:text-dark-textColor-50">
          {occupation}
        </h2>
        <p className="mt-4  font-secondaryFont text-center text-base transition-colors ease-linear dark:text-dark-textColor-50">
          {description}
        </p>
      </div>
      <div className="flex justify-between mt-10 border-t transition-colors ease-linear dark:border-none border-gray-300 pt-4">
        <Image
          src={faceBookIcon}
          alt="facebook icon"
          className="h-8 w-8 md:h-10 md:w-10 hover:brightness-110 transition-all ease-linear"
        />
        <Image
          src={linkedInIcon}
          alt="facebook icon"
          className="h-8 w-8 md:h-10 md:w-10 hover:brightness-110 transition-all ease-linear"
        />
        <Image
          src={instagramIcon}
          alt="facebook icon"
          className="h-8 w-8 md:h-10 md:w-10 hover:brightness-110 transition-all ease-linear"
        />
      </div>
    </div>
  );
};

const Section2 = () => {
  return (
    <div className="px-4 md:px-20 grid md:gap-8 md:grid-cols-2 xl:grid-cols-3 w-full mb-20">
      <ProfileCard
        name="Nathaniel Awel"
        occupation="Software Engineer"
        description="He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies."
      />
      <ProfileCard
        name="Nathaniel Awel"
        occupation="Software Engineer"
        description="He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies."
      />
      <ProfileCard
        name="Nathaniel Awel"
        occupation="Software Engineer"
        description="He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies."
      />
      <ProfileCard
        name="Nathaniel Awel"
        occupation="Software Engineer"
        description="He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies."
      />
    </div>
  );
};

const Section3 = () => {
  const [currentNav, setCurrent] = useState<number>(1);
  const pages = [1, 2, 3, 4, 5, 6];
  const updatePage = (page: number) => {
    setCurrent(page);
  };
  return (
    <div className="w-full flex justify-center mb-20">
      <div className="flex flex-wrap gap-4">
        {pages.map((page, index) => (
          <span
            key={index}
            onClick={() => updatePage(page)}
            className={`flex justify-center items-center h-10 w-10 font-bold font-primaryFont bg-slate-300 rounded-lg cursor-pointer ${
              page == currentNav && '!bg-blue-800 !text-white'
            }`}
          >
            {page}
          </span>
        ))}
      </div>
    </div>
  );
};

const Teams = () => {
  return (
    <div className="">
      <Section1 />
      <Section2 />
      <Section3 />
    </div>
  );
};

export default Teams;
