import User from "@/types/user/user";
import { PayloadAction, createSlice } from "@reduxjs/toolkit";

const initialState: {user: User, message: string} = {
    user: {
        token: "",
        user: "",
        userEmail: "",
        userName: "",
        userProfile: "",
        userRole: ""
    },
    message: ""
}

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {

        setUser: (state, action: PayloadAction<User>) => {
            state.user = action.payload
        },

        logout: (state) => {
            state.user = {
                token: "",
                user: "",
                userEmail: "",
                userName: "",
                userProfile: "",
                userRole: ""
            }
        },
        setMessage: (state, action: PayloadAction<string>) => {
            state.message = action.payload;
        }
    }
})

export const { setUser, logout, setMessage } = userSlice.actions