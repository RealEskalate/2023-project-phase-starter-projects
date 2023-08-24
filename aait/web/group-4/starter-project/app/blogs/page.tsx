import BlogCard from "@/components/blogs/BlogCard";

export default function Blogs(){
    let pages : number[] = [1, 2, 3, 4]

    return (
        <div className="w-full pt-10">
            <div className="w-full flex justify-center font-cards pb-10">
                <h2 className="self-start font-bold text-xl">Blogs</h2>
                <div className="flex justify-center items-center gap-4 w-5/6">
                    <input placeholder="Search..." className=" px-10 w-[210px] h-[30px] border-2 border-gray-400 rounded-[15px]" type="text" />
                    <button className="px-6 py-2 rounded-full border-none bg-blue-800 text-white">
                        + New Blog
                    </button>
                </div>
            </div>
            <div className="flex flex-col gap-5 w-full items-center">
                {
                    pages.map((num)=>{
                        return <BlogCard/>
                    })
                }
            </div>
            <div className="flex justify-center gap-6 my-20">
                {
                    pages.map((num)=>{
                        return <button className="rounded-lg border-none w-[40px] h-[40px] bg-blue-800 text-white">
                            {num}
                        </button>}
                    )
                }
            </div>
        </div>
    )
}