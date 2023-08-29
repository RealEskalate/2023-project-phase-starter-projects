"use client";
import { useAuth } from "@/hooks/useAuth";
import { useGetStoriesQuery } from "@/lib/redux/features/stories";
import Image from "next/image";
import Link from "next/link";
export default function Home() {
  const { auth } = useAuth();
  const { data, isLoading, isError } = useGetStoriesQuery();
  console.log(data);
  return (
    <main className="mx-auto lg:px-24 px-5 pt-36 font-sans-serif	font-poppins">
      <header className="grid grid-cols-1 sm:grid-cols-1 md:grid-cols-1 lg:grid-cols-2 gap-4 ">
        <div className="sm:grid-cols-1 md:grid-cols-1 lg:grid-cols-2 space-y-10">
          <div className="xl:text-7xl sm:text-6xl text-4xl font-extrabold">
            <p className="xl:text-left text-center">
              <span className="text-[#160041] leading-10">Africa to </span>
              <span className="text-primary leading-10">
                Silicon
                <br />
                Valley
              </span>
            </p>
          </div>
          <p className="text-2xl font-normal text-text-header-2 leading-10 mt-4 xl:text-left text-center">
            A2SV up-skills high-potential university students, connects them
            with opportunities at top tech companies
          </p>
          <div className="mt-8 flex items-center xl:justify-start justify-evenly w-full">
            {!auth.isAuthenticated && (
              <button className=" border-2	rounded-xl p-3 h-14 mr-4 text-primary text-xl	font-medium	 ">
                Get Started
              </button>
            )}
            <button className=" border-2	rounded-xl p-3 h-14 bg-primary text-white text-xl	font-medium	flex items-center">
              <span>Support Us</span>
              <svg
                width="28"
                height="28"
                viewBox="0 0 28 28"
                fill="none"
                xmlns=""
              >
                <g clipPath="url(#clip0_3602_2395) ">
                  <path
                    d="M5.75195 13.7996H21.8514"
                    stroke="white"
                    strokeWidth="2.29993"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                  <path
                    d="M17.251 18.3994L21.8508 13.7996"
                    stroke="white"
                    strokeWidth="2.29993"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                  <path
                    d="M17.251 9.19971L21.8508 13.7996"
                    stroke="white"
                    strokeWidth="2.29993"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                </g>
                <defs>
                  <clipPath id="clip0_3602_2395">
                    <rect
                      width="27.5991"
                      height="27.5991"
                      fill="white"
                      transform="translate(0.00195312)"
                    />
                  </clipPath>
                </defs>
              </svg>
            </button>
          </div>
        </div>

        <div className="hidden xl:flex xl:justify-end xl:items-center">
          <Image
            src="/images/teams.png"
            alt=""
            width={500}
            height={500}
            className=" object-contain"
          />
        </div>
      </header>
      <section className="mt-20 text-center space-y-10">
        <p className="xl:text-5xl sm:text-4xl text-3xl text-text-header-1">
          Lets build a better
          <br />
          tomorrow
        </p>
        <br />
        <p className="text-text-content xl:text-2xl text-lg">
          A2SV upskills high-potential university students, connects them with
          opportunities at top tech companies around the world, and creates
          digital solutions to urgent problems in their home countries. The
          program is free for students, making the opportunity available for
          youth who have talent but lack the means to use it.
        </p>
        <br />
        <Link
          href="/teams"
          className="w-max border-2	rounded-xl p-3 h-14 bg-primary text-white text-xl font-medium flex space-x-3 mx-auto items-center"
        >
          <Image
            src="/images/tabler_message-circle.svg"
            height={28}
            width={28}
            alt="tabler_message-circle"
          />
          <span>Connect to our team</span>
        </Link>
      </section>
      <div className="hidden md:block mt-10 h-96 overflow-hidden">
        <Image
          src="/images/team.jpg"
          width={1120}
          height={515}
          alt="team"
          className="w-full aspect-video object-cover rounded-lg"
        />
      </div>
      <section className="text-center mt-20 xl:min-h-[60vh] flex flex-col items-center justify-center text-text-header-1">
        <p className="xl:text-5xl sm:text-4xl text-3xl">
          <span>Google SWE Interviews Acceptance</span>
          <br className="xl:block hidden" />
          <span> Rate Comparison</span>
        </p>
        <br />
        <div className="bg-slate-100 px-5 py-10 rounded-xl grid grid-cols-1 lg:grid-cols-6  gap-10">
          <div className="flex justify-center w-full mt-4 text-text-content font-normal text-xl lg:col-span-1 col-span-6">
            <p>
              <span>A2SV students are</span>
              <span className="text-[#160041] font-semibold text-xl"> 35</span>
              <span> times more likely to pass </span>
              <span className="text-[#160041] font-semibold text-xl">
                Google SWE interviews
              </span>
              <span> than average candidates.</span>
            </p>
          </div>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 lg:col-span-5 col-span-6 gap-7">
            <div className="bg-white rounded-xl space-y-3 px-5 py-3 drop-shadow-md w-full mx-auto flex flex-col justify-center items-center">
              <p className="text-xl	font-semibold	">2019</p>
              <p className="text-2xl	font-semibold	">Founded</p>
              <p className="text-xl	font-normal	">5% average</p>
            </div>
            <div className="bg-white rounded-xl space-y-3 px-5 py-3 drop-shadow-md w-full mx-auto flex flex-col justify-center items-center">
              <p className="text-xl	font-semibold	">2020</p>
              <p className="text-2xl	font-semibold	">27%</p>
              <p className="text-xl	font-normal	">5.2% average</p>
            </div>
            <div className="bg-white rounded-xl space-y-3 px-5 py-3 drop-shadow-md w-full mx-auto flex flex-col justify-center items-center">
              <p className="text-xl	font-semibold	">2021</p>
              <p className="text-2xl	font-semibold	">59%</p>
              <p className="text-xl	font-normal	">3.2% average</p>
            </div>
            <div className="bg-white rounded-xl space-y-3 px-5 py-3 drop-shadow-md w-full mx-auto flex flex-col justify-center items-center">
              <p className="text-xl	font-semibold	">2022</p>
              <p className="text-2xl	font-semibold	">70%</p>
              <p className="text-xl	font-normal	">2.5% average</p>
            </div>
          </div>
        </div>
      </section>
      <section className="my-16 space-y-10">
        <div className="grid md:grid-cols-2 grid-cols-1 mt-12 items-center">
          <div className="hidden md:block col-span-">
            <Image src="/images/cir.png" alt="" width={300} height={300} />
          </div>
          <div className="">
            <p className="md:text-right text-center text-4xl font-semibold	text-text-header-2 p-4">
              Internships
            </p>
            <p className="md:text-right text-center text-xl	font-normal	text-text-content max-w-max	p-4	">
              Students who passed their interviews get 3-month internships to
              gain experience in building scalable products that are widely used
              around the world.
            </p>
          </div>
        </div>
        <div className="grid md:grid-cols-2 grid-cols-1 items-center">
          <div>
            <p className="md:text-left text-center text-4xl font-semibold	text-text-header-2 p-4">
              360° Trainings
            </p>
            <p className="md:text-left text-center text-xl	font-normal	text-text-content max-w-max	p-4">
              A2SV upskills students with a 360° software engineering program
              that focuses on problem-solving, effective speaking, and personal
              development.
            </p>
          </div>
          <div className="hidden md:block">
            <Image
              src="/images/360.png"
              alt=""
              className="float-right"
              width={300}
              height={300}
            />
          </div>
        </div>

        <div className="grid md:grid-cols-2 grid-cols-1 mt-18 items-center">
          <div className="hidden md:block">
            <Image
              src="/images/social-project.png"
              alt=""
              width={300}
              height={300}
            />
          </div>
          <div>
            <p className="md:text-right text-center text-4xl font-semibold text-text-header-2 p-4">
              Social Projects
            </p>
            <p className="md:text-right text-center text-xl	font-normal	text-text-content max-w-max	p-4		">
              Students work on social projects with industry experts to address
              the most pressing problems in their community.
            </p>
          </div>
        </div>
      </section>

      <section>
        <div className=" bg-gradient-to-r 0% from-primary from-10% to-[#019CFA] to-90% flex flex-col justify-center items-center py-16 rounded-xl relative ">
          <Image
            src="/images/africa-bg.svg"
            width={200}
            height={200}
            alt="africa icons"
            className="w-96 absolute z-0"
          />
          <p className="text-white text-2xl my-3 z-10">
            Help us sustain our mission!
          </p>
          <button className="border-2	rounded-xl px-10 h-14 bg-white text-primary text-xl font-medium cursor-pointer z-10">
            Support Us
          </button>
        </div>
      </section>
      <section className="mt-12 text-center">
        {isLoading ? (
          <div className="flex justify-center items-center h-[400px]">
            <div className="animate-spin rounded-full border-t-4 border-blue-500 border-opacity-75 h-12 w-12"></div>
          </div>
        ) : data ? (
          <div>
            <h1 className="md:text-5xl text-4xl text-center font-bold my-5">
              Impact Stories
            </h1>
            <div className="grid grid-cols-1 sm:grid-cols-1 md:grid-cols-1 lg:grid-cols-2">
              <div className="md:text-left text-center flex flex-col justify-center md:items-center space-y-5">
                <h2 className="text-2xl font-semibold	text-text-header-2">
                  {data[0].personName}
                </h2>
                <p className="mt-2 text-dark-chocolate font-medium	text-lg">
                  Software engineer At Google
                </p>
                <p className="mt-2 mb-3 text-base text-center	font-normal	text-text-header-2 max-w-[50ch]">
                  “When I joined A2SV in 2019, I found the concept of data
                  structures and algorithms quite challenging. A2SV's smooth
                  learning process and dedicated team molded me to see the peak
                  of my abilities. Through A2SV's effective education and
                  continual support, I passed Google's internship interviews and
                  attended a summer internship at Google in Amsterdam. However,
                  the A2SV program and training is beyond technical education
                  and interview preparation. As an A2SVian, I also learned the
                  values of putting humanity first, giving back to our
                  community, and utilizing teamwork with my colleagues, which I
                  can now consider my big family. After completing three
                  remarkable months at Google, I was offered a full-time
                  position at Google's London office for 2022. “
                </p>
                <Link
                  href="/stories"
                  className="border-2	rounded-xl px-5 w-32 h-10 bg-primary text-white text-base font-normal mx-auto flex items-center justify-center"
                >
                  See More
                </Link>
              </div>
              <div className="hidden md:block">
                <Image
                  src="/images/impact.png"
                  alt=""
                  width={300}
                  height={300}
                  className="ml-64"
                />
              </div>
            </div>
          </div>
        ) : (
          <div>Error</div>
        )}
      </section>
      <section></section>
    </main>
  );
}

