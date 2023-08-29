"use client";

import React, {useState, useEffect} from 'react';
import TeamMembers  from "@/components/teams/TeamMembers";

const landingImage = "./images/landing image area.png"
const memberImage = "./images/member.png"
interface TeamMemberData {
  name: string;
  department: string;
  bio: string;
  socialMedia: SocialMediaLink[];
  image: string;
}

interface SocialMediaLink {
  url: string;
  icon: string;
}

// interface TeamProps {
//   members: TeamMemberData[];
// }

const Headers: React.FC = () => {
  const [members, setMembers] = useState<TeamMemberData[]>([]);

  useEffect(() => {
    fetch('https://a2sv-backend.onrender.com/api/members') // Replace with your API endpoint
      .then(response => response.json())
      .then(data => setMembers(data))
      .catch(error => console.error('Error fetching blogs:', error));
  }, []);
  // const members: TeamMemberData[] = [
    
   
  //   {
  //     name: 'Nathaniel Awel',
  //     department: 'Software Engineer',
  //     bio: 'He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.',
  //     socialMedia: [
  //       { url: 'https://twitter.com/johndoe', icon: "./images/linkedin.png" },
  //       { url: 'https://linkedin.com/in/johndoe', icon: './images/facebook.png' },
  //       { url: 'https://linkedin.com/in/johndoe', icon: './images/instagram.svg' },
  //     ],
  //     image: memberImage,
  //   },
  // ];
  
  return (
    <>
    {/* hero section start */}
    <div className="flex mt-40">
      <div className="w-1/2 pt-16 ml-24">
        <h1 className='uppercase text-[#363636] font-poppins font-bold	 text-4xl md:text-5xl lg:text-5xl leading-150 md:leading-160 lg:leading-[70px]'>The team we’re currently <br />working with</h1>
       <div className='mt-4'>
          <p className='font-poppins font-normal text-base md:text-lg lg:text-2xl lg:leading-[30px] text-[#7D7D7D]'>Meet our development team is a small but highly skilled and experienced group of professionals. We have a talented mix of web developers, software engineers, project managers and quality assurance specialists who are passionate about developing exceptional products and services.</p>
        </div> 
      </div>
      <div className="w-1/2">
        <img src={landingImage}  alt="" />
        
      </div>
      </div>
      {/* hero section end */}
      <div className=" mx-auto py-30">
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6 items-center p-10">
      {members.map((member, index) => (
        <TeamMembers
          key={index}
          name={member.name}
          department={member.department}
          bio={member.bio}
          socialMedia={member.socialMedia}
          image={member.image}
        />
      ))}
        
      {/* <ReactPaginate
        previousLabel={'Previous'}
        nextLabel={'Next'}
        pageCount={pageCount}
        onPageChange={handlePageChange}
        containerClassName={'pagination'}
        activeClassName={'active'}
      /> */}
      </div>
      <div className="flex justify-center mb-40">
            <button className='mr-4  px-3 py-1 text-white bg-blue-700 rounded'>1</button>
            <button className='mr-4  px-3 py-1 text-black bg-[#E1E7EC] rounded'>2</button>
            <button className='mr-4  px-3 py-1 text-black bg-[#E1E7EC] rounded'>3</button>
            <button className='mr-4  px-3 py-1 text-black bg-[#E1E7EC] rounded'>4</button>
            <button className='mr-4  px-3 py-1 text-black bg-[#E1E7EC] rounded'>5</button>
        </div>
    </div>
      {/* Members section start */}

      <div>

      </div>

      {/* Members section end */}




    </>
  );
};

export default Headers;
