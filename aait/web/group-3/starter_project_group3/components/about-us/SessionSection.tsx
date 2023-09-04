import { aboutUs } from "@/data/about-us/About-Us";
import Image from "next/image";

const SessionSection: React.FC = () => {
  return (
    <div className="flex flex-col gap-20">
      <h1 className="font-semibold text-3xl nav_bar_screen:text-5xl text-center font-Poppins">
        A2SV <span className="text-primary">Sessions</span>
      </h1>

      <div className="grid md:grid-cols-2 lg:grid-cols-3 font-Poppins gap-6">
        {aboutUs.map((data, i) => (
          <div className="flex flex-col gap-4 shadow-lg items-start border-2 p-6" key={i}>
            <div className="about-us-avatar rounded-full p-4">
              <Image src={data.imageUrl} width={40} height={40} alt="icons" />
            </div>

            <p className="font-semibold text-2xl">{data.title}</p>
            <p className="text-lg">{data.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default SessionSection;
