'use client'

import React, { useState } from "react";
import { authors, blogs } from "@/data/blog/blog";
import BlogCard from "@/components/blog/BlogCard";
import SearchBar from "@/components/blog/SearchBar";
import Pagination from "@/components/blog/Pagination";
import Link from "next/link";

const itemsPerPage = 2;

const BlogPage: React.FC = () => {

    const [currentPage, setCurrentPage] = useState(1)
    const indexOfLastBlog = currentPage * itemsPerPage;
    const indexOfFirstBlog = indexOfLastBlog - itemsPerPage

    const currentBlogs = blogs.slice(indexOfFirstBlog, indexOfLastBlog);
    const totalPages = Math.ceil(blogs.length / itemsPerPage)

    const handlePageChange = (page:number) => {
        setCurrentPage(page)
    }


  return (
    <div>
      <SearchBar />
      <div className="flex flex-col gap-4">
        {currentBlogs.map((blog) => (
          <Link href={`${blog._id}`}>
              <BlogCard key={blog._id} {...blog} />
          </Link>
        ))}
      </div>
      <div className="m-16 flex justify-center">
        <Pagination
          currentPage={currentPage}
          totalPages={totalPages}
          onPageChange={handlePageChange}
          className="pagination"
        />
      </div>
    </div>
  );
};

export default BlogPage;
