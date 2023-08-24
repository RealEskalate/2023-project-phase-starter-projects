"use client";
import { Provider } from "react-redux"

import { store } from "@/lib/redux/store"

interface ProviderProps {
  children: React.ReactNode
}

const ReduxProvider = ({ children }: ProviderProps) => {
  return <Provider store={store}>{children}</Provider>
}

export default ReduxProvider