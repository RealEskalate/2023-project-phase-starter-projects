"use client"

/* Components */

import LandingSection from "./components/home/LandingSection"
import BuildBetterSection from "./components/home/BuildBetterSection"
import HelpUs from "./components/home/HelpUs"
import ImpactStoriesSection from "./components/home/ImpactStoriesSection"
import SuccsessRateSection from "./components/home/SuccsessRateSection"

export default function IndexPage() {

  console.log(localStorage.getItem('login'));
  

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

export const metadata = {
  title: 'Redux Toolkit',
}
