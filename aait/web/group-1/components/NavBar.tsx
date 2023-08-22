import Image from "next/image";
import React from "react";
import A2SVLogo from '../public/images/A2SV.svg'
import { LinkItems } from "./LinkItems";

interface NavItems {
    link: string,
    name: string
}

export const NavBar = () => {
    const navItems: NavItems[] = [
        {
            link: '/',
            name: 'home'
        },
        {
            link: '/teams',
            name: 'teams'
        },
        {
            link: '/success',
            name: 'success stories'
        },
        {
            link: '/about',
            name: 'about us'
        },
        {
            link: '/contact',
            name: 'get involved'
        },
    ]

  return (
    <div className="w-full py-8 p-4 bg-white">
      <div className="flex justify-between items-center font-montserrat">
        {/* logo section */}
        <div>
          <Image src={A2SVLogo} alt="A2SV logo" width={100} height={50}/>
        </div>

        {/* Navigation section */}
        <div className="flex gap-6">
            {navItems.map((nav: NavItems) => <LinkItems key={nav.name} name={nav.name} link={nav.link}/>)}
        </div>

        {/* login signup section */}
        <div className="flex gap-2">
            <button className="btn">Login</button>
            <button className="btn bg-blue-800 text-white">Donate</button>
        </div>
      </div>
    </div>
  );
};
