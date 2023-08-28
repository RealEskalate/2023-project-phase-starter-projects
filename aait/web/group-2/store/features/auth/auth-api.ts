import User from '@/types/auth/user'
import UserCredential from '@/types/auth/userCredential'
import {createApi,fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const authApi = createApi({
    reducerPath: 'auth-api',
    baseQuery:fetchBaseQuery({baseUrl:'https://a2sv-backend.onrender.com/api/auth/'}),
    endpoints: (build)=>({
        registerUser:build.mutation({
            query:((user:User)=>({
                url:'register',
                method:'Post',
                body:user
            }))
        }),
        loginUser:build.mutation({
            query:((userCredential:UserCredential)=>({
                url:'login',
                method:'Post',
                body:userCredential
            }))
        })
    })
})

export const { useRegisterUserMutation,useLoginUserMutation } = authApi
export default authApi