import Link from "next/link";
import { usePathname } from "next/navigation";
import { useState } from "react";

const NavMenu = () => {
  const links: { link: string; name: string }[] = [
    { name: "Home", link: "/" },
    { name: "Team", link: "/teams" },
    { name: "Success Stories", link: "/success-stories" },
    { name: "About Us", link: "/about-us" },
    { name: "Blogs", link: "/blogs" },
    { name: "Get Involved", link: "/get-involved" },
  ];
  const pathname = usePathname();
  const [activeLink, setActiveLink] = useState(0);
  
  return (
    <>
      {links.map((lin, i) => {
        return (
            <div>
              <div key={lin.name} className="flex flex-col group">
                <Link className="pb-2 hover:text-gray-400" href={`${lin.link}`} onClick={() => setActiveLink(i)}>
                  {lin.name}
                </Link>
                <span
                  className={`${
                    activeLink === i ? "w-full" : "w-0"
                  } group-hover:w-full h-[2px] bg-blue-800`}
                  style={{ transition: "width 0.3s ease-in-out" }}
                ></span>
              </div>
            </div>
        );
      })}
    </>
  );
};

export default NavMenu;
