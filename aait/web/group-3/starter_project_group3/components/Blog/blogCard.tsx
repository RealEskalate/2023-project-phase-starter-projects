import Image from "next/image";
import React from "react";
import { BlogModel } from "@/types/Blog/blogTypes";

interface BlogCardProps {
  blog: BlogModel;
}
const BlogCard = ({ blog }: BlogCardProps) => {
  return (
    <div key={blog.header} className=" w-[23%] shadow-md rounded-md ">
      <div className=" flex justify-center items-center">
        <Image src={blog.image} alt="blog image" width={350} height={350} />
      </div>
      <p className="font-bold text-nav_text_color mx-5 py-3">{blog.header}</p>
      <p className="flex mx-5  pt-3 pb-5 justify-start gap-x-2 items-center">
        <Image src={blog.personImage} alt="blog image" width={20} height={20} />
        by
        <span className="text-nav_text_color font-bold">
          {blog.personName}{" "}
        </span>
        <span className="text-sm font-light text-blog_icons_text_color">
          {blog.date}
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

      <p className="text-[12px]  pb-5  text-[#8E8E8E]">{blog.content}</p>

      <p className="flex justify-between items-center mx-1 mb-2">
        <span className="flex  gap-x-2">
          <Image
            src={"assets/pendingClock.svg"}
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
  );
};

export default BlogCard;
