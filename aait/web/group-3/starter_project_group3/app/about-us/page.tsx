// Importing necessary components
import HeadLineSection from "@/components/about-us/HeadLineSection";
import ProblemSection from "@/components/about-us/ProblemSection";
import SessionSection from "@/components/about-us/SessionSection";
import SocialProjectSection from "@/components/about-us/SocialProjectSection";
import SolvingSection from "@/components/about-us/SolvingSection";

// Defining the AboutUs functional component
const AboutUs: React.FC = () => {
  return (
    // Wrapping the content in a flex container with vertical alignment
    <div className="flex flex-col items-center mx-8 md:mx-20 gap-56 ">
      {/* Rendering the HeadLineSection component */}
      <HeadLineSection />

      {/* Rendering the ProblemSection component */}
      <ProblemSection />

      {/* Rendering the SolvingSection component */}
      <SolvingSection />

      {/* Rendering the SocialProjectSection component */}
      <SocialProjectSection />

      {/* Rendering the SessionSection component */}
      <SessionSection />
    </div>
  );
};

// Exporting the AboutUs component as the default export
export default AboutUs;
