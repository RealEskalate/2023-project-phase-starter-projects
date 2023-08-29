import Image from "next/image"

export const HowWeSolveSection = () => {
  return (
    <div className="lg:w-1446px lg:h-[558px] rounded-md flex flex-col sm:flex-col p-4 gap-12 items-center lg:flex-row lg:gap-32 md:flex-col">
            <div className="lg:w-1/2 lg:[h-558px]">
                <Image src={"/images/about/amico-puzzle.svg"} width={500} height={400} alt="how we solve puzzle "/>
            </div>
            <div className="lg:w-1/2 lg:h-[336px] lg:flex lg:flex-col lg:gap-4">
                <div className="lg:w-[522px] lg:h-50">
                    <p className="lg:text-5xl lg:leading-50 text-2xl font-lato font-extrabold">How we are <span className="text-blue-500">solving</span> it</p>
                </div>
                <div className="bg-black w-14 h-14 rounded-md grid place-content-center">
                    <Image src={"/images/about/info-icon-3.svg"} width={40} height={40} alt="how we solve bulb icon"/>
                </div>

                <div className="lg:w-[636px] lg:h-[114px]">
                     <p className="font-nunito font-normal text-xl lg:text-2xl lg:leading-38">
                     Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere.
                     </p>
                </div>
            </div>
        </div>
  )
}

