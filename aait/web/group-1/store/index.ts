import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit'
import { authApi } from './auth/authApi'
import { blogsApi } from './features/blogs/blogs'
import { profileApi } from './features/user/userApi'

export const store = configureStore({
  reducer: {
    [authApi.reducerPath]: authApi.reducer,
    [blogsApi.reducerPath]: blogsApi.reducer,
    [profileApi.reducerPath]: profileApi.reducer,
  },

  middleware: getDefaultMiddleware => getDefaultMiddleware()
  .concat(authApi.middleware, blogsApi.middleware, profileApi.middleware)
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch