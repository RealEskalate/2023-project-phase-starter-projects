import { configureStore } from "@reduxjs/toolkit";
import { storiesApi } from "./features/story/story-api";
import { blogsApi } from "./features/blog/blog-api";

export const store = configureStore({
  reducer: {
    [storiesApi.reducerPath]: storiesApi.reducer,
    [blogsApi.reducerPath]: blogsApi.reducer
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(
      storiesApi.middleware,
    ).concat(blogsApi.middleware)


});

export type AppDispatch = typeof store.dispatch

export type RootState = ReturnType<typeof store.getState>