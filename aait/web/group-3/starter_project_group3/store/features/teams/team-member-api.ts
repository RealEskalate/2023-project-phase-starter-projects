import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { TeamMember } from '@/types/team/team';
const baseUrl = 'https://a2sv-backend.onrender.com/api';

export const teamsApi = createApi({
    reducerPath: 'teamsPath',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    tagTypes: ['teams'],
    endpoints: (builder) => ({
        getTeams: builder.query<TeamMember[], void>({
            query: () => '/members',
            providesTags: ['teams']
        }),

    })
});

export const {useGetTeamsQuery} = teamsApi;