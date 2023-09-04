import Image from "next/image";

const StorySection: React.FC = () => {
  return (
    <div className="flex flex-col gap-24">
      <h1 className="capitalize text-2xl nav_bar_screen:text-3xl font-bold text-black_text_color leading-relaxed text-center">
        Impact stories
      </h1>
      <div className="grid gap-9 nav_bar_screen:gap-0 nav_bar_screen:grid-cols-2">
        <div className="flex flex-col items-center gap-16 nav_bar_screen:items-start">
          <div>
            <h1 className="font-semibold text-2xl text-center nav_bar_screen:text-left nav_bar_screen:text-3xl leading-relaxed mb-2">
              Abel Tsegaye
            </h1>
            <p className="font-medium text-lg nav_bar_screen:text-xl">
              Software Engineer at Google
            </p>
          </div>

          <p className="text-lg nav_bar_screen:text-2xl nav_bar_screen:w-3/4">
            “ When I joined A2SV in 2019, I found the concept of data structures
            and algorithms quite challenging. A2SV&apos;s smooth learning
            process and dedicated team molded me to see the peak of my
            abilities. Through A2SV&apos;s effective education and continual
            support, I passed Google&apos;s internship interviews and attended a
            summer internship at Google in Amsterdam. However, the A2SV program
            and training is beyond technical education and interview
            preparation. As an A2SVian, I also learned the values of putting
            humanity first, giving back to our community, and utilizing teamwork
            with my colleagues, which I can now consider my big family. After
            completing three remarkable months at Google, I was offered a
            full-time position at Google&apos;s London office for 2022. “
          </p>

          <button className="bg-primary rounded-lg text-white py-5 px-11">
            see more
          </button>
        </div>

        <Image
          objectFit="cover"
          src="/assets/landing_page_stories.svg"
          alt="stories"
          width={1000}
          height={800}
        />
      </div>
    </div>
  );
};

export default StorySection;
