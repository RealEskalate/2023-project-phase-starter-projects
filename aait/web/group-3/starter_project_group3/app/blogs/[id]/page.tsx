'use client'

import { useParams } from "next/navigation";
import React from "react";
import parse from 'html-react-parser';
import BlogCard from "@/components/blog/BlogCard";
import { useGetSingleBlogQuery } from "@/store/features/blog-detail/blog-detail";
import Loading from "@/components/commons/Loading";
import Error from "@/components/commons/Error";
import SmallBlogCard from "@/components/blog/SmallBlogCard";


const BlogDetailPage :React.FC = () => {
  const params = useParams()
  const blogId = params.id;
  const {data:blog, error, isLoading} = useGetSingleBlogQuery(blogId as string)
  
  if (isLoading){
      return <Loading />
  }

  if (error){
      return <Error />    
  }

  if (blog) {
    return (
      <div className="flex flex-col items-center mt-16 md:p-0">
        <div className="bg-white rounded-lg shadow-md max-w-screen-lg w-full">
          <h1 className="text-2xl text-center font-bold mb-2">{blog.title}</h1>
  
          <div className="flex items-center justify-center text-gray-600 text-sm mb-8">
            <p className="mr-2">{blog.tags.join(", ")}</p>
            <p>|</p>
            <p className="mx-2">5 min read</p>
          </div>
  
          <div className="flex justify-center items-center mb-8">
            <div className="w-full md:w-5/6">
              <img
                src={blog?.image}
                alt="Picture of the author"
                className="w-full h-auto object-cover"
              />
            </div>
          </div>
  
          <div className="flex flex-col gap-2 justify-center items-center my-8">
            <img
              src={blog.author?.image || '../assets/profile.svg'}
              alt={`${blog.author?.name}'s Avatar` }
              className="w-16 h-16 rounded-full mr-3"
            />
            <div className="flex flex-col gap-2">
              <div className="flex gap-4">
                <p className="tracking-widest">{blog.author?.name || 'Unknown'}</p>
                <p>|</p>
                <p className="tracking-widest">Software Engineer</p>
              </div>
              <p className="text-center text-blue-700">{blog.author?.email}</p>
            </div>
          </div>
  
          <div className="text-center px-4 md:px-32 overflow-hidden">
            {parse(blog.description)}
          </div>
          <div className=" px-4 mt-8">
              <h1 className="text-2xl pl-8 font-semibold">Related Blogs</h1>
              <div className="flex gap-4 px-5 my-4">
                 <SmallBlogCard blogs={blog.relatedBlogs} />
              </div>
          </div>
        </div>
  
      </div>
    );
  }else{
    return null
  }
};

export default BlogDetailPage;
