"use client";
import React from "react";
import Image from "next/image";
import useStories from "@/hooks/useStories";

export default function SuccessStoryCard() {
  const { stories, isLoading, error } = useStories();
  console.log(stories);

  return (
    <>
      {stories?.map((item, index) => (
        <div
          className={`px-10 w-full flex gap-14 rounded-xl ${
            index % 2 && "flex-row-reverse"
          }`}
        >
          <div className="relative w-[45%] h-[650px] rounded-xl ">
            <Image
              src="/im.png"
              alt=""
              width={500}
              height={600}
              className="w-full h-full bg-image object-cover rounded-xl"
            />
            <div className="h-44 -translate-y-44 flex flex-col  left text-slate-50  gap-2 px-7 py-5 bg-opacity-50 opacity-100 backdrop-blur-lg rounded-xl">
              <p className="text-3xl font-poppins font-semibold tracking-wide ">
                {item.personName}
              </p>
              <p className="text-2xl font-poppins font-semibold tracking-wide">
                {item.role}
              </p>
              <p className="text-xl font-poppins font-medium tracking-wide">
                {item.location}
              </p>
            </div>
          </div>
          <div className="w-[55%] h-[600px] flex flex-col self-center  justify-center  gap-5 rounded-xl">
            <div className="flex flex-col gap-3">
              <h1 className="text-2xl font-montserrat leading-10 font-semibold">
                {item.story[0].heading}
              </h1>
              <p className="text-sm font-montserrat font-normal italic">
                {item.story[0].paragraph}
              </p>
            </div>
            <div className="flex flex-col gap-3">
              <h1 className="text-2xl font-montserrat leading-10 font-semibold ">
                {item.story[1].heading}
              </h1>
              <p className="text-sm font-montserrat  font-normal italic">
                {item.story[1].paragraph}
              </p>
            </div>
            <div className="flex flex-col gap-3">
              <h1 className="text-2xl font-montserrat leading-10 font-semibold">
                {item.story[2].heading}
              </h1>
              <p className="text-sm font-montserrat font-normal italic">
                {item.story[2].paragraph}
              </p>
            </div>
          </div>
        </div>
      ))}
    </>
  );
}
