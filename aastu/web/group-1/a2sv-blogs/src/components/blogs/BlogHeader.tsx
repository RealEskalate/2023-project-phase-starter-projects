import Link from "next/link";
import React from "react";

export default function BlogHeader() {
  return (
    <div className="w-[60%] mx-28 flex lg:flex-row flex-col justify-between">
      <h1 className="text-xl font-montserrat lg:visible invisible font-extrabold text-black leading-5">
        Blogs
      </h1>
      <div className="flex lg:gap-5 justify-between">
        <input
          className="h-10 border border-black px-5 md:w-60 sm:w-48 w-36 rounded-3xl placeholder:text-sm placeholder:font-montserrat placeholder:font-medium placeholder:pl-4"
          placeholder="Search . . ."
          type="text"
          name=""
          id=""
        />
        <Link
          href="/blogs/create"
          className="h-10 text-white font-montserrat md:text-sm text-xs font-semibold md:w-32 w-32 bg-blue-800 px-5 rounded-full  flex items-center"
        >
          + New Blog
        </Link>
      </div>
    </div>
  );
}
