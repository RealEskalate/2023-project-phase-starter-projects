'use client';

import { FC, useEffect, useRef, useState } from 'react';
import Image from 'next/image';
import A2SVLogo from '@/assets/images/Group 39.svg';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { AiOutlineMenu, AiOutlineClose, AiOutlineArrowUp } from 'react-icons/ai';
import ProfileDropDown from './home/ProfileDropDown';
import { useClickOutside } from '../hooks/useClickOutside';
import { useAppDispatch, useAppSelector } from '@/lib/redux/hooks';
import { unsetUser } from '@/lib/redux/slices/loginSlice';
import useDarkMode from '@/lib/useDarkMode';
import { NavProps } from '@/lib/types';
import { Nav } from './Nav';

const Header: FC = () => {
  const currentRoute = usePathname();
  const [openMenu, setOpenMenu] = useState<boolean>(false);
  const [loggedIn, setLoggedIn] = useState(false);
  const [isClient, setClient] = useState(false);
  // console.log(useDarkMode());
  const [colorTheme, setTheme] = useDarkMode();
  const[backToTopState, setbackToTopState] = useState<boolean>(false)

  const BackToTop = ()=>{
    window.scrollTo(0, 0);
  }

  const handleScroll = () => {
    if (window.scrollY > 300) {
      console.log(window.scrollY)
      setbackToTopState(true);
    } else {
      setbackToTopState(false);
    }
  };

  useEffect(() => {
    window.addEventListener('scroll', handleScroll, true);
    return () => window.removeEventListener('scroll', handleScroll, true);
  });

  const handleDarkMode = () => {
    console.log('color theme', colorTheme);

    setTheme(colorTheme === 'light' ? 'light' : 'dark');
  };

  useEffect(() => {
    setClient(true);
  }, []);

  const wrapperRef = useRef(null);

  const dispatch = useAppDispatch();
  const loginState = useAppSelector((state: any) => state.login);

  useClickOutside(wrapperRef, () => {
    setOpenMenu(false);
  });

  const handleSignOut = () => {
    dispatch(unsetUser());
  };

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
    <div className="shadow-sm sticky z-20 top-0 bg-white dark:bg-dark-backgroundLight transition-colors ease-linear flex lg:justify-between text-center w-full h-[90px] py-4 px-9">
      <div className="w-[165px] h-[45px] py-2 flex-1 lg:flex-none">
        <Link href="/">
          <Image width={165} height={45} src={A2SVLogo} alt="A2SV Logo" />
        </Link>
      </div>
      <nav className="hidden lg:flex list-none py-4 px-9">
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/'
              ? 'text-blue-500 pb-8 border-b-[4px] border-blue-500 rounded-sm'
              : ' text-[#565656] dark:text-dark-textColor-100'
          }`}
        >
          <Link href="/">Home</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/teams'
              ? 'text-blue-500 pb-8 border-b-[4px] border-blue-500 rounded-sm'
              : ' text-[#565656] dark:text-dark-textColor-100'
          }`}
        >
          <Link href="/teams">Teams</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/stories'
              ? 'text-blue-500 pb-8 border-b-[4px] border-blue-500 rounded-sm'
              : ' text-[#565656] dark:text-dark-textColor-100'
          }`}
        >
          <Link href="/stories">Success Stories</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/about'
              ? 'text-blue-500 pb-8 border-b-[4px] border-blue-500 rounded-sm'
              : ' text-[#565656] dark:text-dark-textColor-100'
          }`}
        >
          <Link href="/about">About Us</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/blog'
              ? 'text-blue-500 pb-8 border-b-[4px] border-blue-500 rounded-sm'
              : ' text-[#565656] dark:text-dark-textColor-100'
          }`}
        >
          <Link href="/blog">Blogs</Link>
        </li>
        <li
          className={`mr-9 font-secondaryFont font-semibold ${
            currentRoute === '/donate'
              ? 'text-blue-500 pb-8 border-b-[4px] border-blue-500 rounded-sm'
              : ' text-[#565656] dark:text-dark-textColor-100'
          }`}
        >
          <Link href="/donate">Get Involved</Link>
        </li>
      </nav>

      {openMenu && (
        <nav
          className={`absolute right-5 w-48 px-4 py-2  mt-12 bg-slate-100 dark:bg-dark-backgroundLight text-left flex flex-col lg:hidden shadow-md`}
          ref={wrapperRef}
        >
          {links
            .filter((link) => {
              if (loginState && ['Login'].includes(link.name)) {
                return false;
              } else if (!loginState && [('Profile', 'Logout')].includes(link.name)) {
                return false;
              }

              return true;
            })
            .map((link: NavProps, index: number) => {
              return <Nav key={index} {...link} />;
            })}
        </nav>
      )}
      <div className="flex gap-2">
        <div className="flex py-4 h-full items-center gap-5">
          <Link
            className="bg-[#264FAD] text-white font-secondaryFont font-bold rounded-lg px-4 py-2 hidden lg:block"
            href="/donate"
          >
            Donate
          </Link>
          {loginState && isClient ? (
            <ProfileDropDown handleSignOut={handleSignOut} />
          ) : (
            <Link
              href="/login"
              className="mr-4 font-secondaryFont font-bold hover:text-primaryColor transition-all ease-linear hidden lg:block  "
            >
              Login
            </Link>
          )}{' '}
        </div>
        <div onClick={handleDarkMode} className="h-full flex items-center justify-center">
          <div className="flex items-center justify-center px-3 py-3 dark:text-dark-textColor-100 hover:bg-dark-background/[0.1] dark:hover:bg-dark-textColor-100/[0.1] transition-all ease-linear rounded-full">
            {colorTheme === 'light' ? (
              <svg
                // onClick={() => handleDarkMode}
                xmlns="http://www.w3.org/2000/svg"
                className="h-6 w-6"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M9.663 17h4.673M12 3v1m6.364 1.636l-.707.707M21 12h-1M4 12H3m3.343-5.657l-.707-.707m2.828 9.9a5 5 0 117.072 0l-.548.547A3.374 3.374 0 0014 18.469V19a2 2 0 11-4 0v-.531c0-.895-.356-1.754-.988-2.386l-.548-.547z"
                />
              </svg>
            ) : (
              <svg
                // onClick={() => handleDarkMode}
                xmlns="http://www.w3.org/2000/svg"
                className="h-6 w-6"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M20.354 15.354A9 9 0 018.646 3.646 9.003 9.003 0 0012 21a9.003 9.003 0 008.354-5.646z"
                />
              </svg>
            )}
          </div>
        </div>
        <button className="text-2xl lg:hidden " onClick={() => setOpenMenu(!openMenu)}>
          {' '}
          {openMenu ? <AiOutlineClose /> : <AiOutlineMenu />}
        </button>
        <div onClick={BackToTop} className={`z-40 transition-all delay-50 ${backToTopState ? 'scale-1' : "scale-0"} fixed bottom-10 right-10 rounded-full bg-primaryColor text-white text-2xl p-4 font-bold cursor-pointer hover:scale-110 shadow-lg shadow-black/30 dark:shadow-white/201`}>
            <AiOutlineArrowUp />
        </div>
      </div>
    </div>
  );
};

export default Header;
