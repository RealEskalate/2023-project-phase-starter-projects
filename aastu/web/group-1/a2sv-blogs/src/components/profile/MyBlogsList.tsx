import Link from "next/link";
import ProfileBlogCard from "../blogs/ProfileCard";
import { useGetMyBlogsQuery } from "@/lib/redux/features/blog";

export default function MyBlogsList() {
  const { data: blogs, isLoading, error } = useGetMyBlogsQuery();
  if (isLoading) {
    return (
      <div className="flex justify-center items-center h-[400px]">
        <div className="animate-spin rounded-full border-t-4 border-blue-500 border-opacity-75 h-12 w-12"></div>
      </div>
    );
  }
  if (error || blogs?.length === 0)
    return (
      <div className="w-full flex flex-col items-center justify-center space-y-3 border-b py-10">
        <h2 className="text-text-header-2">No Blogs found.</h2>
        <p className="text-text-content">Get started by creating blogs</p>
        <Link
          href="/blogs/create"
          className="bg-primary px-4 py-1 text-white rounded"
        >
          Create Blog
        </Link>
      </div>
    );
  return (
    <div className="grid lg:grid-cols-4 md:grid-cols-3 sm:grid-cols-2 grid-cols-1 sm:gap-6 mt-3">
      {blogs && blogs.map((blog) => <ProfileBlogCard blog={blog} />)}
    </div>
  );
}
