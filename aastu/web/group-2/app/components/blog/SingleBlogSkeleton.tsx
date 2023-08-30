import React from 'react';
import SmallBlogCardSkeleton from './SmallBlogCardSkeleton';

const SingleBlogSkeleton = () => {
  const blogs = new Array(3).fill(0);

  return (
    <div className="grid grid-rows gap-0 animate-pulse">
      <div className="text-3xl font-primaryFont text-center mt-20 mx-auto dark:text-dark-textColor-100">
        <div className="bg-gray-300 h-10 w-60"></div>
      </div>
      <div className="text-xs font-secondaryFont flex items-center justify-center font-light uppercase text-gray-500 h-5 m-3">
        <div className="bg-gray-300 h-3 w-40"></div> &nbsp;&nbsp;|&nbsp;&nbsp;{' '}
        <div className="bg-gray-300 h-3 w-10"></div>
      </div>
      <div className="flex items-center justify-center m-9">
        <div className="w-full max-w-screen-xl mx-auto max-h-[65vh] object-cover object-center bg-gray-300"></div>
      </div>
      <div>
        <div className="flex items-center justify-center">
          <div className="rounded-full bg-gray-300 w-16 h-16"></div>
        </div>
        <div className="text-xs font-secondaryFont flex items-center justify-center font-normal uppercase h-5 mt-3">
          <div className="bg-gray-300 h-3 w-40"></div> &nbsp;&nbsp;|&nbsp;&nbsp;{' '}
          <div className="bg-gray-300 h-3 w-20"></div>
        </div>
        <div className="text-xs font-secondaryFont flex items-center justify-center font-semibold text-blue-600 uppercase h-5">
          <div className="bg-gray-300 h-3 w-20"></div>
        </div>
      </div>
      <div
        dangerouslySetInnerHTML={{ __html: '<div class="bg-gray-300 h-20"></div>' }}
        className="text-base font-primaryFont flex items-center justify-center mx-4 lg:mx-64 mb-4 lg:mb-8 mt-8 pl-2"
      ></div>
      <div className="text-base lg:text-lg font-primaryFont flex flex-col items-center text-gray-600 justify-center mx-4 lg:mx-64 pl-2 dark:text-dark-textColor-50">
        <div className="bg-gray-300 h-8 w-2/3 mb-4"></div>
        <div className="bg-gray-300 h-8 w-3/4 mb-4"></div>
        <div className="bg-gray-300 h-8 w-1/2 mb-4"></div>
        <div className="bg-gray-300 h-8 w-3/5"></div>
      </div>
      <div className="text-xl font-secondaryFont font-semibold mt-20 mb-4 text-center lg:text-left lg:mx-48 dark:text-dark-textColor-100">
        Related Blogs
      </div>
      <div className="flex flex-col lg:flex-row mx-auto lg:pl-40 mb-32">
        {blogs.map((_, index) => {
          return <SmallBlogCardSkeleton key={index} />;
        })}
      </div>
    </div>
  );
};

export default SingleBlogSkeleton;
