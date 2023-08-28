import RootLayout from '../layout';
import Image, {StaticImageData} from 'next/image';
import vector from '@/assets/images/Vector.png';
import vector1 from '@/assets/images/Vector1.png';
import bees from '@/assets/images/bees.png';
import africaIcon from '@/assets/images/info iconicon1.png';
import codeIcon from '@/assets/images/info iconicon2.png';
import userWritingIcon from '@/assets/images/amicosolve.png';
import puzzleSolveIcon from '@/assets/images/amicopuzzle.png';
import bulbIcon from '@/assets/images/info iconicon3.png';
import hakimHubIcon from '@/assets/images/Hakimhub.png';
import trackSym from '@/assets/images/TrackSym.png';
import gitHubIcon from '@/assets/images/github.png';
import linkIcon from '@/assets/images/link.png';
import rocketIcon from '@/assets/images/RocketIcon.png';
import triangleIcon from '@/assets/images/TriangleIcon.png';
import questionIcon from '@/assets/images/QuestionIcon.png'
import codeIconNew from '@/assets/images/CodeIcon.png';
import pullIcon from '@/assets/images/PullIcon.png';
import biWeeklyIcon from '@/assets/images/BiWeeklyIcon.png';

const Section1 = ()=>{
    return (
        <div className='flex justify-center px-8'>
            <div className='flex justify-center flex-wrap mt-20 md:mt-30 text-center lg:text-left'>
                <div className='w-full lg:w-[400px] md:mr-14'>
                    <h1 className='font-primaryFont text-[40px] font-bold text-[#2B2A35] dark:text-dark-textColor-100'><span className='text-primaryColor'>Africa</span> to Silicon Valley</h1>
                    <p className='font-secondaryFont mt-10 text-xl leading-8 dark:text-dark-textColor-50'>A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
                    <button className='mt-14 bg-primaryColor px-6 md:px-12 py-3 md:py-4 text-white text-xl font-medium font-secondaryFont rounded-xl'>Meet our team</button>
                    <p className='font-secondaryFont mt-10 lg:mt-24 italic text-l text-gray-700 leading-8 text-l dark:text-dark-textColor-50'>A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
                </div>
                <div className='flex flex-col gap-10 w-11/12 lg:w-[600px] mt-20 lg:mt-[-20px]'>
                    <h1 className='text-xl font-medium font-primaryFont text-gray-700 dark:text-dark-textColor-100'>Group activites</h1>
                    <div className='flex flex-col gap-6'>
                        <div className='grid sm:grid-cols-2 gap-4'>
                            <div className="bg-[url('/images/landing1.png')] bg-cover h-[250px] w-full rounded-2xl flex justify-center items-center">
                                <p className='text-white text-2xl font-medium font-primaryFont w-2/3 text-center drop-shadow-md dark:text-dark-background'>The education process</p>
                            </div>                     
                            <div className="bg-[url('/images/landing2.png')] bg-cover h-[250px] w-full rounded-2xl flex justify-center items-center">
                                <p className='text-white text-2xl font-medium font-primaryFont w-2/3 text-center drop-shadow-lg dark:text-dark-background'>Development Phase</p>
                            </div>
                        </div>
                        <div className='bg-slate-900 h-[200px] rounded-2xl w-full relative flex md:justify-between'>
                            <div className='relative'>
                                <Image src={vector} alt={'vector1'} className='hidden md:block absolute top-[-40px] left-20 h-full scale-[0.55] rotate-12'/>
                                <Image src={vector1} alt={'vector2'} className='hidden md:block relative top-44'/>
                                <Image src={bees} alt={'bees'} className='hidden md:block absolute left-28 top-1'/>
                            </div>
                            <div className='text-white min-w-[200px] flex justify-start md:justify-center items-center pr-4'>
                                <div className='text-left md:text-right pl-4 md:pl-0'>
                                    <h1 className='text-xl md:text-xl font-semibold font-primaryFont dark:text-dark-textColor-100'>20% percent growth</h1>
                                    <p className='text-base md:text-md font-secondaryFont mt-4 text-gray-300  dark:text-dark-textColor-50'>180% students growth</p>
                                    <p className='text-base md:text-md font-secondaryFont text-gray-300 dark:text-dark-textColor-50'>20% faster learning track</p>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    );
}

const Section2 = ()=>{
    return(
        <div className='flex justify-center'>
            <div className='flex flex-wrap justify-center px-6 lg:ml-28 mt-40'>
                <div className='w-full lg:w-[400px] md:mr-10'>
                    <h1 className='font-primaryFont text-[40px] font-bold text-[#2B2A35] dark:text-dark-textColor-100'>The Problem We <span className='text-primaryColor'>Are Solving</span></h1>
                    <Image src={africaIcon} className='text-left mt-6 text-gray-500 dark:text-dark-backgroundLight' height={70} alt='africa info icon'/>
                    <p className='font-primaryFont leading-8 text-l mt-4 text-gray-500 dark:text-dark-textColor-50'>Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.</p>
                    <Image src={codeIcon} className='text-left mt-14 text-gray-500' height={70} alt='code info icon'/>
                    <p className='font-primaryFont leading-8 text-l mt-4 text-gray-500 dark:text-dark-textColor-50'>With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential.</p>
                </div>

                <div className='flex flex-col justify-center items-center lg:items-end w-11/12 lg:w-[600px] mt-20 lg:mt-[-20px]'>
                    <Image src={userWritingIcon} alt="user writing icon" className='w-80 h-80 lg:w-[500px] lg:h-[500px]'/>
                </div>
            </div>
        </div>
    )
}

