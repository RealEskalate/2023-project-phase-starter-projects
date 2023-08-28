'use client'
import { store } from "@/store/store"
import { Provider } from "react-redux"
import {ApiProvider} from '@reduxjs/toolkit/query/react'
import BlogForm from "@/components/blog/AddBlogForm"
import { blogApi } from "@/store/blog/blogsApi"

export default function Home() {
  return (
    <main>
     <Provider store={store}>
      <ApiProvider api={blogApi}>
        <BlogForm/>
      </ApiProvider>
     </Provider>
    </main>
  )
}
