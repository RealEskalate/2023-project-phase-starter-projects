import Authenticate from "@/components/auth/Authenticate";
import ProfileMenu from "@/components/profile/ProfileHeader";
import { ReactNode } from "react";

export default function Layout({ children }: { children: ReactNode }) {
  return (
      <Authenticate>
        <div>
          <ProfileMenu />
          <main>{children}</main>
        </div>
      </Authenticate>
  );
}
