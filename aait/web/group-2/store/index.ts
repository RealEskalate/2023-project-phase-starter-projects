import { configureStore } from "@reduxjs/toolkit";
import { successApi } from "./features/success-stories";
import authApi from "./features/auth/auth-api";

export const store = configureStore({
  reducer: {
    [successApi.reducerPath]: successApi.reducer,
    [authApi.reducerPath]: authApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
      .concat(authApi.middleware, successApi.middleware),
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
