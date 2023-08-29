import StoriesSection from "@/components/success-stories/StoriesSection";
import HeadLineSection from "@/components/success-stories/HeadLineSection";
import InterviewPartnerSection from "@/components/success-stories/InterviewPartnerSection";

const SuccessStories = () => {

  return (
    <div className="flex flex-col gap-14 items-center mx-10 md:mx-20 mt-20">
      <HeadLineSection />
      <StoriesSection />
      <InterviewPartnerSection />
    </div>
  );
};

export default SuccessStories;
