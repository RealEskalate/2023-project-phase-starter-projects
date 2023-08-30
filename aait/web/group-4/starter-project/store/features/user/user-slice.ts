import User from "@/types/user/user";
import { PayloadAction, createSlice } from "@reduxjs/toolkit";

const initialState: {user: User | null, message: {content: string}} = {
    user: null,
    message: {
        content: ""
    }
}

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {

        setUser: (state, action: PayloadAction<User>) => {
            state.user = action.payload
            
        },

        logout: (state) => {
            state.user = null
        },
        setMessage: (state, action: PayloadAction<string>) => {
            state.message.content = action.payload;
        }
    }
})

export const { setUser, logout, setMessage } = userSlice.actions