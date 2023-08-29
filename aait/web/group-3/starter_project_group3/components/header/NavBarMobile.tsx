// Import necessary modules and components
import { navLinks } from "@/types/nav/Nav"; // Importing an array of navigation links
import NavLink from "./NavLink"; // Importing the NavLink component
import { ReactNode } from "react"; // Importing the ReactNode type


// Define the NavBarMobile component
const NavBarMobile : React.FC<{ isOpen: boolean; children: ReactNode; }> = ({
  isOpen,
  children,
}: {
  isOpen: boolean;
  children: ReactNode;
}) => {
  return (
    // Container for the mobile navigation
    <div
      className={`navigation ${
        isOpen ? "flex flex-col justify-center items-center" : "hidden"
      } nav_bar_screen:hidden gap-9 font-semibold text-nav_text_color`}
    >
      {/* Mapping over the 'navLinks' array and creating 'NavLink' components */}
      {navLinks.map((navLink) => (
        // Using the 'NavLink' component and passing link path and name as props
        <NavLink key={navLink.linkName} to={navLink.linkPath}>{navLink.linkName}</NavLink>
      ))}

      {/* Displaying the children passed to the component */}
      {children}
    </div>
  );
};

export default NavBarMobile; // Export the NavBarMobile component
