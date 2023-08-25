import Image from "next/image";

export default function TeamHome() {
    return (
        <div className=" mb-20">
      <div className="grid grid-cols-2 gap-5 pb-10 ">
        {/* Left Section */}
        <div className="pr-0">
          <h1 className="font-bold font-poppins text-5xl text-gray-800 uppercase pl-[60px]  pt-[60px] w-[500px]">THE TEAM WE'RE </h1>
          <h1 className="font-bold font-poppins text-5xl text-gray-800 uppercase pl-[60px]  w-[500px] pt-3">CURRENTLY</h1>
          <h1 className="font-bold font-poppins text-5xl text-gray-800 uppercase pl-[60px] w-[500px] pt-3">WORKING WITH</h1>

          <p className="text-gray-500 font-poppins text-xl font-normal pl-[62px] pt-6 w-[600px]">
          Meet our development team is a small but highly skilled and experienced group 
          of professionals. We have a talented mix of web developers, software engineers, 
          project managers and quality assurance specialists who are passionate about 
          developing exceptional products and services.
          </p>
        </div>  
  
        {/* Right Section */}
        <div className="relative w-[630px] h-[600px] bg-white pl-0">
            <Image
                src="/team.png"
                alt="Team"
                layout="fill"
                objectFit="cover"
                className="rounded-[12px]"
            />
         
        </div> 
        
        
      </div>
      <hr />
     

      </div>
    ); 
  }