import Link from "next/link";
import BlogCard from "./BlogCard";
import { data } from "@/data/manage-section-data.json";

const Blogs = () => {
  let n = [1, 2, 3, 5, 6, 7, 8];

  return (
    <>
      {/* manage section */}
      <div className="flex flex-col items-center md:items-stretch space-y-4 py-8 border-b md:py-12 md:space-y-2">
        <div className="flex justify-between">
          <h2 className=" text-slate-gray text-lg font-semibold md:text-2xl">
            Manage {data[1].manageText}
          </h2>
          <button className=" hidden px-10 py-2 text-white mb-1 rounded-lg bg-primary-color md:block">
              New blog
            </button>
        </div>
        <p className="text-medium-gray text-sm md:text-xl">
          {data[1].manageDetail}
        </p>
          <Link href="/add-blog" className="px-10 py-2 text-white mb-1 w-fit rounded-lg bg-primary-color md:hidden">
              New blog
            </Link>
      </div>
      <div className="py-8 gap-12 flex flex-col items-center md:grid md:grid-cols-2 xl:grid-cols-4">
        {n.map((_) => (
          <BlogCard />
        ))}
      </div>
    </>
  );
};

export default Blogs;
