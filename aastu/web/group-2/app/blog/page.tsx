'use client';
import React, { useState } from 'react';
import { useAppSelector } from '@/lib/redux/hooks';
import { useGetBlogsQuery } from '@/lib/redux/slices/blogsApi';
import SingleBlogCard from '../components/blog/SingleBlogCard';
import { Pagination } from '../components/Pagination';
import Link from '@/node_modules/next/link';
import { Blog } from '@/lib/types';
import BlogCardSkeleton from '../components/blog/BlogCardSkeleton';

const Page: React.FC = () => {
  const [page, setPage] = useState(1);
  const [search, setSearch] = useState('');
  const [blogsPerPage, setBlogsPerPage] = useState(3); // Dynamic number of blogs per page
  const [paginationCount, setPaginationCount] = useState(5); // Dynamic number of pagination numbers
  const loginState = useAppSelector((state: any) => state.login);
  const { data: blogs, error, isLoading, isSuccess } = useGetBlogsQuery();

  if (error) {
    throw Error('Network');
  }

  if (isLoading) {
    return (
      <div>
        <div className=" flex flex-col w-full gap-4 lg:px-52 md:px-40 px-8 mt-5 items-center justify-center ">
          {[1, 2, 3].map((d) => {
            return <BlogCardSkeleton key={d} />;
          })}
        </div>
      </div>
    );
  }

  const blogsToShow = blogs
    ?.filter((blog: Blog) => {
      return (
        blog.title.toLowerCase().includes(search.toLowerCase()) ||
        blog.author?.name.toLowerCase().includes(search.toLowerCase())
      );
    })
    .sort((a: Blog, b: Blog) => b?.createdAt?.localeCompare(a?.createdAt || ''));

  //let bls = blogsToShow.map((blog) => blog.title);

  const totalBlogs = blogsToShow?.length; // Calculate total number of blogs

  const startIndex = (page - 1) * blogsPerPage;
  const endIndex = startIndex + blogsPerPage;
  const paginatedBlogs = blogsToShow?.slice(startIndex, endIndex);

  return (
    <div className="w-full font-secondaryFont mt-20 flex flex-col justify-center items-center">
      {/* search section */}
      <div className="w-full flex flex-col lg:flex-row items-center justify-between lg:px-24 px-8 gap-10 lg:gap-0 mb-10">
        <h2 className="text-2xl  font-semibold dark:text-dark-textColor-100">Blogs</h2>
        <div className="flex gap-2">
          <input
            type="text"
            name="search"
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            placeholder="Search..."
            className="border px-4 lg:px-10 py-2 rounded-3xl text-sm dark:outline-primaryColor dark:bg-dark-textColor-100"
          />
          {loginState && (
            <Link
              href="/blog/add-blog"
              className="bg-primaryColor text-white px-3 sm:px-6 py-2 sm:py-4 rounded-3xl text-xs lg:text-sm font-semibold hover:scale-95 transition-all ease-linear hover:bg-blue-900 disabled:bg-neutral-300 disabled:text-neutral-500 text-center flex items-center"
            >
              + New Blog
            </Link>
          )}
        </div>
        <div className=""></div>
      </div>

      {/* blog list */}
      <div className="flex flex-col w-full gap-4 lg:px-52 md:px-40 px-8 mt-5 items-center justify-center">
        {paginatedBlogs?.map((blog: Blog, index: number) => (
          <React.Fragment key={index}>
            {index > 0 && <hr className="mt-4 mb-6 bg-textColor-100  dark:invisible w-3/4" />}
            <SingleBlogCard {...blog} />
          </React.Fragment>
        ))}
      </div>
      <div className="mt-10">
        <Pagination
          setPage={setPage}
          page={page}
          paginationCount={paginationCount}
          totalBlogs={totalBlogs}
          blogsPerPage={blogsPerPage}
        />
      </div>
    </div>
  );
};

export default Page;
