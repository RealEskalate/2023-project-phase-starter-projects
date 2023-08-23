"use client"
import Link from "next/link";
import { usePathname } from 'next/navigation'
import React from "react";

interface Props {
  name: string;
  link: string;
}

export const LinkItems: React.FC<Props> = ({ name, link }) => {
  const pathname = usePathname();
  const isCurrentRoute = pathname === link;

  return (
    <div className={`group ${isCurrentRoute ? 'cursor-pointer font-bold' : 'hover:cursor-pointer font-semibold'}`}>
      <Link
        className={`text-sm capitalize ${isCurrentRoute ? 'text-blue-800' : 'group-hover:text-blue-800'}`}
        href={link}
      >
        {name}
      </Link>
      <div className={`h-1 mt-1 mx-0.5 rounded-full bg-blue-800 opacity-0 ${isCurrentRoute ? 'opacity-100' : 'group-hover:opacity-100'} transition-opacity`}></div>
    </div>
  );
};
