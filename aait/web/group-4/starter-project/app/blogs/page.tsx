"use client"

import {useState} from "react";

import {useGetBlogsQuery} from "@/store/blogs/BlogApi";
import BlogCard from "@/components/blogs/BlogCard";

export default function Blogs(){

    const [page, setPage] = useState(1)

    let {data: blogs, error, isLoading} = useGetBlogsQuery()

    const goToPage = (pageNumber: number) => {
        setPage(pageNumber);
    };

    if (isLoading){

        return (
            <div className="flex justify-center items-center">
                <div
                    className="inline-block h-60 w-60 animate-spin rounded-full border-8 border-solid border-current border-r-transparent align-[-0.125em] motion-reduce:animate-[spin_1.5s_linear_infinite]"
                    role="status">
                  <span
                      className="!absolute !-m-px !h-px !w-px !overflow-hidden !whitespace-nowrap !border-0 !p-0 ![clip:rect(0,0,0,0)]"
                  >Loading...</span>
                </div>
            </div>

        )
    }
    if (error){
        return <div
            className="mb-3 inline-flex w-full items-center rounded-lg bg-danger-100 px-6 py-5 text-base text-danger-700"
            role="alert">
              <span className="mr-2">
                <svg
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 24 24"
                    fill="currentColor"
                    className="h-5 w-5">
                  <path
                      fill-rule="evenodd"
                      d="M12 2.25c-5.385 0-9.75 4.365-9.75 9.75s4.365 9.75 9.75 9.75 9.75-4.365 9.75-9.75S17.385 2.25 12 2.25zm-1.72 6.97a.75.75 0 10-1.06 1.06L10.94 12l-1.72 1.72a.75.75 0 101.06 1.06L12 13.06l1.72 1.72a.75.75 0 101.06-1.06L13.06 12l1.72-1.72a.75.75 0 10-1.06-1.06L12 10.94l-1.72-1.72z"
                      clip-rule="evenodd" />
                </svg>
              </span>
            Error while fetching data
        </div>
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