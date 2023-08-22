import RootLayout from '../layout';
import Image from 'next/image';
import vector from '@/assets/images/Vector.png';
import vector1 from '@/assets/images/Vector1.png';
import bees from '@/assets/images/bees.png';
const Section1 = ()=>{
    return (
        <div className='flex flex-wrap ml-28 mt-20'>
            <div className='w-full xl:w-[550px] mr-14'>
                <h1 className='font-primaryFont text-[40px] font-bold text-[#2B2A35]'><span className='text-primaryColor'>Africa</span> to Silcon Valley</h1>
                <p className='font-secondaryFont mt-10 text-xl leading-8'>A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
                <button className='mt-14 bg-primaryColor px-12 py-6 text-white text-xl font-medium font-secondaryFont rounded-xl'>Meet our team</button>
                <p className='font-secondaryFont mt-24 italic text-l text-gray-700 leading-8'>A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
            </div>
            <div className='flex flex-col gap-10 w-[750px] mt-[-60px]'>
                <h1 className='text-2xl font-medium font-primaryFont text-gray-800'>Group activites</h1>
                <div className='flex flex-col gap-6'>
                    <div className='grid grid-flow-col gap-4'>
                        <div className="bg-[url('/images/landing1.png')] bg-cover h-[250px] w-full rounded-2xl flex justify-center items-center">
                            <p className='text-white text-2xl font-medium font-primaryFont w-1/2 text-center drop-shadow-md'>The education process</p>
                        </div>                     
                        <div className="bg-[url('/images/landing2.png')] bg-cover h-[250px] w-full rounded-2xl flex justify-center items-center">
                            <p className='text-white text-2xl font-medium font-primaryFont w-1/2 text-center drop-shadow-lg'>The education process</p>
                        </div>
                    </div>
                    <div className='bg-slate-900 h-[180px] rounded-2xl w-full relative flex justify-between'>
                        <div className='relative flex'>
                            <Image src={vector} alt={'vector1'} className='absolute'/>
                            <Image src={vector1} alt={'vector2'} className='absolute'/>
                            <Image src={bees} alt={'bees'} className='absolute'/>
                        </div>
                        <div className='text-white w-1/2 flex justify-center items-center'>
                            <div className=''>
                                <h1 className='text-xl font-semibold font-primaryFont'>20% percent growth</h1>
                                <p className='text-md font-secondaryFont'>180% students growth 20% faster learning track</p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
}

const AboutPage = ()=>{
    return(
        <div>
            <Section1 />
        </div>
    )
}


export default AboutPage