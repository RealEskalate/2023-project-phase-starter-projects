import User, { EditPasswordData, EditProfileData, EditProfileResponse, LoginInputData } from "@/types/user/user";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { setMessage, setUser } from "./user-slice";
import { RootState } from "@/store";

const BASE_URL = "https://a2sv-backend.onrender.com/api/auth/";

export const userApi = createApi({
    reducerPath: "userApi",

    baseQuery: fetchBaseQuery({ baseUrl: BASE_URL,
    prepareHeaders: (headers, {getState}) => {
        const state = getState() as RootState;
        headers.set("Authorization", `Bearer ${state.user.user.token}`)
        return headers
    } }),
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
            async onQueryStarted(arg, { dispatch, getState, queryFulfilled }) {
                const { data: { body, message } } = await queryFulfilled;
                const state = getState() as RootState;

                dispatch(setMessage(message));

                dispatch(setUser({
                    token: state.user.user.token,
                    user: body._id,
                    userEmail: body.email,
                    userName: body.name,
                    userProfile: body.image,
                    userRole: body.role
                }));
            }
        }),
        editPassword: builder.mutation<{message: string}, EditPasswordData>({
            query(data) {
                return {
                    url: 'change-password',
                    method: 'PATCH',
                    body: data,
                };
            },
            invalidatesTags: ["user"],
            async onQueryStarted(arg, { dispatch, getState, queryFulfilled }) {
                const { data: { message } } = await queryFulfilled;

                dispatch(setMessage(message));
            }

        })
    }),
})

export const { useEditPasswordMutation, useEditProfileMutation } = userApi;
