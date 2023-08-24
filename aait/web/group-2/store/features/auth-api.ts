import User from '@/types/auth/user'
import {createApi,fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const authApi = createApi({
    reducerPath: 'api',
    baseQuery:fetchBaseQuery({baseUrl:'https://a2sv-backend.onrender.com/api/auth/'}),
    endpoints: (build)=>({
        registerUser:build.mutation({
            query:((user:User)=>({
                url:'register',
                method:'Post',
                body:user
            }))
        })
    })
})

export const { useRegisterUserMutation } = authApi
export default authApi