"use client";
import SmallBlogCard from "@/components/blog/BlogCard";
import { Blog } from "@/types/blog/blog";
import React, {useState, useEffect} from "react";

const MyBlogs = () => {
  const [blogs, setBlogs] = useState<Blog[]>([]);

  useEffect(() => {
    fetch('https://a2sv-backend.onrender.com/api/blogs') 
      .then(response => response.json())
      .then(data => {
        if (data.length > 13){
          const partial = data.slice(0, 12);
          setBlogs(partial)
        }else{
          setBlogs(data)
        }
      })
      .catch(error => console.error('Error fetching blogs:', error));
  }, []);

  return (
    <div className="mb-32 p-10">
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
