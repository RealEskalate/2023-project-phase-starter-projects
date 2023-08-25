import LandingSection from "./LandingSection";
import BuildBetterSection from "./BuildBetterSection";
import SuccessRateSection from "./SuccessRateSection";
import HelpUsSection from "./HelpUsSection";
import ImpactStoriesSection from "./ImpactStoriesSection";

const HomePage = () => (
  <div className="p-10 flex flex-col md:p-20 space-y-24">
    {/* Landing Section */}
    <LandingSection />

    {/* Build a better tomorrow section */}
    <BuildBetterSection />

    {/* Success Rate section */}
    <SuccessRateSection />

    {/* Help us section */}
    <HelpUsSection />

    {/* Impact stories section */}
    <ImpactStoriesSection />
  </div>
);

export default HomePage;
