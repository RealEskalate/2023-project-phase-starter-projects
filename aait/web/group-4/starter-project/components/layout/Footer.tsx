import React from "react";
import Link from "next/link";
import Image from "next/image";

const Footer: React.FC = () => {
  const baseURL = "/images/common";

  let socialMedia: string[] = [
    `${baseURL}/facebook.png`,
    `${baseURL}/linkedin.png`,
    `${baseURL}/instagram.png`,
    `${baseURL}/twitter.png`,
    `${baseURL}/youtube.png`,
  ];
  return (
    <footer className="flex flex-col pt-16 border-t-2 px-20 pb-10 font-{montserrat} ">
      <div className="text-left grid place-items-center grid-cols-1 lg-1:grid-cols-5 md:grid-cols-2 border-b-2 pb-10 md: gap-12">
        <div className="flex flex-col w-56 lg-1:w-full">
          <Image
            src="/images/common/rafiki.png"
            objectFit="cover"
            width={400}
            height={400}
            alt="Helping a partner"
          />
        </div>
        <div className="flex text-left items-center flex-col gap-8">
          <p className=" font-semibold text-center text-[20px]">
            Get involved in improving tech education in Africa!
          </p>
          <button className="px-2 py-3 w-2/3 font-bold rounded-lg border-none bg-blue-800 text-white">
            Support Us
          </button>
        </div>
        <div className="flex flex-col gap-6">
          <h3 className="font-semibold text-lg">Links</h3>
          <ul className="flex flex-col gap-6 font-light">
            <li>
              <Link href="/">Home</Link>
            </li>
            <li>
              <Link href="/success-stories">Success Stories</Link>
            </li>
            <li>
              <Link href="/about">About Us</Link>
            </li>
            <li>
              <Link href="/get-involved">Get Involved</Link>
            </li>
          </ul>
        </div>
        <div className="flex flex-col gap-6">
          <h3 className="font-semibold text-lg">Teams</h3>

          <ul className="flex flex-col gap-6 font-light">
            <li>
              <a href="https://a2sv.org/board">Board Members</a>
            </li>
            <li>
              <a href="https://a2sv.org/advisors">Advisors/Mentors</a>
            </li>
            <li>
              <a href="https://a2sv.org/executives">Executives</a>
            </li>
            <li>
              <a href="https://a2sv.org/staff">Staffs</a>
            </li>
          </ul>
        </div>
        <div className="flex flex-col gap-6">
          <h3 className="font-semibold text-lg">Blogs</h3>

          <ul className="flex flex-col gap-6 font-light">
            <li>
              <Link href="#">Recent Blogs</Link>
            </li>
            <li>
              <Link href="#">New Blog</Link>
            </li>
          </ul>
        </div>
      </div>
      <div className="flex flex-col justify-between items-center gap-8 md:flex-row pt-10">
        <p className="font-light order-last md:order-first">
          &copy; 2020 Africa to Silicon Valley, Inc. All right reserved.
        </p>
        <div className="flex gap-5 justify-center items-end md:justify-end ">
          {socialMedia.map((link: string, i) => {
            return (
              <a href="http://www.fb.com" key={i}>
                <img className="w-[20px] h-[20px]" src={link} />
              </a>
            );
          })}
        </div>
      </div>
    </footer>
  );
};

export default Footer;
