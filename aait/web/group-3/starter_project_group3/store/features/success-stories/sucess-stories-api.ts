import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { SuccessStory } from '@/types/success-story/sucess_story';

const baseUrl = 'https://a2sv-backend.onrender.com/api';

export const storiesApi = createApi({
    reducerPath: 'storiesPath',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    tagTypes: ['stories'],
    endpoints: (builder) => ({
        getStories: builder.query<SuccessStory[], void>({
            query: () => '/success-stories',
            providesTags: ['stories']
        }),

    })
});

export const {useGetStoriesQuery} = storiesApi;
