import "./globals.css";
import type { Metadata } from "next";
import { Poppins } from "next/font/google";
import { NavBar } from "@/components/layout/NavBar";

import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'

const inter = Poppins({
  weight: "400",
  subsets: ["latin"],
});
import StateProvider from "@/components/provider/StateProvider";
import Footer from "@/components/layout/Footer";

export const metadata: Metadata = {
  title: "Create Next App",
  description: "Generated by create next app",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <StateProvider>
      <html lang="en">
        <body className={`flex flex-col ${inter.className}`}>
          <header>
            <NavBar />
          </header>
          <main>
            {children}
          <ToastContainer
            position='top-right'
            autoClose={2000}
            hideProgressBar={false}
            newestOnTop={false}
            closeOnClick
            rtl={false}
            pauseOnFocusLoss
            draggable
            pauseOnHover
            theme='colored'
          />
          </main>
          <Footer />
        </body>
      </html>
    </StateProvider>
  );
}
