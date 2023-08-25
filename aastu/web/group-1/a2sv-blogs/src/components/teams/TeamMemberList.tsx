"use client"

import TeamMemberCard from "./TeamMemberCard"; 
import { useState, useEffect } from "react";
import { TeamMember } from "@/types/TeamMember";
import PaginationButtons from "./PaginationButtons";

export async function fetchMembers(){
  const res = await fetch("https://a2sv-backend.onrender.com/api/members");
  return await res.json();
}

export default function TeamMemberList() {
  const [members, setMembers] = useState<TeamMember[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 6;

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  }

  useEffect(() => {
    const fetchData = async() => {
      const data = await fetchMembers();
      setMembers(data);
    }
    fetchData();
  }, [])
  
  const startIndex = (currentPage - 1) * pageSize;
  const endIndex = startIndex + pageSize;
  const currentMembers = members.slice(startIndex, endIndex);

  return (
    <div>
    <div className="flex flex-wrap justify-center">
      {currentMembers.map(member => (
        <TeamMemberCard key={member.id} member={member} />  
      ))}

     
    </div>
     <PaginationButtons
     currentPage={currentPage}
     totalPages={Math.ceil(members.length / pageSize)}
     setCurrentPage={handlePageChange}  
   />
    </div>
  );

}