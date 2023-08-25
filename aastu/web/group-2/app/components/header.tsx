'use client';

import { FC, useEffect, useRef, useState } from 'react';
import Image from 'next/image';
import A2SVLogo from '@/assets/images/Group 39.svg';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { AiOutlineMenu, AiOutlineClose } from 'react-icons/ai';
import ProfileDropDown from './home/ProfileDropDown';
import { useClickOutside } from '../hooks/useClickOutside';

const Header: FC = () => {
  const currentRoute = usePathname();
  const [openMenu, setOpenMenu] = useState<boolean>(false);
  const [loggedIn, setLoggedIn] = useState(false);
  const wrapperRef = useRef(null);

  useClickOutside(wrapperRef, () => {
    setOpenMenu(false);
  });

  useEffect(() => {
    if (localStorage.getItem('login')) {
      setLoggedIn(true);
    }
  }, []);

  const handleSignOut = () => {
    localStorage.removeItem('login');
    setLoggedIn(false);
  };

  interface NavProps {
    isLink: boolean;
    href?: string;
    name: string;
    onClick?: () => void;
    className?: string;
  }

  const links: NavProps[] = [
    {
      name: 'Home',
      isLink: true,
      href: '/',
    },
    {
      name: 'Teams',
      isLink: true,
      href: '/teams',
    },
    {
      name: 'Success Stories',
      isLink: true,
      href: '/stories',
    },
    {
      name: 'About Us',
      isLink: true,
      href: '/about',
    },
    {
      name: 'Blogs',
      isLink: true,
      href: '/blog',
    },
    {
      name: 'Get Involved',
      isLink: true,
      href: '/donate',
    },
    {
      name: 'Profile',
      isLink: true,
      href: '/profile',
    },
    {
      name: 'Logout',
      isLink: false,
      href: 'null',
      onClick: handleSignOut,
    },
    {
      name: 'Login',
      isLink: true,
      href: '/login',
    },
  ];

  return (
    <div className="shadow-sm sticky z-10 top-0 bg-white flex lg:justify-between text-center w-full h-[90px] py-4 px-9">
      <div className="w-[165px] h-[45px] py-2 flex-1 lg:flex-none">
        <Image width={165} height={45} src={A2SVLogo} alt="A2SV Logo" />
      </div>
      <nav className="hidden lg:flex list-none py-4 px-9">
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/'
              ? 'text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm'
              : ' text-[#565656]'
          }`}
        >
          <Link href="/">Home</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/teams'
              ? 'text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm'
              : ' text-[#565656]'
          }`}
        >
          <Link href="/teams">Teams</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/stories'
              ? 'text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm'
              : ' text-[#565656]'
          }`}
        >
          <Link href="/stories">Success Stories</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/about'
              ? 'text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm'
              : ' text-[#565656]'
          }`}
        >
          <Link href="/about">About Us</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/blog'
              ? 'text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm'
              : ' text-[#565656]'
          }`}
        >
          <Link href="/blog">Blogs</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/donate'
              ? 'text-[#264FAD] pb-8 border-b-[4px] border-[#264FAD] rounded-sm'
              : ' text-[#565656]'
          }`}
        >
          <Link href="/donate">Get Involved</Link>
        </li>
      </nav>
      {openMenu && (
        <nav
          className={`absolute right-5 w-48 px-4 py-2  mt-12 bg-slate-100 text-left flex flex-col lg:hidden shadow-md`}
          ref={wrapperRef}
        >
          {links
            .filter((link) => {
              if (loggedIn && ['Login'].includes(link.name)) {
                return false;
              } else if (!loggedIn && [('Profile', 'Logout')].includes(link.name)) {
                return false;
              }

              return true;
            })
            .map((link: NavProps, index: number) => {
              return <Nav key={index} {...link} />;
            })}
        </nav>
      )}

      <button className="text-2xl  mr-10 lg:hidden " onClick={() => setOpenMenu(!openMenu)}>
        {' '}
        {openMenu ? <AiOutlineClose /> : <AiOutlineMenu />}
      </button>
      <div className="flex py-4 h-full items-center gap-5">
        <Link
          className="bg-[#264FAD] text-white font-secondaryFont font-bold rounded-lg px-4 py-2 hidden lg:block"
          href="/donate"
        >
          Donate
        </Link>
        {loggedIn ? (
          <ProfileDropDown handleSignOut={handleSignOut} isLoggedin={loggedIn} />
        ) : (
          <Link
            href="/login"
            className="mr-4 font-secondaryFont font-bold hover:text-primaryColor transition-all ease-linear hidden lg:block  "
          >
            Login
          </Link>
        )}{' '}
      </div>
    </div>
  );
};

export default Header;

export const Nav = ({
  isLink,
  href,
  name,
  onClick,
  className,
}: {
  isLink: boolean;
  href?: string;
  name: string;
  onClick?: () => void;
  className?: string;
}) => {
  const currentRoute = usePathname();
  if (isLink) {
    return (
      <Link
        href={href}
        className={`w-full px-2 py-2 flex gap-4 items-center  hover:bg-slate-300 transition-all ease-in-out rounded`}
      >
        <span
          className={` ${
            currentRoute === `${href}`
              ? 'text-[#264FAD] font-medium border-b-[4px] border-[#264FAD] rounded-sm'
              : ' text-[#565656]'
          }`}
        >
          {name}
        </span>
      </Link>
    );
  }
  if (onClick) {
    return (
      <span
        onClick={() => onClick()}
        className={`w-full px-2 py-2 flex gap-4 items-center  hover:bg-slate-300 transition-all ease-in-out rounded text-[#565656] cursor-pointer`}
      >
        {name}
      </span>
    );
  }
  return (
    <button
      className={`w-full px-2 py-2 flex gap-4 items-center  hover:bg-slate-300 transition-all ease-in-out rounded text-[#565656] cursor-pointer`}
    >
      {name}
    </button>
  );
};
