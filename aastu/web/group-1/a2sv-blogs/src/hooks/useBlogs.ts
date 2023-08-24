import { useGetBlogsQuery } from "@/lib/redux/features/blog";

export default function useBlogs() {
  const { data: blogs, isLoading, error } = useGetBlogsQuery();
  return {
    getBlogs: () => ({
      blogs,
      isLoading,
      error,
    }),
  };
}
