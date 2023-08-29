"use client";
import SmallBlogCard from "@/components/blog/SmallBlogCard";
import React from "react";
import { blog } from "@/data/blog/blog";

const MyBlogs = () => {
  return (
    <div className="mb-32">
      <div className=" py-10 text-blog_list_sub_text_color  ">
        <p className="text-xl  font-bold">Manage Blogs</p>
        <p className="text-sm">
          Edit, Delete and View the Status of your blogs
        </p>
      </div>
      <hr className="py-1" />
      <SmallBlogCard blogs={blog} />
    </div>
  );
};

export default MyBlogs;
