import { Blog } from "@/types/Blog";
import Image from "next/image";
import React from "react";

const BlogItem: React.FC<Blog> = ({
  _id,
  image,
  title,
  description,
  author,
  isPending,
  tags,
  likes,
  relatedBlogs,
  skills,
}) => {
  return (
    <div className="w-full flex flex-col gap-6">
      {/* horizontal line */}
      <div className="mx-6 rounded-full bg-gray-200 h-0.5"></div>

      {/* Author info */}
      <div className="flex gap-2">
        <div className="w-24 h-24 overflow-hidden rounded-full">
          <Image
            src={image}
            alt={"pfp"}
            width={100}
            height={100}
            layout="responsive"
          />
        </div>
      </div>
    </div>
  );
};

export default BlogItem;
