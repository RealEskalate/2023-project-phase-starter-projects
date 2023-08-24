import {
  useCreateBlogMutation,
  useGetBlogByIdQuery,
  useGetBlogsQuery,
} from "@/lib/redux/features/blog";
import { Blog } from "@/types";

export default function useBlogs() {
  return {
    getBlogs: () => {
      const { data: blogs, isLoading, error } = useGetBlogsQuery();
      return { blogs, isLoading, error };
    },
    getBlogById: (id: string) => {
      const { data: blog, isLoading, error } = useGetBlogByIdQuery(id);
      return { blog, isLoading, error };
    },
    createBlog: async (blogData: Blog) => {
      const [createBlog, { isLoading, error }] = useCreateBlogMutation();
      const blog = await createBlog(blogData);
      return { blog, isLoading, error };
    },
  };
}
