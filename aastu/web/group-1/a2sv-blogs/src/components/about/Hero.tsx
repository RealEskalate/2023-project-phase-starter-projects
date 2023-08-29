import React from "react";
import Image from "next/image";
import Link from "next/link";

const Hero = () => {
  return (
    <div>
      <section>
        <div>
          <div className="grid lg:grid-cols-2 grid-cols-1 justify-center">
            <div className="flex flex-col w-full mt-6 items-center md:items-start">
              <h3 className="text-5xl font-bold mb-5">
                <span className="text-primary">Africa</span> to Silicon Valley
              </h3>
              <p className="text-neutral-500 text-base mt-6 max-w-[50ch] leading-relaxed">
                A2SV is a social enterprise that enables high-potential
                university students to create digital solutions to Africa’s most
                pressing problems.
              </p>
              <Link href="/teams">
                <button className="bg-primary rounded-md px-9 py-4 text-white my-10 w-max">
                  Meet our team
                </button>
              </Link>
              <p className=" text-neutral-500 text-base max-w-[50ch] italic leading-relaxed">
                A2SV is a social enterprise that enables high-potential
                university students to create digital solutions to Africa’s most
                pressing problems.
              </p>
            </div>
            <div className="hidden lg:block">
              <h6>Group activity</h6>
              <div className="grid grid-cols-2 gap-5 mt-6 w-full">
                <Image
                  width={200}
                  height={200}
                  src="/images/activity tile2.png"
                  alt="image"
                  className="w-full"
                />
                <Image
                  width={200}
                  height={200}
                  src="/images/activity tile5.png"
                  alt="image"
                  className="w-full"
                />
              </div>
              <div>
                <div>
                  <Image
                    width={625}
                    height={200}
                    src="/images/more info7.png"
                    alt="image"
                    className="mt-4 rounded-md"
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
      <section>
        <div>
          <div className="grid lg:grid-cols-2 grid-cols-1 mt-10">
            <div className="py-10 justify-center">
              <h3 className="text-3xl font-bold">
                The Problem <span className="text-primary">We Are</span> <br />
                <span className="text-primary"> Solving</span>
              </h3>
              <div>
                <div className="mt-6">
                  <Image
                    width={50}
                    height={50}
                    src="/images/info iconicon1 (1).svg"
                    alt="image"
                  />
                </div>
                <p className="text-neutral-500 text-sm md:text-md mt-6 leading-relaxed">
                  Africa’s future depends on innovation. Transformative
                  technologies can drive rapid economic growth and lift millions
                  of people out of poverty. However, university computer science
                  education is misaligned with global market needs and fails to
                  incorporate practice-based learning, leaving students unable
                  to apply their skills in real-world contexts.
                </p>
              </div>
              <div className="mt-10">
                <Image
                  width={50}
                  height={50}
                  src="/images/info iconicon2.png"
                  alt="img"
                />
              </div>
              <p className="text-neutral-500 text-sm md:text-md mt-6 leading-relaxed">
                With few global tech companies on the continent, aspiring
                engineers don’t have access to experienced mentors, or the
                opportunity to work on products that operate at scale. Smart and
                ambitious students who could create life-changing technologies
                aren’t able to reach their potential.
              </p>
            </div>

            <div className="flex items-center justify-center">
              <Image
                width={400}
                height={563}
                src="/images/amicosolve.png"
                alt="image"
              />
            </div>
          </div>
          <div className="grid lg:grid-cols-2 grid-cols-1 gap-4 mt-20">
            <div className="">
              <Image
                width={300}
                height={300}
                src="/images/amicopuzzle.png"
                alt="img"
                className="w-2/3 hidden lg:block"
              />
            </div>
            <div className="">
              <h1 className="text-3xl font-bold">
                How we are <span className="text-primary">solving it</span>
              </h1>
              <div className="mt-5 ">
                <Image
                  width={50}
                  height={50}
                  src="/images/info iconicon3.png"
                  alt="img"
                />
              </div>
              <p className="text-neutral-500 text-sm md:text-md mt-5 leading-relaxed">
                Offering students an ecosystem to actualize their ideas means
                that up-and-coming developers use their skills to benefit
                Africa, rather than taking their talent elsewhere.
              </p>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Hero;
