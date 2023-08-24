import React from "react";

export default function BlogHeader() {
  return (
    <div className="w-[60%] mx-28 flex justify-between">
      <h1 className="text-xl font-montserrat font-extrabold text-black leading-5">
        Blogs
      </h1>
      <div className="flex gap-5">
        <input
          className="h-10 border border-black px-5 w-60 rounded-3xl placeholder:text-sm placeholder:font-montserrat placeholder:font-medium placeholder:pl-4"
          placeholder="Search . . ."
          type="text"
          name=""
          id=""
        />
        <button className="h-10 text-white font-montserrat text-sm font-semibold w-32 bg-blue-800 px-5 rounded-full">
          + New Blog
        </button>
      </div>
    </div>
  );
}
