import Image from "next/image"
import teamsIcon from '@/assets/images/teamLanding.png';
import profilePic from '@/assets/images/profile.png';

const Section1 = ()=>{
    return(
        <div className='flex flex-wrap ml-10 xl:ml-28 mt-40'>
            <div className='w-full xl:w-[550px] mr-14'>
                <h1 className='font-primaryFont text-[40px] font-bold text-[#2B2A35]'>The team we’re currently working with</h1>
                <p className='font-secondaryFont mt-10 text-xl leading-8'>Meet our development team is a small but highly skilled and experienced group of professionals. We have a talented mix of web developers, software engineers, project managers and quality assurance specialists who are passionate about developing exceptional products and services.</p>
                
            </div>
            <div className='flex flex-col gap-10 xl:w-[700px] mt-20 xl:mt-[-20px]'>
                <Image src={teamsIcon} alt="teams landing" />
            </div>
        </div>
    )
}

const ProfileCard = ()=>{
    return(
        <div className="w-[400px] h-auto pb-10 shadow-xl px-14">
            <div className="flex justify-center w-full">
                <div className="rounded-full bg-gray-200 p-2 overflow-hidden flex justify-center items-center">
                    <Image src={profilePic} alt="proflie picture" height={150}/>
                </div>
            </div>
            <div>
                <h1 className="flex justify-center mt-4 font-primaryFont text-3xl tracking-widest font-bold">Nathaniel Awel</h1>
                <h2>Software Engineer</h2>
                <p>He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.</p>

            </div>
        </div>
    )
}

const Section2 = ()=>{
    return(
        <div className="px-20 mt-20 grid grid-cols-3">
            <ProfileCard />
            <ProfileCard />
            <ProfileCard />
            <ProfileCard />
        </div>
    )
}



const Teams = ()=>{
    return(
        <div className="">
            <Section1 />
            <Section2 />
        </div>
    )
}

export default Teams