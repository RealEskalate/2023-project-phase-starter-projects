"use client";
import ReduxProvider from "@/lib/providers";
import AOS from "aos";
import type { Metadata } from "next";
import "./globals.css";
import "aos/dist/aos.css";
import React, { useEffect } from "react";

export const metadata: Metadata = {
  title: "A2SV Blogs",
  description: "This is a starter project for AASTU group 1 web team",
};

const FloatButton = () => {
  const [show, setShow] = React.useState(false);

  React.useEffect(() => {
    function handleScroll() {
      console.log(window);
      setShow(window.scrollY > 100);
    }

    window.addEventListener("scroll", handleScroll);
    return () => window.removeEventListener("scroll", handleScroll);
  });

  return (
    show && (
      <div className="fixed bottom-6 right-6 z-50">
        <button
          className="w-12 h-12 bg-[#264FAD] rounded-full shadow-lg focus:outline-none text-white flex justify-center items-center"
          onClick={() => {
            window.scrollTo({ top: 0, behavior: "smooth" });
          }}
        >
          <svg
            aria-hidden="true"
            focusable="false"
            data-prefix="fas"
            className="h-4 w-4"
            role="img"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 448 512"
          >
            <path
              fill="currentColor"
              d="M34.9 289.5l-22.2-22.2c-9.4-9.4-9.4-24.6 0-33.9L207 39c9.4-9.4 24.6-9.4 33.9 0l194.3 194.3c9.4 9.4 9.4 24.6 0 33.9L413 289.4c-9.5 9.5-25 9.3-34.3-.4L264 168.6V456c0 13.3-10.7 24-24 24h-32c-13.3 0-24-10.7-24-24V168.6L69.2 289.1c-9.3 9.8-24.8 10-34.3.4z"
            ></path>
          </svg>
        </button>
      </div>
    )
  );
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  useEffect(() => {
    AOS.init({
      delay: 400,
      duration: 800,
      easing: "ease-in-out",
    });
  }, []);

  useEffect(() => {
    AOS.refresh();
  }, []);

  return (
    <html lang="en" className="scroll-smooth">
      <body>
        <ReduxProvider>{children}</ReduxProvider>
        <FloatButton />
      </body>
    </html>
  );
}
