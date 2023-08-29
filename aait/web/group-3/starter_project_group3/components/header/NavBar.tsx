import { navLinks } from "@/types/nav/Nav";
import NavLink from "./NavLink";
import { useEffect, useState } from "react";
import { authTypes } from "@/types/auth/authTypes";

const NavBar: React.FC = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    const userString = localStorage.getItem("user");
    const user: authTypes | null = userString ? JSON.parse(userString) : null;
    if (user) {
      setIsLoggedIn(true);
    }
  }, []);

  return (
    <div className="navigation hidden nav_bar_screen:flex-row nav_bar_screen:flex gap-9 font-semibold text-nav_text_color">
      {navLinks.map((navLink) => {
        if (navLink.linkName === "Profile" && !isLoggedIn) {
          return null; // Skip rendering the "Profile" link if not logged in
        }
        return (
          <NavLink key={navLink.linkName} to={navLink.linkPath}>
            {navLink.linkName}{" "}
          </NavLink>
        );
      })}
    </div>
  );
};

export default NavBar;
