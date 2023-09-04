import { footerBLogLinks, footerLinks } from "@/types/footerNav/footerNav";
import Image from "next/image";
import Link from "next/link";
import React from "react";

const Footer = () => {
  return (
    <section className="bg-white mx-1 flex justify-center flex-col items-center border-t-[1px] mb-2 mt-5 font-Montserrat py-14">
      <div className=" w-[90%] p-5  flex justify-around gap-4 flex-col md:flex-row  ">
        {/* image for desktop */}
        <div className=" hidden md:block flex w-[20%]  justify-center items-center ">
          <Image
            width={450}
            height={200}
            src="/assets/footer.svg"
            alt="My Image"
          />
        </div>

        {/* image for mobile */}
        <div className="  md:hidden flex w-full  justify-center items-center">
          <Image
            width={450}
            height={200}
            src="/assets/footer.svg"
            alt="My Image"
          />
        </div>

        {/* for text */}
        <div className="w-full md:w-[25%] font-bold my:8 md:my-0  py-3 flex gap-y-10 justify-center items-center flex-col ">
          <p className=" m-1">
            Get involved in improving tech education in Africa!
          </p>

          <button className="rounded-lg bg-primary  text-white w-3/4   py-2">
            Support Us
          </button>
        </div>

        {/* for links */}
        <section className="  w-full md:w-[55%] flex  justify-between md:justify-around  items-start  flex-wrap flex-row  py-5 md:py-2 gap-y-10">
          {/* Links */}
          <div className=" flex justify-center flex-col font-light gap-y-5">
            <p className="font-semibold ">Links</p>
            {footerLinks.map((link) => (
              <Link
                key={link.linkName}
                href={link.linkPath}
                className="hover:font-semibold transition ease-in-out duration-200"
              >
                {link.linkName}
              </Link>
            ))}
          </div>

          {/* Teams */}
          <div className=" flex justify-center flex-col font-light gap-y-5">
            <p className="font-semibold">Teams</p>
            {footerBLogLinks.map((link) => (
              <Link
                key={link.linkName}
                href={link.linkPath}
                className="hover:font-semibold transition ease-in-out duration-200"
              >
                {link.linkName}
              </Link>
            ))}
          </div>

          {/* Blogs */}
          <div className=" flex justify-center flex-col font-light gap-y-5">
            <p className=" font-semibold">Blogs</p>
            {footerBLogLinks.map((link) => (
              <Link
                key={link.linkName}
                href={link.linkPath}
                className="hover:font-semibold transition ease-in-out duration-200"
              >
                {link.linkName}
              </Link>
            ))}
          </div>
        </section>
      </div>

      {/* copyright */}
      <div className="w-[98%] md:border-t-2 pb-4 md:py-8   mx-auto flex  mt-5 flex-col md:flex-row justify-between gap-y-5  ">
        <div className="flex justify-start">
          <Image
            width={15}
            height={15}
            alt="copyright image"
            src={"/assets/copyright.svg"}
          />
          <p className="text-sm md:text-base">
            2020 Africa to Silicon Valley, Inc. All right reserved.
          </p>{" "}
        </div>

        <p className="flex justify-center md:justify-end gap-x-8   ">
          <Image
            width={25}
            height={25}
            alt="twitter image"
            src={"/assets/twitter.svg"}
          />
          <Image
            width={25}
            height={25}
            alt="facebook image"
            src={"/assets/facebook.svg"}
          />
          <Image
            width={25}
            height={25}
            alt="youtube image"
            src={"/assets/youtube.svg"}
          />
          <Image
            width={25}
            height={25}
            alt="linkedin image"
            src={"/assets/linkedin.svg"}
          />
          <Image
            width={25}
            height={25}
            alt="instagram image"
            src={"/assets/instagram.svg"}
          />
        </p>
      </div>
    </section>
  );
};

export default Footer;
