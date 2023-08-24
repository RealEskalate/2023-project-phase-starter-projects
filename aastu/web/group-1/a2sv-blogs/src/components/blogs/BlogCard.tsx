import React from "react";
import Image from "next/image";

export default function BlogCard() {
  return (
    <div className="w-full h-80  border-t border-[#D7D7D7]">
      <div className="h-[25%]   flex items-center gap-3 px-4">
        <Image
          className="w-14 h-14 rounded-full object-cover"
          src="/images/team.jpg"
          alt=""
          width={100}
          height={100}
        />
        <div className="flex flex-col gap-0.5">
          <h1 className="font-montserrat font-semibold text-base leading-5 flex gap-0">
            Yishake Bogale{" "}
            <span className="flex items-center">
              <svg
                className="w-5 h-5 shrink-0"
                viewBox="0 0 25 25"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <circle
                  cx="12.5"
                  cy="12.5"
                  r="1.5"
                  fill="#121923"
                  stroke="#121923"
                  stroke-width="1.2"
                />
              </svg>
            </span>
            <span className="text-xs flex items-center text-[#868686]">
              Apr 16, 2022
            </span>
          </h1>
          <p className="font-montserrat font-semibold tracking-wide text-xs text-[#9c9c9c]">
            SOFTWARE ENGINEER
          </p>
        </div>
      </div>
      <div className="h-[60%] flex items-center mx-auto px-4 gap-14">
        <div className="flex flex-col gap-4">
          <h1 className="font-montserrat text-xl font-black leading-5 text-black">
            The essential guide to Competitive Programming
          </h1>
          <h1 className="font-montserrat text-xl font-black leading-5 text-black">
            Tab System On React : 3 ways to do it.
          </h1>
          <p className="font-montserrat text-base font-normal leading-7">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
            eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim
            ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut
            aliquip ex ea{" "}
          </p>
        </div>
        <Image
          src="/images/blogs.png"
          alt=""
          width={500}
          height={200}
          className="w-[500px] h-48 rounded-xl object-scale-down"
        />
      </div>
      <ul className="h-[15%] flex items-center gap-10 p-5">
        <li className=" px-8 py-2 font-montserrat font-semibold text-sm text-[#8E8E8E] bg-[#ededf0] rounded-full">
          UI/UX
        </li>
        <li className="px-8 py-2 font-montserrat font-semibold text-sm text-[#8E8E8E] bg-[#ededf0] rounded-full">
          Development
        </li>
      </ul>
    </div>
  );
}
