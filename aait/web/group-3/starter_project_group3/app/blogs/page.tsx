'use client'

import React, { useState } from "react";
import BlogCard from "@/components/blog/BlogCard";
import SearchBar from "@/components/blog/SearchBar";
import Pagination from "@/components/blog/Pagination";
import Link from "next/link";
import Error from "@/components/commons/Error";
import { useGetBlogsQuery } from "@/store/features/blogs/blogs-api";
import Loading from "@/components/commons/Loading";

const itemsPerPage = 4;

const BlogPage: React.FC = () => {
    const {data:blogs, error, isLoading  } = useGetBlogsQuery();
    const [currentPage, setCurrentPage] = useState(1)

    if (isLoading){ 
      return <Loading />
    
    }
    if (error){
        return <Error />    
    }
    if (blogs) {

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
            <Link href={`/blogs/${blog._id}`}>
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
    }else{
      return null
    }
};

export default BlogPage;
