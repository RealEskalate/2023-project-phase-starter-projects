"use client";

import Loading from "@/components/Loading";
import BlogItem from "@/components/blogs/BlogItem";
import { useGetBlogsQuery } from "@/store/blog/blogApi";
import { Blog } from "@/types/Blog";
import Link from "next/link";
import React, { useEffect, useState } from "react";

const page = () => {
  const { data: blogs, isLoading, isError, error } = useGetBlogsQuery();
  const [searchQuery, setSearchQuery] = useState<string>("");
  const [filteredBlogs, setFilteredBlogs] = useState<Blog[] | undefined>([]);

  useEffect(() => {
    const newFilteredBlogs: Blog[] | undefined = blogs?.filter((blog) =>
      blog.title.toLowerCase().includes(searchQuery.toLowerCase())
    );
    setFilteredBlogs(newFilteredBlogs);
  }, [searchQuery, blogs]);

  return (
    <div>
      {isLoading && <Loading />}
      {isError && (
        <div className="text-center font-bold text-xl">
          {(error as Error).message}
        </div>
      )}
      {!isLoading && !isError && (
        <div className="py-10 font-montserrat">
          {/* Search section and header */}
          <div className="px-20 flex flex-col md:flex-row space-y-4 md:space-y-0 md:space-x-96">
            <h1 className="font-semibold text-xl">Blogs</h1>
            <div className="flex space-x-6">
              <input
                type="text"
                placeholder="Search..."
                className="px-10 rounded-full py-2 outline outline-1 outline-gray-300 font-montserrat placeholder:text-sm"
                value={searchQuery}
                onChange={(e) => setSearchQuery(e.target.value)}
              />
              <button className="btn-light bg-blue-800 text-white">
                <Link href={"/blog/addBlog"}>+ New Blog</Link>
              </button>
            </div>
          </div>

          {/* Blogs section */}
          <div className="px-56 py-10">
            <div className="w-full">
              {filteredBlogs?.length == 0 && (
                <div className="text-center font-bold text-xl">
                  No Blogs found
                </div>
              )}
              {filteredBlogs?.map((blog: Blog) => (
                <BlogItem
                  key={blog._id}
                  _id={blog._id}
                  image={blog.image}
                  title={blog.title}
                  description={blog.description}
                  author={blog.author}
                  isPending={blog.isPending}
                  tags={blog.tags}
                  likes={blog.likes}
                  relatedBlogs={blog.relatedBlogs}
                  skills={blog.skills}
                  createdAt={blog.createdAt}
                  updatedAt={blog.updatedAt}
                />
              ))}
            </div>
          </div>

          {/* pagination */}
          <div className="w-full flex justify-center space-x-5 mt-4">
            <div className="page bg-blue-800 text-white">1</div>
            <div className="page bg-gray-200">2</div>
            <div className="page bg-gray-200">3</div>
            <div className="page bg-gray-200">4</div>
            <div className="page bg-gray-200">5</div>
          </div>
        </div>
      )}
    </div>
  );
};

export default page;
