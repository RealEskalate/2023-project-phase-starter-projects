import Image from "next/image";

const HeadLineSection: React.FC = () => {
  return (
    <div className="headline grid gap-9 nav_bar_screen:gap-0 nav_bar_screen:grid-cols-2 font-Poppins mt-20">
      <div className="description flex flex-col gap-12 nav_bar_screen:w-3/4">
        <h1 className="font-bold text-5xl nav_bar_screen:text-7xl">
          Africa to <span className="text-primary">Silicon Valley</span>
        </h1>
        <p className="text-xl nav_bar_screen:text-3xl text-left leading-relaxed">
          A2SV up-skills high-potential university students, connects them with
          opportunities at top tech companies
        </p>
        <div className="buttons flex gap-5 justify-start text-sm nav_bar_screen:text-lg">
          <button className="border-primary text-primary rounded-xl border-2 py-3 px-8 nav_bar_screen:px-5 hover:bg-primary hover:text-white transition ease-in-out duration-200">
            Get Started
          </button>
          <button className="uppercase flex gap-2 items-center  bg-primary rounded-xl text-white py-2 px-8 nav_bar_screen:px-5 group">
            support us{" "}
            <Image
              className="group-hover:animate-fade-right group-hover:animate-infinite animate-duration-2000 animate-ease-linear"
              src="/assets/landing_page_arrow.svg"
              width={30}
              height={30}
              alt="arrow"
            />
          </button>
        </div>
      </div>
      <Image
        objectFit="cover"
        src="/assets/landing_page_bubbles.svg"
        alt="active members"
        width={800}
        height={800}
      />
    </div>
  );
};

export default HeadLineSection;
