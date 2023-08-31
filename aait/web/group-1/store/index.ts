import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit'
import { authApi } from './auth/authApi'
import { teamMembersApi } from "./features/team-members/team-members";
import { blogApi } from './blog/blogApi';


export const store = configureStore({
  reducer: {
    [authApi.reducerPath]: authApi.reducer,
    [blogApi.reducerPath]: blogApi.reducer,
    [teamMembersApi.reducerPath]: teamMembersApi.reducer,
  },

  middleware: getDefaultMiddleware => getDefaultMiddleware().concat(authApi.middleware, blogApi.middleware, teamMembersApi.middleware)
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch