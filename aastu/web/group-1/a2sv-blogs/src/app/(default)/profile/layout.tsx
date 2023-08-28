import NavigationTab from "@/components/profile/NavigationTab";

export default function ProfileLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <main className="lg:px-32 py-28 px-5 mx-auto font-montserrat">
      <h1 className="text-2xl">Profile</h1>
      <div>
        <NavigationTab />
        <hr className="mt-3" />
      </div>
      <div className="mt-10">{children}</div>
    </main>
  );
}
