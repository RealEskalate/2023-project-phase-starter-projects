import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const singleSuccessApi = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://a2sv-backend.onrender.com/api",
  }),
  endpoints: (build) => ({
    getSuccessStories: build.query<any, void>({
      query: () => "/success-stories",
    }),
  }),
});

export const { useGetSuccessStoriesQuery } = singleSuccessApi;
