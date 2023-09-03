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
        <div className='flex w-full h-fit justify-between items-center mt-7'>
            <div className='flex flex-col w-8/12 mr-25'>
                <h3 className='text-4xl font-bold'>{title}</h3>
                <p className='text-2xl text-gray-700 leading-10 mt-6 text-elipses'>{description}</p>
            </div>
            <div className='relative w-[450px] h-[300px] rounded-2xl'>
                <Image src={blogImg} alt='blog image' className=' absolute rounded-2xl w-full ' objectFit='contain' fill={true} />
            </div>
        </div>
    )
}

export default BlogPreview