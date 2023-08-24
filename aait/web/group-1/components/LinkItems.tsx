import Link from "next/link";
import React from "react";

interface Props {
  name: string;
  link: string;
}

export const LinkItems: React.FC<Props> = ({ name, link }) => {
  return (
    <div className="group hover:cursor-pointer font-semibold hover:font-bold">
      <Link
        className="text-sm capitalize group-hover:text-blue-800"
        href={link}
      >
        {name}
      </Link>
      <div className="h-1 mt-1 mx-0.5 rounded-full bg-blue-800 opacity-0 group-hover:opacity-100 transition-opacity"></div>
    </div>
  );
};
