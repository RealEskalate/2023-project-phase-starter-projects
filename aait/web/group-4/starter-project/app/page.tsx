'use client'
import { store } from "@/store/page";
import { storiesApi } from "@/store/story/story-api";
import { ApiProvider } from "@reduxjs/toolkit/dist/query/react";
import { Provider } from "react-redux";
import { ShowStories } from "@/components/story/ShowStories";

export default function Home() {
  return (
    <main>
        <Provider store={store}>
          <ApiProvider api={storiesApi}>
            <ShowStories/>
          </ApiProvider>
        </Provider>
    </main>
  )
}
