"use client"

import {useState} from "react";

import {useGetBlogsQuery} from "@/store/features/blog/blog-api";
import BlogCard from "@/components/blogs/BlogCard";
import Loading from "@/components/common/Loading";

export default function Blogs(){

    const [page, setPage] = useState(1)

    let {data: blogs, error, isLoading} = useGetBlogsQuery()

    const goToPage = (pageNumber: number) => {
        setPage(pageNumber);
    };

    if(isLoading){
        return (
            <Loading/>
        )
    }

    if(blogs){

        const numberOfPages = Math.floor(blogs.length/5);
        const rangeArray = Array.from({ length: numberOfPages }, (_, index) => index);
        const indexOfLastItem = page * 5;
        const indexOfFirstItem = indexOfLastItem - 5;
        const currentItems = blogs.slice(indexOfFirstItem, indexOfLastItem);

        return (
            <div className="w-full pt-10">
                <div className="w-full flex justify-center font-cards pb-10">
                    <h2 className="self-start font-bold text-xl">Blogs</h2>
                    <div className="flex justify-center items-center gap-4 w-5/6">
                        <input placeholder="Search..." className=" px-10 w-[210px] h-[30px] border-2 border-gray-400 rounded-[15px]" type="text" />
                        <button className="px-6 py-2 rounded-full border-none bg-blue-800 text-white">
                            + New Blog
                        </button>
                    </div>
                </div>
                <div className="flex flex-col gap-5 w-full items-center">
                    {
                        currentItems?.map((blog)=>{
                            return <BlogCard key={blog._id} blog={blog}/>
                        })
                    }
                </div>
                <div className="flex justify-center gap-6 my-20">
                    {
                        rangeArray.map((num)=>{
                            return <button key={num} onClick={()=>{ goToPage(num + 1)}} className={(page==num+1)? "bg-blue-800 text-white rounded-lg border-none w-[40px] h-[40px]":"bg-gray-300 text-black rounded-lg border-none w-[40px] h-[40px]"}>
                                {num+1}
                            </button>}
                        )
                    }
                </div>
            </div>
        )

    }


}