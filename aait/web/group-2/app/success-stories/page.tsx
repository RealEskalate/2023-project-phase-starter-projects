"use client";

import SingleSuccessStory from "@/components/single-success-story/SingleSuccessStory";
import { useGetSuccessStoriesQuery } from "@/store/features/success-stories";
import { SuccessStory } from "@/types/successStories";

const SuccessStories = () => {
  const {
    isLoading,
    isSuccess,
    data: successStories,
    error,
    isError,
  } = useGetSuccessStoriesQuery();
  return (
    <main className="">
      <section className="flex flex-col items-center mt-10 md:mt-20">
        <h1 className="text-5xl font-poppins text-gray-800 font-bold text-center">
          Impact Stories
        </h1>
        <p className="text-4xl font-poppins text-gray-700 w-3/4 text-center mt-10 leading-normal">
          Behind every success is a story. Learn about the stories of A2SVians
        </p>
        <div className="w-20 h-2 bg-primary mt-4"></div>
      </section>
      {isLoading && (
        <div className="text-center text-6xl my-48 font-poppins">
          loading...
        </div>
      )}
      {isSuccess && (
        <div className="mt-6">
          {successStories.map((story: SuccessStory, index: number) => (
            <div key={story._id}>
              <SingleSuccessStory successStory={story} index={index} />
            </div>
          ))}
        </div>
      )}
      {isError && <p className="text-red-900">Failed to load data</p>}
      <article>
        <h2 className="font-dm-sans text-center text-5xl text-gray-800 font-semibold mt-10 mx-7">
          Current Interview Partners
        </h2>
        <section className="flex flex-wrap justify-around mx-10 mt-16 md:mx-56 md:mt-24 md:gap-x-14 h-max">
          <div
            className="w-24 h-7 md:w-48 md:h-14 bg-center bg-cover mb-10"
            style={{
              backgroundImage:
                "url('./images/success-stories/google-logo.png')",
            }}
          />
          <div
            className="w-24 h-7 md:w-48 md:h-14 bg-center bg-cover mb-10"
            style={{
              backgroundImage:
                "url('./images/success-stories/palantir-logo.png')",
            }}
          />
          <div
            className="w-24 h-7 md:w-48 md:h-14 bg-center bg-cover mb-10"
            style={{
              backgroundImage:
                "url('./images/success-stories/inst-deep-logo.png')",
            }}
          />
          <div
            className="w-24 h-7 md:w-48 md:h-14 bg-center bg-cover mb-10"
            style={{
              backgroundImage: "url('./images/success-stories/meta-logo.png')",
            }}
          />
          <div
            className="w-24 h-7 md:w-48 md:h-14 bg-center bg-cover mb-10"
            style={{
              backgroundImage:
                "url('./images/success-stories/databricks-logo.png')",
            }}
          />
          <div
            className="w-24 h-7 md:w-48 md:h-14 bg-center bg-cover mb-10"
            style={{
              backgroundImage:
                "url('./images/success-stories/linkedin-logo.png')",
            }}
          />
        </section>
      </article>
    </main>
  );
};

export default SuccessStories;
