import Image from "next/image";

const SolvingSection: React.FC = () => {
  return (
    <div className="grid gap-9 nav_bar_screen:gap-0 nav_bar_screen:grid-cols-2 w-full">
      <Image
        src="/assets/about_us_puzzle.svg"
        alt="problem solving"
        height={400}
        width={700}
      />

      <div className="description flex flex-col gap-12 font-Nunito ">
        <h1 className="font-extrabold text-3xl nav_bar_screen:text-5xl font-Lato">
          How we are <span className="text-primary">solving</span> it
        </h1>

        <div>
          <div className="p-4 w-fit rounded-2xl bg-dark_chocol">
            <Image
              src="/assets/about_us_lamp.svg"
              alt="lamp"
              width={30}
              height={30}
            />
          </div>
          <p className="mt-5 text-light_gray_text_color font-Nunito">
            Offering students an ecosystem to actualize their ideas means that
            up-and-coming developers use their skills to benefit Africa, rather
            than taking their talent elsewhere.
          </p>
        </div>
      </div>
    </div>
  );
};

export default SolvingSection;
