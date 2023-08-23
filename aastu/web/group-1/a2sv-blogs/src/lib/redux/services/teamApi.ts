import { Member } from "@/types";
import baseApi from "./baseApi";

const teamApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getTeams: builder.query<Member[], void>({
      query: () => "/members",
    }),
  }),
});

export default teamApi;
