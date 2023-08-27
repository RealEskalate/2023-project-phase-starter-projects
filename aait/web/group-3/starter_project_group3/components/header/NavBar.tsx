// Importing the 'navLinks' array from the 'Nav' type module and the 'NavLink' component.
import { navLinks } from "@/types/nav/Nav";
import NavLink from "./NavLink";

// Defining the 'NavBar' component.
const NavBar : React.FC = () => {
  return (
    // Container div for the navigation links, using Tailwind CSS classes.
    <div className="navigation hidden nav_bar_screen:flex-row nav_bar_screen:flex gap-9 font-semibold text-nav_text_color">
      {/* Mapping over the 'navLinks' array and creating a 'NavLink' component for each link. */}
      {navLinks.map((navLink) => (
        // Using the 'NavLink' component and passing the link path and name as props.
        <NavLink to={navLink.linkPath}>{navLink.linkName}</NavLink>
      ))}
    </div>
  );
};

// Exporting the 'NavBar' component for use in other parts of the application.
export default NavBar;
