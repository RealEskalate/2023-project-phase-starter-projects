import React from "react";
import Image from 'next/image'

import Member from "@/types/teams/Member";
import SocialMedia from "@/types/teams/SocialMedia";

interface MemberProps {
    member: Member
}

const MemberCard: React.FC<MemberProps> = ({member} )=>{

    const socialMediaImages:SocialMedia ={facebook: "/images/facebook.png", linkedin: "/images/linkedin.png", instagram:"/images/instagram.png"};
    const socialMediaLinks:SocialMedia = member.socialMedia;
    return (
        <div className="flex flex-col items-center space-y-3 text-center rounded-b-md px-14 py-6" style={{boxShadow: "0px 0px 5px lightgrey"}}>
            <Image className="w-1/2 rounded-full" width={100} height={100} src={member.image?member.image:"/images/user%20profile%20area.png"} alt={"member profile image"} />
            <p className="font-cards font-bold text-[24px]">{member.name}</p>
            <p className="font-cards font-semibold text-[20px]">{member.department}</p>
            <p className="font-cards font-medium text-[17px]">
                {member.bio}
            </p>
            <div className="flex justify-around w-4/5 border-t-2 pt-5">
                {
                    Object.keys(socialMediaImages).map((link)=>{
                        return (
                            <a href={socialMediaLinks[link]}>
                                <img className="w-[20px] h-[20px]" src={socialMediaImages[link]}/>
                            </a>
                        )
                    })
                }

            </div>
        </div>
    )
}
export default MemberCard