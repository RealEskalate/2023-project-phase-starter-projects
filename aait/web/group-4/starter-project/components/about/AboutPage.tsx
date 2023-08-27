import Image from "next/image"
import Link from "next/link"
import { SessionsSection } from "./SessionsSection"
import { AboutSection } from "./AboutSection"
import { ProblemsSection } from "./ProblemsSection"
import { HowWeSolveSection } from "./HowWeSolveSection"
import SocialProjectsSections from "./SocialProjectsSections"
export const About = () => {
  return (
    <div className="min-h-full px-5 lg:px-10 m-5 lg:m-10 flex flex-col items-center gap-12 lg:gap-24 max-w-3/4">
        <AboutSection/>
        <ProblemsSection/>
        <HowWeSolveSection/>
        <SocialProjectsSections/>
        <div className="lg:w-379 lg:h-78">
             <p className="font-poppins font-semibold text-5xl leading-78 text-center">A2SV <span className="text-blue-500">Sessions</span></p>
        </div>
        <SessionsSection/>
    </div>
  )
}

