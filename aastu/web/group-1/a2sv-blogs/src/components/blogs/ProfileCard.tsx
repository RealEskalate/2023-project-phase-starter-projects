import { Blog } from "@/types";
import Image from "next/image";

export default function ProfileBlogCard({ blog }: { blog: Blog }) {
  return (
    <div className="shadow rounded">
      <div>
        <Image
          src={blog.image}
          alt={blog.title}
          width={300}
          height={200}
          className="w-full"
        />
      </div>
      <div className="p-3">
        <h2 className="text-neutral-700">
          Design Liberalized Exchange Rate Management
        </h2>
        <div className="flex items-center mt-3">
          {/* <img src="/avatar.svg" alt="" /> */}
          <p className="ml-2 space-x-1">
            <span className="text-neutral-500">by</span>
            <span className="font-semibold text-sm">Fred Boone</span>
          </p>
          <span className="w-px h-4 bg-slate-500 mx-2"></span>
          <p className="text-neutral-500 text-sm">Jan 10, 2020</p>
        </div>
        <div className="text-neutral-500 grid-cols-3 space-x-2 mt-3">
          <span className="bg-neutral-100 px-6 py-1 rounded-2xl text-sm text-neutral-500">
            UI/UX
          </span>

          <span className="bg-neutral-100 px-6 py-1 rounded-2xl text-sm text-neutral-500">
            DEVELOPMENT
          </span>
        </div>
        <p className="text-neutral-600 text-sm break-words mt-3">
          A little personality goes a long way, especially on a business blog.
          So don’t be afraid to let loose.
        </p>
        <hr className="my-3" />
        <div>
          <div className="flex justify-between font-semibold">
            <span className="text-orange-500">Pending</span>
            <span className="text-primary">Read More</span>
          </div>
        </div>
      </div>
    </div>
  );
}
