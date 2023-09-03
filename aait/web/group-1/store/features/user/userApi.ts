import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = 'https://a2sv-backend.onrender.com/api';

export const profileApi = createApi({
  reducerPath: 'profileApi',
  baseQuery: fetchBaseQuery({ 
    baseUrl: BASE_URL,
    prepareHeaders: (headers, { getState }) => {
      const userData = localStorage.getItem('user');
      const token = userData ? JSON.parse(userData)?.token : null;
      if(token) {
        headers.set('Authorization', `Bearer ${token}`);
      }
      return headers;
    }
  }),
  endpoints: (builder) => ({
    editProfile: builder.mutation({
      query: (newUserData) => ({
        url: '/auth/edit-profile',
        method: 'PATCH',
        body: newUserData,
      }),
    }),
    changePassword: builder.mutation({
      query: (newPasswordInfo) => ({
        url: '/auth/change-password',
        method: 'PATCH',
        body: newPasswordInfo,
      }),
    }),
  }),
});

export const { useEditProfileMutation, useChangePasswordMutation } = profileApi;
