import React from 'react';
import Image from 'next/image';
import { Blog } from '@/types/Blog';
import { BiSolidTime } from 'react-icons/bi';
import Link from 'next/link';
import { formatDate } from '@/utils/dateFormater';

interface PropsInterface {
  post: Blog;
}

const Card: React.FC<PropsInterface> = ({ post }) => {
  const dateFormatted: string = formatDate(post.createdAt);

  return (
    <div className='col-span-1 font-montserrat shadow-lg rounded-md'>
      <Image
        className='object-cover w-full'
        src={ post.image }
        alt={ post.description }
        width={ 420 }
        height={ 300 }
      />

      <div className='px-5 flex flex-col items-start space-y-5 py-5'>

        <h4 className='text-gray-700 text-sm'>{ post.title }</h4>

        <div className='flex justify-start items-center space-x-3'>
          <Image
            className='rounded-full'
            src={ post.author.image }
            alt={ post.author.name }
            width={ 26 }
            height={ 26 }
          />
          <p className='text-[11px] text-[#B9B9C3] font-light'>by <span className='text-[#6E6B7B] font-semibold'>{ post.author.name }</span> | { dateFormatted }</p>
        </div>

        <div className='flex items-center justify-start space-x-4 min-h-[20px]'>
          {
            post.skills.map(skill => (
              <div className='text-[9px] px-4 py-2 font-semibold text-gray-400 rounded-full border bg-gray-200'>{ skill }</div>
            ))
          }
        </div>

        <div className='text-[11px] text-gray-500'>{ post.description }</div>

        <div className='flex justify-between items-center w-full border-t pt-4 text-[12px]'>
          <div className={`flex justify-start items-center space-x-1 ${ post.isPending ? 'text-orange-400' : 'text-green-400' }`}>
            <BiSolidTime />
            <span>{ post.isPending ? 'Pending' : 'Published' }</span>
          </div>
          <div className='text-[#7367F0] font-semibold cursor-pointer'>
            <Link href={`/blog/${post._id}`}>Read More</Link>
          </div>
        </div>

      </div>

    </div>
  )
}

export default Card;
