"use client";

import Image from "next/image";
import { useParams } from "next/navigation";
import React from "react";
import parse from "html-react-parser";
import { useGetSingleBlogQuery } from "@/store/blog/blogApi";
import Loading from "@/components/Loading";

const page = () => {
  const { blogId } = useParams();
  const {
    data: blog,
    isLoading,
    isError,
    error,
  } = useGetSingleBlogQuery(blogId);
  
  return isLoading ? (
    <Loading />
  ) : isError ? (
    <div className="text-center font-bold font-montserrat text-xl">
      {(error as any).data
        ? (error as any).data?.error
        : "An Error Occurred while loading the data"}
    </div>
  ) : (
    <div className="py-20 font-montserrat">
      <div className="text-center text-4xl font-canon">{blog?.title}</div>
      <div className="flex justify-center mt-4 space-x-4 text-gray-500 uppercase text-xs">
        <div>{blog?.tags.join(", ")}</div>
        <div className="w-0.5 my-0.5 bg-gray-400"></div>
        <p>6 min Read</p>
      </div>
      <Image
        src={blog ? blog.image : "./images/blogs/coder.svg"}
        alt={"Blog's Main image"}
        width={300}
        height={100}
        className="w-3/4 mt-16 mb-12 mx-auto h-96 object-cover"
      />
      <div className="flex flex-col items-center space-y-2">
        <Image
          src={
            blog?.author?.image || '../images/blogs/Default_pfp.svg'
          }
          alt={"Author's profile picture"}
          width={100}
          height={100}
          className="w-12 h-12 object-cover rounded-full"
        />
        <div className="flex justify-center mt-4 space-x-4 text-gray-500 uppercase text-xs font-medium">
          <p>{blog?.author?.name || 'anonymus'}</p>
          <div className="w-0.5 my-0.5 bg-gray-400"></div>
          <p>{blog?.author?.role || 'anonymus'}</p>
        </div>
        <p className="-mt-2 text-xs text-blue-700 uppercase font-medium">
          @{blog?.author?.name || 'anonymus'}
        </p>
      </div>

      <div className="mt-10 w-7/12 mx-auto font-light">
        {parse(blog?.description as string)}
      </div>

      <div
        className={`${
          blog?.relatedBlogs.length === 0 ? "hidden" : "block"
        } w-3/4 mx-auto`}
      >
        <h1 className="text-xl font-bold">Related Blogs</h1>
        <div className="mt-6 grid grid-cols-3 gap-x-8 gap-y-4">
          {/* @TODO: unccomment the code after the component has been merged */}
          {/* {blog?.relatedBlogs?.map((relatedBlog: Blog) => <RelatedBlog /> )} */}
        </div>
      </div>
    </div>
  );
};

export default page;
