import Image from "next/image";
import React, { useEffect } from "react";
import { Blog } from "@/types/blog/blog";
import Link from "next/link";
import parse from "html-react-parser";

interface BlogCardProps {
  blogs: Blog[];
}

const SmallBlogCard = ({ blogs }: BlogCardProps) => {
  return (
    <div className="py-4 flex justify-between items-center flex-wrap gap-y-8">
      {blogs.map((blog) => (
        <div key={blog.title} className=" w-[23%] rounded-md ">
          <div className=" shadow-lg flex justify-center items-center">
            <Image
              className="rounded-md"
              src={blog.image}
              alt="blog image"
              width={350}
              height={350}
            />
          </div>
          <p className="font-bold text-nav_text_color text-sm py-3">
            {blog.title}
          </p>
          <p className="flex mx-5  pb-3 justify-start gap-x-2 items-center">
            <Image
              src={blog.author?.image || ""}
              alt="blog image"
              width={20}
              height={20}
            />
            by
            <span className="text-nav_text_color text-xs font-bold ">
              {blog.author?.name}
            </span>
            <span className="text-sm  font-light text-blog_icons_text_color">
              {blog.createdAt.slice(0, 4)} -{blog.createdAt.slice(5, 7)} -
              {blog.createdAt.slice(8, 10)}
            </span>
          </p>

          <div className="flex justify-center pb-5">
            {blog.skills.map((skill) => (
              <span
                key={skill}
                className="text-xs font-medium mx-3 text-[#8E8E8E]   bg-[#F5F5F5] py-1 px-3 rounded-lg"
              >
                {skill}
              </span>
            ))}
          </div>

          <p className="text-[12px] line-clamp-3  pb-5  text-[#8E8E8E]">
            {parse(blog.description)}
          </p>

          <p className="flex justify-between items-center mx-1">
            {
              <span className="flex gap-x-2">
                <Image
                  src={"assets/pendingClock.svg"}
                  alt="blog image"
                  width={20}
                  height={20}
                />
                <span className="text-sm text-blog_pending_icon_text_color font-bold">
                  {"pending"}
                </span>
              </span>
            }

            <Link
              href={`/blogs/${blog._id}`}
              className="text-primary font-bold "
            >
              Read More
            </Link>
          </p>
        </div>
      ))}
    </div>
  );
};

export default SmallBlogCard;
