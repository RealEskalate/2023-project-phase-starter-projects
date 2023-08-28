import { AiOutlineMessage } from "react-icons/ai";
import Image from "next/image";

const BuildBetterSection = () => {
  return (
    <section className="flex flex-col gap-16 items-center text-center">
      <h2 className="text-[#363636] text-4xl md:text-5xl font-semibold capitalize lg:w-1/3 leading-normal mt-44">
        Lets build a better tomorrow
      </h2>
      <p className="text-[#7D7D7D] text-2xl md:text-3xl">
        A2SV upskills high-potential university students, connects them with
        opportunities at top tech companies around the world, and creates
        digital solutions to urgent problems in their home countries. The
        program is free for students, making the opportunity available for youth
        who have talent but lack the means to use it.
      </p>

      <button className="flex gap-4 items-center px-12 py-5 rounded-lg text-white bg-primary-color text-lg md:text-2xl">
        <span>
          <AiOutlineMessage/>
        </span>
        <span>Connect to our team</span>
      </button>

      <Image
        src="/images/homepage/build-better-section-image.png"
        alt="Connect to our team"
        height={1400}
        width={1400}
      />
    </section>
  );
};

export default BuildBetterSection;
