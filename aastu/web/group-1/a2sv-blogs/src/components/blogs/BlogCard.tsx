"use client";
import React, { useState, useEffect } from "react";
import Image from "next/image";
import { useGetBlogsQuery } from "@/lib/redux/features/blog";
import Link from "next/link";
import { Blog } from "@/types";

export default function BlogCard({ searchQuery }: { searchQuery: string }) {
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 3;
  const [filteredData, setFilteredData] = useState<Blog[]>([]); // filtered data state
  const { data, isLoading, error } = useGetBlogsQuery();
  useEffect(() => {
    if (data) {
      setFilteredData(data);
    }
  }, [data]);
  const totalItems = data?.length ?? 0;
  const totalPages = Math.ceil(totalItems / pageSize);

  const startIndex = (currentPage - 1) * pageSize;
  const endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);
  const currentItems = filteredData?.slice(startIndex, endIndex + 1);

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

  useEffect(() => {
    if (searchQuery !== "") {
      const filteredData = data?.filter((item) =>
        item.title.toLowerCase().includes(searchQuery.toLowerCase())
      );
      setFilteredData(filteredData!);
    } else {
      setFilteredData(data!);
    }
    console.log(searchQuery);
  }, [searchQuery]);

  const LoadingSkeleton = () => {
    return (
      <>
        {Array(3)
          .fill(null)
          .map((i) => (
            <div className="xl:w-[1200px] md:w-[900px] sm:w-[600px] w-[300px] ">
              <div className="w-full border-t border-[#D7D7D7] py-5 flex flex-col gap-1 animate-pulse">
                <div className="h-[25%] flex items-center gap-3 px-10">
                  <div className="w-14 h-14 rounded-full bg-gray-300"></div>
                  <div className="flex flex-col gap-0.5">
                    <div className="md:w-96 w-52 h-4 bg-gray-300"></div>
                    <div className="md:w-80 w-40 h-3 bg-gray-300"></div>
                  </div>
                </div>
                <div className="h-[60%] flex lg:flex-row flex-col items-center px-4 lg:gap-14 gap-5 justify-between">
                  <div className="hidden lg:flex flex-col h-full gap-5 px-2">
                    <div className="w-44 h-6 bg-gray-300"></div>
                    <div className="w-full h-24 bg-gray-300"></div>
                  </div>
                  <div className="w-72 h-48 rounded-xl bg-gray-300"></div>
                </div>
                <div className="flex items-center bg-white flex-wrap lg:gap-1 gap-3 px-2">
                  <div className="h-[15%] flex items-center gap-10 px-3 justify-start">
                    <div className="px-5 py-1.5 font-montserrat font-semibold lg:text-sm text-xs text-[#8E8E8E] bg-[#ededf0] rounded-full flex w-20 h-6"></div>
                  </div>
                </div>
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
            <div className="w-full border-t border-[#D7D7D7] py-5 flex flex-col gap-1 space-y-5">
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
              <div className="h-[60%] flex  lg:flex-row flex-col items-center px-4 lg:gap-14 gap-5 justify-between">
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
              <div className="flex items-center bg-white flex-wrap lg:gap-1 gap-3 px-2">
                <ul className="h-[15%] flex flex-wrap items-center sm:gap-6 gap-3 px-3 justify-start">
                  {item?.tags?.map(
                    (tag, index) =>
                      tag && (
                        <li
                          key={index}
                          className="px-5 py-2 font-montserrat font-semibold lg:text-sm text-xs text-[#8E8E8E] bg-[#ededf0] rounded-full flex"
                        >
                          {tag}
                        </li>
                      )
                  )}
                </ul>
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
