'use client';
import Link from 'next/link';
import Image from 'next/image';
import twitter from '@/assets/images/twitter.svg';
import facebook from '@/assets/images/facebook.svg';
import youtube from '@/assets/images/youtube.svg';
import linkedin from '@/assets/images/linkedin.svg';
import instagram from '@/assets/images/instagram.svg';
import helpingPartner from '@/assets/images/helpingPartner.svg';

const Footer = () => {
  return (
    <div className="grid mt-auto">
      <div className="grid grid-cols-1 mx-auto h-full lg:grid-cols-[4fr_7fr_5fr_7fr_4fr] lg:h-[250px] pl-[55px] py-[40px]  border-t-[#C7C7C7] dark:border-dark-backgroundLight border-t-[0.4px]">
        <div className='hidden lg:block w-[160px] h-[160px] pb-2'>
          <Image src={helpingPartner} width={200} height={200} alt="Helping a Partner" />
        </div>
        <div className='text-center mr-8 lg:ml-4' >
            <p className='font-secondaryFont font-semibold mt-8 mb-4  dark:text-dark-textColor-50'>Get involved in improving tech education in Africa!</p>
            <Link className='bg-[#264FAD] text-white font-secondaryFont font-bold rounded-lg px-8 py-2 mt-4' href='/donate'>Support Us</Link>
        </div>
        <div>
            <nav className='hidden lg:block ml-22 list-none font-secondaryFont text-sm'>
                <p className='font-semibold'>Links</p>
                <li className='font-light mt-4'><Link href='/'>Home</Link></li>
                <li className='font-light mt-4'><Link href='/stories'>Success Stories</Link></li>
                <li className='font-light mt-4'><Link href='/about'>About Us</Link></li>
                <li className='font-light mt-4'><Link href='/donate'>Get Involved</Link></li>
            </nav>
        </div>
        <div>
        <nav className='hidden lg:block ml-[40px] list-none font-secondaryFont text-sm'>
                <p className='font-semibold'>Teams</p>
                <li className='font-light mt-4'><Link href=''>Board Members</Link></li>
                <li className='font-light mt-4'><Link href=''>Advisor/Mentors</Link></li>
                <li className='font-light mt-4'><Link href=''>Executives</Link></li>
                <li className='font-light mt-4'><Link href=''>Staffs</Link></li>
            </nav>
        </div>
        <div>
        <nav className='hidden lg:block ml-22 list-none font-secondaryFont text-sm'>
                <p className='font-semibold'>Blogs</p>
                <li className='font-light mt-4'><Link href='/blog'>Recent Blogs</Link></li>
                <li className='font-light mt-4'><Link href='/blog'>New Blog</Link></li>
            </nav>
        </div>
      </div>

      <div className="flex flex-col-reverse items-center lg:flex-row justify-between px-[40px] py-[35px] border-t-[#C7C7C7] dark:border-dark-backgroundLight border-t-[0.4px]">
        <div className="mt-8 md:font-secondaryFont font-light text-base text-center">
          <span className="text-xl text-[#555555]">&copy;</span> 2020 Africa to Silicon Valley ,
          Inc. All right reserved.
        </div>
        <div className="flex h-[20px] w-[280px] list-none items-center justify-between">
          <li className="ml-8">
            <Link href="#">
              <Image width={800} height={800} src={twitter} alt="twitter logo" />
            </Link>
          </li>
          <li className="ml-8">
            <Link href="#">
              <Image width={800} height={800} src={facebook} alt="twitter logo" />
            </Link>
          </li>
          <li className="ml-8">
            <Link href="#">
              <Image width={800} height={800} src={youtube} alt="twitter logo" />
            </Link>
          </li>
          <li className="ml-8">
            <Link href="#">
              <Image width={800} height={800} src={linkedin} alt="twitter logo" />
            </Link>
          </li>
          <li className="ml-8">
            <Link href="#">
              <Image width={800} height={800} src={instagram} alt="twitter logo" />
            </Link>
          </li>
        </div>
      </div>
    </div>
  );
};

export default Footer;
