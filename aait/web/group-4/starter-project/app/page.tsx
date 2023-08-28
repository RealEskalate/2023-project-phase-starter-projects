import BuildBetterSection from "@/components/homepage/BuildBetterSection";
import HelpUsSection from "@/components/homepage/HelpUsSection";
import ImpactStoriesSection from "@/components/homepage/ImpactStoriesSection";
import LandingSection from "@/components/homepage/LandingSection";
import SuccessRateSection from "@/components/homepage/SuccessRateSection";

export default function Home() {
  return (
      <div className="flex flex-col space-y-24">
        <LandingSection />

        <BuildBetterSection />

        <SuccessRateSection />

        <HelpUsSection />

        <ImpactStoriesSection />
      </div>
  );
}
