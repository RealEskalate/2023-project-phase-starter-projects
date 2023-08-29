import { blogApi } from './blog/blogsApi'
import { configureStore } from '@reduxjs/toolkit'

export const store = configureStore({
  reducer: {
    [blogApi.reducerPath]: blogApi.reducer,
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(blogApi.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch