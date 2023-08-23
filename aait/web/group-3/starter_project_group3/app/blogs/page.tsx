'use client'

import React, { useState } from "react";
import { Blog, Author } from "@/types/blog/blog";
import BlogCard from "@/components/blog/BlogCard";
import SearchBar from "@/components/blog/SearchBar";
import Pagination from "@/components/blog/Pagination";

const itemsPerPage = 2;

const BlogPage: React.FC = () => {
    const authors: Author[] = [
    {
        _id: "1",
        name: "John Doe",
        email: "john@example.com",
        image: "./assets/profile.svg",
        role: "user",
    },
    {
        _id: "2",
        name: "Jane Smith",
        email: "jane@example.com",
        image: "./assets/profile.svg",
        role: "user",
    },
    ];

    const blogs: Blog[] = [
   {
        _id: "1",
        image: "./assets/blogImage.svg",
        title: "Mastering the Art of Code Refactoring",
        description: "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhCode refactoring is an essential practice...Lorem ipsum dolor, sit amet consectetur adipisicing elit. Voluptatibus ipsum similique saepe in incidunt ullam doloribus dolore animi. Commodi facilis",
        author: authors[0],
        isPending: true,
        tags: ["Programming", "Code"],
        likes: 0,
        relatedBlogs: [],
        skills: ["Web Development", "Mobile"],
        createdAt: "2023-08-18T21:49:49.752Z",
        updatedAt: "2023-08-18T21:49:49.752Z",
        __v: 0,
    },
    {
        _id: "2",
        image: "./assets/blogImage.svg",
        title: "The Art of Problem Solving",
        description: "jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjCode refactoring is an essential practice...Lorem ipsum dolor, sit amet consectetur adipisicing elit. Voluptatibus ipsum similique saepe in incidunt ullam doloribus dolore animi. Commodi facilis",
        author: authors[1],
        isPending: true,
        tags: ["Programming", "Problem Solving"],
        likes: 0,
        relatedBlogs: [],
        skills: ["Software Engineering"],
        createdAt: "2023-08-19T10:00:00.000Z",
        updatedAt: "2023-08-19T10:00:00.000Z",
        __v: 0,
    },
    {
        _id: "3",
        image: "./assets/blogImage.svg",
        title: "astering the Art of Code Refactoring",
        description: "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhCode refactoring is an essential practice...Lorem ipsum dolor, sit amet consectetur adipisicing elit. Voluptatibus ipsum similique saepe in incidunt ullam doloribus dolore animi. Commodi facilis",
        author: authors[0],
        isPending: true,
        tags: ["Programming", "Code"],
        likes: 0,
        relatedBlogs: [],
        skills: ["Web Development", "Mobile"],
        createdAt: "2023-08-18T21:49:49.752Z",
        updatedAt: "2023-08-18T21:49:49.752Z",
        __v: 0,
    },
    {
        _id: "4",
        image: "./assets/blogImage.svg",
        title: "Mastering the Art of Code Refactoring",
        description: "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhCode refactoring is an essential practice...Lorem ipsum dolor, sit amet consectetur adipisicing elit. Voluptatibus ipsum similique saepe in incidunt ullam doloribus dolore animi. Commodi facilis",
        author: authors[0],
        isPending: true,
        tags: ["Programming", "Code"],
        likes: 0,
        relatedBlogs: [],
        skills: ["Web Development", "Mobile"],
        createdAt: "2023-08-18T21:49:49.752Z",
        updatedAt: "2023-08-18T21:49:49.752Z",
        __v: 0,
    },
    ];

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
          <BlogCard key={blog._id} {...blog} />
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
