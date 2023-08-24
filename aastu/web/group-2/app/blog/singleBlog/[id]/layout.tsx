import Image from 'next/image';
import React from 'react';
import arrowBack from '@/assets/images/arrowLeft.svg';
import Link from 'next/link';
import { AiOutlineLeft } from 'react-icons/ai';

const layout = ({ children }) => {
  return (
    <div>
      <Link
        href="../"
        className="ml-10 mt-10 flex items-center font-medium hover:text-primaryColor transition-all ease-linear "
      >
        <AiOutlineLeft /> Go Back
      </Link>
      {children}
    </div>
  );
};

export default layout;
