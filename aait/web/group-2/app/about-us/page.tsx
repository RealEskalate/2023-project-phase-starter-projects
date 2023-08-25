import Image from "next/image";

import Listitems from "@/components/ListItem";
import Link from "next/link";

const content = {
    problem: [
        {
            id: "1",
            imgUrl: "/images/Rectangle-1.png",
            body: "Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.",
        },
        {
            id: "2",
            imgUrl: "/images/Rectangle-1.png",
            body: "With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential."
        },
    ],
    solution: [{ id: "1", imgUrl: "/images/Rectangle-1.png", body: "Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere." }],

    sessions: [
        {
            id: '0',
            icon: '/images/Ellipse-0.png',
            title: 'Bi-weekly contests',
            body: 'Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces.',
        },
        {
            id: '1',
            icon: '/images/Ellipse-1.png',
            title: 'Technical Training',
            body: '6 days a week, 3 hours of lectures and practice sessions to improve technical problem-solving skills.'
        },
        {
            id: '2',
            icon: '/images/Ellipse-2.png',
            title: 'Q&As',
            body: 'In Q&As, we get to know engineers, founders, and entrepreneurs from top tech companies. We see that they are normal people like us and we learn the best practices.'
        },
        {
            id: '3',
            icon: '/images/Ellipse-3.png',
            title: 'Problem Solving Sessions',
            body: 'We solve technical problems on a whiteboard while explaining to the class. It helps to get a feel of an interview environment.'
        },
        {
            id: '4',
            icon: '/images/Ellipse-4.png',
            title: 'Learning How To Approach',
            body: 'Students observe how an experienced problem solver approaches a problem from understanding it to implementing a working solution.'
        },
        {
            id: '5',
            icon: '/images/Ellipse-5.png',
            title: 'Bi-weekly 1:1s',
            body: 'In 1:1s, we can talk about anything that matters; clearly no boundaries. The more we speak our minds without a filter, the better for the team.'
        },


    ]
};