const SkeletonLoader: React.FC = () => {
  return (
    <div
      role="status"
      className="space-y-8 animate-pulse md:space-y-0 md:space-x-8 grid md:grid-cols-2 md:items-center w-full"
    >
      <div role="status" className="space-y-2.5 animate-pulse max-w-lg">
        <div className="flex items-center w-full space-x-2">
          <div className="h-2.5 bg-gray-200 rounded-full w-32"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-24"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-full"></div>
        </div>
        <div className="flex items-center w-full space-x-2 max-w-[480px]">
          <div className="h-2.5 bg-gray-200 rounded-full w-full"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-full"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-24"></div>
        </div>
        <div className="flex items-center w-full space-x-2 max-w-[400px]">
          <div className="h-2.5 bg-gray-100 rounded-full w-full"></div>
          <div className="h-2.5 bg-gray-200 rounded-full w-80"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-full"></div>
        </div>
        <div className="flex items-center w-full space-x-2 max-w-[480px]">
          <div className="h-2.5 bg-gray-200 rounded-full w-full"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-full"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-24"></div>
        </div>
        <div className="flex items-center w-full space-x-2 max-w-[440px]">
          <div className="h-2.5 bg-gray-100 rounded-full w-32"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-24"></div>
          <div className="h-2.5 bg-gray-200 rounded-full w-full"></div>
        </div>
        <div className="flex items-center w-full space-x-2 max-w-[360px]">
          <div className="h-2.5 bg-gray-100 rounded-full w-full"></div>
          <div className="h-2.5 bg-gray-200 rounded-full w-80"></div>
          <div className="h-2.5 bg-gray-100 rounded-full w-full"></div>
        </div>
        <span className="sr-only">Loading...</span>
      </div>
      <div className="flex items-center justify-center w-full h-72 bg-gray-100 rounded sm:w-full">
        <svg
          className="w-10 h-10 text-gray-200"
          aria-hidden="true"
          xmlns="http://www.w3.org/2000/svg"
          fill="currentColor"
          viewBox="0 0 20 18"
        >
          <path d="M18 0H2a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2Zm-5.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3Zm4.376 10.481A1 1 0 0 1 16 15H4a1 1 0 0 1-.895-1.447l3.5-7A1 1 0 0 1 7.468 6a.965.965 0 0 1 .9.5l2.775 4.757 1.546-1.887a1 1 0 0 1 1.618.1l2.541 4a1 1 0 0 1 .028 1.011Z" />
        </svg>
      </div>
      <span className="sr-only">Loading...</span>
    </div>
  );
};
