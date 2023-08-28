import Image from "next/image";

export const AboutSection = () => {
  return (
    <div className="flex flex-col md:m-10 lg:flex-row gap-4 p-4 lg:w-[1446px] lg:h-[854px]">
      <div className="flex flex-col gap-y-14 lg:h-[691px] lg:w-[879px] tablet:w-1/2">
        <h1 className="lg:w-[482px] lg:h-[50px] lg:font-48 font-lato table:text-3xl text-5xl">
          <span className="text-blue-500">Africa</span> to Silicon Valley
        </h1>
        
        <p className="text-2xl font-normal font-nunito lg:leading-[38px] lg:w-2/4">
          A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems. 
        </p>
        
        <button className="bg-blue-500 h-10 w-36 text-white rounded-md font-nunito font-normal ">
          Meet our team
        </button>
        
        <p className="font-nunito font-light italic text-2xl leading-38 lg:w-2/4">
          A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.
        </p>
      </div>

      <div className="flex flex-col lg:h-[691px] lg:w-[879px] gap-2 lg:gap-4 tablet:max-w-1/2">
        <p className="font-poppins font-medium text-xl leading-30">Group activities</p>

        <div className="flex flex-col md:flex-row gap-2 lg:h-[276px] lg:w-[800px]">
          <div className="lg:w-[388px] lg:h-[276px] bg-red m-2">
            <Image 
              src="/images/about/activity-tile-2.svg" alt="about seciton activity-tile icon"
              width={388}
              height={276}
            />
          </div>

          <div className="lg:w-[388px] lg:h-[276px] bg-green m-2">
            <Image 
              src="/images/about/activity-tile-5.svg" alt="about section activity-tile icon"
              width={388}
              height={276}
            />
          </div>
        </div>

        <div className="lg:w-[800px] lg:h-[212px]">
          <Image 
            src="/images/about/more-info-7-1.svg" alt="about section more-info icon "
            width={800}
            height={212}
          />
        </div>
      </div>
    </div>
  )
}
