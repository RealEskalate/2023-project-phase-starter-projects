"use client";
import Image from "next/image";
import { useGetBlogByIdQuery } from "@/lib/redux/features/blog";

const Blog = ({ params }: { params: { id: string } }) => {
  // Sample blog object, fetched from the backend
  const blogId = params.id;

  const { data: blogData, isLoading, error } = useGetBlogByIdQuery(blogId);

  if (isLoading) {
    return (
      <div className="flex justify-center items-center h-[400px]">
        <div className="animate-spin rounded-full border-t-4 border-blue-500 border-opacity-75 h-12 w-12"></div>
      </div>
    );
  }

  if (error) {
    return <div>Error fetching data</div>;
  }

  if (!blogData) {
    return <div>No blog data available.</div>;
  }

  return (
    <div className="md:p-20 p-5 flex flex-col items-center gap-10">
      <div className="flex flex-col items-center gap-4 mt-24">
        <h1 className="text-3xl font-french md:max-md:max-lg:text-xl">
          {blogData.title}
        </h1>
        <p className="font-montserrat uppercase text-xs text-center">
          {blogData.tags.map((tag: any, index: any) =>
            index != blogData.tags.length - 1 ? `${tag}, ` : tag
          )}
        </p>
      </div>
      {blogData.image && (
        <Image
          src={blogData.image}
          alt="blog image"
          width={1000}
          height={450}
        />
      )}{" "}
      <div className="flex flex-col items-center gap-2">
        {blogData.author && (
          <Image
            src={blogData.author.image}
            alt="author image"
            width={50}
            height={50}
            className="rounded-full"
          />
        )}
        <p className="font-montserrat uppercase text-xs">
          {blogData.author && blogData.author.name}
        </p>
      </div>
      <div className="md:px-32 flex flex-col gap-8 text-justify py-4">
        {blogData.description.split("\n").map((paragraph: any, index: any) => (
          <p
            key={index}
            className="font-montserrat text-sm text-left"
            dangerouslySetInnerHTML={{ __html: paragraph }}
          ></p>
        ))}
      </div>
      <div className="text-left w-full flex flex-col gap-12">
        <h1 className="font-montserrat text-xl font-bold">Related Blogs</h1>
        <div className="flex gap-4 flex-wrap">
          {blogData.relatedBlogs.length > 0 &&
            blogData.relatedBlogs.map((blog: any, index: any) => (
              <div key={index} className="flex flex-col items-center gap-4">
                {blog.image && (
                  <Image
                    src={blog.image}
                    alt="blog image"
                    width={300}
                    height={200}
                  />
                )}
                <p className="font-montserrat text-sm">{blog.title}</p>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Blog;
