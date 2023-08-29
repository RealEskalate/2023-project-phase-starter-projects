import Image from "next/image";

const ImpactStoriesSection = () => {
  return (
    <section className="flex flex-col gap-12 items-center">
      <h2 className="font-{montserrat} font-bold text-4xl md:text-5xl text-[#363636]">
        Impact Stories
      </h2>
      <div className="grid grid-flow-row auto-rows-max place-items-center gap-12 lg-1:gap-0 lg-1:grid-cols-2">
        {/* left section */}
        <div className="flex flex-col gap-12">
          <div className="flex flex-col gap-4 items-start">
            <h3 className="font-semibold text-2xl text-[#363636]">
              Abel Tsegaye
            </h3>
            <p className="font-medium text-lg text-[#4D4A49]">
              Software Engineer at Google
            </p>
          </div>
          <p className="text-sm md:text-xl text-[#242424]">
            “ When I joined A2SV in 2019, I found the concept of data structures
            and algorithms quite challenging. A2SV's smooth learning process and
            dedicated team molded me to see the peak of my abilities. Through
            A2SV's effective education and continual support, I passed Google's
            internship interviews and attended a summer internship at Google in
            Amsterdam. However, the A2SV program and training is beyond
            technical education and interview preparation. As an A2SVian, I also
            learned the values of putting humanity first, giving back to our
            community, and utilizing teamwork with my colleagues, which I can
            now consider my big family. After completing three remarkable months
            at Google, I was offered a full-time position at Google's London
            office for 2022. “
          </p>

          <button className="bg-primary-color text-white w-fit rounded-md px-10 py-3">
            See more
          </button>
        </div>
        {/* right section */}
        <div className="flex justify-end ">
          <Image
            objectFit="cover"
            src="/images/homepage/impact-story-gallery.png"
            alt="Impact Story Gallery"
            width={580}
            height={500}
          />
        </div>
      </div>
    </section>
  );
};

export default ImpactStoriesSection;
