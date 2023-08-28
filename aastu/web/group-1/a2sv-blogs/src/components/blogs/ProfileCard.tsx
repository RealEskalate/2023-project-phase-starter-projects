import { Blog } from "@/types";
import Image from "next/image";
import Link from "next/link";

export default function ProfileBlogCard({ blog }: { blog: Blog }) {
  return (
    <div className="md:my-0 my-3 shadow rounded">
      <div>
        <Image
          src={blog.image}
          alt={blog.title}
          width={300}
          height={200}
          className="w-full h-52 object-cover"
        />
      </div>
      <div className="p-3">
        <h2 className="text-neutral-700">{blog.title}</h2>
        <div className="flex items-center mt-3">
          <Image
            src={blog.author?.image!}
            alt={blog.author?.name!}
            width={34}
            height={34}
            className="rounded-full"
          />
          <p className="ml-2 space-x-1">
            <span className="text-neutral-500">by</span>
            <span className="font-semibold text-sm">{blog.author?.name}</span>
          </p>
          <span className="w-px h-4 bg-slate-500 mx-2"></span>
          <p className="text-neutral-500 text-sm">
            {new Date(blog.createdAt)
              .toDateString()
              .trimStart()
              .split(" ")
              .filter((text, index) => index > 0)
              .join(" ")}
          </p>
        </div>
        <div className="text-neutral-500 flex flex-wrap mt-3">
          {blog.tags &&
            blog.tags.map((tag) => (
              <span className="bg-neutral-100 px-2 py-1 rounded-2xl text-sm text-neutral-500 m-1">
                {tag}
              </span>
            ))}
        </div>
        <p className="text-neutral-600 text-sm break-words mt-3">
          A little personality goes a long way, especially on a business blog.
          So don’t be afraid to let loose.
        </p>
        <hr className="my-3" />
        <div>
          <div className="flex justify-between items-end font-semibold h-5">
            {blog.isPending && <span className="text-orange-500">Pending</span>}
            <Link href={`/blogs/${blog._id}`} className="text-primary">
              Read More
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
}
