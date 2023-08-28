//"use client"

/* Components */

import LandingSection from "./components/home/LandingSection"
import BuildBetterSection from "./components/home/BuildBetterSection"
import HelpUs from "./components/home/HelpUs"
import ImpactStoriesSection from "./components/home/ImpactStoriesSection"
import SuccsessRateSection from "./components/home/SuccsessRateSection"

export default function IndexPage() {

  return (
    <div className='space-y-16'>
      <LandingSection />
      <BuildBetterSection />
      <SuccsessRateSection />
      <HelpUs />
      <ImpactStoriesSection />
    </div>
  )
}

export const metadata = {
  title: 'A2SV Blog',
}
