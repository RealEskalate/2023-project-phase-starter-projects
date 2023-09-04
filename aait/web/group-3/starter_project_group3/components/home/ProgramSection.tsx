import { training_programs } from "@/types/home/TrainingPrograms";
import Image from "next/image";

const ProgramSection: React.FC = () => {
  return (
    <div className="training_programs flex flex-col gap-36">
      {training_programs.map((training_program, i) => (
        <div
          className="flex flex-col justify-center min-[1265px]:flex-row min-[1265px]:justify-between items-center gap-9"
          key={i}
        >
          <Image
            className={`${
              training_program.isOrderLast ? "min-[1265px]:order-last" : ""
            }`}
            src={training_program.image_url}
            alt="programs"
            height={400}
            width={400}
          />

          <div
            className={`flex flex-col max-[1265px]:items-center max-[1265px]:text-center ${
              training_program.isOrderLast
                ? ""
                : "min-[1265px]:text-right min-[1265px]:items-end"
            }`}
          >
            <h1 className="font-semibold text-xl nav_bar_screen:text-2xl">
              {training_program.title}
            </h1>
            <p className="text-light_gray_text_color text-lg nav_bar_screen:text-xl w-2/3 nav_bar_screen:w-1/2">
              {training_program.content}
            </p>
          </div>
        </div>
      ))}
    </div>
  );
};

export default ProgramSection;
