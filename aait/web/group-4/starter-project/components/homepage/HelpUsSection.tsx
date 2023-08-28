import Image from "next/image";

const HelpUsSection = () => {
  return (
    <section className="relative bg-gradient-to-r from-primary-color to-dodger-blue px-12 py-32 mt-32">
      <Image
        className="z-0"
        src="/images/homepage/africa.svg"
        alt="Africa"
        fill
      />
      <div className="flex flex-col font-{montserrat} font-semibold gap-8 justify-center items-center">
        <h3 className="z-10  text-white text-center text-2xl md:text-3xl">
          Help us sustain our mission!
        </h3>
        <button className="z-10 bg-white text-sm md:text-xl text-primary-color px-12 py-3 rounded-md">
          Support Us
        </button>
      </div>
    </section>
  );
};

export default HelpUsSection;
