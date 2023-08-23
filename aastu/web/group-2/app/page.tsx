/* Components */

import LandingSection from "./components/home/LandingSection"
import BuildBetterSection from "./components/home/BuildBetterSection"
import HelpUs from "./components/home/HelpUs"
import ImpactStoriesSection from "./components/home/ImpactStoriesSection"

export default function IndexPage() {
  return (
  <>
    <LandingSection />
    <BuildBetterSection />
    <HelpUs />
    <ImpactStoriesSection />
  </>
  )
}

export const metadata = {
  title: 'Redux Toolkit',
}
