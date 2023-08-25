import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Blog } from '@/types/blog/blog';


const baseUrl = 'https://a2sv-backend.onrender.com/api';

export const singleBlogApi = createApi({
    reducerPath: 'blogPath',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    tagTypes: ['blog'],
    endpoints: (builder) => ({
        getSingleBlog: builder.query<Blog, string>({
            query: (blogId) => `blogs/${blogId}`,
            providesTags: ['blog']
            
        }),
        
    })
});

export const {useGetSingleBlogQuery} = singleBlogApi
