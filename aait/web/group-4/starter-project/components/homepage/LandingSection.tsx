import Image from "next/image";
import {BsArrowRightShort} from "react-icons/bs"

const LandingSection = () => (
  <section className="grid grid-flow-row auto-rows-max place-items-center gap-12 xl:grid-flow-col xl:auto-cols-fr">
    {/* Left Section */}
    <div className="flex flex-col gap-8 items-center lg-1:items-start">
      <h1 className="text-6xl font-extrabold text-center text-[#160041] md:text-7xl xl:w-3/4 xl:text-left">
        Africa to <span className="text-primary-color">Silicon Valley</span>
      </h1>
      <p className="text-2xl text-center text-[#424242] max-w-xl leading-relaxed mb-8 md:text-left md:text-4xl">
        A2SV up-skills high-potential university students, connects them with
        opportunities at top tech companies
      </p>
      <div className="flex justify-center text-sm w-full gap-4 lg-1:justify-start md:text-xl md:gap-8 ">
        <button className="text-primary-color font-medium  bg-smoke rounded-lg border-[3px] border-primary-color px-4 py-3 md:px-10 md:py-4">
          Get Started
        </button>
        <button className="bg-primary-color uppercase px-4 py-3 rounded-lg flex items-center gap-1 text-white md:flex-row md:w-fit  md:px-10 md:py-4">
          <span className="font-{roboto} font-semibold">Support Us</span>
          <BsArrowRightShort className="w-5 h-5"/>
        </button>
      </div>
    </div>
    {/* Right Section */}
    <div className="flex justify-end">
      <Image
        src="/images/homepage/image-collection.png"
        width={600}
        height={600}
        alt="a2svians"
      />
    </div>
  </section>
);

export default LandingSection;
