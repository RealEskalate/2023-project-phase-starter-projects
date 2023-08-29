'use client';

import React from 'react';
import { usePathname } from 'next/navigation';
import Link from 'next/link';

export default function ProfileLayout({
  children,
}: {
  children: React.ReactNode
}) {
  const links: string[] = [ 'Personal Information', 'My Blogs', 'Account Setting' ];
  const linkPathname = new Map<string, string>([
    ['Personal Information', '/profile'],
    ['My Blogs', '/profile/my-blogs'],
    ['Account Setting', '/profile/account']
  ]);
  const pathname = usePathname();

  return (
    <div className='px-[100px] flex flex-col space-y-5 font-montserrat'>
      <h1 className='text-[22px] font-semibold'>Profile</h1>
      <div className={ `flex justify-between items-center text-md border-b ${ pathname === '/profile/my-blogs' ? 'pb-2' : 'pb-4' }` }>
        <div className='flex space-x-10 text-[12px] text-[#494949] font-semibold'>
          {
            // links.map(link => <h3 className={ pathname === linkPathname.get(link) && `border-b-2 border-[#264FAD] -mb-5` } >{ link }</h3>)
            links.map(link => (
              <Link
                href={ linkPathname.get(link) as string }
                className={
                  pathname === linkPathname.get(link) ? 'border-b-2 border-[#264FAD] -mb-4' : ''
                }
              >{ link }</Link>
            ))
          }
        </div>
        { pathname === linkPathname.get('My Blogs') && <button className='text-[10px] font-semibold bg-[#264FAD] rounded-md text-white px-12 py-2'>New Blog</button> }
      </div>
      { children }
    </div>
  );
}







// import React, { ReactNode } from 'react';

// interface PropsInterface {
//   children: ReactNode;
// }

// const ProfileLayout: React.FC<PropsInterface> = ({ children }) => {
//   return (
//     <div>
//       <h1>This is Persitent layout accross components.</h1>
//       { children }
//     </div>
//   );
// }

// export default ProfileLayout;
