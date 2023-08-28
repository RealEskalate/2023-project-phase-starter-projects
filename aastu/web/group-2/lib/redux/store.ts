/* Core */
import { configureStore } from '@reduxjs/toolkit';

/* Instruments */
import { blogsApi } from './slices/blogsApi';
import { loginSlice } from './slices/loginSlice';
import { usersApi } from './slices/usersApi';

export const store = configureStore({
  reducer: {
    [blogsApi.reducerPath]: blogsApi.reducer,
    [usersApi.reducerPath]: usersApi.reducer,
    login: loginSlice.reducer,
  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware().concat(blogsApi.middleware).concat(usersApi.middleware);
  },
});

/* Types */
// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;
