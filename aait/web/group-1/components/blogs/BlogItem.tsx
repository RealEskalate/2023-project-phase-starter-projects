import { Blog } from "@/types/Blog";
import Image from "next/image";
import React from "react";
import AuthorInfo from "./AuthorInfo";
import parse from "html-react-parser";
import Link from "next/link";

const BlogItem: React.FC<Blog> = ({
  _id,
  image,
  title,
  description,
  author,
  tags,
  createdAt,
}) => {
  const reducedDescription =
    description.length > 150
      ? `${description.substring(0, 150)}...`
      : description;

  return (
    <div className="w-full">
      {/* horizontal line */}
      <div className="mx-2 mb-10 rounded-full bg-gray-200 h-0.05"></div>

      <div className="w-full flex items-center space-x-16">
        <div className="w-3/4 flex flex-col space-y-6 mb-10">
          {/* Author info */}
          {author && <AuthorInfo author={author} createdAt={createdAt} />}

          {/* Blog content */}
          <div>
            <h1 className="font-bold text-xl">{title}</h1>
            <p className="mt-4  font-light">
              {parse(reducedDescription)}
              <Link
                href={`/blog/${_id}`}
                className="text-blue-500 hover:text-blue-800 hover:underline inline ml-3"
              >
                Read more
              </Link>
            </p>
          </div>

          {/* tags */}
          <div className="mt-2">
            <div className="flex flex-wrap gap-4">
              {tags?.map((tag: string) => (
                <div className="blog-tag bg-gray-200 text-gray-600">{tag}</div>
              ))}
            </div>
          </div>
        </div>

        <Image
          src={image ? image : "./images/blogs/coder.svg"}
          alt={""}
          width={100}
          height={50}
          className="-mt-6 w-64 h-44 object-cover rounded-lg justify-self-end"
        />
      </div>
    </div>
  );
};

export default BlogItem;
