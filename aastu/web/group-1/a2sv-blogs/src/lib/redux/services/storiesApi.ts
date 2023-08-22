import baseApi from "./baseApi";

const storiesApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getStories: builder.query({
      query: () => "/stories",
    }),
  }),
});

export default storiesApi;
