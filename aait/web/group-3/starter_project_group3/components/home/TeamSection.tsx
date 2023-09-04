import Image from "next/image";

const TeamSection: React.FC = () => {
  return (
    <div className="text-center flex flex-col items-center gap-10">
      <h1 className="capitalize text-2xl nav_bar_screen:text-3xl font-semibold text-black_text_color leading-relaxed min-[1100px]:w-1/6">
        Lets build a better tomorrow
      </h1>

      <p className="text-light_gray_text_color font-normal text-lg nav_bar_screen:text-xl">
        A2SV upskills high-potential university students, connects them with
        opportunities at top tech companies around the world, and creates
        digital solutions to urgent problems in their home countries. The
        program is free for students, making the opportunity available for youth
        who have talent but lack the means to use it.
      </p>
      <button className="flex gap-3 justify-center items-center px-5 py-3 rounded-md bg-primary text-white font-medium">
        <Image
          src="/assets/landing_page_message.svg"
          width={30}
          height={30}
          alt="arrow"
        />
        Connect to our team
      </button>

      <Image
        objectFit="cover"
        src="/assets/landing_page_people.jpg"
        alt="people"
        width={1500}
        height={800}
      />
    </div>
  );
};

export default TeamSection;
