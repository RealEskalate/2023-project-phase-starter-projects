import type { InferGetServerSidePropsType, GetServerSideProps } from 'next'
import Link from 'next/link'

import BlogTags from '@/components/blogs/BlogTags'
import { Blog } from '@/types/blog'
import SearchArea from '@/components/blogs/SearchArea'
import BlogAuthor from '@/components/blogs/BlogAuthor'
import BlogPreview from '@/components/blogs/BlogPreview'



export const getBlogs = async () => {
    const res = await fetch('https://a2sv-backend.onrender.com/api/blogs')

    return await res.json()
}






const BlogsPage: React.FC = async () => {

    const blogs = await getBlogs();
    return (
        <div className='w-11/12 mx-auto mt-20'>
            <SearchArea />
            <div className='w-4/5 flex flex-col mt-24 mx-auto'>
                {
                    blogs && blogs.map((blog: Blog, index: number) => {

                        return (
                            <div className='w-full flex flex-col text-left border-gray-300 border-t-2 py-8'>
                                <BlogAuthor name='' role='' imgUrl='' date=''/>
                                <Link prefetch href={`blogs/${blog._id}`}>
                                    <BlogPreview title={blog.title} description={blog.description} blogImg={blog.image} />
                                </Link>
                                <div className='flex flex-wrap w-full'>
                                    {
                                        blog.tags.map((tag, index) => {
                                            return <BlogTags tag={tag} key={index}/>
                                                
                                        })}
                                </div>
                            </div>
                        )
                    })

                }

            </div>
        </div>
    )
}

export default BlogsPage