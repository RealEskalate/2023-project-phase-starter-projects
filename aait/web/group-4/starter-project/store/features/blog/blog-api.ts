import { createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";
import Member from "@/types/team/Member";
import Blog from "@/types/blog/blog";
import { RootState } from "@/store";

export const blogsApi = createApi({
    reducerPath: "blogsApi",
    baseQuery: fetchBaseQuery({baseUrl: "https://a2sv-backend.onrender.com/api",
    prepareHeaders: (headers, { getState }) => {
        const token = (getState() as RootState).user.user?.token;
        if (token) {
          headers.set("Authorization", `Bearer ${token}`);
        }
        return headers;
      }
}),
    tagTypes: ["blog"],
    endpoints: (builder)=>({
        getBlogs: builder.query<Blog[], void>({
            query: () => "blogs",
        }),
        getMembers: builder.query<Member[], void>({
            query: ()=>"members"
        })
        ,
        addBlog: builder.mutation<Blog, FormData>({
            query: (blog) => ({
              url: '/blogs',
              method: 'POST',
              body: blog,
            }),
            invalidatesTags:['blog']
          }),

          getMyBlogs: builder.query<Blog[], void>({
            query: () => "/blogs/my-blogs",
        }),
    }),
})

export const { useGetBlogsQuery, useGetMembersQuery, useAddBlogMutation, useGetMyBlogsQuery} = blogsApi;
