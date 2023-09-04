import { configureStore } from "@reduxjs/toolkit";
import { createBlogApi } from "./features/create-blog/create-blog-api";
import { singleBlogApi } from "./features/blog-detail/blog-detail";
import { blogsApi } from "./features/blogs/blogs-api";
import { authApi } from "./features/auth";
import { teamsApi } from "./features/teams/team-member-api";
import { storiesApi } from "./features/success-stories/sucess-stories-api";
import { myblogsApi } from "./features/my-blogs";
import { createUpdateProfileAPI } from "./update-personal-information";
import { stateSlice } from "./user-Slice";

export const store = configureStore({
  reducer: {
    LogInState:stateSlice.reducer, 
    [blogsApi.reducerPath]: blogsApi.reducer,
    [singleBlogApi.reducerPath]: singleBlogApi.reducer,
    [createBlogApi.reducerPath]: createBlogApi.reducer,
    [authApi.reducerPath]: authApi.reducer,
    [teamsApi.reducerPath]: teamsApi.reducer,
    [storiesApi.reducerPath]: storiesApi.reducer,
    [myblogsApi.reducerPath]: myblogsApi.reducer,
    [createUpdateProfileAPI.reducerPath]: createUpdateProfileAPI.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
      .concat(blogsApi.middleware)
      .concat(singleBlogApi.middleware)
      .concat(createBlogApi.middleware)
      .concat(authApi.middleware)
      .concat(teamsApi.middleware)
      .concat(storiesApi.middleware)
      .concat(myblogsApi.middleware)
      .concat(createUpdateProfileAPI.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
