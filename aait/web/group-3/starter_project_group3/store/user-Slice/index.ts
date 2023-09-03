import { checkLocalStorage } from "@/components/header/Header";
import { authTypes } from "@/types/auth/authTypes";
import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  status: checkLocalStorage(),
};

export const stateSlice = createSlice({
  name: "status",
  initialState,
  reducers: {
    setLogInStatus: (state: any) => {
      state.status = true;
    },
    removeLogInStatus: (state: any) => {
      state.status = true;
    },
  },
});

export const { setLogInStatus, removeLogInStatus } = stateSlice.actions;
