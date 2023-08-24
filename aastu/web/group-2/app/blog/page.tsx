'use client';
import { Blog, User } from '@/lib/types';
import React, { useEffect, useState } from 'react';
import SingleBlogCard from '../components/blog/SingleBlogCard';
import { useGetBlogsQuery } from '@/lib/redux/slices/blogsApi';
import Loading from '../components/loading';

const Page: React.FC = () => {
  const [search, setSearch] = useState('');
  const { data: blogs, error, isLoading, isSuccess } = useGetBlogsQuery();

  if (isLoading) {
    return <Loading />;
  }

  return (
    <div className="w-full font-secondaryFont mt-20 flex flex-col justify-center items-center">
      {/* search section */}
      <div className="w-full flex flex-col lg:flex-row items-center justify-between lg:px-24 px-10 gap-10 lg:gap-0">
        <h2 className="text-2xl  font-semibold">Blogs</h2>
        <div className="flex gap-5">
          <input
            type="text"
            name="search"
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            placeholder="Search..."
            className="border px-4 lg:px-10 py-2 rounded-3xl text-sm"
          />
          <button className="bg-primaryColor text-white px-6 py-4 rounded-3xl text-xs lg:text-sm font-semibold">
            + New Blog
          </button>
        </div>
        <div className=""></div>
      </div>

      {/* blog list */}
      <div className="flex flex-col gap-4 lg:px-52 md:px-40 px-8 mt-5">
        {blogs
          ?.filter((blog: Blog) => {
            return (
              blog.title.toLowerCase().includes(search.toLowerCase()) ||
              blog.author?.name.toLowerCase().includes(search.toLowerCase())
            );
          })
          .map((blog: Blog, index: number) => (
            <>
              <hr className="mt-4 mb-6 bg-textColor-100 w-3/4" />
              <SingleBlogCard key={index} {...blog} />
            </>
          ))}
      </div>
    </div>
  );
};

export default Page;
