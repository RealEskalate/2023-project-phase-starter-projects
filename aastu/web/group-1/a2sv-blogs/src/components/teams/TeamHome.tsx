import Image from "next/image";
export default function TeamHome() {

  return (
    <div className="mt-0 max-w-7xl mx-auto px-4">
      
      <div className="md:flex md:items-center md:space-x-12">
      <div className= "pr-0">
          <h1 className="font-bold font-poppins text-4xl md:text-5xl text-gray-800 uppercase pl-[60px]  pt-[60px] w-[500px]">THE TEAM WE'RE </h1>
          <h1 className="font-bold font-poppins text-4xl md:text-5xl text-gray-800 uppercase pl-[60px]  w-[500px] pt-3">CURRENTLY</h1>
          <h1 className="font-bold font-poppins text-4xl md:text-5xl text-gray-800 uppercase pl-[60px] w-[500px] pt-3">WORKING WITH</h1>

          <p className="mt-5 text-gray-500  font-poppins text-xl font-normal pl-[62px] pt-6 w-[600px]">
          Meet our development team is a small but highly skilled and experienced group 
          of professionals. We have a talented mix of web developers, software engineers, 
          project managers and quality assurance specialists who are passionate about 
          developing exceptional products and services.
          </p>  
        </div>

        <Image 
          src="/team.png"  
          alt="team image"
          width={500}
          height={400}
          className="w-full mb-10 md:w-1/2 md:mb-0 rounded-lg mt-24 " 
        />

        

      </div>

      <hr className="my-10" />

    </div>
  );

}
