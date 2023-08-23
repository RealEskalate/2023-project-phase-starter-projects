/* Components */

import LandingSection from "./components/home/LandingSection"
import BuildBetterSection from "./components/home/BuildBetterSection"
import HelpUs from "./components/home/HelpUs"
import ImpactStoriesSection from "./components/home/ImpactStoriesSection"
import SuccsessRateSection from "./components/home/SuccsessRateSection"

export default function IndexPage() {
  return (
  <>
    <LandingSection />
    <BuildBetterSection />
    <SuccsessRateSection />
    <HelpUs />
    <ImpactStoriesSection />
  </>
  )

  }
