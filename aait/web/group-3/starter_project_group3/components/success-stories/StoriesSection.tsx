"use client";
import { useGetStoriesQuery } from "@/store/features/success-stories/sucess-stories-api";
import Image from "next/image";
import Loading from "../commons/Loading";
import Error from "../commons/Error";

const StoriesSection = () => {
  const { data: stories, error, isLoading } = useGetStoriesQuery();
  let isOrderLast = false;

  if (isLoading) {
    return <Loading />;
  }
  if (error) {
    return <Error />;
  }

  if (stories) {
    return (
      <div className="flex flex-col gap-36 font-Montserrat">
        {stories.map((story) => (
          <div
            key={story._id}
            className="flex flex-col items-center gap-9 nav_bar_screen:flex-row nav_bar_screen:justify-between"
          >
            <div
              className={`relative  min-w-[40%] overflow-hidden rounded-lg ${
                isOrderLast ? "nav_bar_screen:order-last" : ""
              }`}
            >
              {(isOrderLast = !isOrderLast)}
              <Image
                src={story.imgURL}
                alt="sucess story"
                width={1800}
                height={400}
              />

              <div className="flex flex-col items-start gap-2 p-6 absolute bottom-0 left-0 w-full text-white backdrop-filter backdrop-blur-lg">
                <p className="font-semibold text-sm md:text-xl">
                  {story.personName}
                </p>
                <p className="font-semibold text-sm md:text-lg">{story.role}</p>
                <p className="font-medium text-xs md:text-base">
                  {story.location}
                </p>
              </div>
            </div>

            <div className="flex flex-col gap-10 justify-center">
              {story.story.map((content) => (
                <div key={content._id}>
                  <h1 className="font-semibold leading-relaxed text-lg md:text-2xl">
                    {content.heading}
                  </h1>
                  <p className="mt-5 italic text-sm md:text-lg">
                    {content.paragraph}
                  </p>
                </div>
              ))}
            </div>
          </div>
        ))}
      </div>
    );
  } else {
    return null;
  }
};

export default StoriesSection;
