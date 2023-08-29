"use client";
import Link from "next/link";
import { useState } from "react";
import data from "@/data/profile.json";

const ProfileHeader = () => {

  const [activeLink, setActiveLink] = useState(0);

  const {headerData} = data;

  return (
    <>
      <div className="flex flex-col">
        <h1 className="text-3xl mb-12 md:text-4xl">Profile</h1>
        {/* Profile Navbar */}
        <div className="flex justify-between  border-b">
          <nav className="flex justify-start gap-12">
            {headerData.map((link, i) => (
              <div>
                <Link
                  key={i}
                  href={link.link}
                  className={`text-[#494949] text-sm md:text-xl font-semibold ${
                    activeLink === i ? "text-primary-color" : ""
                  }`}
                  onClick={() => setActiveLink(i)}
                >
                  {link.name}
                </Link>
                <hr
                  className={`${
                    activeLink !== i && "hidden"
                  } mt-4 border-2 border-primary-color rounded-full`}
                />
              </div>
            ))}
          </nav>
          {activeLink === 1 && (
            <button className=" hidden px-10 py-2 text-white mb-1 rounded-lg bg-primary-color md:block">
              New blog
            </button>
          )}
        </div>
        {/* manage section */}
        <div className="flex flex-col items-center md:items-stretch space-y-4 py-8 border-b md:py-12 md:space-y-2">
          <div className="flex justify-between">
            <h2 className=" text-slate-gray text-lg font-semibold md:text-2xl">
              Manage {headerData[activeLink].manageText}
            </h2>
            {activeLink !== 1 && (
              <button className="hidden px-8 py-4 text-xs text-white font-semibold rounded-lg bg-primary-color md:text-sm md:block">
                Save Changes
              </button>
            )}

          </div>
          <p className="text-medium-gray text-sm md:text-xl">{headerData[activeLink].manageDetail}</p>
          {activeLink !== 1 && (
            <button className="px-5 py-4 text-xs text-white font-semibold rounded-lg bg-primary-color md:hidden">
              Save Changes
            </button>
          )}
          {activeLink === 1 && (
            <button className="px-10 py-2 text-white mb-1 w-fit rounded-lg bg-primary-color md:hidden">
              New blog
            </button>
          )}
        </div>
        
      </div>
    </>
  );
};

export default ProfileHeader;