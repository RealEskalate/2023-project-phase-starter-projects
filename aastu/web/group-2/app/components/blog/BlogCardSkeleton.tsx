import React from 'react';
import Chip from './Chip'; // Assuming you have a Chip component

const BlogCardSkeleton = () => {
  return (
    <div className="dark:bg-dark-backgroundLight/[0.6] dark:hover:bg-dark-backgroundLight hover:bg-neutral-200 lg:hover:bg-white px-4 py-4 rounded-lg cursor:pointer transition-all ease-in-out w-full animate-pulse">
      {/* author profile skeleton */}
      <div className="flex items-start gap-5 mb-7">
        <div className="w-14 h-14 rounded-full bg-gray-300"></div>
        <div className="flex flex-col dark:text-dark-textColor-100">
          <span className="text-lg font-medium flex bg-gray-300 w-28">&nbsp;</span>
          <span className="text-xs text-textColor-50 uppercase bg-gray-200 w-20">&nbsp;</span>
        </div>
      </div>
      {/* blog title , excerpt and image skeleton */}
      <div className="lg:flex lg:flex-row lg:gap-10 flex flex-col-reverse justify-between gap-5">
        <div className="w-full">
          <h2 className="text-lg font-bold mb-4 cursor-pointer md:text-2xl dark:text-dark-textColor-100 bg-gray-300 w-2/3">
            &nbsp;
          </h2>
          <div className="text-base text-textColor-100 dark:text-dark-textColor-50 bg-gray-200 w-full h-7"></div>
        </div>
        <div className="relative w-full sm:w-[400px] h-[200px] bg-gray-300"></div>
      </div>
      {/* tags skeleton */}
      <div className="flex flex-wrap md:gap-4 gap-2 mt-4">
        <div className="bg-gray-200 w-16 h-6 rounded"></div>
        <div className="bg-gray-200 w-16 h-6 rounded"></div>
        <div className="bg-gray-200 w-16 h-6 rounded"></div>
      </div>
    </div>
  );
};

export default BlogCardSkeleton;
