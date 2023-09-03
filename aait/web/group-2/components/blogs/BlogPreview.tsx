import Image from'next/image'

interface BlogPreviewProps {
    title: string;
    description: string;
    blogImg: string;
}

const BlogPreview: React.FC<BlogPreviewProps> = ({
    title,
    description,
    blogImg,
}) => {
    return (
        <div className='flex justify-between mt-11'>
            <div className='flex flex-col w-9/12'>
                <h3 className='text-4xl font-bold'>{title}</h3>
                <p className='text-2xl text-gray-700 leading-10 mt-6'>{description}</p>
            </div>
            <div className='relative w-[450px] h-[300px]'>
                <Image src={blogImg} alt='blog image' className=' absolute rounded-md w-full ' objectFit='contain' layout='fill' />
            </div>
        </div>
    )
}

export default BlogPreview 