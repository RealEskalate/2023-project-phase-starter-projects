

const SearchArea: React.FC = () => {
    return (
        <div className='w-full flex relative'>
            <div className='flex items-center'>
                <h2 className='ml-5 text-3xl font-semibod'>Blogs</h2>
            </div>
            <div className='absolute mx-auto flex justify-center w-full'>
                <input name='' className='w-96 h-16 rounded-[32px] border-2 border-gray-300 outline-none pl-10 text-xl text-gray-400' placeholder='Search...' />
                <button className='w-48 h-16 rounded-[32px] bg-primary text-white ml-2 text-center font-semibold text-xl'>+ New Blog</button>
            </div>

        </div>
    )
}

export default SearchArea