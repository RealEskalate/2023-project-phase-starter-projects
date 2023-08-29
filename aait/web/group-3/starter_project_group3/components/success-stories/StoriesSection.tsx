import { sucessStories } from "@/data/success_stories/SucessStories";
import Image from "next/image";

const StoriesSection = () => {
    return ( 
        <div className="flex flex-col gap-36 font-Montserrat">
        {sucessStories.map((sucessStory) => (
          <div className="flex flex-col items-center gap-9 nav_bar_screen:flex-row nav_bar_screen:justify-between">
            <div
              className={`relative rounded-lg w-full h-full ${
                sucessStory.isOrderLast ? "nav_bar_screen:order-last" : ""
              }`}
            >
              <Image
                src={sucessStory.image_url}
                alt="sucess story"
                width={1800}
                height={400}
              />

              <div className="flex flex-col items-start gap-2 p-6 rounded-b-lg absolute bottom-0 left-0 w-full text-white backdrop-filter backdrop-blur-lg">
                <p className="font-semibold text-sm md:text-xl">
                  {sucessStory.name}
                </p>
                <p className="font-semibold text-sm md:text-lg">
                  {sucessStory.position}
                </p>
                <p className="font-medium text-xs md:text-base">
                  {sucessStory.location}
                </p>
              </div>
            </div>

            <div className="flex flex-col gap-10 justify-center">
              <div>
                <h1 className="font-semibold leading-relaxed text-lg md:text-2xl">
                  {sucessStory.title_first}
                </h1>
                <p className="mt-5 italic text-sm md:text-lg">
                  {sucessStory.content_first}
                </p>
              </div>

              <div>
                <h1 className="font-semibold leading-relaxed text-lg md:text-2xl">
                  {sucessStory.title_second}
                </h1>
                <p className="mt-5 italic text-sm md:text-lg">
                  {sucessStory.content_second}
                </p>
              </div>

              <div>
                <h1 className="font-semibold leading-relaxed text-lg md:text-2xl">
                  {sucessStory.title_third}
                </h1>
                <p className="mt-5 italic text-sm md:text-lg">
                  {sucessStory.content_third}
                </p>
              </div>
            </div>
          </div>
        ))}
      </div>
    );

}
 
export default StoriesSection;