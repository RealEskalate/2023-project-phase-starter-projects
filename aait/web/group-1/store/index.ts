import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit'
import { authApi } from './auth/authApi'
import { blogsApi } from './features/blogs/blogs'


export const store = configureStore({
  reducer: {
    [authApi.reducerPath]: authApi.reducer,
    [blogsApi.reducerPath]: blogsApi.reducer,
  },

  middleware: getDefaultMiddleware => getDefaultMiddleware().concat(authApi.middleware, blogsApi.middleware)
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch