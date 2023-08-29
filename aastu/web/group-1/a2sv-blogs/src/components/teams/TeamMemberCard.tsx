import React from "react";
import { FaLinkedin, FaFacebook, FaInstagram } from "react-icons/fa";
import Image from "next/image";
import { TeamMember } from "@/types/TeamMember";

interface props {
  member: TeamMember;
}

const TeamMemberCard: React.FC<props> = ({ member }) => {
  return (
    <div className="w-full h-[460px] rounded-[12px] bg-white shadow-lg mt-5 sm:w-full">
      <div className="text-center py-5">
        <Image
          className="w-[150px] h-[150px] rounded-full mx-auto bg-gray-300"
          width={150}
          height={150}
          src="/images/profile_.png"
          alt={member.name}
        />
      </div>

      <div className="text-center py-2">
        <div className="font-poppins font-bold text-xl leading-tight tracking-widest text-gray-800">
          {member.name}
        </div>

        <div className="text-gray-800 font-poppins font-normal text-base">
          {member.department}
        </div>

        <div className="mt-4 text-gray-400 text-center font-poppins text-sm px-2">
          {member.bio}
        </div>
      </div>

      <div className="text-center pt-20">
        <hr className="border-gray-200" />
      </div>

      <div className="flex justify-evenly pt-4">
        <a href={member.socialMedia.linkedin}>
          <FaLinkedin size={30} color="#9CA3AF" />
        </a>

        <a href={member.socialMedia.facebook} className="pl-4">
          <FaFacebook size={30} color="#9CA3AF" />
        </a>

        <a href={member.socialMedia.instagram} className="pl-4">
          <FaInstagram size={30} color="#9CA3AF" />
        </a>
      </div>
    </div>
  );
};

export default TeamMemberCard;
