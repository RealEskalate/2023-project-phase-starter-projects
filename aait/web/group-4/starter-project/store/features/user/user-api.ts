import User, { EditPasswordData, EditProfileResponse } from "@/types/user/user";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { RootState } from "@/store";

const BASE_URL = "https://a2sv-backend.onrender.com/api/auth/";

export const userApi = createApi({
    reducerPath: "userApi",

    baseQuery: fetchBaseQuery({ baseUrl: BASE_URL,
    prepareHeaders: (headers, {getState}) => {
        const state = getState() as RootState;
        headers.set("Authorization", `Bearer ${state.user.user?.token}`)
        return headers
    } }),
    tagTypes: ["user"],
    endpoints: (builder) => ({

        editProfile: builder.mutation<EditProfileResponse, FormData>({
            query(data) {
                return {
                    url: 'edit-profile',
                    method: 'PATCH',
                    body: data,
                };
            },
            invalidatesTags: ["user"]
        }),
        editPassword: builder.mutation<{message: string}, EditPasswordData>({
            query(data) {
                return {
                    url: 'change-password',
                    method: 'PATCH',
                    body: data,
                };
            },
            invalidatesTags: ["user"]
        })
    }),
})

export const { useEditPasswordMutation, useEditProfileMutation } = userApi;
