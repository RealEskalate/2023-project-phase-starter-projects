import { navLinks } from "@/types/nav/Nav";
import NavLink from "./NavLink";
import { useSelector } from "react-redux";

const NavBar: React.FC = () => {
  const loginStatus = useSelector((state: any) => state.LogInState.status);

  return (
    <div className="navigation hidden nav_bar_screen:flex-row nav_bar_screen:flex gap-9 font-semibold text-nav_text_color">
      {navLinks.map((navLink) => {
        if (navLink.linkName === "Profile" && !loginStatus) {
          return null; 
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
