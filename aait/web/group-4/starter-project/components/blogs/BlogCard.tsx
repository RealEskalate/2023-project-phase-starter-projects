export default function BlogCard(){
    return (
        <div className="font-cards text-black w-4/5 border-t-[2px] py-4 border-gray-300">
            <div className="flex items-start gap-4">
                <img className="w-[50px] rounded-full" src="/images/blog_profile.png"/>
                <div>
                    <span className="text-[16px] font-bold">Leul Abay</span> &#x2022; <span className="text-gray-600">Apr 16, 2022</span>
                    <p className="font-bold text-gray-500">SOFTWARE ENGINEER</p>
                </div>
            </div>
            <div className="grid grid-cols-2 w-full px-4 place-items-center">
                <div className="">
                    <h2>
                        The essential guide to Competitive Programming
                        Tab System On React : 3 ways to do it.
                    </h2>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
                    </p>
                </div>
                <img className="w-3/4 self-center rounded-lg" src="/images/blog_picture.png"/>
            </div>
            <div>
                <button className="px-6 py-2 rounded-full border-none bg-gray-200 text-gray-400">
                    UX
                </button>
                <button className="px-6 py-2 rounded-full border-none bg-gray-200 text-gray-400">
                    Development
                </button>
            </div>
        </div>
    )
}