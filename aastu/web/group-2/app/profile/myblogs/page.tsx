'use client';
import { Blog, User } from '@/lib/types';

import MyBlogCard from '@/app/components/profile/MyblogCard';
import { useGetBlogsQuery, useMyBlogsQuery } from '@/lib/redux/slices/blogsApi';
import Link from 'next/link';
import Loading from '@/app/components/loading';
import { Pagination } from '@/app/components/Pagination';
import { useState } from 'react';
import { useAppSelector } from '@/lib/redux/hooks';
import MyBlogCardSkeleton from '@/app/components/profile/MyBlogCardSkeleton';

export default function Section() {
  const { data: blogs, error, isSuccess, isLoading } = useMyBlogsQuery();
  const [blogsPerPage, setBlogsPerPage] = useState(6); // Dynamic number of blogs per page
  const [paginationCount, setPaginationCount] = useState(5);
  const [page, setPage] = useState(1);
  const [search, setSearch] = useState('');

  if (isLoading) {
    return <MyBlogCardSkeleton />;
  }

  const blogsToShow = blogs
    ?.filter((blog: Blog) => {
      return (
        blog.title.toLowerCase().includes(search.toLowerCase()) ||
        blog.author?.name.toLowerCase().includes(search.toLowerCase())
      );
    })
    .sort((a: Blog, b: Blog) => b?.createdAt?.localeCompare(a?.createdAt));

  //let bls = blogsToShow.map((blog) => blog.title);

  const totalBlogs = blogsToShow.length; // Calculate total number of blogs

  const startIndex = (page - 1) * blogsPerPage;
  const endIndex = startIndex + blogsPerPage;
  const paginatedBlogs = blogsToShow.slice(startIndex, endIndex);

  return (
    <div>
      <div className="flex flex-col items-center gap-4 md:flex-row md:justify-between py-2 border-b-2 border-[#EFEFEF] mb-7 px-4 dark:border-dark-backgroundLight  dark:bg-dark-background">
        <div className=" font-secondaryFont">
          <h3 className="font-semibold text-textColor-200 text-lg text-center md:text-left md:text-lg dark:text-dark-white">
            Manage Blogs
          </h3>
          <p className="font-medium text-textColor-50 text-base text-center md:text-left dark:text-dark-textColor-50">
            Edit, Delete and View the Status of your blogs
          </p>
          <div className="flex gap-2 w-full justify-center items-center my-5">
            <input
              type="text"
              name="search"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
              placeholder="Search..."
              className="border px-4 lg:px-10 py-2 rounded-3xl text-sm dark:outline-primaryColor dark:bg-dark-textColor-100"
            />
          </div>
        </div>
        <div className=" flex items-center">
          <Link
            href="/blog/add-blog"
            className="bg-primaryColor text-white font-secondaryFont font-semibold rounded-lg px-4 py-1 md:px-8 md:py-2"
          >
            Add Blog
          </Link>
        </div>
      </div>
      <div className="grid font-secondaryFont mb-12 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
        {paginatedBlogs?.map((blog, i) => {
          return <MyBlogCard key={i} {...blog} />;
        })}
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
}
