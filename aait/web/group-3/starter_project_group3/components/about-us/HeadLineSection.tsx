import Image from "next/image";

const HeadLineSection: React.FC = () => {
  return (
    <div className="headline grid gap-9 nav_bar_screen:gap-0 nav_bar_screen:grid-cols-2 mt-20">
      <div className="description flex flex-col gap-12 font-Nunito nav_bar_screen:w-3/4">
        <h1 className="font-extrabold text-3xl nav_bar_screen:text-5xl font-Lato">
          <span className="text-primary">Africa </span> to Silicon Valley
        </h1>

        <p className="text-lg nav_bar_screen:text-xl text-left leading-relaxed">
          A2SV is a social enterprise that enables high-potential university
          students to create digital solutions to Africa&apos;s most pressing
          problems.
        </p>

        <button className="bg-primary rounded-xl text-white py-4 px-8 font-semibold w-fit">
          Meet our Team
        </button>

        <p className="italic font-light text-sm nav_bar_screen:text-lg">
          A2SV is a social enterprise that enables high-potential university
          students to create digital solutions to Africa&apos;s most pressing
          problems.
        </p>
      </div>

      <div className="font-Poppins">
        <p className="font-medium text-lg mb-4">Group activities</p>
        <div className="flex flex-wrap gap-3">
          <div className="flex justify-center items-center flex-grow rounded-lg bg-[url('/assets/about_us_education.png')] bg-cover p-16">
            <p className="text-white drop-shadow-lg font-medium">
              The education process
            </p>
          </div>
          <div className="flex justify-center items-center flex-grow rounded-lg bg-[url('/assets/about_us_development.png')] bg-cover p-16">
            <p className="text-white drop-shadow-lg font-medium">
              Development phase
            </p>
          </div>

          <div className="flex justify-center items-center gap-14 rounded-lg bg-very_dark_blue px-7 w-full py-7 min-[1281px]:py-7 min-[500px]:justify-between">
            <Image
              className="max-[1281px]:w-36 max-[500px]:hidden"
              src={"/assets/about_us_Beepath.svg"}
              alt="Bee path"
              height={200}
              width={250}
            />

            <div className="flex flex-col items-end gap-4">
              <p className="font-semibold text-white max-[1281px]:text-sm">
                20% percent growth
              </p>

              <div className="text-light_gray_text_color text-right max-[1281px]:text-sm">
                <p>180% students growth</p>
                <p>20% faster learning track</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HeadLineSection;
