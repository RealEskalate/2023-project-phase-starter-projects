import React from "react";
import Image from "@/node_modules/next/image";
const Problems = () => {
  return (
    <>
      <div className="p-10 flex flex-col sm:flex-row w-full mx-auto">
        <div className="p-16 w-full sm:w-1/2 md:w-3/4 lg:w-full">
          <h1 className="font-bold font-lato text-5xl">
            The Problems We{" "}
            <span className="text-blue-first ">
              Are
              <br />
              Solving
            </span>{" "}
          </h1>
          <div className="mt-10 relative">
            <Image
              src="/images/about/Rectangle 290.png"
              alt=""
              width={80}
              height={80}
            />
            <Image
              className="absolute bottom-5 left-5"
              src="/images/about/africa.png"
              alt=""
              width={40}
              height={45}
            />
          </div>
          <div className="mt-20">
            <p className="font-nunito  text-light-text-color">
              Africa’s future depends on innovation. Transformative technologies
              can drive rapid economic growth and lift millions of people out of
              can drive rapid economic growth and lift millions of people out of
              poverty. However, university computer science education
              ismisaligned with global market needs and fails to incorporate
              practice-based learning, leaving students unable to apply their
              skills in real-world contexts.
            </p>
          </div>
          <div className="mt-20 relative">
            <Image
              src="/images/about/Rectangle 290.png"
              alt=""
              width={80}
              height={80}
            />
            <Image
              className="absolute bottom-4 left-4"
              src="/images/about/bracket.png"
              alt=""
              width={45}
              height={45}
            />
          </div>
          <div className="mt-20">
            <p className="font-nunito text-paragraph-color">
              With few global tech companies on the continent, aspiring <br />
              engineers don’t have access to experienced mentors or the
              <br /> opportunity to work on products that operate at scale.
              Smart and <br />
              ambitious students who could create life-changing technologies
              <br /> aren’t able to reach their potential.
            </p>
          </div>
        </div>
        <div className="p-4 sm:ml-10 mt-4 sm:mt-0 sm:w-auto">
          <Image
            className="mt-36 mx-auto"
            src="/images/about/Problem-solving.png"
            alt="problem-solvin-img"
            width={1000}
            height={563}
          />
        </div>
      </div>
      <div className="p-10 flex flex-col sm:flex-row w-full mx-auto">
        <div className="p-20 lg:w-1/2 sm:w-1/2">
          <Image
            src="/images/about/puzzle.png"
            alt="puzzle-image"
            width={600}
            height={560}
          />
        </div>
        <div className="mx-auto mt-10 sm:mt-0">
          <h1 className="text-5xl font-lato">
            How We are <span className="text-blue-first">solving </span>it
          </h1>
          <div className="relative mt-10">
            <Image
              src="/images/about/Rectangle 290.png"
              alt="background-img"
              width={80}
              height={80}
            />
            <Image
              className="absolute bottom-4 left-4"
              src="/images/about/bulb.png"
              alt="bulb"
              width={45}
              height={50}
            />
          </div>
          <p className="mt-20 font-lato text-pragraph-color">
            Offering students an ecosystem to actualize their ideas means that
            up-and-coming developers
            <br />
            use their skills to benefit Africa, rather than taking their talent
            elsewhere.
          </p>
        </div>
      </div>
    </>
  );
};

export default Problems;
