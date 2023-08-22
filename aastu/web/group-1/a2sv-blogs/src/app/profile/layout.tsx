import NavigationTab from "@/components/profile/NavigationTab";
import Link from "next/link";

export default function ProfileLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html>
      <body>
        <main className="px-20 mx-auto">
          <h1 className="text-2xl mt-8">Profile</h1>
          <div>
            <NavigationTab />
            <hr className="mt-3" />
          </div>
          {children}
        </main>
      </body>
    </html>
  );
}
