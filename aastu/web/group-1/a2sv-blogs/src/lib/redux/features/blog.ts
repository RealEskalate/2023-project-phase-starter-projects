import blogApi from "../services/blogApi";

export const {
  useGetBlogsQuery,
  useGetBlogByIdQuery,
  useCreateBlogMutation,
  useUpdateBlogMutation,
  useDeleteBlogMutation,
  useGetMyBlogsQuery,
} = blogApi;
