import { Blog } from "@/types/Blog";
import Image from "next/image";
import React from "react";

const BlogItem: React.FC<Blog> = ({
  _id,
  image,
  title,
  description,
  author,
  tags,
  createdAt
}) => {
  return (
    <div className="w-full flex flex-col gap-6 mb-10">
      {/* horizontal line */}
      <div className="mx-2 rounded-full bg-gray-200 h-0.5"></div>

      {/* Author info */}
      <div className="flex gap-8">
        <div className="w-16 h-16 rounded-full">
          <Image
            src={image}
            alt={"pfp"}
            width={50}
            height={50}
            layout="responsive"
            className="rounded-full"
          />
        </div>

        <div className="self-center">
          <div className="flex gap-4 items-center">
            <h1 className="text-lg">{author ? author.name! : 'Anonymous Writer'}</h1>
            <div className="w-1 h-1 rounded-full bg-gray-700"></div>
            <p className="text-sm text-gray-500">{createdAt.slice(0, 10)}</p>
          </div>
          <div className="mt-1">
            <h1 className="text-gray-500 uppercase text-xs">{author ? author.name! : 'Anonymous role'}</h1>
          </div>
        </div>
      </div>

      {/* Blog content */}
      <div>
        <h1 className="font-bold text-xl">{title}</h1>
        <p className="mt-4 text-gray-500">{description}</p>
      </div>

      {/* tags */}
      <div className="mt-2">
        <div className="flex flex-wrap space-x-4">
          {tags?.map((tag: string) => <div className="blog-tag bg-gray-200 text-gray-600">{tag}</div>)}
          
        </div>
      </div>
    </div>
  );
};

export default BlogItem;
