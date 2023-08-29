"use client";
import React from "react";
import Image from "next/image";
import useStories from "@/hooks/useStories";

export default function SuccessStoryCard() {
  const { stories, isLoading, error } = useStories();

  if (isLoading) {
    return (
      <div className="flex justify-center items-center h-[400px]">
        <div className="animate-spin rounded-full border-t-4 border-blue-500 border-opacity-75 h-12 w-12"></div>
      </div>
    );
  }

  if (error) {
    return <div>Error loading data.</div>;
  }

  return (
    <>
      {stories?.map((item, index) => (
        <div
          key={index}
          className={`w-full flex lg:flex-row flex-col gap-4 lg:gap-14 rounded-xl ${
            index % 2 && "lg:flex-row-reverse"
          }`}
        >
          <div className="relative lg:w-[45%] w-full h-[400px] lg:h-[650px] rounded-xl">
            <Image
              src="/images/yishak.png"
              alt=""
              width={500}
              height={600}
              className="w-full h-full bg-image object-cover rounded-xl"
            />
            <div className="h-24 lg:h-44 -translate-y-24 lg:-translate-y-44 flex flex-col  left text-slate-50  gap-1 lg:gap-2 px-4 lg:px-7 py-3 lg:py-5 bg-opacity-50 opacity-100 backdrop-blur-lg rounded-xl">
              <p className="text-xl lg:text-2xl font-poppins font-semibold tracking-wide ">
                {item.personName}
              </p>
              <p className="lg:text-lg text-md font-poppins font-semibold tracking-wide">
                {item.role}
              </p>
              <p className="lg:text-base text-md font-poppins font-medium tracking-wide">
                {item.location}
              </p>
            </div>
          </div>
          <div className="lg:w-[55%] w-full h-[auto] lg:h-[600px] flex flex-col self-center justify-center gap-3 rounded-xl">
            {item.story.map((story, idx) => (
              <div key={idx} className="flex flex-col gap-2">
                <h1 className="text-lg font-montserrat font-semibold">
                  {story.heading}
                </h1>
                <p className="text-sm font-montserrat font-normal italic">
                  {story.paragraph}
                </p>
              </div>
            ))}
          </div>
        </div>
      ))}
    </>
  );
}
