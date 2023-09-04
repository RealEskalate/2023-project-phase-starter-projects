import Image from "next/image";
import { Story } from "@/types/story/story-type";

interface StoryCardProps {
  successStory: Story;
  index: number;
}

export const SuccessStoryCard: React.FC<StoryCardProps> = ({
  successStory,
  index,
}) => {
  return (
    <div className="flex flex-col items-center w-full gap-8 lg:justify-evenly lg:flex-row lg:gap-12 my-5 lg:my-10">
      <div
        className={`relative flex flex-col  ${
          index % 2 != 0 && "lg:order-last"
        } w-96 h-fit`}
      >
        <Image
          width={400}
          height={100}
          src={successStory?.imgURL}
          className="rounded-md"
          alt={successStory?.personName}
          priority
        />
        <div className="absolute flex flex-col gap-2 w-full bottom-0 p-8 rounded-lg shadow-lg backdrop-filter backdrop-blur-lg backdrop-opacity-100 text-white">
          <p className="text-2xl font-semibold">{successStory?.personName}</p>
          <p className="font-semibold text-lg">{successStory?.role}</p>
          <p className="font-semibold text-lg">{successStory?.location}</p>
        </div>
      </div>

      <div className="flex flex-grow flex-col max-w-3xl w-full md:w-96 gap-4 md:mt-0 mt-4 md:mx-4">
        {successStory.story.map((item) => {
          return (
            <div className="flex flex-col gap-2" key={item._id}>
              <h4 className="font-medium text-base md:text-3xl ">
                {item.heading}
              </h4>
              <p className="text-xs italic md:text-lg">{item.paragraph}</p>
            </div>
          );
        })}
      </div>
    </div>
  );
};