export default function AboutUs() {
    return (
        <div className="w-11/12 mx-auto mt-40">
            <div className="flex flex-row justify-between gap-10">
                <div className="flex-1 pr-5">
                    <h1 className="text-secondary font-lato text-5xl leading-[50px] font-extrabold">
                        <span className="text-primary">Africa</span> to Silicon Valley
                    </h1>
                    <p className="text-2xl font-nunito text-tertiary leading-9 font-normal mt-10">
                        A2SV is a social enterprise that enables high-potential university
                        students to create digital solutions to Africa’s most pressing
                        problems.
                    </p>
                    <button className="text-white text-2xl font-nunito font-semibold leading-9 bg-primary h-20 w-72 rounded-xl my-20">
                        Meet Our Team
                    </button>
                    <p className="text-xl text-tertiary leading-9 font-nunito font-normal mt-5">
                        A2SV is a social enterprise that enables high-potential university
                        students to create digital solutions to Africa’s most pressing
                        problems.
                    </p>
                </div>
                <div className="flex-1">
                    <h2 className="text-2xl font-poppins font-medium leading-7">
                        Group Activities
                    </h2>
                    <div className="grid gap-6 grid-cols-2 mt-8">
                        <div className="relative h-72 col-span-1 rounded-xl">
                            <Image
                                src="/images/group-activity-1.png"
                                alt="Picture of the author"
                                layout="fill"
                                objectFit="cover"
                                className="rounded-xl"
                            />
                            <div className="absolute inset-0 flex flex-col justify-center items-center text-white text-center p-4">
                                <h3 className="text-2xl ">
                                    The Education <br />
                                    Process
                                </h3>
                            </div>
                        </div>
                        <div className="relative h-70 col-span-1 bg-primary rounded-xl">
                            <Image
                                src="/images/group-activity-2.png"
                                alt="Picture of the author"
                                layout="fill"
                                objectFit="cover"
                                className="rounded-xl"
                            />
                            <div className="absolute inset-0 flex flex-col justify-center items-center text-white text-center p-4">
                                <h3 className="text-2xl ">
                                    Developemnt <br />
                                    Phase
                                </h3>
                            </div>
                        </div>
                        <div className=" relative h-48 col-span-2 bg-gray-400 rounded-xl">
                            <Image
                                src="/images/group-activity-3.png"
                                alt="Activites in Percentage"
                                layout="fill"
                                objectFit="cover"
                                className="rounded-xl"
                            />
                            <div className="absolute inset-0 flex flex-col justify-center items-center text-white text-center p-4 right-0">
                                <h3 className="text-2xl font-semibold px-2 mb-4">
                                    20% percent growth
                                </h3>
                                <p className="text-xl text-tertiary">180% student growth</p>
                                <p className="text-xl text-tertiary">
                                    20% faster learning track
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div className="flex flex-row justify-between mt-20">
                <div className="flex-1">
                    <h1 className="font-extrabold mb-4 text-[54px] leading-[60px]">
                        The Problem We <span className="text-blue-500">Are Solving</span>
                    </h1>
                    <div className="flex flex-col gap-4 items-start">
                        {
                            content.problem.map(item => {
                                return <div key={item.id}>
                                    <Listitems imgUrl={item.imgUrl} body={item.body} id={item.id} />
                                </div>
                            })
                        }
                    </div>
                </div>
                <div className="flex-1">
                    <div className="relative flex flex-col space-around h-4/5 w-4/5 mx-auto">
                        <Image
                            src="/images/amicosolve.png"
                            alt="the problmes we solve"
                            layout="fill"
                            objectFit="contain"
                            className="absolute rounded-xl"
                        />
                    </div>
                </div>
            </div>
            {/* How we are solving it */}

            <div className="flex flex-row justify-between mt-20">
                <div className="flex-1">
                    <div className="relative flex flex-col space-around h-96 w-96 ml-8">
                        <Image
                            src="/images/amicopuzzle.png"
                            alt="solving puzzles picture"
                            layout="fill"
                            objectFit="contain"
                            className="absolute rounded-xl"
                        />
                    </div>
                </div>
                <div className="flex-1">
                    <h1 className="font-extrabold mb-4 text-[54px] leading-[60px]">
                        How are we <span className="text-blue-500">solving</span> it
                    </h1>
                    <div className="flex flex-col gap-4 items-start">
                        {
                            content.solution.map(item => {
                                return <div key={item.id}>
                                    <Listitems imgUrl={item.imgUrl} body={item.body} id={item.id} />
                                </div>
                            })
                        }
                    </div>
                </div>

            </div>

            <div className="mt-20">
                <h1 className='text-center text-[52px] text-[#2B2A35] font-poppins font-semibold mb-20'>Social <span className='text-primary'>Projects</span></h1>
                <div className='grid grid-row-2 gap-10'>
                    <div className='grid grid-cols-2'>
                        <div className='relative cols-span-1 w-full h-64'>
                            <Image
                                src='/images/hakim.png'
                                alt='hakim hub'
                                layout="fill"
                                objectFit="contain"
                                className="rounded-xl"
                            />
                        </div>
                        <div className='cols-span-1 text-right'>

                            <h4 className='text-[#1E3A8A] text-2xl'>Social project</h4>
                            <h2 className='mt-6 text-5xl text-primary capitalize font-semibold leading-8'>hakim hub</h2>
                            <p className='text-[22px] font-poppins font-light mt-6 mb-16'>HakimHub is a platform that provides information about healthcare facilities and healthcare professionals in Ethiopia. Hakimhub makes information about hospitals, medical laboratories, and doctors conveniently accessible to its users.</p>


                            <div className='flex justify-end w-full gap-4'>
                                <Link href='#' className='relative w-8 h-8'>
                                    <Image src='/images/github.png' alt='github link' layout="fill" objectFit="contain" />
                                </Link>
                                <Link href='#' className='relative w-8 h-8'>
                                    <Image src='/images/link.png' alt='website link' layout="fill" objectFit="contain" />
                                </Link>
                            </div>
                        </div>
                    </div>
                    <div className='grid grid-cols-2 '>

                        <div className='cols-span-1 text-left'>

                            <h4 className='text-[#1E3A8A] text-2xl'>Social project</h4>
                            <h2 className='mt-6 text-5xl text-primary capitalize font-semibold leading-8'>track sym</h2>
                            <p className='text-[22px] font-poppins font-light mt-8 mb-16'>TrackSym is a non-commercial app that uses crowd-sourcing to collect and visualize the density of the relevant Covid-19 symptoms. Symptom data, aggregated by places, can help people avoid visiting areas that are heavily populated by symptomatic people.</p>


                            <div className='flex justify-start w-full gap-4'>
                                <Link href='#' className='relative w-8 h-8'>
                                    <Image src='/images/github.png' alt='github link' layout="fill" objectFit="contain" />
                                </Link>
                                <Link href='#' className='relative w-8 h-8'>
                                    <Image src='/images/link.png' alt='website link' layout="fill" objectFit="contain" />
                                </Link>
                            </div>
                        </div>
                        <div className='relative cols-span-1 w-full h-64'>
                            <Image
                                src='/images/trackSym.png'
                                alt='hakim hub'
                                layout="fill"
                                objectFit="contain"
                                className="rounded-xl"
                            />
                        </div>
                    </div>

                </div>
            </div>

            <div className='mt-20'>
                <h2 className='font-poppins font-semibold text-[52px] text-center'>A2SV <span className='text-primary'>Session</span></h2>
                <div className='grid grid-cols-3 gap-4 `grid-rows-2  font-poppins my-4'>
                    {
                        content.sessions.map(session => {
                            return (
                                <div className=' p-8 col-span-1 shadow-lg rounded-lg'>
                                    <div className='relative w-[100px] h-[100px]'>
                                        <Image
                                            src={session.icon}
                                            alt='icon'
                                            objectFit="contain"
                                            layout='fill'
                                        />
                                    </div>
                                    <h3 className='my-9 text-3xl font-semibold text-[#363636] leading-9'>{session.title}</h3>
                                    <p className='text-2xl text-[#495167] font-nunito leading-8'>{session.body}</p>
                                </div>
                            )
                        })
                    }
                </div>

            </div>

        </div>
    );
}
