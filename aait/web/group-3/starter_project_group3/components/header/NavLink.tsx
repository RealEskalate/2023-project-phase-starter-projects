"use client";
import { usePathname } from "next/navigation";
import Link from "next/link";

const NavLink: React.FC<{ to: string; children: React.ReactNode }> = ({
  to,
  children,
}: {
  to: string;
  children: React.ReactNode;
}) => {
  const pathname = usePathname();

  // Check if the current pathname matches the "to" prop
  const isActive = pathname === to;

  return (
    <div>
      {/* Create a Link component with the provided "to" prop */}
      <Link
        href={to}
        className={`${
          isActive ? "text-primary" : ""
        } hover:text-black hover:font-bold`}
      >
        {children}
      </Link>

      {/* Display a horizontal line (hr) if the link is active */}
      {isActive && (
        <hr
          className={
            isActive ? "w-full mt-2 border-t-4 rounded-full border-primary" : ""
          }
        />
      )}
    </div>
  );
};

export default NavLink;
