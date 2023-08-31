'use client'

import React, { useMemo, useState, useEffect } from "react";
import BlogCard from "@/components/blog/BlogCard";
import SearchBar from "@/components/blog/SearchBar";
import Pagination from "@/components/blog/Pagination";
import Link from "next/link";
import Error from "@/components/commons/Error";
import { useGetBlogsQuery } from "@/store/features/blogs/blogs-api";
import Loading from "@/components/commons/Loading";
import { Blog } from "@/types/blog/blog";

const PageSize = 4;

const BlogPage: React.FC = () => {
    const { data: blogs, error, isLoading } = useGetBlogsQuery();
    const [currentPage, setCurrentPage] = useState(1);
    const [currentBlogs, setCurrentBlogs] = useState<Blog[] | null>(null);

    useEffect(() => {
      if (blogs) {
        const firstPageIndex = (currentPage - 1) * PageSize;
        const lastPageIndex = firstPageIndex + PageSize;
        setCurrentBlogs(blogs.slice(firstPageIndex, lastPageIndex));
      }
    }, [currentPage, blogs]);

    if (isLoading) { 
      return <Loading />;
    }

    if (error) {
      return <Error />;
    }

    return (
      <div>
        <SearchBar />
        <div className="flex flex-col gap-4">
          {currentBlogs?.map((blog) => (
            <Link href={`/blogs/${blog._id}`} key={blog._id}>
              <BlogCard {...blog} />
            </Link>
          ))}
        </div>
        <div className="m-16 flex justify-center">
          <Pagination
            className="pagination-bar"
            currentPage={currentPage}
            totalCount={blogs ? blogs.length : 0}
            pageSize={PageSize}
            onPageChange={page => setCurrentPage(page)}
          />
        </div>
      </div>
    );
};

export default BlogPage;
