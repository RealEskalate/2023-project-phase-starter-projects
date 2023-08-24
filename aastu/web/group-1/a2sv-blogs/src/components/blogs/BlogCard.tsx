"use client";
import React from "react";
import Image from "next/image";
import { useGetBlogsQuery } from "@/lib/redux/features/blog";

export default function BlogCard() {
  const { data, isLoading, error } = useGetBlogsQuery();
  const options = { year: "numeric", month: "short", day: "2-digit" };

  return (
    <>
      {data?.map((item) => (
        <div className="w-full h-80  border-t border-[#D7D7D7]">
          <div className="h-[25%] flex items-center gap-3 px-4">
            <Image
              className="w-14 h-14 rounded-full object-cover"
              src={item.image}
              alt=""
              width={100}
              height={100}
            />
            <div className="flex flex-col gap-0.5">
              <h1 className="font-montserrat font-semibold text-base leading-5 flex gap-0">
                {item.author?.name}
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
                  {new Date(item.updatedAt).toLocaleDateString(
                    "en-US",
                    options
                  )}
                </span>
              </h1>
              <p className="font-montserrat font-semibold tracking-wide text-xs text-[#9c9c9c]">
                {item.author?.role.toUpperCase()}
              </p>
            </div>
          </div>
          <div className="h-[60%] flex items-center mx-auto px-4 gap-14 py-5">
            <div className="flex flex-col">
              <h1 className="font-montserrat text-xl font-black leading-9 text-black">
                {item.title}
              </h1>
              <p className="font-montserrat text-base font-normal leading-7 text-[#737373]">
                {item.description}
              </p>
            </div>
            <Image
              src={item.image}
              alt=""
              width={300}
              height={200}
              className="w-72 h-48 rounded-xl object-cover"
            />
          </div>
          <div className="flex items-center">
            {item?.tags?.map((tag) => (
              <ul className="h-[15%] flex items-center gap-10 px-3 justify-start">
                <li className=" px-5 py-1.5 font-montserrat font-semibold text-sm text-[#8E8E8E] bg-[#ededf0] rounded-full flex">
                  {tag}
                </li>
              </ul>
            ))}
          </div>
        </div>
      ))}
    </>
  );
}
