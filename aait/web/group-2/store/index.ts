import { configureStore } from "@reduxjs/toolkit";
import { singleSuccessApi } from "./features/success-stories";
// import { setupListeners } from "@reduxjs/toolkit/dist/query";
import authApi from "./features/auth-api";

const store = configureStore({

    reducer:{
        [singleSuccessApi.reducerPath]:singleSuccessApi.reducer,
        [authApi.reducerPath]:authApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware()
            // .concat(singleSuccessApi.middleware)
            .concat(authApi.middleware)
})


export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
export default store