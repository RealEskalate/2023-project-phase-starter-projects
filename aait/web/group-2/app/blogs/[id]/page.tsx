import { Blog } from "@/types/blog"
import Image from "next/image"

export const getBlogDetail = async (blogId: string) => {
  const res = await fetch(`https://a2sv-backend.onrender.com/api/blogs/${blogId}`)
  console.log('response', res)
  const blog: Blog = await res.json()

  return blog
}



const BlogDetail: React.FC = async ({
  params: { id },
}: {
  params: { id: string }
}) => {

  const blogDetail: Blog = await getBlogDetail(id)

  console.log('blog details', blogDetail)

  return (
    <div className='flex flex-col w-4/5 mx-auto my-20'>
      {/*  Title section */}
      <div className='flex flex-col justify-center items-center'>
        <h2 className="leading-9 text-4xl py-5">The essential guide to Competitive Programming</h2>
        <div className='flex flex-row justify-center items-center uppercase text-lg gap-4'>
          <h4 className="text-gray-400 ">Programming, Tech </h4>
          <h4 className="text-gray-400 mx-2">|</h4>
          <h4 className="text-gray-400"> 5 min read</h4>
        </div>
      </div>
      {/* Image section */}
      <div className='relative w-full h-[600px] flex flex-col justify-center items-center bg-gray-300 my-16'>
        {/* <Image src={blogDetail.image} alt="blog image" className='absolute w-full h-96 object-cover' objectFit="contain" layout='fill'/> */}
      </div>
      {/*Author section */}
      <div className='flex flex-col justify-center items-center'>
        <div className="w-20 h-20 rounded-[40px] bg-primary">
          <Image src={blogDetail.author} alt="author image" className='w-full h-full object-cover rounded-[40px]' />
        </div>
        <div className='flex flex-row justify-center items-center mt-6 gap-4'>
          <h4 className="text-gray-400">Chaltu Kebede</h4>
          <h4 className="text-gray-400"> | </h4>
          <h4 className="text-gray-400">Software Engineer</h4>
        </div>
        <h4 className="text-blue-300">@Chaltu_Kebede</h4>
      </div>
      {/* Body section */}
      <div className='w-ful flex flex-row justify-end'>
        <div className="w-11/12 flex flex-col  mt-10 ">
          <div className="w-full flex flex-col items-center">
            <div className='mr-0'>
              <p className="text-justify pt-6">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam
                voluptatum, quibusdam, voluptate, quia quod voluptas quos
                exercitationem voluptatibus quas quibusdam, voluptate, quia quod
                voluptas quos exercitationem voluptatibus quas
              </p>
              <p className="text-justify pt-6">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam
                voluptatum, quibusdam, voluptate, quia quod voluptas quos
                exercitationem voluptatibus quas quibusdam, voluptate, quia quod
                voluptas quos exercitationem voluptatibus quas
              </p>
              <p className="text-justify pt-6">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam
                voluptatum, quibusdam, voluptate, quia quod voluptas quos
                exercitationem voluptatibus quas quibusdam, voluptate, quia quod
                voluptas quos exercitationem voluptatibus quas
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
        <div className="flex flex-row justify-center items-center">
          <div className='flex fle-col w-[400px] h-[600px]'>
            <div className="h-[270px] w-full bg-gray-300 mr-10">
              <Image src={blogDetail.image} alt="blog image" className='w-full h-full object-cover' />
            </div>
            <div className='w-11/12 mx-auto my-5 flex flex-col items-center'>
                <h3 className='text-xl capitalize font-medium'>Design Liberalized Exchange Rate Management</h3>
            </div>
          </div>


        </div>
      </div>
    </div>
  )
}

export default BlogDetail