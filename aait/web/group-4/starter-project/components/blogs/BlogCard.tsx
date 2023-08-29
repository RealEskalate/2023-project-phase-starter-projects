"use client"

import React from "react";
import Link from "next/link";
import Image from "next/image"

import BlogData from "@/types/blogs/BlogData";
import dummyAuthor from "@/data/dummyAuthor.json"
interface BlogProps {
    blog: BlogData;
}

const BlogCard: React.FC<BlogProps> = ({blog}) => {

    return (
        <Link className="w-4/5" href={`/blogs/${blog._id}`}>
            <div className="font-cards text-black w-full border-t-[2px] py-4 border-gray-300">
                <div className="flex items-start gap-4">
                    {
                        blog.author?(
                            <>
                                <Image className="w-[50px] h-[50px] rounded-full" width={50} height={50} src={blog.author.image} alt={"a2sv logo"} />
                                <div>
                                    <span className="text-[16px] font-bold">{blog.author.name}</span> &#x2022; <span className="text-gray-600">Apr 16, 2022</span>
                                    <p className="font-bold text-gray-500">{blog.author.role}</p>
                                </div>
                            </>
                        ):(
                            <>
                                <img className="w-[50px] h-[50px] object-cover rounded-full" src={dummyAuthor.image}/>
                                <div>
                                    <span className="text-[16px] font-bold">{dummyAuthor.name}</span> &#x2022; <span className="text-gray-600">Apr 16, 2022</span>
                                    <p className="font-bold text-gray-500">{dummyAuthor.role}</p>
                                </div>
                            </>
                        )
                    }
                </div>
                <div className="grid md:grid-cols-2 grid-cols-1 mb-3 w-full px-4 place-items-center">
                    <div className=" flex gap-2 flex-col py-6">
                        <h2 className="text-black text-xl font-bold">
                            {blog.title}
                        </h2>
                        <p>
                            {blog.description}
                        </p>
                    </div>
                    <Image className="w-3/4 self-center rounded-lg" width={50} height={50} src={blog.image} alt={"blog image"} />
                </div>
                <div className="flex gap-2">
                    {
                        blog.tags.map((tag)=>{
                            return(
                                <button className="px-6 py-2 rounded-full border-none bg-gray-200 text-gray-400">
                                    { tag }
                                </button>
                            )
                        })
                    }
                </div>
            </div>
        </Link>

    )
}

export default BlogCard