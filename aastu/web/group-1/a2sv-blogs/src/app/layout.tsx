import type { Metadata } from "next";
import "./globals.css";
import ReduxProvider from "@/lib/providers";

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
    <html>
      <body>
        <ReduxProvider>{children}</ReduxProvider>
      </body>
    </html>
  );
}
