"use client"

import {useState} from "react";
import Image from 'next/image'

import MemberCard from "@/components/teams/MemberCard";
import {useGetMembersQuery} from "@/store//blogs/BlogApi";


export default function Teams(){

    const [page, setPage] = useState(1)
    const {data: members, error, isLoading} = useGetMembersQuery()

    const goToPage = (pageNumber: number) => {
        setPage(pageNumber);
        ScrollButton();
    };

    const ScrollButton = () => {
        const scrollToContent = () => {
            const targetContentElement = document.getElementById('targetContent');

            if (targetContentElement) {
                const targetPosition = targetContentElement.getBoundingClientRect().top + window.scrollY;

                window.scrollTo({
                    top: targetPosition,
                    behavior: 'smooth',
                });
            }
        };
    }



    if (isLoading){

        return (
            <div className="flex justify-center items-center">
                <div
                    className="inline-block h-60 w-60 animate-spin rounded-full border-8 border-solid border-current border-r-transparent align-[-0.125em] motion-reduce:animate-[spin_1.5s_linear_infinite]"
                    role="status">
                  <span
                      className="!absolute !-m-px !h-px !w-px !overflow-hidden !whitespace-nowrap !border-0 !p-0 ![clip:rect(0,0,0,0)]"
                  >Loading...</span>
                </div>
            </div>

        )
    }
    if (error){
        return <div
            className="mb-3 inline-flex w-full items-center rounded-lg bg-danger-100 px-6 py-5 text-base text-danger-700"
            role="alert">
              <span className="mr-2">
                <svg
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 24 24"
                    fill="currentColor"
                    className="h-5 w-5">
                  <path
                      fill-rule="evenodd"
                      d="M12 2.25c-5.385 0-9.75 4.365-9.75 9.75s4.365 9.75 9.75 9.75 9.75-4.365 9.75-9.75S17.385 2.25 12 2.25zm-1.72 6.97a.75.75 0 10-1.06 1.06L10.94 12l-1.72 1.72a.75.75 0 101.06 1.06L12 13.06l1.72 1.72a.75.75 0 101.06-1.06L13.06 12l1.72-1.72a.75.75 0 10-1.06-1.06L12 10.94l-1.72-1.72z"
                      clip-rule="evenodd" />
                </svg>
              </span>
            Error while fetching data
        </div>
    }

    if (members){
        const numberOfPages = Math.floor(members.length/5);
        const rangeArray = Array.from({ length: numberOfPages }, (_, index) => index);
        const indexOfLastItem = page * 6;
        const indexOfFirstItem = indexOfLastItem - 6;
        const currentItems = members.slice(indexOfFirstItem, indexOfLastItem);


        return <div className="w-full font-cards pb-16 pt-14">
            <div className="grid md:grid-cols-2 grid-cols-1 pt-3 w-full items-center">
                <div className="w-[80%] -mt-16 mb-12 md:space-y-7 text-left pl-12 md:justify-self-end">
                    <h1 className="text-6xl font-bold -md:text-3xl">
                        The team we’re currently
                        working with
                    </h1>
                    <p className="text-xl">
                        Meet our development team is a small but highly skilled and experienced group of professionals. We have a talented mix of web developers, software engineers, project managers and quality assurance specialists who are passionate about developing exceptional products and services.
                    </p>
                </div>
                <Image className="w-[100%] p-6 float-right" width={100} height={100} src="/images/blog/landing%20image%20area.png" alt={"teams hero image"} />

            </div>
            <div id="MembersContainer" className="grid md:grid-cols-3 grid-cols-1 gap-2 px-20">
                {
                    currentItems.map((member)=>{
                        return (
                            <MemberCard key={member._id} member={member}/>
                        )
                    })
                }
            </div>
            <div className="flex justify-center gap-6 mt-20">
                {
                    rangeArray.map((num)=>{
                        return <button key={num} onClick={()=>{ goToPage(num + 1)}} className={(page==num+1)? "bg-blue-800 text-white rounded-lg border-none w-[40px] h-[40px]":"bg-gray-300 text-black rounded-lg border-none w-[40px] h-[40px]"}>
                            {num+1}
                        </button>}
                    )
                }
            </div>

        </div>
    }

}