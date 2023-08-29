import { configureStore } from "@reduxjs/toolkit";
import { storiesApi } from "./features/story/story-api";
import { blogsApi } from "./features/blog/blog-api";
import { userApi } from "./features/user/user-api";
import { userSlice } from "./features/user/user-slice";

export const store = configureStore({
  reducer: {
    [storiesApi.reducerPath]: storiesApi.reducer,
    [blogsApi.reducerPath]: blogsApi.reducer,
    [userApi.reducerPath]: userApi.reducer,
    user: userSlice.reducer
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(
      storiesApi.middleware,
    ).concat(blogsApi.middleware).concat(userApi.middleware)


});

export type AppDispatch = typeof store.dispatch

export type RootState = ReturnType<typeof store.getState>