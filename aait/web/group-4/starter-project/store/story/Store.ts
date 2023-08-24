import { configureStore } from "@reduxjs/toolkit";
import { storiesApi } from "./StoryApi";


export const store = configureStore({
  reducer: {
    [storiesApi.reducerPath]: storiesApi.reducer,
    
  },

  middleware:(getDefaultMiddleware)=>
    getDefaultMiddleware().concat(
      storiesApi.middleware, 
      )
  

});

export type AppDispatch = typeof store.dispatch

export type RootState = ReturnType<typeof store.getState>