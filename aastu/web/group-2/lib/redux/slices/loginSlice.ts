import { TokenAndUser } from "@/lib/types";
import { createSlice } from "@reduxjs/toolkit";

const initialState: TokenAndUser = {
  token: "",
  user: null
}

export const loginSlice = createSlice({
  name: "loginSlice",
  initialState,
  reducers: {
    setUser: (state: TokenAndUser, action) => {     
      console.log("I'm here",action) 
      localStorage.setItem("login", JSON.stringify(action.payload))
      state = action.payload
    },
    unsetUser: () => {
      localStorage.removeItem("login")
      return ({
        token: "",
        user: null
      })
    }
  }
})

export const { setUser, unsetUser } = loginSlice.actions