const Section3 = ()=>{
    return(
        <div className='flex justify-center'>
            <div className='flex flex-wrap justify-center px-6 lg:ml-28'>
                <div className='w-full lg:w-[400px] md:mr-10'>
                    <h1 className='font-primaryFont text-[40px] font-bold text-[#2B2A35] dark:text-dark-textColor-100'>How we are <span className='text-primaryColor'>solving</span> it</h1>
                    <Image src={bulbIcon} className='text-left mt-6 text-gray-500 dark:text-dark-backgroundLight' height={70} alt='Bulb icon'/>
                    <p className='font-primaryFont leading-8 text-l mt-4 text-gray-500 dark:text-dark-textColor-50'>Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere.</p>
                </div>
                <div className='flex flex-col justify-center items-center lg:items-end w-11/12 lg:w-[600px] mt-20 lg:mt-[-20px]'>
                    <Image src={puzzleSolveIcon} alt="Puzle solve icon" className='w-80 h-80 lg:w-[500px] lg:h-[500px]'/>
                </div>
            </div>
        </div>
    )
}

const Section4 = ()=>{
    return(
        <div className='mt-20 lg:mt-40 flex justify-center'>
            <div>
                <h1 className='w-fill flex justify-center text-5xl font-bold text-[#2B2A35] dark:text-dark-textColor-100'>Social <span className='text-primaryColor'> Projects</span></h1>
                <div className='flex flex-wrap justify-around mt-20 gap-6 mx-6 lg:mx-0'>
                    <div className='flex flex-col justify-center items-start w-11/12 lg:w-[600px]'>
                        <Image src={hakimHubIcon} alt="Puzle solve icon" height={500}/>
                    </div>
                    <div className='w-full lg:w-[400px] lg:mt-20 lg:text-right'>
                        <h1 className='font-primaryFont text-[20px]  text-primaryColor'>Solcial Project</h1>
                        <h1 className='font-primaryFont text-[40px]  text-primaryColor'>Hakim Hub</h1>
                        <p className='font-primaryFont leading-8 text-l mt-4 text-gray-500 dark:text-dark-textColor-50'>HakimHub is a platform that provides information about healthcare facilities and healthcare professionals in Ethiopia. Hakimhub makes information about hospitals, medical laboratories, and doctors conveniently accessible to its users.</p>
                        <div className='flex lg:justify-end w-full mt-10'>
                            <div className='flex gap-3'>
                                <Image src={gitHubIcon} alt="github icon" className='cursor-pointer'/>
                                <Image src={linkIcon} alt="open icon" className='cursor-pointer'/>
                            </div>
                        </div>
                    </div>
                </div>
                <div className='flex flex-row-reverse flex-wrap justify-around gap-6 mx-6 lg:mx-0 mt-10 md:mt-0'>
                    <div className='flex flex-col justify-center items-start w-11/12 lg:w-[600px]'>
                        <Image src={trackSym} alt="Puzle solve icon" height={500}/>
                    </div>
                    <div className='w-full lg:w-[400px] lg:mt-20 text-left'>
                        <h1 className='font-primaryFont text-[20px]  text-primaryColor'>Solcial Project</h1>
                        <h1 className='font-primaryFont text-[40px]  text-primaryColor'>Track Sym</h1>
                        <p className='font-primaryFont leading-8 text-l mt-4 text-gray-500 dark:text-dark-textColor-50'>TrackSym is a non-commercial app that uses crowd-sourcing to collect and visualize the density of the relevant Covid-19 symptoms. Symptom data, aggregated by places, can help people avoid visiting areas that are heavily populated by symptomatic people.</p>
                        <div className='flex justify-start w-full mt-10'>
                            <div className='flex gap-3'>
                                <Image src={gitHubIcon} alt="github icon" className='cursor-pointer'/>
                                <Image src={linkIcon} alt="open icon" className='cursor-pointer'/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

type cardType = {
    title: string;
    icon: StaticImageData;
    content: string;
}
const Section5Cards = ({title, icon, content }: cardType)=>{
    return(
        <div className='shadow-lg dark:shadow-sm dark:shadow-dark-backgroundLight rounded-lg px-10 mt-10 pb-6 flex flex-col items-center text-center dark:bg-dark-backgroundLight pt-4'>
                <Image src={icon} height={90} alt='rocket icon'/>
                <h1 className='font-primaryFont text-2xl text-black mt-10 font-semibold dark:text-dark-textColor-100'>{title}</h1>
                <p className='font-primaryFont leading-8 text-l mt-4 text-gray-700 dark:text-dark-textColor-50'>{content}</p>
        </div>
    )
}

const Section5 = ()=>{
    return(
        <div className='mt-20 mx-6 lg:mx-28'>
            <h1 className='w-fill flex justify-center text-5xl font-bold mb-20 dark:text-dark-white'>A2SV <span className='text-primaryColor'>  Sessions</span></h1>
            <div className='grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4'>
                <Section5Cards title="Bi-weekly contests" icon={rocketIcon} content="Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces."/>
                <Section5Cards title="Technical Training" icon={triangleIcon} content="Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces."/>
                <Section5Cards title="Q&As" icon={questionIcon} content="Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces."/>
                <Section5Cards title="Problem Solving Sessions" icon={codeIconNew} content="Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces."/>
                <Section5Cards title="Learning How To Approach" icon={pullIcon} content="Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces."/>
                <Section5Cards title="Bi-weekly 1:1s" icon={biWeeklyIcon} content="Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces."/>
            </div>
        </div>
    )
}
const AboutPage = ()=>{
    return(
        <div className='mb-20'>
            <Section1 />
            <Section2 />
            <Section3 />
            <Section4 />
            <Section5 />
        </div>
    )
}


export default AboutPage