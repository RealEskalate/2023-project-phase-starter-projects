import SuccessStoryProps from "@/types/successStories";

const SingleSuccessStory = ({ successStory, index }: SuccessStoryProps) => {
  const direction = index % 2 ? "md:flex-row-reverse" : "md:flex-row";
  return (
    <div
      className={`flex w-100 p-5 md:p-32 flex-col items-center ${direction} justify-around mt-10 md:mt-4`}
    >
      <div
        className="h-screen w-4/5 md:w-2/5 bg-center bg-cover overflow-hidden rounded-xl flex flex-col-reverse"
        style={{ backgroundImage: `url(${successStory.imgURL})` }}
      >
        <div className="h-32 md:h-48 w-full backdrop-blur-lg bg-whilte/30 rounded-xl overflow-hidden p-2 md:p-5">
          <h2 className="text-white font-sans text-xl md:text-4xl font-semibold m-3">
            {successStory.personName}
          </h2>
          <p className="text-white font-sans text-sm sm:text-normal md:text-2xl font-semibold m-3">
            {successStory.role}
          </p>
          <p className="text-white font-sans text-sm sm:text-normal md:text-2xl font-semibold m-3">
            {successStory.location}
          </p>
        </div>
      </div>
      <div className="w-4/5 md:w-1/2 mt-10">
        <div className="flex flex-col pt-8 ">
          {successStory.story.map((story) => {
            return (
              <div key={story._id} className="mt-8 text-center md:text-left">
                <h3 className="font-poppins font-semibold text-2xl">
                  {story.heading}
                </h3>
                <p className="font-poppins text-gray-500 italic font-thin space-x-1 text-base mt-4">
                  {story.paragraph}
                </p>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default SingleSuccessStory;
