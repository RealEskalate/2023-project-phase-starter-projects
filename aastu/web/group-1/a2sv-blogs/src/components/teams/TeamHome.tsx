import Image from "next/image";

export default function TeamHome() {
  return (
    <div className="text-center md:text-left ">
      <div className="flex flex-col md:flex-row md:items-center">
        <div className="md:w-1/2 md:pr-4 md:pt-[3px]">
          <h1 className="font-bold font-poppins text-2xl md:text-5xl text-gray-800 uppercase mb-3 pt-20 ">
            THE TEAM WE'RE <br /> CURRENTLY <br /> WORKING WITH
          </h1>
          <p className="text-gray-500 font-poppins text-sm md:text-xl font-normal md:w-5/5 mb-2">
            Meet our development team is a small but highly skilled and
            experienced group of professionals. We have a talented mix of web
            developers, software engineers, project managers, and quality
            assurance specialists who are passionate about developing
            exceptional products and services.
          </p>
        </div>
        <div className="md:w-1/2 md:pl-16 md: pt-[80px]">
          <Image
            src="/images/team_.png"
            alt="team image"
            width={600}
            height={500}
            className="hidden md:block"
          />
        </div>
      </div>
      <hr className="my-8 md:my-12" />
    </div>
  );
}
