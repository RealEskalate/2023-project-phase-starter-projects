import Image from "next/image";
import React from "react";
import { Blog } from "@/types/blog/blog";

interface BlogCardProps {
  blogs: Blog[];
}

const SmallBlogCard = ({ blogs }: BlogCardProps) => {
  return (
    <div className="py-4 flex justify-between items-center flex-wrap gap-y-8">
      {blogs.map((blog) => (
        <div key={blog._id} className=" w-[23%] rounded-md shadow-md ">
          <div className=" shadow-lg flex justify-center items-center">
            <Image
              className=" rounded-md"
              src={blog.image}
              alt="blog image"
              width={350}
              height={350}
            />
          </div>
          <p className="font-bold text-nav_text_color text-sm p-3">
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

          <p className="text-[12px] line-clamp-3  pb-5 px-3 text-[#8E8E8E]">
            {blog.description}
          </p>

          <p className="flex justify-between items-center mx-1 px-3 pb-3">
            <span className="flex  gap-x-2">
              <Image
                src={"../images/pendingClock.svg"}
                alt="blog image"
                width={20}
                height={20}
              />
              <span className="text-sm text-blog_pending_icon_text_color font-bold">
                Pending
              </span>
            </span>

            <button className="text-primary font-bold ">Read More</button>
          </p>
        </div>
      ))}
    </div>
  );
};

export default SmallBlogCard;
