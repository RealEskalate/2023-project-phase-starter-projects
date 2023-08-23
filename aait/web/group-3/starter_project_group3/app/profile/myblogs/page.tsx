"use client";
import React from "react";
import { blogsList } from "@/data/myBlogs";
import BlogCard from "@/components/Blog/blogCard";

const MyBlogs = () => {
  return (
    <div className="mb-32">
      <div className=" py-10 text-blog_list_sub_text_color  ">
        <p className="text-xl  font-bold">Manage Blogs</p>
        <p className="text-sm font-medium">
          Edit, Delete and View the Status of your blogs
        </p>
      </div>
      <hr className="py-1" />
      <div className="  py-4 flex justify-between items-center flex-wrap gap-y-8">
        {blogsList.map((blog) => (
          <BlogCard key={blog.image} blog={blog} />
        ))}
      </div>
    </div>
  );
};

export default MyBlogs;
