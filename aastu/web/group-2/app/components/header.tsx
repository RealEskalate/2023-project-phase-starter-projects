'use client';

import { FC, useEffect, useState } from "react"
import Image from "next/image"
import A2SVLogo from '@/assets/images/Group 39.svg'
import Link from "next/link"
import { usePathname } from 'next/navigation'
import { AiOutlineMenu } from 'react-icons/ai'


const Header: FC = () => {
  const currentRoute = usePathname();
  const [openMenu, setOpenMenu] = useState<boolean>(false)
  const [loggedIn, setLoggedIn] = useState(false)

  useEffect(() => {
      if (localStorage.getItem("login")) {
          setLoggedIn(true)
      }
  }, [])

  const handleSignOut = (e: any) => {
      e.preventDefault()

      localStorage.removeItem("login")
      setLoggedIn(false)
  };

    return (
        <div className="shadow-sm sticky z-10 top-0 bg-white flex justify-between text-center w-full h-[90px] py-4 px-9">
            <div className="w-[165px] h-[45px] py-2">
                <Image width={500} height={500} src={A2SVLogo} alt="A2SV Logo" />
            </div>
            <nav className="hidden lg:flex list-none py-4 px-9">
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "/" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='/'>Home</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "/teams" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='/teams'>Teams</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "/stories" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='/stories'>Success Stories</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "/about" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='/about'>About Us</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "/blog" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='/blog'>Blogs</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "/donate" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='/donate'>Get Involved</Link></li>
            </nav>
            {openMenu && (
                <nav className={`absolute right-0 px-4 py-2 list-none mt-12 bg-slate-100 text-left lg:hidden`}>
                    <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "/" ? "text-[#264FAD] font-medium border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='/'>Home</Link></li>
                    <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "/teams" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='/teams'>Teams</Link></li>
                    <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "/stories" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='/stories'>Success Stories</Link></li>
                    <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "/about" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='/about'>About Us</Link></li>
                    <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "/blog" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='/blog'>Blogs</Link></li>
                    <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "/doante" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='/donate'>Get Involved</Link></li>
                </nav>
            )}

            <button className="text-2xl lg:hidden " onClick={() => setOpenMenu(!openMenu)}> <AiOutlineMenu /> </button>
            <div className="hidden lg:block py-4">
            {
                    loggedIn ? (
                        <button onClick={handleSignOut} className="mr-4 font-secondaryFont font-bold mb-4">
                            Sign Out
                        </button>
                    ) : (
                        <Link href="/login" className="mr-4 font-secondaryFont font-bold mb-4">
                            Login
                        </Link>
                    )
                }         <Link className="bg-[#264FAD] text-white font-secondaryFont font-bold rounded-lg px-6 py-3" href='/donate'>Donate</Link>
            </div>
    </div>
  )
}


export default Header;
