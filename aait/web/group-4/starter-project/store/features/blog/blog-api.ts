import { createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";
import BlogData from "@/types/blog/blog";
import Member from "@/types/team/Member";

export const blogsApi = createApi({
    reducerPath: "blogsApi",
    baseQuery: fetchBaseQuery({baseUrl: "https://a2sv-backend.onrender.com/api"}),
    tagTypes: ["blog"],
    endpoints: (builder)=>({
        getBlogs: builder.query<BlogData[], void>({
            query: () => "blogs",
        }),
        getMembers: builder.query<Member[], void>({
            query: ()=>"members"
        })
    }),
})

export const { useGetBlogsQuery, useGetMembersQuery} = blogsApi;
