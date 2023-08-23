"use client";

import { FC ,useState } from "react"
import Image from "next/image"
import A2SVLogo from '@/assets/images/Group 39.svg'
import Link from "next/link"
import { usePathname } from 'next/navigation'
import { AiOutlineMenu } from 'react-icons/ai'


const Header: FC = () => {
    const currentRoute = usePathname();
    const [openMenu, setOpenMenu] = useState<boolean>(false);

  return (
    <div className="shadow-sm sticky z-10 top-0 bg-white flex justify-between text-center w-full h-[90px] py-4 px-9">
            <div className="w-[165px] h-[45px] py-2">
                <Image width={500} height={500}  src={A2SVLogo} alt="A2SV Logo" />
            </div>
            <nav className="hidden lg:flex list-none py-4 px-6">
                <li className= {`mr-9 font-secondaryFont font-semibold ${currentRoute === "/" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='#'>Home</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='#'>Teams</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='#'>Success Stories</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "/about" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='#'>About Us</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='#'>Blogs</Link></li>
                <li className={`mr-9 font-secondaryFont font-semibold ${currentRoute === "" ? "text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='#'>Get Involved</Link></li>
            </nav>
            {openMenu && (
            <nav className={`absolute right-0 px-4 py-2 list-none mt-12 bg-slate-100 text-left lg:hidden`}>
                <li className= {`mr-9 font-secondaryFont font-light ${currentRoute === "/" ? "text-[#264FAD] font-medium border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"}`}><Link href='#'>Home</Link></li>
                <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='#'>Teams</Link></li>
                <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='#'>Success Stories</Link></li>
                <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "/about" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='#'>About Us</Link></li>
                <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='#'>Blogs</Link></li>
                <li className={`mr-9 font-secondaryFont font-light ${currentRoute === "" ? "text-[#264FAD] font-medium mb-2 border-b-[4px] border-[#264FAD] rounded-sm" : " text-[#565656]"} pt-2`}><Link href='#'>Get Involved</Link></li>
            </nav>
            )}

            <button className="text-2xl lg:hidden " onClick={() => setOpenMenu(!openMenu)}> <AiOutlineMenu /> </button>
            <div className="hidden lg:block py-1">
                <button className="mr-4 font-secondaryFont font-bold"> Login</button>
                <button className="bg-[#264FAD] text-white font-secondaryFont font-bold rounded-lg px-4 py-2">Donate</button>
            </div>
    </div>
  )
}


export default Header;