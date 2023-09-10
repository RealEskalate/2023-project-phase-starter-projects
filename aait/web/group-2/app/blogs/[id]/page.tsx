"use client"
import Image from "next/image"
import { useGetBlogByIdQuery } from "@/store/features/blogs/blogs-api"
import BlogTags from "@/components/blogs/BlogTags"





const BlogDetailPage: React.FC = ({
  params: { id },
}: {
  params: { id: string }
}) => {


  const { data: blogDetail, isLoading, isFetching } = useGetBlogByIdQuery(id as string)


  return (
    <div className='flex flex-col w-4/5 mx-auto my-20'>
    
      <div className='flex flex-col justify-center items-center'>
        <h2 className="leading-9 text-4xl py-5">The essential guide to Competitive Programming</h2>
        <div className='flex flex-row justify-center items-center uppercase text-lg gap-4'>
          <h4 className="text-gray-400 ">Programming, Tech </h4>
          <h4 className="text-gray-400 mx-2">|</h4>
          <h4 className="text-gray-400"> 5 min read</h4>
        </div>
      </div>

      
      <div className='relative w-full h-[600px] flex flex-col justify-center items-center bg-gray-300 my-16'>
        <Image src='/images/blog-img.jpg' alt="blog image" className='absolute' objectFit="cover" fill={true}/>
      </div>

     
      <div className='flex flex-col justify-center items-center'>
        <div className="w-20 h-20 rounded-[40px] bg-primary">
         
        </div>
        <div className='flex flex-row justify-center items-center mt-6 gap-4'>
          <h4 className="text-gray-400">Chaltu Kebede</h4>
          <h4 className="text-gray-400"> | </h4>
          <h4 className="text-gray-400">Software Engineer</h4>
        </div>
        <h4 className="text-blue-300">@Chaltu_Kebede</h4>
      </div>


      
      <div className='w-ful flex flex-row justify-end'>
        <div className="w-11/12 flex flex-col  mt-10 ">
          <div className="w-full flex flex-col items-center">
            <div className='mr-0'>
              <p className="text-justify pt-6">
                {blogDetail && blogDetail.description}
              </p>
            </div>
          </div>
        </div>
      </div>

      {/* Related section */}
      <div className="w-full flex flex-col justify-center items-center text-left mt-10">
        <div className="w-full ml-0 my-15">
          <h3 className="w-full text-3xl font-semibold leading-11">Related Blogs</h3>
        </div>
        <div className="w-full grid grid-cols-3 gap-5 items-center mt-10">
          <div className='col-span-1 flex flex-col w-fit h-fit'>
            <div className="relative h-[270px] w-full bg-gray-300 mr-10">
              <Image src="/images/blog-img.jpg" alt="blog image" className='absolute w-full h-full object-cover' fill={true} />
            </div>
            <div className='w-11/12 mx-auto my-5 flex flex-col items-center text-left'>
              <h3 className='w-full text-left text-xl capitalize font-medium'>Design Liberalized Exchange Rate Management</h3>
            </div>
            <div className='flex w-full gap-2 justify-start items-center'>
              <div className='w-7 h-7 rounded-[14px] bg-primary'></div>
              <h3 className='font-semibold text-lg'>Fred Boone</h3>
              <div className='text-gray-500 '>|</div>
              <div className='text-gray-500'>Jan 20, 2023</div>
            </div>
              <div className='flex gap-2 items-align justify-start mt-4'>
              <div className='text-gray-700 bg-gray-300 rounded-full text-lg px-4 py-2'>UI/UX</div>
                <div className='text-gray-700 bg-gray-300 rounded-full text-xl px-4 py-2'>Development</div>
              </div>
              <div className='border-b-2 border-gray-300 w-full py-4'>
                <p className="text-gray-500">A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.</p>
              </div>
              <div className='flex flex-row justify-between items-center my-8'>
                <div className='text-700 font-semibold'>2.3K Likes</div>
                <div className='flex flex-row gap-2 cursor-pointer text-purple-500'>Read More</div>
              </div>
            </div>
            <div className='col-span-1 flex flex-col w-fit h-fit'>
            <div className="relative h-[270px] w-full bg-gray-300 mr-10">
              <Image src="/images/blog-img.jpg" alt="blog image" className='absolute w-full h-full object-cover' fill={true} />
            </div>
            <div className='w-11/12 mx-auto my-5 flex flex-col items-center text-left'>
              <h3 className='w-full text-left text-xl capitalize font-medium'>Design Liberalized Exchange Rate Management</h3>
            </div>
            <div className='flex w-full gap-2 justify-start items-center'>
              <div className='w-7 h-7 rounded-[14px] bg-primary'></div>
              <h3 className='font-semibold text-lg'>Fred Boone</h3>
              <div className='text-gray-500 '>|</div>
              <div className='text-gray-500'>Jan 20, 2023</div>
            </div>
              <div className='flex gap-2 items-align justify-start mt-4'>
              <div className='text-gray-700 bg-gray-300 rounded-full text-lg px-4 py-2'>UI/UX</div>
                <div className='text-gray-700 bg-gray-300 rounded-full text-xl px-4 py-2'>Development</div>
              </div>
              <div className='border-b-2 border-gray-300 w-full py-4'>
                <p className="text-gray-500">A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.</p>
              </div>
              <div className='flex flex-row justify-between items-center my-8'>
                <div className='text-700 font-semibold'>2.3K Likes</div>
                <div className='flex flex-row gap-2 cursor-pointer text-purple-500'>Read More</div>
              </div>
            </div>
            <div className='col-span-1 flex flex-col w-fit h-fit'>
            <div className="relative h-[270px] w-full bg-gray-300 mr-10">
              <Image src="/images/blog-img.jpg" alt="blog image" className='absolute w-full h-full object-cover' fill={true} />
            </div>
            <div className='w-11/12 mx-auto my-5 flex flex-col items-center text-left'>
              <h3 className='w-full text-left text-xl capitalize font-medium'>Design Liberalized Exchange Rate Management</h3>
            </div>
            <div className='flex w-full gap-2 justify-start items-center'>
              <div className='w-7 h-7 rounded-[14px] bg-primary'></div>
              <h3 className='font-semibold text-lg'>Fred Boone</h3>
              <div className='text-gray-500 '>|</div>
              <div className='text-gray-500'>Jan 20, 2023</div>
            </div>
              <div className='flex gap-2 items-align justify-start mt-4'>
              <div className='text-gray-700 bg-gray-300 rounded-full text-lg px-4 py-2'>UI/UX</div>
                <div className='text-gray-700 bg-gray-300 rounded-full text-xl px-4 py-2'>Development</div>
              </div>
              <div className='border-b-2 border-gray-300 w-full py-4'>
                <p className="text-gray-500">A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.</p>
              </div>
              <div className='flex flex-row justify-between items-center my-8'>
                <div className='text-700 font-semibold'>2.3K Likes</div>
                <div className='flex flex-row gap-2 cursor-pointer text-purple-500'>Read More</div>
              </div>
            </div>
          </div>

        </div>
      </div>
    
  )
}

export default BlogDetailPage