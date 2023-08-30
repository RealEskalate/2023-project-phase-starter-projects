import React from 'react'


interface BlogAuthorProps {
    name: string,
    role: string,
    date: string,
    imgUrl: string
}

const BlogAuthor: React.FC<BlogAuthorProps> = ({name, role, date,imgUrl}:BlogAuthorProps) => {
    return (
        <div className='flex justify-start align-center'>
                                    <div className='w-[88px] h-[88px] rounded-[44px] bg-primary'>
                                        {/* <Image src={imgUrl} alt='blog image' className='rounded-md w-full ' objectFit='contain' layout='fill'  /> */}
                                    </div>
                                    <div className='flex justify-start items-center'>
                                        <div className='flex items-start'>
                                            <div className='ml-6 flex flex-col text-left'>
                                                <h4 className='text-2xl  font-semibold capitalize'>Yididya Kebede</h4>
                                                <h4 className='text-lg text-[#9C9C9C] uppercase' >Software Engineer</h4>
                                            </div>
                                            <div className='flex ml-3'>
                                                <div className='flex justify-center items-center'><div className='w-[6px] h-[6px] rounded-[3px] bg-gray-400'></div><h5 className='text-gray-600 ml-3'> date-month-year</h5></div>
                                            </div>
                                        </div>

                                    </div>

                                </div>
    );
    }

    export default BlogAuthor;