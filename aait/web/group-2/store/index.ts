import { configureStore } from "@reduxjs/toolkit";
import { singleSuccessApi } from "./features/successStories";
import { setupListeners } from "@reduxjs/toolkit/dist/query";

const store = configureStore({

    reducer:{
        [singleSuccessApi.reducerPath]:singleSuccessApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(singleSuccessApi.middleware),
})


export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
export default store