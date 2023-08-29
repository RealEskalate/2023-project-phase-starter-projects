import { createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

import BlogData from "@/types/blogs/BlogData";
import Member from "@/types/teams/Member";

export const api = createApi({
    reducerPath: "blogapi",
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

export const { useGetBlogsQuery, useGetMembersQuery} = api;
