"use client";
import SmallBlogCard from "@/components/blog/SmallBlogCard";
import React from "react";
import { useGetMyBlogsQuery } from "@/store/features/my-blogs";
import Loading from "@/components/commons/Loading";

const MyBlogs = () => {
  const { data: blogs, error, isLoading } = useGetMyBlogsQuery();

  if (isLoading) {
    return <Loading />;
  }
  return (
    <div className="mb-32">
      <div className=" py-10 text-blog_list_sub_text_color  ">
        <p className="text-xl  font-bold">Manage Blogs</p>
        <p className="text-sm">
          Edit, Delete and View the Status of your blogs
        </p>
      </div>
      <hr className="py-1" />
      {blogs && blogs.length === 0 && (
        <p className="capitalize font-Montserrat text-6xl my-20  font-bold w-9/12 mx-auto text-gray-400">
          No blogs added yet.
        </p>
      )}
      {blogs && blogs.length > 0 && <SmallBlogCard blogs={blogs} />}
    </div>
  );
};

export default MyBlogs;
