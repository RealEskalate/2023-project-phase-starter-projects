
interface BlogTagsProps {
    tag: string,
}

const BlogTags: React.FC<BlogTagsProps> = ({tag}) => {

    return (
        <div className='bg-gray-200 rounded-full  mr-2 my-5'>
            <h5 className='text-2xl py-5 px-7 text-gray-500 font-semibold'>{tag}</h5>
        </div>
    )
}

export default BlogTags