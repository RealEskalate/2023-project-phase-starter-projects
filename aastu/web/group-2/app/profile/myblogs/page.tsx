"use client"
import { Blog, User } from '@/lib/types';


import MyBlogCard from "@/app/components/profile/MyblogCard"
import { useGetBlogsQuery, useMyBlogsQuery } from '@/lib/redux/slices/blogsApi';

export default function Section() {

    const {data: blogs, error, isSuccess, isLoading} = useMyBlogsQuery()

    return (
        <div
            className='grid font-secondaryFont mb-12 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4'>
            {blogs?.map((blog, i) => {
                return (
                    <MyBlogCard key={i} {...blog} />
                )
            })}
        </div>
    )
}