import React from 'react';
import { FaLinkedin, FaFacebook, FaInstagram } from 'react-icons/fa';
import Image from 'next/image';
import { TeamMember } from '@/types/TeamMember';

interface props {
  member : TeamMember;
}

const TeamMemberCard: React.FC<props> = ({member}) => {
  console.log(member)

  return (
    <div className="w-[400px] h-[600px] rounded-[12px] bg-white shadow-lg ml-2"> 
    <div className=' pl-[120px] pt-5'>
    <Image 
        className="w-[150px] h-[150px] rounded-full absolute bg-gray-300"
        width={500}
        height={600}
        src={member.imageUrl}
        alt={member.name}  
      />

    </div>
      
      <div className='mt-[180px]'>
      <div className=" pl-[90px] w-[300px] h-[51px] absolute font-poppins font-bold text-xl leading-tight tracking-widest text-center ">
        {member.name}
      </div>

      <div className="pl-[110px] pt-8 text-base absolute text-gray-800 font-poppins font-normal leading-tight tracking-widest text-center">
        {member.department}
      </div>

      <div className=" mt-20 pl-10 w-[350px] h-[396px] absolute text-gray-400 text-center leading-tight font-poppins text-sm">
        {member.bio}
      </div>

      </div>

      <div className='pl-5 pr-5 text-gray-50 mt-[500px]'>
      <hr />
      </div>
      
      
      <div className="flex pl-[100px] w-[250px] h-[40px] justify-between absolute mt-[20px]">
        <a href={member.socialMedia.linkedin} >
        <FaLinkedin size={30} color="#9CA3AF" /> 
        </a>

        <a href={member.socialMedia.facebook} className='pl-14'>

        <FaFacebook size={30} color="#9CA3AF" />
        </a>
        
        <a href={member.socialMedia.instagram} className='pl-14'>
        <FaInstagram size={30} color="#9CA3AF" />
        </a>
     </div>
    </div>
  );
}

export default TeamMemberCard;