'use client'
import React from "react";
import Image from "@/node_modules/next/image";


const AboutSection:React.FC = () => {
  return (
    <>
      <div className=" p-10 lg:flex sm:flex-row ">
        <div className=" p-12">
          <h1 className="font-lato mb-20 font-bold text-5xl">
            <span className="text-blue-first ">Africa </span>To Silicon Valley
          </h1>
          <p className="text-gray-400 mb-20 font-normal font-nunito text-2xl ">
            A2SV is a social enterprise that enables high-potential
            <br />
            university students to create digital solutions to <br />
            Africa’s most pressing problems.
          </p>
          <button className="bg-blue-first font-nunito hover:bg-blue-800 text-white text-lg font-bold py-2 px-4 rounded-md">
            Meet our team
          </button>
          <p className="text-gray-400 mt-20 font-nunito italic text-xl">
            A2SV is a social enterprise that enables high-potential
            <br />
            university students to create digital solutions to Africa’s
            <br /> most pressing problems.
          </p>
        </div>
        <div className="p-16 mx-auto">
          <h1 className="text-lg sm:text-xl mb-5 font-weight-500 font-poppins">
            Group Activities
          </h1>
          <div className="flex flex-col sm:flex-row mb-5">
            <div className="relative mb-5  mr-5">
              <Image
                width={300}
                height={100}
                className="mr-5"
                src="/images/about/image1.png"
                alt="education-image"
              />
              <p className="font-poppins text-white drop-shadow-lg absolute top-16 left-24">
                The Education<br/>
                    Process
                
              </p>
            </div>
            <div className="relative">
              <Image width={300} height={100} className="" src="/images/about/image2.png" alt="Devlopment-image" />
              <p className="font-poppins text-white drop-shadow-lg absolute top-16 left-24">
                Education <br/>
                Phase
              </p>
              
            </div>
          </div>
          <div className="relative">
            <Image
              width={650}
              height={300}
              className="rounded-lg"
              src="/images/about/img crp.png"
              alt="path-image"
            />
            <p className="absolute font-poppins text-white text-semibold lg:top-8 lg:right-10 sm:top-1 left-96 md:top-4 md:left-96 md:text-sm sm:text-xs font-bold ">
              20% percent Growth
            </p>
            <p className="absolute font-poppins text-card-gray lg:top-16 lg:right-10  sm:top-20 left-96 md:top-12 md:left-96 md:text-sm sm:text-xs font-bold ">
              180% student Growth
            </p>
            <p className=" absolute font-poppins  text-card-gray  lg:top-24  lg:right-10   sm:top-28 left-96 md:top-20 md:left-96 md:text-sm sm:text-xs font-bold ">
              20% faster learning track
            </p>
          </div>
        </div>
      </div>
    </>
  );
};

export default AboutSection;

