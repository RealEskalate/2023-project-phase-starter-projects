import React from "react";
import Image from 'next/image'

import BlogData from "@/types/blogs/BlogData";
import BlogCardSmall from "@/components/blogs/SmallBlogCard";
import dummyAuthor from "@/data/dummyAuthor.json"

export default async ({params}: { params: { id: string } }) => {

    const responseData = await fetch(`https://a2sv-backend.onrender.com/api/blogs/${params.id}`);
    const data: BlogData = await responseData.json();

    const relatedBlogsSizeArray = [1, 2, 3];

    return (
        <div className="flex flex-col items-center lg:px-32 md:px-14 px-8 md:pt-14 pt-8">
            <div className="flex flex-col items-center font-blog">
                <h1 className="text-[2rem] font-bold">
                    {data.title}
                </h1>
                <span className="flex uppercase text-[1rem] text-gray-500">
                    {
                        data.tags.map((tag)=><p>{tag + ","}</p>)
                    }
                    <p> | 6 MIN READ</p>
                </span>
            </div>

            <Image className="w-full md:py-12 py-7 object-cover" width={40} height={40} alt={"blog image"} src={data.image}/>

            {
                data.author?(
                    <div className="flex flex-col items-center gap-2 md:pb-12">
                        <img className=" rounded-full w-[80px] h-[80px]" src={data.author.image} />
                        <span className="flex gap-2 justify-between font-nav text-gray-400 uppercase text-[1rem]">
                    <p>{ data.author.name }</p>
                    <p> | </p>
                    <p>{ data.author.role }</p>
                </span>
                        <p className="font-semibold text-blue-600 ">{data.author.email}</p>
                    </div>
                ):(
                    <div className="flex flex-col items-center gap-2 md:pb-12">
                        <Image className=" rounded-full w-[80px] h-[80px]" width={80} height={80} src={dummyAuthor.image} />
                        <span className="flex gap-2 justify-between font-nav text-gray-400 uppercase text-[1rem]">
                    <p>{ dummyAuthor.name }</p>
                    <p> | </p>
                    <p>{ dummyAuthor.role }</p>
                </span>
                        <p className="font-semibold text-blue-600 ">{dummyAuthor.email}</p>
                    </div>
                )

            }


            <div className="font-nav flex flex-col gap-8 md:pl-32 pl-6 text-left text-gray-500">
                <h2 className='md:text-[2rem] text-[1.3rem] font-bold text-black'>
                    {data.description}
                </h2>
                <p className="text-[0.9rem] md:text-[1.2rem]">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>
            </div>

            <div className="flex flex-col py-20">
                <h1 className="text-[1.5rem] font-bold font-nav mb-8">
                    Related Blogs
                </h1>
                <div className="grid md:grid-cols-3 gap-6 grid-cols-1">
                    {
                        relatedBlogsSizeArray.map((num)=>{
                            return (
                                <BlogCardSmall/>
                            )
                        })
                    }
                </div>
            </div>
        </div>
    )
}
