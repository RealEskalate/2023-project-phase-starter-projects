import User, { EditProfileData, EditProfileResponse, LoginInputData } from "@/types/user/user";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const BASE_URL = "https://a2sv-backend.onrender.com/api/auth/";

export const userApi = createApi({
    reducerPath: "userApi",
    baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
    tagTypes: ["user"],
    endpoints: (builder) => ({

        editProfile: builder.mutation<EditProfileResponse, EditProfileData>({
            query(data) {
                return {
                    url: 'edit-profile',
                    method: 'PATCH',
                    body: data,
                };
            },
            invalidatesTags: ["user"],
            async onQueryStarted(arg, { dispatch, queryFulfilled }) {
                const { data: user } = await queryFulfilled
                // dispatch()
            }
        }),
        editPassword: builder.mutation<User, LoginInputData>({
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
