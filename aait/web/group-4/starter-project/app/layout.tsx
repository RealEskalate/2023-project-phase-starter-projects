'use client'
import Navbar from "@/components/layout/Navbar";
import type { Metadata } from "next";
import Footer from "@/components/layout/Footer";
import "./globals.css";
import { Provider } from "react-redux";
import { store } from "@/store/page";
import { ApiProvider } from "@reduxjs/toolkit/dist/query/react";
import { storiesApi } from "@/store/story/story-api";

export const metadata: Metadata = {
  title: "A2SV",
  description: "Generated by create next app",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className="font-{poppins}">
        <Navbar/>
        <main className="p-10 md:p-20">
          <Provider store={store}>
            <ApiProvider api={storiesApi}>
            {children}
            </ApiProvider>
          </Provider>
        </main>
        <Footer/>
      </body>
    </html>
  );
}