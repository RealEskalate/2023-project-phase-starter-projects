import ReduxProvider from "@/lib/providers";
import type { Metadata } from "next";
import "./globals.css";

export const metadata: Metadata = {
  title: "A2SV Blogs",
  description: "This is a starter project for AASTU group 1 web team",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body>
        <ReduxProvider>{children}</ReduxProvider>
      </body>
    </html>
  );
}
