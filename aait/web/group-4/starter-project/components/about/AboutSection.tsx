import Image from "next/image"

export const AboutSection = () => {
  return (
    <div className="flex lg:flex-row gap-2 flex-col">
            
            <div className="flex flex-col gap-y-14 h-691 w-879">
               <h1 className="w-482 h-50px font-48 font-48 font-lato text-5xl">
                  <span className="text-blue-500">Africa</span> to Silicon Valley
               </h1>
              
               <p className="text-2xl font-normal font-nunito leading-38 lg:w-2/4">
                    A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems. 
               </p>
               
               <button className="bg-blue-500 h-10 w-36 text-white rounded-md font-nunito font-normal ">
                    Meet our team
               </button>
               <p className="font-nunito font-light italic text-2xl leading-38 lg:w-2/4">
                    A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.
               </p>
            </div>

            <div className="flex flex-col h-691 w-879 gap-4">
                <p className="font-poppins font-medium text-xl leading-30">Group activities</p>

                <div className="flex flex-row gap-2 h-276 w-800">
                        <div className="flex flex-row w-800 h-276 gap-2">
                            <div className="h-276 w-388 bg-red">
                            <Image 
                                src="/images/about/activity tile2.svg" alt="img"
                                width={388}
                                height={276}
                            />
                            </div>

                            <div className="w-388 h-276 bg-green">
                            <Image 
                                src="/images/about/activity tile5.svg" alt="img"
                                width={388}
                                height={276}
                            />
                            </div>

                        </div>
                </div>

                <div className="w-800 h-212">
                        <Image 
                        src="/images/about/more info7 (1).svg" alt="img"
                        width={800}
                        height={212}
                        />
                 </div>
           </div>

        </div>
  )
}
