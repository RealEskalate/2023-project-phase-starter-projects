import { authTypes } from '@/types/auth/authTypes';
import Link from 'next/link'
import React from 'react'

const SearchBar = () => {
    let userString = null;
    if (typeof window !== 'undefined'){
    userString = localStorage.getItem("user");}
    const user: authTypes | null = userString ? JSON.parse(userString) : null;
    const token = user?.token

  return (
    <div className=' md:p-10 lg:pl-24 lg:pr-48 py-8 flex flex-col md:flex-row justify-between items-center'>
        <h1 className='font-bold text-2xl'>Blogs</h1>
        <div className='flex mt-8 lg:mt-0  lg:mr-48  sm:items-center '>
            <div  className='w-3/4'>
                <input
                    type="text"
                    placeholder="Search..."
                    className=" pl-4 sm:px-16 py-1 w-3/4  border rounded-full border-gray-300  focus:ring focus:ring-primary focus:outline-none"

                />
            </div>
            <div>
                <Link href={token ? '/blogs/create': '/login'} className='bg-primary rounded-full sm:px-4 py-2 text-white border-none'><button className='p-2'><strong>+</strong> New Blog</button></Link>
            </div>
        </div>
    </div>
  )
}

export default SearchBar