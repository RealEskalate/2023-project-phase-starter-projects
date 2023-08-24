"use client"
import { Blog, User } from '@/lib/types';
const startingId = 10;
const users: User[] = [
  ];
  
  const blogs: Blog[] = [
    
  ];

import MyBlogCard from "@/app/components/profile/MyblogCard"
export default function Section() {
    return (
        <div 
            className='grid font-secondaryFont mb-12 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4'>
            {blogs.map((blog, i) => {
                return (
                    <MyBlogCard key={i} {...blog} />
                )
            })}
        </div>
    )
}