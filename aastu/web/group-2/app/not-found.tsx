'use client';
import Image from 'next/image';
import Link from 'next/link';
import _404 from '../assets/images/404.svg';
function Error({ error, reset }: { error: Error; reset: () => void }) {
  return (
    <html lang="en">
      <body className="overflow-hidden">
        <div className=" bg-white w-screen h-screen overflow-hidden flex justify-center items-center flex-col">
          <h1 className="text-3xl font-bold text-primaryColor">OOPS!</h1>
          <h1 className="text-xl font-bold text-textColor-100 mt-3">Page Not Found</h1>
          <Image src={_404} width={400} height={400} alt="404 Error" />
          <Link
            href="./"
            className="bg-textColor-blue text-white px-6 py-4 rounded-3xl text-xs lg:text-sm font-semibold"
          >
            Go To Home Page
          </Link>
        </div>
      </body>
    </html>
  );
}

export default Error;
