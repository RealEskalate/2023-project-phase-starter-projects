import Image from "next/image";
import Link from "next/link";

const SocialProjectSection: React.FC = () => {
  return (
    <div className="flex flex-col gap-20">
      <h1 className="font-semibold text-3xl nav_bar_screen:text-5xl text-center font-Poppins">
        Social <span className="text-primary">Projects</span>
      </h1>

      <div className="flex flex-col gap-24">
        <div className="grid gap-9 nav_bar_screen:gap-0 nav_bar_screen:grid-cols-2 w-full">
          <Image
            src="/assets/about_us_hakimhub.png"
            alt="problem solving"
            height={400}
            width={700}
          />

          <div className="flex flex-col gap-7 text-right items-center nav_bar_screen:items-end">
            <div>
              <p className="font-Fira_code text-primary">Social Project</p>
              <p className="font-Inter font-semibold text-primary text-3xl">
                Hakim Hub
              </p>
            </div>

            <p className="font-Poppins text-lg font-light text-center nav_bar_screen:text-right">
              HakimHub is a platform that provides information about healthcare
              facilities and healthcare professionals in Ethiopia. Hakimhub
              makes information about hospitals, medical laboratories, and
              doctors conveniently accessible to its users.
            </p>

            <div className="flex gap-5">
              <Link href="#">
                <Image
                  src="/assets/about_us_github.svg"
                  alt="github"
                  height={30}
                  width={30}
                />
              </Link>

              <Link href="#">
                <Image
                  src="/assets/about_us_link.svg"
                  alt="github"
                  height={30}
                  width={30}
                />
              </Link>
            </div>
          </div>
        </div>

        <div className="grid gap-9 nav_bar_screen:gap-9 nav_bar_screen:grid-cols-2 w-full">
          <Image
            className="order-first nav_bar_screen:order-last w-full"
            src="/assets/about_us_tracksys.png"
            alt="problem solving"
            height={400}
            width={700}
          />

          <div className="flex flex-col gap-7 items-center nav_bar_screen:items-start">
            <div>
              <p className="font-Fira_code text-primary">Social Project</p>
              <p className="font-Inter font-semibold text-primary text-3xl">
                Track Sym
              </p>
            </div>

            <p className="font-Poppins text-lg font-light text-center nav_bar_screen:text-left">
              TrackSym is a non-commercial app that uses crowd-sourcing to
              collect and visualize the density of the relevant Covid-19
              symptoms. Symptom data, aggregated by places, can help people
              avoid visiting areas that are heavily populated by symptomatic
              people.
            </p>

            <div className="flex gap-5">
              <Link href="#">
                <Image
                  src="/assets/about_us_github.svg"
                  alt="github"
                  height={30}
                  width={30}
                />
              </Link>

              <Link href="#">
                <Image
                  src="/assets/about_us_link.svg"
                  alt="github"
                  height={30}
                  width={30}
                />
              </Link>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SocialProjectSection;
