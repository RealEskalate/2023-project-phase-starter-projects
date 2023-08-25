import { useCreateBlogMutation } from "@/lib/redux/features/blog";
import { Blog } from "@/types";

export default function useBlogCreate() {
  const [createBlog, { isLoading, error, isSuccess }] = useCreateBlogMutation();
  return {
    createBlog: async (blogData: FormData) => {
      const blog = await createBlog(blogData);
      return { blog, isLoading, error };
    },
    isLoading,
    error,
    isSuccess,
  };
}
