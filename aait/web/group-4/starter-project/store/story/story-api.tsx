import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Story } from '@/types/Story/story-type';

export const storiesApi = createApi({
  reducerPath: 'storiesApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://a2sv-backend.onrender.com/api/' }),
  endpoints: (builder) => ({
    getAllStories: builder.query<Story[], void>({
      query: () => 'success-stories',
    }),
  }),
});


export const {useGetAllStoriesQuery} = storiesApi