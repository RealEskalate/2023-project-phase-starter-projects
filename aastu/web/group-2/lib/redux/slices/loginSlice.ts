import { TokenAndUser } from '@/lib/types';
import { createSlice } from '@reduxjs/toolkit';

let initialState: TokenAndUser | null = null;

if (typeof window !== 'undefined') {
  // Perform localStorage action

  const data = localStorage.getItem('login');
  if (data) {
    initialState = JSON.parse(data);
  }
}

export const loginSlice = createSlice({
  name: 'loginSlice',
  initialState,
  reducers: {
    setUser: (state: TokenAndUser, action) => {
      console.log("I'm here", action);
      localStorage.setItem('login', JSON.stringify(action.payload));
      return action.payload;
    },
    unsetUser: (state: any) => {
      localStorage.removeItem('login');
      return null;
    },
  },
});

export const { setUser, unsetUser } = loginSlice.actions;
