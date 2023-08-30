import User, { LoginInputData, RegisterInputData, RegisterResponseData } from "@/types/user/user";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { setMessage, setUser } from "../user/user-slice";

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
            invalidatesTags: ["auth"],
            async onQueryStarted(arg, { dispatch, queryFulfilled }) {
                await queryFulfilled
                dispatch(setMessage("Registered in Successfully!"))
            }
        }),
        login: builder.mutation<User, LoginInputData>({
            query(data) {
                return {
                    url: 'login',
                    method: 'POST',
                    body: data,
                };
            },
            invalidatesTags: ["auth"],
            async onQueryStarted(arg, { dispatch, queryFulfilled }) {
                const { data: user } = await queryFulfilled
                dispatch(setMessage("Logged in Successfully!"))
                dispatch(setUser(user))
            }
        })
    }),
})

export const { useLoginMutation, useRegisterMutation } = auhtApi;
