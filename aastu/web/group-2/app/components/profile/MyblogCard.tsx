import { Blog } from '@/lib/types';
import Image from 'next/image';
import React from 'react';
import Chip from '../Chip';
import Link from 'next/link'
import { AiFillClockCircle } from 'react-icons/ai'

const SingleBlogCard: React.FC<Blog> = ({
    author,
    image,
    createdAt,
    title,
    tags,
}) => {
    return (
        <div
            className='space-y-4 bg-white overflow-hidden shadow-lg rounded-md'>
            <Image
                className='w-full'
                src={image}
                alt={title}
                width={300}
                height={200}
            />
            <div
                className='p-3 space-y-4'>
                <div
                    className='flex items-center space-x-4 text-sm'>
                    <Image
                        src={author?.image ? author.image : ""}
                        alt={author?.name + ' picture'}
                        width={40}
                        height={40}
                        className='rounded-full'
                    />
                    <span> by {author?.name}</span>
                    <span>{createdAt}</span>
                </div>
                <div
                    className='flex flex-wrap w-full items-start text-center'>
                    {tags.map((tag, i) => {
                        return (
                            <p
                                className='block m-2 rounded-full py-1 px-3 bg-gray-100'>{tag}</p>
                        )

                    })}
                </div>

                <hr
                    className='w-10/12 mx-auto' />
                <div
                    className='px-4 flex justify-between font-semibold'>

                    <span
                        className='text-[#FF9F43]'>
                        <AiFillClockCircle className='inline-block mr-1' />
                        Pending
                    </span>
                    <Link
                        className='text-[#7367F0]'
                        href='#'>

                        Read More
                    </Link>

                </div>

            </div>
        </div>
    );
};

export default SingleBlogCard;
