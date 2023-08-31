import Image from "next/image"
import Link from "next/link"
import { SessionsSection } from "@/components/about/SessionsSection"
import { AboutSection } from "@/components/about//AboutSection"
import { ProblemsSection } from "@/components/about//ProblemsSection"
import { HowWeSolveSection } from "@/components/about//HowWeSolveSection"
import SocialProjectsSections from "@/components/about//SocialProjectsSections"

export default function About(){
  return (
    <div className="min-h-full max-w-screen px-5  lg:px-10 m-5 lg:m-10 flex flex-col items-center gap-8 lg:gap-24 tablet:flex-col">
        <AboutSection/>
        <ProblemsSection/>
        <HowWeSolveSection/>
        <SocialProjectsSections/>
        <div className="lg:w-[379px] lg:h-78">
             <p className="font-poppins font-semibold text-5xl leading-78 text-center">A2SV <span className="text-blue-500">Sessions</span></p>
        </div>
        <SessionsSection/>
    </div>
  )
}
