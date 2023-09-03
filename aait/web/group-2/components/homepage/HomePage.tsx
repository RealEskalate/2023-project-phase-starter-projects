import Image from "@/node_modules/next/image";

export default function HomePage() {
  return (
    <main className="bg-white-500 p-20">
      {
        //landing section
      }
      <div className="h-screen flex">
        {
          //written part
        }
        <div className="w-1/2 m-4">
          <h1 className="text-7xl leading-80 my-12">
            <b className="font-poppins text-dark-blue">Africa to</b>
            <b className="text-blue-800 font-Roboto"> Silicon Valley</b>
          </h1>
          <div className="w-3/4">
            <p className="text-3xl leading-60 my-10">
              A2SV up-skills high-potential university students, connects them
              with opportunities at top tech companies
            </p>
            <div className="flex justify-center">
              <button className="border border-blue-500 text-blue-800 bg-white px-4 py-2 rounded-md mr-5 w-1/2">
                Get Started
              </button>
              <button className="bg-blue-800 text-white px-4 py-2 rounded-md w-1/2">
                SUPPORT US
              </button>
            </div>
          </div>
        </div>

        {
          //pic part
        }
        <div className="w-1/2 m-4">
          <img src="/images/Home/front.png" />
        </div>
      </div>

      {
        //etter section
      }
      <div className="h-screen flex items-center justify-center">
        <div>
          <h1 className="text-7xl leading-80  my-12 text-center">
            Lets build a better
            <br />
            tomorrow
          </h1>
          <p className="text-xl leading-60 my-12 text-center">
            A2SV upskills high-potential university students, connects them with
            opportunities at top tech companies around the
            <br /> world, and creates digital solutions to urgent problems in
            their home countries. The program is free for students,
            <br /> making the opportunity available for youth who have talent
            but lack the means to use it.
          </p>
          <div className="flex justify-center">
            <button className="bg-blue-500 text-white w-405 h-89 px-4 py-2 rounded-md">
              Connect to our team
            </button>
          </div>
        </div>
      </div>

      <div className="h-screen">
        <img src="/images/Home/group-pic.jpg" />
      </div>

      <div className="h-screen m-4">
        <h1 className="text-center text-5xl font-bold">
          Google SWE Interviews Acceptance
          <br />
          Rate Comparison
        </h1>
        <div className="flex items-center space-between bg-gray-100 rounded-lg shadow-md p-10 m-4">
          <div className="w-1/4">
            <p>
              A2SV students are <b>35</b> times more likely to pass{" "}
              <b>Google SWE interviews</b> than average candidates.
            </p>
          </div>
          <div></div>
          <div className="bg-white rounded-lg shadow-md p-10 m-4 w-1/4">
            <div className="text-base text-gray-700 mb-4">2019</div>
            <div className="text-lg font-bold mb-2">Founded</div>
            <div className="text-sm text-gray-500">5% average</div>
          </div>

          <div className="bg-white rounded-lg shadow-md p-10 m-4 w-1/4">
            <div className="text-base text-gray-700 mb-4">2020</div>
            <div className="text-lg font-bold mb-2">27%</div>
            <div className="text-sm text-gray-500">5.2% average</div>
          </div>

          <div className="bg-white rounded-lg shadow-md p-10 m-4 w-1/4">
            <div className="text-base text-gray-700 mb-4">2021</div>
            <div className="text-lg font-bold mb-2">59%</div>
            <div className="text-sm text-gray-500">3.9% average</div>
          </div>
          <div className="bg-white rounded-lg shadow-md p-10 m-4 w-1/4">
            <div className="text-base text-gray-700 mb-4">2022</div>
            <div className="text-lg font-bold mb-2">70%</div>
            <div className="text-sm text-gray-500">2.6% average</div>
          </div>
        </div>
      </div>

      <div className="">
        <div className="grid grid-cols-1 sm:grid-cols-3 place-items-center">
          <div>
            <img src="/images/Home/interns.png" />
          </div>

          <div className="col-span-2 p-10 w-[600px] text-end ml-24">
            <p className="text-lg font-bold mb-2">Internships</p>
            <p>
              Students who passed their interviews get 3-month internships to
              gain experience in building scalable products that are widely used
              around the world.
            </p>
          </div>
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-3 place-items-center">
          <div className="col-span-2 p-10 w-[600px] text-start">
            <p className="text-lg font-bold mb-2">360° Training</p>
            <p>
              A2SV upskills students with a 360° software engineering program
              that focuses on problem-solving, effective speaking, and personal
              development.
            </p>
          </div>
          <div className="col-span-1 flex">
            <img src="/images/Home/training.png" className="ml-4" />
          </div>
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-3 place-items-center">
          <div>
            <img src="/images/Home/groups.png" />
          </div>
          <div className="col-span-2 p-10 w-[600px] text-start">
            <p className="text-lg font-bold mb-2">Social Projects</p>
            <p>
              Students work on social projects with industry experts to address
              the most pressing problems in their community.
            </p>
          </div>
        </div>

        <div className="relative bg-gradient-to-l from-blue-400 to-blue-700 h-64 m-10">
          <Image
            width={200}
            height={200}
            src="/images/Home/africa.jpg"
            alt="Image"
            className="opacity-10 bg-transparent mx-auto h-64"
          />
          <div className="absolute top-0 left-0 w-full h-full flex flex-col justify-center items-center z-10">
            <h1 className="text-white text-3xl mb-4">
              Help us sustain our mission!
            </h1>
            <button className="bg-white text-blue-500 px-4 py-2 rounded-md">
              Support Us
            </button>
          </div>
        </div>

        {
          //impact stories section
        }
        <div className="">
          {
            //written part
          }
          <div className="mt-2">
            <h1 className="text-7xl text-center leading-80 mt-24">
              Impact stories
            </h1>
            <div className="flex items-center space-between">
              <div className="w-1/2">
                <p className="text-xl leading-60">
                  “ When I joined A2SV in 2019, I found the concept of data
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
                <div className="">
                  <button className="bg-blue-500 text-white px-4 py-2 rounded-md m-2">
                    See More
                  </button>
                </div>
              </div>
              <div>
                <img src="/images/Home/story.png" alt="Story" />
              </div>
            </div>
          </div>

          {
            //other parts
          }
        </div>
      </div>
    </main>
  );
}
