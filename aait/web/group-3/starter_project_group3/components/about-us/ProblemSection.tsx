import Image from "next/image";

const ProblemSection: React.FC = () => {
  return (
    <div className="grid gap-9 nav_bar_screen:gap-0 nav_bar_screen:grid-cols-2 w-full">
      <div className="description flex flex-col gap-12 font-Nunito nav_bar_screen:w-3/4">
        <h1 className="font-extrabold text-3xl nav_bar_screen:text-5xl font-Lato">
          The Problem We <span className="text-primary">Are Solving</span>
        </h1>

        <div className="flex flex-col gap-10">
          <div>
            <div className="p-4 w-fit rounded-2xl bg-dark_chocol">
              <Image
                src="/assets/about_us_africa.svg"
                alt="africa"
                width={30}
                height={30}
              />
            </div>
            <p className="mt-5 text-light_gray_text_color font-Nunito">
              Africa&apos;s future depends on innovation. Transformative
              technologies can drive rapid economic growth and lift millions of
              people out of poverty. However, university computer science
              education is misaligned with global market needs and fails to
              incorporate practice-based learning, leaving students unable to
              apply their skills in real-world contexts.
            </p>
          </div>

          <div>
            <div className="px-4 py-6 w-fit rounded-2xl bg-dark_chocol">
              <Image
                src="/assets/about_us_tag.svg"
                alt="africa"
                width={30}
                height={30}
              />
            </div>
            <p className="mt-5 text-light_gray_text_color font-Nunito">
              Africa&apos;s future depends on innovation. Transformative
              technologies can drive rapid economic growth and lift millions of
              people out of poverty. However, university computer science
              education is misaligned with global market needs and fails to
              incorporate practice-based learning, leaving students unable to
              apply their skills in real-world contexts.
            </p>
          </div>
        </div>
      </div>

      <Image
        className="order-first nav_bar_screen:order-last"
        src="/assets/about_us_problem.svg"
        alt="problem solving"
        height={400}
        width={700}
      />
    </div>
  );
};

export default ProblemSection;
