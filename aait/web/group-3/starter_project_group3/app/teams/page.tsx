"use client";
import HeadLineSection from "@/components/team/HeadLineSection";
import Pagination from "@/components/team/Pagination";
import { teams } from "@/data/team/Teams";
import Image from "next/image";
import Link from "next/link";
import { useState } from "react";

const Teams: React.FC = () => {
  const itemsPerPage = 6;
  const [currentPage, setCurrentPage] = useState(1);
  const indexOfLast = currentPage * itemsPerPage;
  const indexOfFirst = indexOfLast - itemsPerPage;

  const currentTeam = teams.slice(indexOfFirst, indexOfLast);
  const totalPages = Math.ceil(teams.length / itemsPerPage);

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  return (
    <div className="flex flex-col items-center mx-8 md:mx-20 gap-36 font-Poppins">
      <HeadLineSection />
      <hr className="w-full" />
      {/* <div className="flex flex-row gap-4 flex-wrap justify-center "> */}
      <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-4">
        {currentTeam.map((team) => (
          <div className="flex flex-col gap-6 shadow-lg items-center border-2 p-6">
            <Image src={team.imageUrl} width={100} height={100} alt="teams" />
            <div className="flex flex-col gap-2 justify-center text-center">
              <p className="font-bold  text-2xl">{team.name}</p>
              <p className="font-semibold text-lg">{team.role}</p>
            </div>
            <p>{team.description}</p>
            <hr className="w-full" />
            <div className="flex justify-between w-full">
              <Link href={"#"}>
                <Image
                  src="/assets/facebook.svg"
                  width={30}
                  height={30}
                  alt="social media"
                />
              </Link>

              <Link href={"#"}>
                <Image
                  src="/assets/linkedin.svg"
                  width={30}
                  height={30}
                  alt="social media"
                />
              </Link>

              <Link href={"#"}>
                <Image
                  src="/assets/instagram.svg"
                  width={30}
                  height={30}
                  alt="social media"
                />
              </Link>
            </div>
          </div>
        ))}
      </div>

      <div className="mb-16 -mt-16 flex justify-center">
        <Pagination
          currentPage={currentPage}
          totalPages={totalPages}
          onPageChange={handlePageChange}
          className="pagination"
        />
      </div>
    </div>
  );
};

export default Teams;
