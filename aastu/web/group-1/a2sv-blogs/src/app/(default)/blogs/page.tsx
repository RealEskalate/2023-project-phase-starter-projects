"use client";
import BlogCard from "@/components/blogs/BlogCard";
import BlogHeader from "@/components/blogs/BlogHeader";
import Image from "next/image";
import React, { useState } from "react";

export default function page() {
  const [searchQuery, setSearchQuery] = useState<string>(""); // search query state

  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(e.target.value);
  };

  return (
    <div className="lg:px-32 px-5 py-28 flex flex-col gap-16">
      <div className="justify-center flex">
        <BlogHeader searchQuery={searchQuery} handleSearch={handleSearch} />
      </div>
      <div className="flex flex-col md:gap-8 gap-5 items-center mx-auto">
        <BlogCard searchQuery={searchQuery} />
      </div>
    </div>
  );
}
