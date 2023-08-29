import Link from "next/link";
import Image from "next/image"

import data from "@/data/relatedBlog.json"
export default function BlogCardSmall(){



    return (
        <div className="flex flex-col rounded-t-md shadow-md font-nav">
            <Image className="w-full h-[250px] object-cover rounded-md" width={250} height={250} src={data.image} alt={"blog image"}/>
            <div className="flex flex-col p-6 gap-4">
                <h2 className="text-[1.2rem] font-medium ">
                    {data.title}
                </h2>
                <div className="flex justify-start gap-2 items-center">
                    <Image className=" rounded-full w-[30px] h-[30px]" width={30} height={30} src={data.author.image} alt={"author's image"} />
                    <span className="flex gap-2 justify-between font-nav text-gray-400 items-center align-text-bottom">
                        <p className="text-[0.9rem]">by</p>
                        <p className="text-black text-[1rem] font-bold">{ data.author.name }</p>
                        <p> | </p>
                        <p>{ data.author.role }</p>
                    </span>
                </div>
                <div className="flex gap-2">
                    {
                        data.tags.map((tag)=>{
                                return (
                                    <button className="px-6 py-2 rounded-full border-none bg-gray-200 text-gray-400">
                                        {
                                            tag
                                        }
                                    </button>
                                )
                            }
                        )
                    }
                </div>

                <div className="border-b-2 pb-4 border-gray-400">
                    <p className="text-gray-500">
                        {
                            data.description
                        }
                    </p>
                </div>
                <div className="flex justify-between">
                    <span className="flex gap-2 font-bold text-gray-500">
                        <img src={"/images/Mask.png"} />
                        <p>
                            {
                                `${data.likes} Likes`
                            }
                        </p>
                    </span>
                    <Link className="text-blue-600 font-bold font-nav" href={"/blogs/" + data._id}> Read More</Link>
                </div>

            </div>
        </div>
    )
}