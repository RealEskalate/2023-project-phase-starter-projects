'use client';
import { Blog, User } from '@/lib/types';

import MyBlogCard from '@/app/components/profile/MyblogCard';
import { useGetBlogsQuery, useMyBlogsQuery } from '@/lib/redux/slices/blogsApi';
import Link from 'next/link';

export default function Section() {
  const { data: blogs, error, isSuccess, isLoading } = useMyBlogsQuery();

  return (
    <div>
      <div className="flex flex-col items-center gap-4 md:flex-row md:justify-between py-2 border-b-2 border-[#EFEFEF] mb-7 px-4">
        <div className=" font-secondaryFont">
          <h3 className="font-semibold text-textColor-200 text-lg text-center md:text-left md:text-lg">
            Manage Blogs
          </h3>
          <p className="font-medium text-textColor-50 text-base text-center md:text-left">
            Edit, Delete and View the Status of your blogs
          </p>
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
        {blogs?.map((blog, i) => {
          return <MyBlogCard key={i} {...blog} />;
        })}
      </div>
    </div>
  );
}
