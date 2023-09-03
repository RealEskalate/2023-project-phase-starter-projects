import baseApi from "./baseApi";
import { Blog } from "@/types";

const blogApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getBlogs: builder.query<Blog[], void>({
      query: () => "/blogs",
      // sort blogs by createdAt
      transformResponse: (response: Blog[]) =>
        response.sort(
          (a, b) =>
            new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
        ),
    }),
    getBlogById: builder.query({
      query: (id: string) => `/blogs/${id}`,
    }),
    createBlog: builder.mutation<Blog, FormData>({
      query: (body) => ({
        url: "/blogs",
        method: "POST",
        body,
      }),
    }),
    updateBlog: builder.mutation({
      query: ({ id, body }) => ({
        url: `/blogs/${id}`,
        method: "PUT",
        body,
      }),
    }),
    deleteBlog: builder.mutation({
      query: (id) => ({
        url: `/blogs/${id}`,
        method: "DELETE",
      }),
    }),
    getMyBlogs: builder.query<Blog[], void>({
      query: () => "/blogs/my-blogs",
    }),
  }),
  overrideExisting: false,
});

export default blogApi;
