import Image from "next/image"
import Link from "next/link"

export const SocialProjectsSections = () => {
  return (
    <div className="lg:w-[1446px] lg:h-[1229px] rounded-md md:flex-col flex flex-col p-4 gap-4 lg:gap-24 lg:flex-col">

    <div className="lg:w-385 lg:h-78">
         <p className="font-poppins font-semibold text-5xl leading-78 text-center">Social <span className="text-blue-500">Projects</span></p>
    </div>


    <div className="lg:w-1473 lg:h-400 rounded-sm flex flex-col items-center gap-4 lg:flex-row lg:gap-24 md:w-md md:gap-12">
          <div className="lg:w-1/2 lg:h-400 rounded-sm">
              <Image src={"/images/about/rectangle-296.svg"} width={800} height = {400} alt="hakim hub"/>
          </div>

          <div className="lg:w-1/2 lg:h-344 flex flex-col justify-center gap-4">
                <p className="lg:w-202 lg:h-17 font-normal text-2xl leading-17 text-end font-fira-code text-blue-500">Social Project</p>
                <p className="font-semibold text-4xl leading-31 text-end font-inter text-blue-500">Hakim Hub</p>

                <div className="lg:w-612 lg:h-140">
                    <p className="font-poppins font-light text-2xl ">
                    HakimHub is a platform that provides information about healthcare facilities and healthcare professionals in Ethiopia. 
                    Hakimhub makes information about hospitals, medical laboratories, and doctors conveniently accessible to its users.
                    </p>
                </div>

                <div className="lg:w-full w-80 h-32 flex flex-row justify-end">
                  <Link href="#"><Image src={"/images/about/github.svg"} width={32} height={32} alt="github icon"/></Link>
                  <Link href="#"><Image src={"/images/about/link.svg"} width={32} height={32} alt="link icon"/></Link>
                </div>

          </div>
    </div>



    <div className="lg:w-1476 lg:52 rounded-md flex flex-col items-center md:w-md gap-4 lg:flex-row lg:gap-24">

          <div className="lg:w-1/2 lg:h-344 flex flex-col justify-center gap-4">
                <p className="lg:w-202 lg:h-17 font-normal text-2xl leading-17 text-start font-fira-code text-blue-500">Social Project</p>
                <p className="font-semibold text-4xl leading-31 text-start font-inter text-blue-500">Track Sym</p>

                <div className="lg:w-612 lg:h-140">
                    <p className="font-poppins font-light text-2xl">
                    TrackSym is a non-commercial app that uses crowd-sourcing to collect and visualize the density of the relevant Covid-19 symptoms.
                    Symptom data, aggregated by places, can help people avoid visiting areas that are heavily populated by symptomatic people.
                    </p>
                </div>

                <div className="w-80 h-32 flex flex-row">
                  <Link href="#"><Image src={"/images/about/github.svg"} width={32} height={32} alt="github icon"/></Link>
                  <Link href="#"><Image src={"/images/about/link.svg"} width={32} height={32} alt="link icon"/></Link>
                </div>
          </div>

          <div className="lg:w-1/2 lg:h-400 rounded-sm">
              <Image src={"/images/about/rectangle-tracksys.svg"} width={800} height = {400} alt="track system"/>
          </div>

    </div>
</div>
  )
}

export default SocialProjectsSections