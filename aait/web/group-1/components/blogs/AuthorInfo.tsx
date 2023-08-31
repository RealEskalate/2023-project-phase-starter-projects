import { Author } from "@/types/Author";
import Image from "next/image";
import React from "react";

interface AuthorAndImage {
  author: Author;
  createdAt: string;
}

const AuthorInfo: React.FC<AuthorAndImage> = ({ author, createdAt }) => {
  return (
    <div className="flex space-x-8">
      <Image
        src={author && author.image ? author.image : './images/blogs/Default_pfp.svg'}
        alt={"Author's profile picture"}
        width={100}
        height={100}
        className="w-12 h-12 object-cover rounded-full"
      />

      <div className="self-center">
        <div className="flex space-x-4 items-center">
          <h1 className="text-lg  font-semibold">
            {author ? author.name! : "Anonymous Writer"}
          </h1>
          <div className="w-1 h-1 rounded-full bg-gray-700"></div>
          <p className="text-sm text-gray-500">{createdAt.slice(0, 10)}</p>
        </div>
        <div className="mt-1">
          <h1 className="text-gray-500 uppercase text-xs">
            {author ? author.role! : "Anonymous role"}
          </h1>
        </div>
      </div>
    </div>
  );
};

export default AuthorInfo;
