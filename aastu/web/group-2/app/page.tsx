/* Components */

import LandingSection from "./components/home/LandingSection"
import BuildBetterSection from "./components/home/BuildBetterSection"

export default function IndexPage() {
  return (
  <>
    <LandingSection />
    <BuildBetterSection />
  </>
  )
}

export const metadata = {
  title: 'Redux Toolkit',
}
