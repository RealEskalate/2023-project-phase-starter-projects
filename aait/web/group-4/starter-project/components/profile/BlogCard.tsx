import {MdAccessTimeFilled} from "react-icons/md"

const BlogCard = () => {
    return (
        <div className="flex flex-col max-w-xs shrink rounded-lg text-[#5E5873] shadow-lg shadow-gray-200 font-{montserrat} overflow-clip md:max-w-sm">
            {/* blog image */}
            <div className="h-1/2">
                <img
                    className="object-cover rounded-t-lg"
                    src="https://images.unsplash.com/photo-1542831371-29b0f74f9713?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80"
                    alt="" />
            </div>

            
            <div className="flex flex-col gap-8 p-8">
                <h3 className="text-lg font-medium md:text-xl">Design Liberalized Exchange Rate Management</h3>
                {/* by */}
                <div className="flex gap-2 justify-start text-sm">
                    <img
                        className="object-cover w-8 h-8 rounded-full"
                        src="https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60"
                        alt="" />
                    <p className="divide-x space-x-2 text-gray-300">
                        by <span className="font-semibold text-gray-500">Fred Boone</span>{" "}
                        <span className="text-gray-300 px-2">Jan 10, 2020</span>
                    </p>
                </div>
                {/* tags */}
                <div className="flex gap-4">
                    <button className="bg-gray-200 rounded-full px-4 py-2 text-xs font-semibold">UI/UX</button>
                    <button className="bg-gray-200 rounded-full px-4 py-2 text-xs font-semibold">DEVELOPMENT</button>
                </div>
                {/* blog body */}
                <div className="border-b pb-6">
                    <p className="truncate">A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.</p>
                </div>

                <div className="flex justify-between">
                    <p className="flex items-center gap-2 text-orange-400">
                        <MdAccessTimeFilled className="w-5 h-5" />
                        <span className="font-semibold">Pending</span>
                    </p>
                    <button className="text-indigo-500 font-semibold text-base">Read More</button>
                </div>
            </div>
        </div>
    );
};

export default BlogCard;
