"use client";
import MyBlogsList from "@/components/profile/MyBlogsList";
import { useAuth } from "@/hooks/useAuth";
export default function page() {
  const { auth } = useAuth();
  console.log(auth);
  return (
    <section>
      <div className="text-gray-500 space-y-1 mt-5">
        <h1 className="text-lg font-bold text-text-header-1">Manage Blogs</h1>
        <p className="text-sm text-text-content">
          Edit, Delete, and View the Status of your blogs
        </p>
      </div>
      <hr className="my-5" />
      <div>{auth.token && <MyBlogsList />}</div>
    </section>
  );
}
