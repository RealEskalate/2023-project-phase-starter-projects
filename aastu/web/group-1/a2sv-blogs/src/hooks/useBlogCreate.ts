import { useCreateBlogMutation } from "@/lib/redux/features/blog";
import { Blog } from "@/types";

export default function useBlogs() {
  const [createBlog, { isLoading, error }] = useCreateBlogMutation();
  return {
    createBlog: async (blogData: Blog) => {
      const blog = await createBlog(blogData);
      return { blog, isLoading, error };
    },
  };
}
