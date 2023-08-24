import { TokenAndUser } from "@/lib/types";
import { createSlice } from "@reduxjs/toolkit";
import { useAppSelector } from "../hooks";
import { RootState } from "../store";

const initialState: TokenAndUser = {
  token: "",
  user: null
}

export const loginSlice = createSlice({
  name: "loginSlice",
  initialState,
  reducers: {
    setUser: (state: TokenAndUser, action) => {     
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

export const checkLogin = (state: RootState) => state.login.token

export const { setUser, unsetUser } = loginSlice.actions