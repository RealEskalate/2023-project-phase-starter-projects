import ProfileMenu from "@/components/profile/ProfileHeader";
import { ReactNode } from "react";

export default function Layout({ children }: { children: ReactNode }) {

  return (
    <div>
        <ProfileMenu/>
      <main>{children}</main>
    </div>
  );
}
