import HeadLineSection from "@/components/home/HeadLineSection";
import ProgramSection from "@/components/home/ProgramSection";
import RateSection from "@/components/home/RateSection";
import { ScrollToTop } from "@/components/home/ScrollToTop";
import StorySection from "@/components/home/StorySection";
import TeamSection from "@/components/home/TeamSection";
import Image from "next/image";

export default function Home() {
  return (
    <div className="flex flex-col items-center mx-8 md:mx-20 gap-56 animate-fade-up">
      <HeadLineSection />
      <TeamSection />
      <RateSection />
      <ProgramSection />

      <div className="support_us relative flex flex-col gap-9 items-center w-full bg-gradient-to-r from-primary to-dodger_blue py-32">
        <Image
          className="z-0"
          src="/assets/landing_page_africa.svg"
          alt="Africa"
          fill
        />
        <p className="font-Montserrat text-xl nav_bar_screen:text-3xl text-white z-10">
          Help us sustain our mission!
        </p>
        <button
          className="font-semibold font-Montserrat text-xl text-primary bg-white rounded-md py-3 px-7 z-10 hover:animate-wiggle hover:animate-infinite animate-duration-1000 animate-ease-linear
"
        >
          Support Us
        </button>
      </div>

      <StorySection />
    </div>
  );
}
