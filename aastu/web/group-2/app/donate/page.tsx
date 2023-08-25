'use client';

import { useState } from 'react';
import { AiOutlineClose, AiFillHeart, AiFillSecurityScan } from 'react-icons/ai';
import team from '@/assets/images/download.webp';
import Image from 'next/image';
import A2SVLogo from '@/assets/images/Group 39.svg';
import Link from 'next/link';
import supportIcon from '@/assets/images/support1.svg';

type RadioOption = {
  id: string;
  label: string;
};

const radioOptions: RadioOption[] = [
  { id: '300', label: '300' },
  { id: '350', label: '350' },
  { id: '650', label: '650' },
  { id: '1200', label: '1200' },
  { id: '3500', label: '3500' },
  { id: '7000', label: '7000' },
];

const Donate = () => {
  const [selectedOption, setSelectedOption] = useState<string>('');
  const [toggleOption, setToggleChange] = useState<string>('give-once');
  const handleOptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    console.log(event.target.value);
    setSelectedOption(event.target.value);
  };
  const handleToggle = (event: React.ChangeEvent<HTMLInputElement>) => {
    console.log(event.target.value);
    setToggleChange(event.target.value);
  };

  return (
    <div className="h-full w-full top-0 fixed overflow-y-scroll bg-slate-900/70 z-20 flex justify-center items-center flex-wrap pb-4">
        <div>
            <div className="fixed top-0 z-30 right-0 mt-5 mr-5">
                <Link href="/">
                <button className="text-3xl text-blue-700 bg-slate-50 rounded-full flex border-[3px] border-blue-800 justify-center items-center p-2">
                    <AiOutlineClose />
                </button>
                </Link>
            </div>
            <div className="mx-10 lg:w-4/5 lg:mx-auto lg:my-20">
                <div className="grid place-content-center place-items-center grid-cols-1 md:grid-cols-2 gap-10 relative">
                    <div className="h-full rounded-xl md:mt-0 bg-slate-100">
                        <Image src={team} alt="" className="rounded-tr-lg rounded-tl-lg" />
                        <Image src={A2SVLogo} alt="" className="rounded-tr-lg rounded-tl-lg mt-4 ml-4" />
                        <h1 className="font-primaryFont text-2xl font-bold text-primaryColor p-4">
                        {' '}
                        Join us in building a digital bridge
                        </h1>
                        <p className="font-secondaryFont p-4 text-sm">
                        Our students represent just a slice of the untapped tech talent in Africa. Your
                        contribution is an essential part of our efforts to provide these exceptional young
                        people with the opportunities they deserve so they can bring their skills back to
                        their home countries to continue expanding opportunity there by growing Africa’s tech
                        hub potential.{' '}
                        </p>
                        <p className="font-secondaryFont mt-3 p-4">Make your contribution today!</p>
                    </div>
                    <div className="h-full rounded-xl bg-slate-100 p-4">
                        <h1 className="font-primaryFont text-2xl font-bold text-primaryColor w-full flex justify-center mt-2 items-center">
                        <AiFillSecurityScan />
                        <span className="ml-2">Secure donation</span>
                        </h1>
                        <div className="flex justify-center mt-4">
                        <div className="rounded-lg border border-slate-700 flex justify-between w-64 cursor-pointer">
                            <label
                            htmlFor="give-once"
                            className={`w-1/2 flex items-center justify-center border px-4 py-2 ${
                                toggleOption == 'give-once' && 'border-2 border-blue-700'
                            } rounded-lg`}
                            >
                            <input
                                type="radio"
                                id="give-once"
                                name="donation-type"
                                value="give-once"
                                checked={selectedOption === 'give-once'}
                                onChange={handleToggle}
                                className="hidden"
                            />
                            Give Once
                            </label>
                            <label
                            htmlFor="monthly"
                            className={`flex items-center w-1/2 justify-center border px-4 py-2 ${
                                toggleOption == 'monthly' && 'border-2 border-blue-700'
                            } rounded-lg`}
                            >
                            <input
                                type="radio"
                                id="monthly"
                                name="donation-type"
                                value="monthly"
                                checked={selectedOption === 'monthly'}
                                onChange={handleToggle}
                                className="hidden"
                            />
                            <span className="text-l text-pink-400">
                                <AiFillHeart />
                            </span>{' '}
                            Monthly
                            </label>
                        </div>
                        </div>
                        <div className="mx-2">
                        <div className="flex flex-wrap">
                            <div className="flex flex-wrap gap-3 mx-2 justify-center mt-4">
                            {radioOptions.map((option) => (
                                <div key={option.id}>
                                <input
                                    type="radio"
                                    id={option.id}
                                    name="amount"
                                    value={option.id}
                                    className="sr-only"
                                    checked={selectedOption === option.id}
                                    onChange={handleOptionChange}
                                />
                                <label
                                    htmlFor={option.id}
                                    className={`w-20 flex justify-center border px-4 py-2 rounded-lg ${
                                    selectedOption === option.id
                                        ? 'border-blue-500 border-2'
                                        : 'border-gray-300'
                                    }`}
                                >
                                    {option.label}
                                </label>
                                </div>
                            ))}
                            </div>
                        </div>
                        <div className="mt-10 mx-4 flex justify-center">
                            <input
                            type="text"
                            className="py-2 px-4 text-blue-700 font-bold outline-1 outline-blue-800 text-xl bg-transparent border-2 border-gray-300 w-full rounded-md"
                            value={selectedOption}
                            />
                        </div>
                        
                        <Image src={supportIcon} className='h-60 w-60 mx-auto mt-10' alt="donate icon"/>
                        <div className="w-full flex justify-center">
                            <button className="bg-primaryColor px-20 rounded-lg py-2 font-secondaryFont text-l text-white">
                            Donate
                            </button>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  );
};

export default Donate;
