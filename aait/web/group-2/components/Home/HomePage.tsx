import Image from "@/node_modules/next/image";
import BuildBetter from "./BuildBetter";
import Landing from "./Landing";

export default function HomePage() {
  return (
    <main className="bg-white-500 p-20">
      {
        //landing section
      }
      <Landing />
      {
        //etter section
      }
      <BuildBetter />

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
