import { configureStore } from "@reduxjs/toolkit";
import { storiesApi } from "./story/story-api";


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