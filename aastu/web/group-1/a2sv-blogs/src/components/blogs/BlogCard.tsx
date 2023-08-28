"use client";
import React, { useState } from "react";
import Image from "next/image";
import { useGetBlogsQuery } from "@/lib/redux/features/blog";
import Link from "next/link";

export default function BlogCard() {
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 3;
  const { data, isLoading, error } = useGetBlogsQuery();

  const totalItems = data?.length ?? 0;
  const totalPages = Math.ceil(totalItems / pageSize);

  const startIndex = (currentPage - 1) * pageSize;
  const endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);
  const currentItems = data?.slice(startIndex, endIndex + 1);

  const options = { year: "numeric", month: "short", day: "2-digit" };

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  const renderPageButtons = () => {
    const pageButtons = [];
    let startPage = 1;
    let endPage = totalPages;

    if (totalPages > 5) {
      if (currentPage <= 3) {
        endPage = 5;
      } else if (currentPage >= totalPages - 2) {
        startPage = totalPages - 4;
      } else {
        startPage = currentPage - 2;
        endPage = currentPage + 2;
      }
    }

    for (let page = startPage; page <= endPage; page++) {
      pageButtons.push(
        <button
          key={page}
          className={`px-2.5 rounded-md font-mono ${
            currentPage === page
              ? "text-[#FFF] bg-[#264FAD]"
              : "text-[#212934] bg-[#d9dee0]"
          }`}
          onClick={() => handlePageChange(page)}
        >
          {page}
        </button>
      );
    }

    return pageButtons;
  };
  const LoadingSkeleton = () => {
    return (
      <>
        {Array(3)
          .fill(null)
          .map((i) => (
            <div className="w-full border-t border-[#D7D7D7] py-5">
              <div className="h-[25%] w-full flex items-center gap-3 px-4">
                <div className="w-14 h-14 rounded-full bg-gray-300"></div>
                <div className="flex flex-col gap-0.5 ">
                  <h1 className="font-montserrat font-semibold text-base leading-5 h-4 w-32 flex gap-0 bg-gray-300 rounded-md"></h1>
                  <p className="font-montserrat font-semibold tracking-wide text-xs h-4 w-32  text-[#9c9c9c] bg-gray-300 rounded-md"></p>
                </div>
              </div>
              <div className="h-[60%] flex w-full lg:flex-row flex-col items-center  px-4 lg:gap-14 gap-5 py-5 justify-between">
                <div className="flex flex-col w-full gap-2">
                  <h1 className="font-montserrat h-4 w-full text-xl font-black leading-9 text-black line-clamp-4 bg-gray-300 rounded-md"></h1>
                  <p className="font-montserrat h-36 w-full text-base font-normal leading-7 text-[#737373] line-clamp-4 bg-gray-300 rounded-md"></p>
                </div>
                <div className="lg:w-72 w-full h-48 rounded-xl bg-gray-300"></div>
              </div>
              <div className="flex items-center bg-white">
                {/* Placeholder for the tags */}
                <ul className="h-[15%] flex items-center gap-10 px-3 justify-start">
                  <li className="px-5 py-1.5 font-montserrat font-semibold text-sm text-[#8E8E8E] bg-[#ededf0] rounded-full flex bg-gray-300"></li>
                </ul>
              </div>
            </div>
          ))}
      </>
    );
  };
  return (
    <>
      {isLoading ? (
        <LoadingSkeleton />
      ) : (
        currentItems?.map((item) => (
          <Link className="w-full" href={`/blogs/${item._id}`}>
            <div className="w-full border-t border-[#D7D7D7] py-5">
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
                          strokeWidth="1.2"
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
              <div className="h-[60%] flex  lg:flex-row flex-col items-center  px-4 lg:gap-14 gap-5 py-5 justify-between">
                <div className="flex flex-col h-full gap-5 px-2">
                  <h1 className="font-montserrat text-xl font-black  text-black line-clamp-4">
                    {item.title}
                  </h1>
                  <p className="font-montserrat text-base font-normal leading-7 text-[#737373] line-clamp-4">
                    <div
                      dangerouslySetInnerHTML={{ __html: item.description }}
                    />
                  </p>
                </div>
                <Image
                  src={item.image}
                  alt=""
                  width={300}
                  height={200}
                  className="lg:w-72 w-full h-48 rounded-xl object-cover"
                />
              </div>
              <div className="flex items-center bg-white flex-wrap lg:gap-1 gap-3">
                {item?.tags?.map(
                  (tag, index) =>
                    tag && (
                      <ul
                        className="h-[15%] flex items-center gap-10 px-3 justify-start"
                        key={index}
                      >
                        <li className="px-5 py-1.5 font-montserrat font-semibold lg:text-sm text-xs text-[#8E8E8E] bg-[#ededf0] rounded-full flex">
                          {tag}
                        </li>
                      </ul>
                    )
                )}
              </div>
            </div>
          </Link>
        ))
      )}

      <div className="flex justify-center mb-10">
        <div className="flex gap-5">{renderPageButtons()}</div>
      </div>
    </>
  );
}
