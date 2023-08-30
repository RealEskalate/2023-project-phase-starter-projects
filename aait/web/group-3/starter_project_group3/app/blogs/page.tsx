'use client'

import React, { useMemo, useState } from "react";
import BlogCard from "@/components/blog/BlogCard";
import SearchBar from "@/components/blog/SearchBar";
import Pagination from "@/components/blog/Pagination";
import Link from "next/link";
import Error from "@/components/commons/Error";
import { useGetBlogsQuery } from "@/store/features/blogs/blogs-api";
import Loading from "@/components/commons/Loading";

const PageSize = 4;

const BlogPage: React.FC = () => {
    const {data:blogs, error, isLoading  } = useGetBlogsQuery();
    const [currentPage, setCurrentPage] = useState(1);

    const currentBlogs = useMemo(() => {
      const firstPageIndex = (currentPage - 1) * PageSize;
      const lastPageIndex = firstPageIndex + PageSize;
      return blogs?.slice(firstPageIndex, lastPageIndex);
    }, [currentPage]);
    
    if (isLoading){ 
      return <Loading />
    
    }
    if (error){
        return <Error />    
    }

    if (blogs) {
      return (
        <div>
          <SearchBar />
          <div className="flex flex-col gap-4">
            {currentBlogs?.map((blog) => (
              <Link href={`/blogs/${blog._id}`}>
                  <BlogCard key={blog._id} {...blog} />
              </Link>
            ))}
          </div>
          <div className="m-16 flex justify-center">
            <Pagination
              className="pagination-bar"
              currentPage={currentPage}
              totalCount={blogs.length}
              pageSize={PageSize}
              onPageChange={page => setCurrentPage(page)}
            
            />
          </div>
        </div>
      );
      }else{
        return null
      }
};

export default BlogPage;
