import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit'
import { authApi } from './auth/authApi'
import { profileApi } from './features/user/userApi'
import { teamMembersApi } from "./features/team-members/team-members";
import { blogApi } from './blog/blogApi';

export const store = configureStore({
  reducer: {
    [authApi.reducerPath]: authApi.reducer,
    [blogApi.reducerPath]: blogApi.reducer,
    [teamMembersApi.reducerPath]: teamMembersApi.reducer,
    [profileApi.reducerPath]: profileApi.reducer,
  },
  middleware: getDefaultMiddleware => getDefaultMiddleware()
  .concat(authApi.middleware, blogApi.middleware, teamMembersApi.middleware, profileApi.middleware)
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch