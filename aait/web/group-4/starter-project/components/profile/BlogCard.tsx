import parse from "html-react-parser";
import Blog from "@/types/blog/blog";
import { MdAccessTimeFilled } from "react-icons/md";
import Image from "next/image";
import { useRouter } from "next/navigation";
import {LuMessageSquare} from "react-icons/lu";

const BlogCard = ({ myBlog }: { myBlog: Blog }) => {
  const router = useRouter();
  return (
    <div className="flex flex-col max-w-xs shrink rounded-lg text-[#5E5873] shadow-lg shadow-gray-200 h-full font-{montserrat} overflow-clip md:max-w-sm">
      {/* blog image */}
      <div className="h-1/2">
        <Image
          className="object-cover rounded-t-lg h-full"
          src={`${myBlog.image}`}
          alt="Blog image"
          width={800}
          height={800}
        />
      </div>

      <div className="flex flex-col gap-8 p-8">
        <h3 className="text-lg font-medium md:text-xl">{myBlog.title}</h3>
        {/* by */}
        <div className="flex gap-2 justify-start text-sm">
          <img
            className="object-cover w-8 h-8 rounded-full"
            src={myBlog.author.image}
            alt=""
          />
          <p className="divide-x space-x-2 text-gray-300">
            by{" "}
            <span className="font-semibold text-gray-500">
              {myBlog.author.name}
            </span>{" "}
            <span className="text-gray-300 px-2">{myBlog.createdAt}</span>
          </p>
        </div>
        {/* tags */}
        <div className="flex gap-4">
          {myBlog.tags.map((tag) => (
            <button className="bg-gray-200 rounded-full px-4 py-2 text-xs font-semibold">
              {tag}
            </button>
          ))}
        </div>
        {/* blog body */}
        <div className="border-b pb-6">
          <p className="truncate">{parse(myBlog.description)}</p>
        </div>

        <div className="flex justify-between">
          <p className="flex items-center gap-2 text-orange-400">
            {myBlog.isPending ? (
              <>
                <MdAccessTimeFilled className="w-5 h-5" />
                <span className="font-semibold">Pending</span>
              </>
            ) : (
              <>
                <LuMessageSquare />
                <p>{`${myBlog.likes} Likes`}</p>
              </>
            )}
          </p>
          <button
            onClick={() => router.push(`/blogs/${myBlog._id}`)}
            className="text-indigo-500 font-semibold text-base"
          >
            Read More
          </button>
        </div>
      </div>
    </div>
  );
};

export default BlogCard;
