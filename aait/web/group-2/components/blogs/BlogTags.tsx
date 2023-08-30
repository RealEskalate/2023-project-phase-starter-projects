
interface BlogTagsProps {
    tag: string,
}

const BlogTags: React.FC<BlogTagsProps> = ({tag}) => {

    return (
        <div className='bg-gray-200 rounded-md px-2 py-1 mr-2 mt-2'>
            <h5 className='text-sm'>{tag}</h5>
        </div>
    )
}

export default BlogTags