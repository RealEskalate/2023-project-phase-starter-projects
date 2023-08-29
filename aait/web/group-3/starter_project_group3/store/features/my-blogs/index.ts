import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Blog } from "@/types/blog/blog";
import { authTypes } from "@/types/auth/authTypes";

const baseUrl = "https://a2sv-backend.onrender.com/api/blogs";

export const myblogsApi = createApi({
  reducerPath: "myblogsPath",
  baseQuery: fetchBaseQuery({
    baseUrl: baseUrl,
    prepareHeaders: (headers, { getState }) => {
      const userString = localStorage.getItem("user");
      const user: authTypes | null = userString ? JSON.parse(userString) : null;
      const token = user?.token;

      if (token) {
        headers.set("Authorization", ` Bearer ${token}`);
        return headers;
      }
    },
  }),
  tagTypes: ["blogs"],
  endpoints: (builder) => ({
    getMyBlogs: builder.query<Blog[], void>({
      query: () => ({
        url: "/my-blogs",
        method: "GET",
      }),
    }),
  }),
});

export const { useGetMyBlogsQuery } = myblogsApi;
