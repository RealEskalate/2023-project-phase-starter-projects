import { Blog } from "@/types/Blog";
import Image from "next/image";
import React from "react";
import AuthorInfo from "./AuthorInfo";

const BlogItem: React.FC<Blog> = ({
  _id,
  image,
  title,
  description,
  author,
  tags,
  createdAt,
}) => {
  return (
    <div className="w-full">
      {/* horizontal line */}
      <div className="mx-2 mb-10 rounded-full bg-gray-200 h-0.05"></div>

      <div className="w-full flex items-center space-x-16">
        
        <div className="w-3/4 flex flex-col space-y-6 mb-10">
          {/* Author info */}
          <AuthorInfo image={image} author={author} createdAt={createdAt} />

          {/* Blog content */}
          <div>
            <h1 className="font-bold text-xl">{title}</h1>
            <p className="mt-4  font-light">{description}</p>
          </div>

          {/* tags */}
          <div className="mt-2">
            <div className="flex flex-wrap space-x-4">
              {tags?.map((tag: string) => (
                <div className="blog-tag bg-gray-200 text-gray-600">{tag}</div>
              ))}
            </div>
          </div>
        </div>

        <Image src={"./images/blogs/coder.svg"} alt={""} width={100} height={50} className="-mt-6 w-64 h-44 object-cover rounded-lg justify-self-end"/>
      </div>
    </div>
  );
};

export default BlogItem;
