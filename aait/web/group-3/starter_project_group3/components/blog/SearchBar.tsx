import Link from 'next/link'
import React from 'react'

const SearchBar = () => {
  return (
    <div className='pl-24 pr-48 py-8 flex justify-between items-center'>
        <h1 className='font-bold'>Blogs</h1>
        <div className='flex mr-48  items-center '>
            <div  className='w-3/4'>
                <input
                    type="text"
                    placeholder="Search..."
                    className="px-16 py-1 w-3/4  border rounded-full border-gray-300  focus:ring focus:ring-blue-400 focus:outline-none"

                />
            </div>
            <div>
                <Link href='/blogs/create' className='bg-primary rounded-full px-4 py-2 text-white border-none'><button className='p-2'>+ New Blog</button></Link>
            </div>
        </div>
    </div>
  )
}

export default SearchBar