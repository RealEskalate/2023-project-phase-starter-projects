import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { BlogPostResponse } from "@/types/blog/blog";
import { authTypes } from "@/types/auth/authTypes";

const baseUrl = "https://a2sv-backend.onrender.com/api/auth";

export const createUpdateProfileAPI = createApi({
  reducerPath: "update-personal-info",
  baseQuery: fetchBaseQuery({
    baseUrl: baseUrl,
    prepareHeaders: (headers, { getState }) => {
      const userString = localStorage.getItem("user");
      const user: authTypes | null = userString ? JSON.parse(userString) : null;
      const token = user?.token;

      if (token) {
        headers.set("Authorization", `Bearer ${token}`);

        return headers;
      }
    },
  }),
  tagTypes: ["blog"],
  endpoints: (builder) => ({
    updateProfile: builder.mutation<any, FormData>({
      query: (newBlog) => ({
        url: "/edit-profile",
        method: "PATCH",
        body: newBlog,
      }),
      invalidatesTags: ["blog"],
    }),
  }),
});

export const { useUpdateProfileMutation } = createUpdateProfileAPI;
