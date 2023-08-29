import BlogCard from "@/components/blogs/BlogCard";
import BlogHeader from "@/components/blogs/BlogHeader";
import Image from "next/image";
import React from "react";

export default function page() {
  return (
    <div className="lg:px-32 px-5 py-28 flex flex-col gap-16">
      <div className="justify-center flex">
        <BlogHeader />
      </div>
      <div className="flex flex-col md:gap-8 gap-5 items-center mx-auto">
        <BlogCard />
      </div>
    </div>
  );
}
