import React from 'react';
const memberImage = "./images/member.png"


interface TeamMembersProps {
  name: string;
  department: string;
  bio: string;
  socialMedia: any;
  image: string;
}

const TeamMembers: React.FC<TeamMembersProps> = ({
  name,
  department,
  bio,
  socialMedia,
  image,
}) => {
  return (
    <div className="flex flex-col items-center p-12 bg-white shadow-xl shadow-xl-top rounded-lg w-500">
        <div>
        <img
            src={memberImage}
            alt="Profile Image"
            className="rounded-full  w-1/2 mx-auto"
        />
            <h2 className="text-2xl uppercase tracking-widest font-black	 mb-2 text-center">{name}</h2>
            <p className="font-poppins uppercase font-bold text-lg leading-9 tracking-widest text-center text-gray-700">{department}</p>
            <p className=" mt-6 font-poppins text-xl font-normal leading-7 text-center text-[#7D7D7D]">{bio}</p>
            <hr className='mt-4' />
            <div className="mt-4 flex justify-between space-x-4">
                <a
                    key={1}
                    href={socialMedia["linkedin"]}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="text-grey-500 hover:text-blue-700"
                >
                   <img src="./images/linkedin.png" alt="" className='w-8' />
                </a>
                <a
                    key={2}
                    href={socialMedia["facebook"]}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="text-grey-500 hover:text-blue-700"
                >
                   <img src="./images/facebook.png" alt="" className='w-8' />
                </a>
                <a
                    key={3}
                    href={socialMedia["instagram"]}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="text-grey-500 hover:text-blue-700"
                >
                   <img src="./images/instagram.svg" alt="" className='w-8' />
                </a>
        </div>
      </div>
    </div>
  );
};

export default TeamMembers;
