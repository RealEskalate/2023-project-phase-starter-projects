"use client";

import { useState, useEffect } from "react";
import { TeamMember } from "@/types/TeamMember";
import PaginationButtons from "./PaginationButtons";
import TeamMemberCard from "./TeamMemberCard";
import { useGetTeamsQuery } from "@/lib/redux/features/teams";
import LoadingSkeleton from "./LoadingSkeleton";

export default function TeamMemberList() {
  const pageSize = 6;
  const [currentPage, setCurrentPage] = useState(1);

  const { data: teams, isLoading, error } = useGetTeamsQuery();

  if (isLoading) {
    const loadingSkeletons = Array.from({ length: pageSize }, (_, index) => (
      <LoadingSkeleton key={index} />
    ));

    return (
      <div className="container mx-auto px-4 md:px-0">
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
          {loadingSkeletons}
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="text-2xl text-gray-500 text-center">
        Error fetching data
      </div>
    );
  }

  const startIndex = (currentPage - 1) * pageSize;
  const endIndex = startIndex + pageSize;
  const currentMembers = teams!.slice(startIndex, endIndex);

  return (
    <div className="container mx-auto px-4 md:px-0">
      <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        {currentMembers.map((member) => (
          <TeamMemberCard key={member.id} member={member} />
        ))}
      </div>
      <PaginationButtons
        currentPage={currentPage}
        totalPages={Math.ceil(teams.length / pageSize)}
        setCurrentPage={setCurrentPage}
      />
    </div>
  );
}
