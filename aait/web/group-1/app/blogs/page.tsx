import BlogItem from "@/components/blogs/BlogItem";
import { Blog } from "@/types/Blog";
import React from "react";

const page = () => {
  const blogs: Blog[] = [
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"]
    },
  ];

  return (
    <div className="py-20 font-montserrat">
      {/* Search section and header */}
      <div className="px-20 flex flex-col md:flex-row gap-4 md:gap-96">
        <h1 className="font-semibold text-xl">Blogs</h1>
        <div className="flex gap-6">
          <input
            type="text"
            placeholder="Search..."
            className="px-10 rounded-full py-2 outline outline-1 outline-gray-300 font-montserrat placeholder:text-sm"
          />
          <button className="btn-light bg-blue-800 text-white">
            + New Blog
          </button>
        </div>
      </div>

      {/* Blogs section */}
      <div className="px-56 py-10">
        <div className="w-full">
          {blogs?.map((blog: Blog) => <BlogItem _id={blog._id} image={blog.image} title={blog.title} description={blog.description} author={blog.author} isPending={blog.isPending} tags={blog.tags} likes={blog.likes} relatedBlogs={blog.relatedBlogs} skills={blog.skills} /> )}
        </div>
      </div>

      {/* pagination */}
      <div className="w-full flex justify-center gap-5 my-8">
        <div className="page bg-blue-800 text-white">1</div>
        <div className="page bg-gray-200">2</div>
        <div className="page bg-gray-200">3</div>
        <div className="page bg-gray-200">4</div>
        <div className="page bg-gray-200">5</div>
      </div>
    </div>
  );
};

export default page;
