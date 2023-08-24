'use client';
import { useState } from "react";
import Image from "next/image";
import Link from "next/link";
export default function NavBar() {
  const [openMenu, setOpenMenu] = useState<boolean>(false);
  return (


    <header>
      <div className="container px-12 w-full py-3 fixed top-0 bg-white content-between w-full">
        <nav className="flex items-center">
          <div>
          <Link href='/'>
              <Image
                src="/images/a2sv-logo.svg"
                width={197}
                height={50}
                alt="Hero image"
              />
            </Link>
          </div>
          <div className="px-4 content-end  cursor-pointer  content-end ml-96">
            <button className="text-2xl lg:hidden " onClick={() => setOpenMenu(!openMenu)}>
              <Image
                src="/images/icons8-hamburger-menu.svg"
                width={50}
                height={50}
                alt="Hamburger"
              />    
              </button>        
          </div>
          <div className="flex-1 text-center font-normal text-text-header-1	text-lg hidden lg:flex list-none w-full 	">
          <ul >         
            <li className="px-5 inline-block"><Link href='/'>Home</Link></li>
            <li className="px-5 inline-block"><Link href='/teams'>Team</Link></li>
            <li className="px-5 inline-block"><Link href='/stories/interviewPartners'>Success Stories</Link></li>
            <li className="px-5 inline-block"> <Link href='/about'>About</Link></li>
            <li className="px-5 inline-block"><Link href='/blogs'>Blogs</Link></li>
            <li className="px-5 inline-block">Get Involved</li>
          </ul>
          </div>
          {openMenu && (
            <div className="flex-1 text-center font-normal text-text-header-1	text-lg  list-none  ">
            <ul >         
              <li className="px-5 inline-block"><Link href='/'>Home</Link></li>
              <li className="px-5 inline-block"><Link href='/teams'>Team</Link></li>
              <li className="px-5 inline-block"><Link href='/stories/interviewPartners'>Success Stories</Link></li>
              <li className="px-5 inline-block"> <Link href='/about'>About</Link></li>
              <li className="px-5 inline-block"><Link href='/blogs'>Blogs</Link></li>
              <li className="px-5 inline-block">Get Involved</li>
            </ul>
            </div>
          )}
          <div className="hidden lg:block content-end row-span-1">
            <span className="text-nav-grey px-5 ">Login</span>
            <span>
              <button className="border-2	rounded-xl px-5 w-22 h-12 bg-primary text-white text-base font-bold ">
                {" "}
                Donate{" "}
              </button>
            </span>
          </div>
        </nav>
      </div>
    </header>
  );
}