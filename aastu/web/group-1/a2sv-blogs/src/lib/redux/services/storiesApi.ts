import { SuccessStory } from "@/types";
import baseApi from "./baseApi";

const storiesApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getStories: builder.query<SuccessStory[], void>({
      query: () => "/success-stories",
    }),
  }),
});

export default storiesApi;
