import ProfileBlogCard from "@/components/blogs/ProfileCard";

export default function page() {
  return (
    <section>
      <div className="text-gray-500 space-y-1 mt-5">
        <h1 className="text-lg font-bold text-text-header-1">Manage Blogs</h1>
        <p className="text-sm text-text-content">
          Edit, Delete, and View the Status of your blogs
        </p>
      </div>
      <hr className="my-5" />
      <div className="grid grid-cols-4 gap-6 mt-3">
        {Array.from({ length: 8 }, (_, i) => i + 1).map(() => (
          <ProfileBlogCard />
        ))}
      </div>
    </section>
  );
}
