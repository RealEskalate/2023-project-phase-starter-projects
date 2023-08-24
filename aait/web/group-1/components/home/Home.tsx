
import RateCard from "@/components/home/RateCard"

import { 
        rateInfo, 
        a2svDescription, 
        a2svActivityInfo,
        impactStory 
      } from "../../data/home/homePageData"

export default function Home() {

  return (
    <main>
      {/* Landing section */}
      <section className="font-poppins flex lg:flex-row flex-col items-center gap-6 mt-20 border">
        <div className="flex flex-col lg:ml-32 lg:mb-40 mb:16 gap-6 text-center lg:text-left">
          <h1 className="font-extrabold text-dark-blue text-5xl">
            Africa to 
            <span className="text-blue-first"> Silicon
              <br/> 
              Valley
            </span>
          </h1>
          <p className="font-poppins font-normal text-light-gray leading-loose lg:w-1/2 mt-5 lg:text-left">
            A2SV up-skills high-potential university students, connects them with opportunities at top tech companies
          </p>
          <div className="font-normal mt-5">
            <button className="btn-blue-outline px-6 py-2 text-xs hover:bg-blue-first hover:text-white mr-4">
              Get Started
            </button>
            <button className="btn-blue px-6 py-2 text-xs font-semibold">
              SUPPORT US
            </button>
          </div>
        </div>
        <img className="lg:w-5/6 lg:h-5/6 lg:mr-20 w-4/5 h-4/5" src="/images/home/image-collection.png" alt="group of people" />
      </section>

      {/* Build better section */}
      <section className="font-poppins flex flex-col items-center mt-20">
        <h2 className="text-3xl text-black-text-color font-semibold">Let's Build A Better</h2>
        <h2 className="text-3xl text-black-text-color font-semibold mt-2">Tomorrow</h2>
        <p className="px-24 my-8 text-sm text-light-text-color text-center">
          {a2svDescription}
        </p>
        <button className="bg-blue-first border rounded-md text-white px-6 py-3">
          <img className="inline w-[20px] h-[20px] mr-2" src="images/home/message.svg"/>
          Connect to our team
        </button>
        <img className="lg:px-40 md:px-20 sm:15 xs:10 mt-20 mb-32 border" src="/images/home/laughing-people.svg" alt="Laughing people" />
        <h2 className="text-black-text-color lg:text-3xl md:text-2xl sm:text-xl font-semibold">Google SWE Interviews Acceptance </h2>
        <h2 className="text-black-text-color lg:text-3xl md:text-2xl sm:text-xlfont-semibold mt-2">Rate Comparison</h2>
      </section>

        {/* Rate and A2SV activities section */}
        <section className="font-poppins">
          <div className="flex lg:flex-row lg:justify-around flex-col lg:mx-28 md:mx-14 sm:mx-7 mt-24 bg-home-card-gray-bg border">
            <div className="px-4 py-14 lg:w-1/5 w-full">
              <p className="font-light text-light-gray text-start">A2SV students are <span className="font-semibold">35</span> times more likely to pass <span className="font-semibold"> Google SWE interviews</span> than average candidates.</p>
            </div>
            <div className="flex lg:flex-row flex-col gap-6 justify-around">
              {rateInfo.map(([year, a2svRate, globalRate]) => (
                <RateCard key={year} year={year} a2svRate={a2svRate} globalRate={globalRate} />
              ))}
            </div>
          </div>
        </section>

        <section className="flex flex-col mx-24 mt-24">
          {a2svActivityInfo.map(([imageSrc, title, description], index) => (
            <div
              key={title}
              className={`flex ${
                index % 2 === 0 ? 'lg:flex-row' : 'lg:flex-row-reverse'
              } flex-col justify-between items-center`}
            >
              <img
                className="w-48 h-48 lg:ml-10 mb-8"
                src={imageSrc}
                alt={`activity ${title}`}
              />
              <div
                className={`px-8 ${
                  index % 2 === 0 ? 'lg:pr-24' : 'lg:pl-24'
                } lg:w-1/2 w-full mb-8 lg:mb-16 text-center lg:text-${
                  index % 2 === 0 ? 'right' : 'left'
                }`}
              >
                <p className="text-xl text-black-text-color mb-4 font-semibold">
                  {title}
                </p>
                <p className="text-light-text-color text-sm">{description}</p>
              </div>
            </div>
          ))}
        </section>


      {/* Support us banner */}
      <div className="relative h-60 bg-gradient-to-r from-blue-first to-[#019CFA] flex justify-center items-center">
        <img className="w-60 h-60 m-auto opacity-5 bg-transparent" src="/images/home/africa.png" alt="" /> 
        <div className="absolute flex flex-col gap-6 font-montserrat font-semibold text-white">
          <p>Help us sustain our mission!</p>
          <button className="bg-white text-blue-600 px-6 py-2 text-xs border rounded-lg mx-10">
            Support Us
          </button>
        </div>
      </div>

      {/* Impact stories */}
      <section className="font-poppins mt-20 text">
        <h2 className="text text-center text-black-text-color text-3xl font-semibold mb-20">Impact Stories</h2>
        <div className="lg:grid lg:grid-rows-1 lg:grid-cols-2 flex flex-col">
          <div className="lg:flex lg:flex-col lg:text-left lg:ml-20 lg:w-3/4 text-center">
            <h3 className="text-deep-gray text-2xl font-bold mb-3">{impactStory[0]}</h3>
            <h4 className="text-light-text-color font-semibold mb-8">{impactStory[1]}</h4>
            <p className="text-deep-gray px-10 lg:px-0 lg:text-left lg:mb-6">{impactStory[2]}</p>
            <button className="self-start btn-blue px-8 py-3 my-6 text-xs">See more</button>
          </div>
          <img className="hidden lg:w-3/4 lg:text-right lg:block" src="/images/home/impact-story-gallery.png" alt="people portrait collage" />
        </div>
      </section>
    </main>
  )
}
