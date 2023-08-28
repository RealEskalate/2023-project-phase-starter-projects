'use client';
import Image from 'next/image';
import Link from 'next/link';
import _500 from '../assets/images/500.svg';
function GlobalError({ error, reset }: { error: Error; reset: () => void }) {
  return (
    <html lang="en">
      <body className="overflow-hidden">
        <div className=" bg-white w-screen h-screen overflow-hidden flex justify-center items-center flex-col">
          <h1 className="text-3xl font-bold text-primaryColor">OOPS!</h1>
          <h1 className="text-xl font-bold text-textColor-100 mt-3">Internal Server Error</h1>
          <p className="my-4 text-textColor-100">{error?.props}</p>
          <Image src={_500} width={400} height={400} alt="404 Error" />
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

export default GlobalError;
