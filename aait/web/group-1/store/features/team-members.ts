import { Profile } from "@/types/Profile";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const teamMembersApi = createApi({
  reducerPath: "members",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://a2sv-backend.onrender.com/api",
  }),
  endpoints: (build) => ({
    getTeamMembers: build.query<Profile[], void>({
      query: () => "/members",
    }),
  }),
});

export const { useGetTeamMembersQuery } = teamMembersApi;
