import Image from "next/image"

export const HowWeSolveSection = () => {
  return (
    <div className="lg:w-1446px lg:h-558 rounded-md flex flex-col gap-12 items-center lg:flex-row lg:gap-32">
            <div className="lg:w-1/2 lg:h-558">
                <Image src={"/images/about/amicopuzzle.svg"} width={500} height={400} alt="logo"/>
            </div>
            <div className="lg:w-1/2 lg:h-336 lg:flex lg:flex-col lg:gap-4">
                <div className="lg:w-522 lg:h-50">
                    <p className="lg:text-5xl lg:leading-50 text-2xl font-lato font-extrabold">How we are <span className="text-blue-500">solving</span> it</p>
                </div>
                <div className="bg-black w-14 h-14 rounded-md grid place-content-center">
                    <Image src={"/images/about/info iconicon3.svg"} width={40} height={40} alt="logo"/>
                </div>

                <div className="lg:w-636 lg:h-114">
                     <p className="font-nunito font-normal text-xl lg:text-2xl lg:leading-38">
                     Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere.
                     </p>
                </div>
            </div>
        </div>
  )
}

