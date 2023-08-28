"use client";
import classNames from "classnames";
import Link from "next/link";
import { usePathname } from "next/navigation";
export default function NavigationTab() {
  const path = usePathname();
  const routeName = path.split("/")[2];
  return (
    <div className="flex justify-between items-center mt-5">
      <div className="md:space-x-5 space-x-4 flex justify-between md:justify-start">
        <Link
          href={"/profile/info"}
          className={classNames("relative text-sm font-bold", {
            "after:content-[''] after:flex after:absolute after:w-full after:h-1 after:bg-primary after:mt-2.5 after:rounded text-primary ":
              routeName === "info",
            "text-text-header-2": routeName !== "info",
          })}
        >
          Personal Information
        </Link>
        <Link
          href={"/profile/blogs"}
          className={classNames("relative text-sm font-bold", {
            "after:content-[''] after:flex after:absolute after:w-full after:h-1 after:bg-primary after:mt-2.5 after:rounded text-primary ":
              routeName === "blogs",
            "text-text-header-2": routeName !== "blogs",
          })}
        >
          My Blogs
        </Link>
        <Link
          href="/profile/setting"
          className={classNames("relative text-sm font-bold", {
            "after:content-[''] after:flex after:absolute after:w-full after:h-1 after:bg-primary after:mt-2.5 after:rounded text-primary ":
              routeName === "setting",
            "text-text-header-2": routeName !== "setting",
          })}
        >
          Account Setting
        </Link>
      </div>
      <div className="hidden">
        <Link
          href={"#"}
          className="text-sm bg-blue-800 px-5 py-2 text-white rounded"
        >
          New Blog
        </Link>
      </div>
    </div>
  );
}
