import InterviewPartners from "@/components/stories/InterviewPartners";
import SuccessStoriesHeader from "@/components/stories/SuccessStoriesHeader";
import SuccessStoryCard from "@/components/stories/SuccessStoryCard";
import React from "react";

export default function page() {
  return (
    <div className="flex flex-col mt-36 gap-14 lg:px-32 px-5 mx-auto">
      <div className="">
        <SuccessStoriesHeader />
      </div>
      <div className="flex flex-col gap-28 mt-20">
        <SuccessStoryCard />
      </div>
      <div>
        <InterviewPartners />
      </div>
    </div>
  );
}
