import User, { LoginInputData, RegisterInputData, RegisterResponseData } from "@/types/user/user";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const BASE_URL = "https://a2sv-backend.onrender.com/api/auth/";

export const auhtApi = createApi({
    reducerPath: "auhtApi",
    baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
    tagTypes: ["auth"],
    endpoints: (builder) => ({

        register: builder.mutation<RegisterResponseData, RegisterInputData>({
            query(data) {
                return {
                    url: 'register',
                    method: 'POST',
                    body: data,
                };
            },
            invalidatesTags: ["auth"]
          
        }),
        login: builder.mutation<User, LoginInputData>({
            query(data) {
                return {
                    url: 'login',
                    method: 'POST',
                    body: data,
                };
            },
            invalidatesTags: ["auth"]
        })
    }),
})

export const { useLoginMutation, useRegisterMutation } = auhtApi;
