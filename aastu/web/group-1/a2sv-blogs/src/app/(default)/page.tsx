import Image from "next/image";
export default function Home() {
  return (
    <main className=" w-full py-10 px-16 pt-20 font-sans-serif	mt-20">
      <header className="grid grid-cols-2 sm:grid-cols-1 md:grid-cols-1 lg:grid-cols-2 gap-4 ">
        <div className="">
          <div className="xl:text-7xl	font-extrabold ">
            <span className="text-[#160041] leading-10">Africa to </span>
            <span className="text-primary leading-10 font-poppins">
              Silicon
              <br />
              Valley
            </span>
          </div>
          <p className="text-2xl font-normal text-text-header-2 leading-10 mt-4 font-poppins">
            A2SV up-skills high-potential university students, connects them
            with opportunities at top tech companies
          </p>
          <div className="mt-8 flex items-center">
            <button className=" border-2	rounded-xl p-3 h-14 mr-4 text-primary text-xl	font-medium	 font-poppins">
              Get Started
            </button>
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

        <div className="hidden lg:block ">
          <Image
            src="/images/teams.png"
            className=" mx-auto"
            alt=""
            width={500}
            height={500}
          />
        </div>
      </header>
      <section className="mt-12 text-center">
        <br />
        <br />
        <p className="text-[40px] text-text-header-1 font-poppins">
          Lets build a better
          <br />
          tomorrow
        </p>
        <br />
        <p className="text-text-content text-xl	font-poppins">
          A2SV upskills high-potential university students, connects them with
          opportunities at top tech companies around the world, and creates
          digital solutions to urgent problems in their home countries. The
          program is free for students, making the opportunity available for
          youth who have talent but lack the means to use it.
        </p>
        <br />
        <button className="border-2	rounded-xl p-3 h-14 bg-primary text-white text-xl font-medium font-poppins">
          Connect to our team
        </button>
      </section>
      <section className="hidden md:block">
        <Image
          src="/images/team.jpg"
          width={1400}
          height={645}
          alt="team"
          className="p-4"
        />
      </section>
      <section className="text-center ">
        <br />
        <br />
        <p className="text-4xl font-poppins">
          Google SWE Interviews Acceptance
          <br />
          Rate Comparison
        </p>
        <br />
        <div className="bg-slate-100 h-100  p-4 rounded-xl grid grid-cols-2 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5  gap-4 ">
          <div className="p-2 text-center mt-4 text-text-content text-xl font-normal font-poppins">
            <span>A2SV students are</span>
            <span className="text-[#160041] font-semibold text-2xl"> 35</span>
            <span> times more likely to pass</span>
            <span className="text-[#160041] font-semibold text-xl">
              Google SWE interviews
            </span>
            <span> than average candidates.</span>
          </div>
          <div className="w-48	h-48	bg-white p-4 rounded-xl ml-4">
            <p className="text-xl	font-semibold	font-poppins">2019</p>
            <br />
            <br />
            <p className="text-2xl	font-semibold	font-poppins">Founded</p>
            <br />
            <p className="text-xl	font-normal	font-poppins">5% average</p>
          </div>
          <div className="w-48	h-48	bg-white p-4 rounded-xl ml-4">
            <p className="text-xl	font-semibold	font-poppins">2020</p>
            <br />
            <br />
            <p className="text-2xl	font-semibold	font-poppins">27%</p>
            <br />
            <p className="text-xl	font-normal font-poppins	">5.2% average</p>
          </div>
          <div className="w-48	h-48	bg-white p-4 rounded-xl ml-4">
            <p className="text-xl	font-semibold	font-poppins">2021</p>
            <br />
            <br />
            <p className="text-2xl	font-semibold	font-poppins">59%</p>
            <br />
            <p className="text-xl	font-normal	font-poppins">3.2% average</p>
          </div>
          <div className="w-48	h-48	bg-white p-4 rounded-xl ml-4">
            <p className="text-xl	font-semibold	font-poppins">2022</p>
            <br />
            <br />
            <p className="text-2xl	font-semibold	font-poppins">70%</p>
            <br />
            <p className="text-xl	font-normal	font-poppins">2.5% average</p>
          </div>
        </div>
      </section>
      <section className="my-16 grid grid-cols-1 sm:grid-cols-1 md:grid-cols-1 lg:grid-cols-2">
        <div className="hidden md:block">
          <Image src="/images/cir.png" alt="" width={300} height={300} />
        </div>

        <div className="text-right	mt-12">
          <p className="text-3xl font-semibold font-poppins	text-text-header-2 p-4">
            Internships
          </p>
          <p className="text-xl	font-normal font-poppins	text-text-content max-w-max		p-4	">
            Students who passed their interviews get 3-month internships to gain
            experience in building scalable products that are widely used around
            the world.
          </p>
        </div>
        <div className="">
          <p className="text-3xl font-semibold font-poppins	text-text-header-2 p-4">
            360° Trainings
          </p>
          <p className="text-xl	font-normal font-poppins	text-text-content max-w-max	p-4">
            A2SV upskills students with a 360° software engineering program that
            focuses on problem-solving, effective speaking, and personal
            development.
          </p>
        </div>
        <div className="ml-56	hidden md:block">
          <Image src="/images/cir.png" alt="" width={300} height={300} />
        </div>
        <div className="	hidden md:block">
          <Image src="/images/cir.png" alt="" width={300} height={300} />
        </div>

        <div className="text-right mt-18	">
          <p className="text-3xl font-semibold font-poppins text-text-header-2 p-4">
            Social Projects
          </p>
          <p className="text-xl	font-normal font-poppins	text-text-content max-w-max	p-4		">
            Students work on social projects with industry experts to address
            the most pressing problems in their community.
          </p>
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
          <p className="text-white text-2xl my-3 z-10 font-montserrat">
            Help us sustain our mission!
          </p>
          <button className="border-2	font-montserrat rounded-xl px-10 h-14 bg-white text-primary text-base font-medium cursor-pointer z-10">
            Support Us
          </button>
        </div>
      </section>
      <section className="mt-12 text-center">
        <br />
        <br />
        <p className="text-5xl font-montserrat">Impact Stories</p>
        <div className="grid grid-cols-1 sm:grid-cols-1 md:grid-cols-1 lg:grid-cols-2">
          <div className="text-left">
            <p className="text-base	font-semibold	text-text-header-2 font-poppins">
              Abel Tsegaye
            </p>
            <p className="mt-2 text-dark-chocolate font-medium	font-poppins text-lg	">
              Software engineer At Google
            </p>
            <p className="mt-2 mb-3 text-base	font-normal font-poppins	text-text-header-2">
              “ When I joined A2SV in 2019, I found the concept of data
              structures and algorithms quite challenging. A2SV's smooth
              learning process and dedicated team molded me to see the peak of
              my abilities. Through A2SV's effective education and continual
              support, I passed Google's internship interviews and attended a
              summer internship at Google in Amsterdam. However, the A2SV
              program and training is beyond technical education and interview
              preparation. As an A2SVian, I also learned the values of putting
              humanity first, giving back to our community, and utilizing
              teamwork with my colleagues, which I can now consider my big
              family. After completing three remarkable months at Google, I was
              offered a full-time position at Google's London office for 2022. “
            </p>
            <button className="border-2	rounded-xl px-5 w-32 h-10 bg-primary text-white text-base font-normal">
              See More
            </button>
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
        <br />
      </section>
      <section></section>
    </main>
  );
}
