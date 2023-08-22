import baseApi from "./baseApi";

const teamApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getTeams: builder.query({
      query: () => "/teams",
    }),
  }),
});

export default teamApi;
