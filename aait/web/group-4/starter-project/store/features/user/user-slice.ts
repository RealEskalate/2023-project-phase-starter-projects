import User from "@/types/user/user";
import { PayloadAction, createSlice } from "@reduxjs/toolkit";


const initialState: {user: User | null} = {
    user: null
}

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {

        setUser: (state, action: PayloadAction<User>) => {
            state.user = action.payload
            localStorage.setItem('user', JSON.stringify(state.user))
            
        },

        logout: (state) => {
            state.user = null
            localStorage.removeItem('user')
        }
    
    }
})

export const { setUser, logout } = userSlice.actions