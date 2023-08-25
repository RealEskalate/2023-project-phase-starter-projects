import Image from 'next/image';
import React, { useState, useRef } from 'react';
import _profImage from '@/assets/images/amicosolve.png';
import { AiOutlineSetting, AiOutlineLogout, AiOutlineDown } from 'react-icons/ai';
import { CgProfile } from 'react-icons/cg';
import Link from 'next/link';
import { Nav } from '../header';
import { useClickOutside } from '@/app/hooks/useClickOutside';

const ProfileDropDown = ({
  handleSignOut,
  isLoggedin,
}: {
  handleSignOut: () => void;
  isLoggedin: boolean;
}) => {
  const [openMenu, setOpenMenu] = useState<boolean>(false);

  const data: any = localStorage.getItem('login');
  const user: any = JSON.parse(data);
  const imgURL = user?.userProfile || _profImage;
  console.log(isLoggedin);
  const wrapperRef = useRef(null);
  useClickOutside(wrapperRef, () => {
    setOpenMenu(false);
  });
  return (
    <div
      className="hidden lg:flex items-center justify-center gap-3 bg-white px-2 py-2 rounded-3xl hover:bg-blue-100 cursor-pointer transition-all ease-linear relative  "
      onClick={() => setOpenMenu(!openMenu)}
    >
      <div className="w-10 h-10 overflow-hidden rounded-full">
        <Image src={imgURL} width={60} height={60} alt="user profile pic" className="center" />
      </div>
      {openMenu && (
        <nav
          className={`absolute right-5 top-5 w-48 px-4 py-2  mt-12 bg-slate-100 text-left flex flex-col shadow-md`}
          ref={wrapperRef}
        >
          <Nav href="/profile" name="Profile" isLink={true} />
          <Nav onClick={() => handleSignOut()} name="Logout" isLink={false} />
        </nav>
      )}
    </div>
  );
};

export default ProfileDropDown;
