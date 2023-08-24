import NavigationTab from "@/components/profile/NavigationTab";

export default function ProfileLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <main className="lg:px-32 mx-auto">
      <h1 className="text-2xl mt-8">Profile</h1>
      <div>
        <NavigationTab />
        <hr className="mt-3" />
      </div>
      {children}
    </main>
  );
}
