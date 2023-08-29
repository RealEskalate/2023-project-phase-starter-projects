import Link from "next/link";
import React from "react";

export default function BlogHeader({
  searchQuery,
  handleSearch,
}: {
  searchQuery: string;
  handleSearch: (e: React.ChangeEvent<HTMLInputElement>) => void;
}) {
  return (
    <div className="flex w-full lg:flex-row justify-between flex-col ">
      <h1 className="text-xl font-montserrat lg:block hidden font-extrabold text-black leading-5 self-center">
        Blogs
      </h1>
      <div className="flex lg:gap-5 gap-5 items-center">
        <div className="max-w-md mx-auto">
          <div className="relative flex items-center w-full py-2 focus-within:shadow-lg bg-white border rounded-xl overflow-hidden">
            <div className="grid place-items-center h-full w-12 text-gray-300">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                className="h-6 w-6"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
                />
              </svg>
            </div>

            <input
              className="peer h-full w-full outline-none text-sm text-gray-700 pr-2"
              type="text"
              id="search"
              placeholder="Search something.."
              value={searchQuery}
              onChange={handleSearch}
            />
          </div>
        </div>
        <Link
          href="/blogs/create"
          className="text-white font-montserrat md:text-base text-base font-semibold bg-blue-800  rounded-full flex items-center px-3 py-1"
        >
          <span className="text-2xl mr-2">+</span>
          New Blog
        </Link>
      </div>
    </div>
  );
}
