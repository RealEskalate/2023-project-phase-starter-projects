"use client";
import { MouseEventHandler, useEffect, useRef, useState } from "react";
import Image from "next/image";
import { useAuth } from "@/hooks/useAuth";

interface Props {
  imageUrl: string;
}

export default function ProfileAvatar({ imageUrl }: Props) {
  const [popoverVisible, setPopoverVisible] = useState(false);
  const { logoutHandler } = useAuth();
  if (!imageUrl) {
    imageUrl = "/images/avatar.jpg";
  }

  const buttonRef = useRef<HTMLButtonElement>(null);

  const togglePopover = () => {
    setPopoverVisible(!popoverVisible);
  };

  const handleSignOut = () => {
    logoutHandler();
  };

  const handleClickOutside = (event: any) => {
    if (
      buttonRef.current &&
      !buttonRef.current.contains(event.target as Node)
    ) {
      setPopoverVisible(false);
    }
  };

  useEffect(() => {
    document.addEventListener("click", handleClickOutside);

    return () => {
      document.removeEventListener("click", handleClickOutside);
    };
  }, []);

  return (
    <div className="relative" onClick={handleClickOutside}>
      <div className="md:ml-3 md:px-0 px-14 rounded-full h-14 flex justify-center items-center">
        <button onClick={togglePopover} ref={buttonRef}>
          <Image
            width={100}
            height={100}
            className="w-12 h-12 rounded-full"
            src={imageUrl}
            alt="image"
          />
        </button>
      </div>
      <div
        className={`z-10 absolute bg-white divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700 dark:divide-gray-600 ${
          popoverVisible ? "opacity-100" : "opacity-0"
        } dark:text-gray-400 dark:bg-white dark:border-gray-600`}
      >
        <ul
          className="py-2 text-sm text-gray-700 dark:text-gray-800 "
          aria-labelledby="dropdownDelayButton"
        >
          <li>
            <a
              href="/profile/info"
              className="block px-4 py-2 dark:hover:text-gray-500"
            >
              Profile
            </a>
          </li>
          <li>
            <button
              onClick={handleSignOut}
              className="block px-4 py-2 dark:hover:text-gray-500"
            >
              Sign out
            </button>
          </li>
        </ul>
      </div>
    </div>
  );
}
