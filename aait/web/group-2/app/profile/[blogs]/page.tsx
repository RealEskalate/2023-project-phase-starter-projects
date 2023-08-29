"use client";
import SmallBlogCard from "@/../../components/blog/BlogCard";
import { Blog } from "@/../../types/blog/blog";
import React, {useState, useEffect} from "react";

const MyBlogs = () => {
  const [blogs, setBlogs] = useState<Blog[]>([]);

  useEffect(() => {
    fetch('https://a2sv-backend.onrender.com/api/blogs') 
      .then(response => response.json())
      .then(data => setBlogs(data))
      .catch(error => console.error('Error fetching blogs:', error));
  }, []);

  return (
    <div className="mb-32 mt-20 p-10">
    <div className=" py-10 text-blog_list_sub_text_color  ">
      <p className="text-xl  font-bold">Manage Blogs</p>
      <p className="text-sm">
        Edit, Delete and View the Status of your blogs
      </p>
    </div>
    <hr className="py-1" />
    <SmallBlogCard blogs={blogs} />
  </div>
  );
};

export default MyBlogs;
