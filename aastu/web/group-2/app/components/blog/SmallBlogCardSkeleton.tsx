import React from 'react';

const SmallBlogCardSkeleton = () => {
  return (
    <div className="transition-all ease-linear m-5 w-80 shadow cursor-pointer hover:shadow dark:hover:shadow-slate-700 rounded-md dark:bg-dark-backgroundLight font-primaryFont animate-pulse">
      <div>
        <div className="bg-gray-300 h-40 w-full rounded-t-md"></div>
      </div>
      <div className="p-4">
        <div className="font-mont font-medium text-base text-gray-700 dark:text-dark-textColor-100">
          <div className="bg-gray-300 h-5 w-2/3"></div>
        </div>
        <div className="flex my-4">
          <div className="bg-gray-300 rounded-full h-6 w-6"></div>
          <div className="font-mont flex ml-2">
            <div className="bg-gray-300 font-extralight h-5 w-16"></div>
            <div className="bg-gray-300 font-semibold h-5 w-24 ml-1"></div>
            <div className="bg-gray-300 h-5 w-12 ml-1"></div>
          </div>
        </div>
        <div className="flex">
          <div className="bg-gray-200 rounded-full m-4 px-6 py-2 font-mont text-xs text-gray-600 dark:bg-dark-background dark:text-dark-textColor-50">
            <div className="bg-gray-300 h-5 w-20"></div>
          </div>
          <div className="bg-gray-200 rounded-full m-4 px-6 py-2 font-mont text-xs text-gray-600 dark:bg-dark-background dark:text-dark-textColor-50">
            <div className="bg-gray-300 h-5 w-20"></div>
          </div>
        </div>
        <div className="text-sm font-mont text-gray-500 dark:text-dark-textColor-50">
          <div className="bg-gray-300 h-20 w-full"></div>
        </div>
        <hr className="my-6 bg-gray-100 border border-gray-200"></hr>
        <div className="flex">
          <div className="bg-gray-300 rounded-full h-6 w-6"></div>
          <div className="text-xs font-mont font-semibold text-gray-600">
            <div className="bg-gray-300 h-5 w-16"></div>
          </div>
          <div className="font-mont text-xs text-indigo-600 ml-32 font-semibold">
            <div className="bg-gray-300 h-5 w-20"></div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SmallBlogCardSkeleton;
