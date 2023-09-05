"use client";
import Link from "next/link";
import BlogCard from "./BlogCard";
import data from "@/data/manage-section-data.json";
import { useGetMyBlogsQuery } from "@/store/features/blog/blog-api";
import Loading from "../common/Loading";

const Blogs = () => {

  const {data:myBlogs, isLoading, isError} = useGetMyBlogsQuery();
  

  return (
    <>
      {/* manage section */}
      {isLoading && <Loading/>}
      <div className="flex flex-col items-center md:items-stretch space-y-4 py-8 border-b md:py-12 md:space-y-2">
        <div className="flex justify-between">
          <h2 className=" text-slate-gray text-lg font-semibold md:text-2xl">
            Manage {data.data[1].manageText}
          </h2>
          <Link className=" hidden px-10 py-2 text-white mb-1 rounded-lg bg-primary-color md:block" href="/add-blog">
              New blog
            </Link>
        </div>
        <p className="text-medium-gray text-sm md:text-xl">
          {data.data[1].manageDetail}
        </p>
          <Link href="/add-blog" className="px-10 py-2 text-white mb-1 w-fit rounded-lg bg-primary-color md:hidden">
              New blog
            </Link>
      </div>
      <div className="py-8 gap-12 flex flex-col items-center md:grid md:grid-cols-2 xl:grid-cols-4">
        {myBlogs?.map((myBlog, i) => (
          <BlogCard key={i} myBlog={myBlog}/>
        ))}
      </div>
    </>
  );
};

export default Blogs;
