"use client"

import {useState} from "react";
import Image from 'next/image'

import MemberCard from "@/components/teams/MemberCard";
import {useGetMembersQuery} from "@/store/features/blog/blog-api";
import Loading from "@/components/common/Loading";


export default function Teams(){

    const [page, setPage] = useState(1)
    const {data: members, isLoading} = useGetMembersQuery()

    const goToPage = (pageNumber: number) => {
        setPage(pageNumber);
    };

    if(isLoading){
        return <Loading/>
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
                <Image className="w-[100%] p-6 float-right" width={400} height={200} src="/images/blog/landing%20image%20area.png" alt={"teams hero image"} />

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