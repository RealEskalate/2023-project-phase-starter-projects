import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Blog } from '@/types/blog/blog';


const baseUrl = 'https://a2sv-backend.onrender.com/api';

export const blogsApi = createApi({
    reducerPath: 'blogsPath',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    tagTypes: ['blogs'],
    endpoints: (builder) => ({
        getBlogs: builder.query<Blog[], void>({
            query: () => '/blogs',
            providesTags: ['blogs']
        }),

    })
});

export const {useGetBlogsQuery} = blogsApi
