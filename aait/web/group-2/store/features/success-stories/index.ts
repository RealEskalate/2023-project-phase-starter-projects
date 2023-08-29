import { SuccessStory } from "@/types/successStories"
import { createApi,fetchBaseQuery } from "@reduxjs/toolkit/query/react"

export const successApi = createApi({
    reducerPath: 'success-api',
    baseQuery: fetchBaseQuery({baseUrl:'https://a2sv-backend.onrender.com/api'}),
    endpoints:(build)=>({
        getSuccessStories: build.query<SuccessStory [],void>({
            query: ()=>'/success-stories'
        })
    })
})

export const { useGetSuccessStoriesQuery } = successApi