"use client";
import React, { useState } from 'react';
import Link from 'next/link';

interface HeaderProps {
  title?: string;
}

const Header: React.FC<HeaderProps> = ({ title }) => {
    const [showMenu, setShowMenu] = useState(false);

    const toggleMobileMenu = () => {
        setShowMenu(!showMenu);
      };

      
  return (
    <>
    <nav className="bg-white fixed top-0 left-0 right-0 z-50">
			<div className="max-w-8xl mx-auto px-4">
				<div className="flex justify-between">
					<div className="flex items-start space-x-7">
						<div>
							<a href="#" className="flex items-center py-4 px-2">
								<img src="./images/a2svlogo.png" alt="Logo" className=" h-7 mr-2"/>
							</a>
						</div>
					</div>
                    <div className="hidden lg:flex justify-between items-center space-x-1 mx-auto">
							<a href="" className="py-4 px-2 mr-5 text-blue-700 border-b-4 border-blue-700 font-semibold ">Home</a>
							<Link href="/teams" className="py-4 px-2 mr-5 text-gray-500 font-semibold hover:text-blue-700 transition duration-300">Teams</Link>
							<a href="" className="py-4 px-2 mr-5 text-gray-500 font-semibold hover:text-blue-700 transition duration-300">Success Stories</a>
							<a href="" className="py-4 px-2 mr-5 text-gray-500 font-semibold hover:text-blue-700 transition duration-300">About Us</a>
							<Link href="/blogs" className="py-4 px-2 mr-5 text-gray-500 font-semibold hover:text-blue-700 transition duration-300">Blogs</Link>
							<a href="" className="py-4 px-2 mr-5 text-gray-500 font-semibold hover:text-blue-700 transition duration-300">Get Involved</a>
					</div>
					<div className="hidden lg:flex items-center space-x-3 ">
						<a href="" className="py-2 px-2 font-medium rounded hover:text-gray-500 transition duration-300">Log In</a>
						<a href="" className="py-2 px-2 font-medium text-white bg-blue-700 rounded hover:bg-blue-900 transition duration-300">Donate</a>
					</div>
					<div className="lg:hidden flex items-center">
						<button className="outline-none mobile-menu-button" onClick={toggleMobileMenu}>
						<svg className=" w-6 h-6 text-gray-500 hover:text-blue-700 "
							x-show="!showMenu"
							fill="none"
							strokeLinecap="round"
							strokeLinejoin ="round"
							strokeWidth="2"
						
							viewBox="0 0 24 24"
							stroke="currentColor"
						>
							<path d="M4 6h16M4 12h16M4 18h16"></path>
						</svg>
					</button>
					</div>
				</div>
			</div>
			<div className={`mobile-menu lg:hidden ${showMenu ? '' : 'hidden'}`}>
				<ul className="">
					<li className="active"><a href="index.html" className="block text-sm px-2 py-4 text-white bg-blue-700 font-semibold">Home</a></li>
					<li><a href="#services" className="block text-sm px-2 py-4 hover:bg-blue-700 transition duration-300">Services</a></li>
					<li><a href="#about" className="block text-sm px-2 py-4 hover:bg-blue-700 transition duration-300">About</a></li>
					<li><a href="#contact" className="block text-sm px-2 py-4 hover:bg-blue-700 transition duration-300">Contact Us</a></li>
				</ul>
			</div>
		</nav>
        </>
  );
};

export default Header;