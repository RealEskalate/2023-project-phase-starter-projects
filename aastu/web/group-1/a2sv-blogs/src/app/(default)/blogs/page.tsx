import BlogCard from "@/components/blogs/BlogCard";
import BlogHeader from "@/components/blogs/BlogHeader";
import PaginationLinks from "@/components/blogs/PaginationLinks";
import Image from "next/image";
import React from "react";

export default function page() {
  return (
    <div className="mt-32 flex flex-col gap-16">
      <BlogHeader />
      <div className="w-[72%] flex flex-col gap-10 items-center mx-auto">
        <BlogCard />
      </div>
      <PaginationLinks />
    </div>
  );
}
