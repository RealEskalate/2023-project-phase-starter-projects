import React from "react";
import Image from "@/node_modules/next/image";


const About_section = () => {
  return (
    <>
      <div className=" p-10 lg:flex sm:flex-row ">
        <div className=" p-16">
          <h1 className="font-sans mb-20 font-bold text-5xl">
            <span className="text-primary">Africa </span>To Silicon Valley
          </h1>
          <p className="text-gray-400 mb-20 font-normal text-2xl ">
            A2SV is a social enterprise that enables high-potential
            <br />
            university students to create digital solutions to <br />
            Africa’s most pressing problems.
          </p>
          <button className="bg-blue-700 hover:bg-blue-800 text-white text-lg font-bold py-2 px-4 rounded-md">
            Meet our team
          </button>
          <p className="text-gray-400 mt-20 italic font-medium text-xl">
            A2SV is a social enterprise that enables high-potential
            <br />
            university students to create digital solutions to Africa’s
            <br /> most pressing problems.
          </p>
        </div>
        <div className="p-16">
          <h1 className="text-lg sm:text-xl mb-5 font-semibold font-poppins">
            Group Activities
          </h1>
          <div className="flex flex-col sm:flex-row mb-5">
            <div className="relative mb-5  mr-5">
              <Image
                width={300}
                height={100}
                className="mr-5"
                src="/images/about/image1.png"
                alt=""
              />
              <p className="font-poppins absolute top-16 left-24">
                The Education
                <pre> process</pre>
              </p>
            </div>
            <div className="relative">
              <Image width={300} height={100} className="" src="/images/about/image2.png" alt="" />
              <p className="font-poppins absolute top-16 left-24">
                Development<pre>process</pre>
              </p>
              
            </div>
          </div>
          <div className="relative">
            <Image
              width={600}
              height={300}
              className="rounded-lg"
              src="/images/about/img crp.png"
              alt=""
            />
            <p className="absolute font-poppins lg:top-8 lg:right-10 sm:top-1 left-96 md:top-4 md:left-96 md:text-sm sm:text-xs text-white font-bold ">
              20% percent Growth
            </p>
            <p className="absolute font-poppins lg:top-16 lg:right-10  sm:top-20 left-96 md:top-12 md:left-96 md:text-sm sm:text-xs text-white font-bold ">
              180% student Growth
            </p>
            <p className=" absolute font-poppins  lg:top-24  lg:right-10   sm:top-28 left-96 md:top-20 md:left-96 md:text-sm sm:text-xs text-white font-bold ">
              20% faster learning track
            </p>
          </div>
        </div>
      </div>
    </>
  );
};

export default About_section;

