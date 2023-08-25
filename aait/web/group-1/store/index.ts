import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit'
import { authApi } from './auth/authApi'
import { blogsApi } from './features/blogs/blogs'
import { teamMembersApi } from "./features/team-members/team-members";


export const store = configureStore({
  reducer: {
    [authApi.reducerPath]: authApi.reducer,
    [blogsApi.reducerPath]: blogsApi.reducer,
    [teamMembersApi.reducerPath]: teamMembersApi.reducer,
  },

  middleware: getDefaultMiddleware => getDefaultMiddleware().concat(authApi.middleware, blogsApi.middleware, teamMembersApi.middleware)
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch