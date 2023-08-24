import { training_programs } from "@/types/home/TrainingPrograms";
import Image from "next/image";

export default function Home() {
  return (
    <div className="flex flex-col items-center mx-20 gap-56">
      <div className="headline grid grid-cols-2 font-Poppins mt-20">
        <div className="description flex flex-col gap-12 w-3/4">
          <h1 className="font-bold text-7xl">
            Africa to <span className="text-primary">Silicon Valley</span>
          </h1>
          <p className="text-3xl text-left leading-relaxed">
            A2SV up-skills high-potential university students, connects them
            with opportunities at top tech companies
          </p>
          <div className="buttons flex gap-5 justify-start text-lg">
            <button className="border-primary text-primary rounded-xl border-2 py-3 px-5">
              Get Started
            </button>
            <button className="uppercase flex gap-2 items-center bg-primary rounded-xl text-white py-2 px-5">
              support us{" "}
              <Image
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

      <div className="text-center flex flex-col items-center gap-10">
        <h1 className="capitalize text-3xl font-semibold text-black_text_color leading-relaxed w-1/6">
          Lets build a better tomorrow
        </h1>
        <p className="text-light_gray_text_color font-normal text-xl">
          A2SV upskills high-potential university students, connects them with
          opportunities at top tech companies around the world, and creates
          digital solutions to urgent problems in their home countries. The
          program is free for students, making the opportunity available for
          youth who have talent but lack the means to use it.
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
          src="/assets/landing_page_people.png"
          alt="people"
          width={1500}
          height={800}
        />
      </div>

      <div className="interview_acceptance flex flex-col justify-center items-center gap-5">
        <h1 className="capitalize text-3xl font-semibold text-black_text_color leading-relaxed text-center w-2/5">
          Google SWE Interviews Acceptance Rate Comparison
        </h1>

        <div className="cards grid grid-cols-5 gap-8 rounded-2xl bg-lavender p-8">
          <p className="text-light_gray_text_color text-2xl">
            A2SV students are <strong className="text-black">35</strong> times
            more likely to pass{" "}
            <strong className="text-black">Google SWE interviews</strong> than
            average candidates.
          </p>

          <div className="flex flex-col justify-center items-center gap-10 bg-white rounded-2xl py-14 drop-shadow-md">
            <p className="text-dark_chocol font-semibold text-xl">2019</p>
            <div className="percents flex flex-col justify-center items-center gap-3">
              <p className="font-semibold text-2xl">Founded</p>
              <p className="text-light_gray_text_color">5% average</p>
            </div>
          </div>

          <div className="flex flex-col justify-center items-center gap-10 bg-white rounded-2xl p-6 drop-shadow-md">
            <p className="text-dark_chocol font-semibold text-xl">2020</p>
            <div className="percents flex flex-col justify-center items-center gap-3">
              <p className="font-semibold text-2xl">27%</p>
              <p className="text-light_gray_text_color">5.2% average</p>
            </div>
          </div>

          <div className="flex flex-col justify-center items-center gap-10 bg-white rounded-2xl p-6 drop-shadow-md">
            <p className="text-dark_chocol font-semibold text-xl">2021</p>
            <div className="percents flex flex-col justify-center items-center gap-3">
              <p className="font-semibold text-2xl">59%</p>
              <p className="text-light_gray_text_color">3.9% average</p>
            </div>
          </div>

          <div className="flex flex-col justify-center items-center gap-10 bg-white rounded-2xl p-6 drop-shadow-md">
            <p className="text-dark_chocol font-semibold text-xl">2022</p>
            <div className="percents flex flex-col justify-center items-center gap-3">
              <p className="font-semibold text-2xl">70%</p>
              <p className="text-light_gray_text_color">2.6% average</p>
            </div>
          </div>
        </div>
      </div>

      <div className="training_programs flex flex-col gap-36">
        {training_programs.map((training_program) => (
          <div className="flex justify-between items-center">
            <Image
              className={`${training_program.isOrderLast ? "order-last" : ""}`}
              src={training_program.image_url}
              alt="programs"
              height={400}
              width={400}
            />

            <div
              className={`flex flex-col gap-5 ${
                training_program.isOrderLast ? "" : "text-right items-end"
              }`}
            >
              <h1 className="font-semibold text-2xl">
                {training_program.title}
              </h1>
              <p className="text-light_gray_text_color text-xl w-1/2">
                {training_program.content}
              </p>
            </div>
          </div>
        ))}
      </div>

      <div className="support_us relative flex flex-col gap-9 items-center w-full bg-gradient-to-r from-primary to-dodger_blue py-32">
        <Image
          className="z-0"
          src="/assets/landing_page_africa.svg"
          alt="Africa"
          fill
        />
        <p className="font-Montserrat text-3xl text-white z-10">
          Help us sustain our mission!
        </p>
        <button className="font-semibold font-Montserrat text-xl text-primary bg-white rounded-md py-3 px-7 z-10">
          Support Us
        </button>
      </div>

      <div className="flex flex-col gap-24">
        <h1 className="capitalize text-3xl font-bold text-black_text_color leading-relaxed text-center">
          Impact stories
        </h1>
        <div className="grid grid-cols-2">
          <div className="flex flex-col gap-16 items-start">
            <div>
              <h1 className="font-semibold text-3xl leading-relaxed mb-2">
                Abel Tsegaye
              </h1>
              <p className="font-medium text-xl">Software Engineer at Google</p>
            </div>

            <p className="text-2xl w-3/4">
              “ When I joined A2SV in 2019, I found the concept of data
              structures and algorithms quite challenging. A2SV's smooth
              learning process and dedicated team molded me to see the peak of
              my abilities. Through A2SV's effective education and continual
              support, I passed Google's internship interviews and attended a
              summer internship at Google in Amsterdam. However, the A2SV
              program and training is beyond technical education and interview
              preparation. As an A2SVian, I also learned the values of putting
              humanity first, giving back to our community, and utilizing
              teamwork with my colleagues, which I can now consider my big
              family. After completing three remarkable months at Google, I was
              offered a full-time position at Google's London office for 2022. “
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
    </div>
  );
}
