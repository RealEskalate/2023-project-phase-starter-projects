import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/dist/query/react";
import { RootState } from "../store";
import { HYDRATE } from "next-redux-wrapper";

const baseApi = createApi({
  reducerPath: "baseApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://a2sv-backend.onrender.com/api/",
    prepareHeaders: (headers, { getState }) => {
      const token = (getState() as RootState).auth.token;
      if (token) {
        headers.set("Authorization", `Bearer ${token}`);
      }
      return headers;
    },
  }),
  extractRehydrationInfo(action, { reducerPath }) {
    if (action.type === HYDRATE) {
      return action.payload[reducerPath];
    }
  },
  endpoints: (builder) => ({}),
});

export default baseApi;
