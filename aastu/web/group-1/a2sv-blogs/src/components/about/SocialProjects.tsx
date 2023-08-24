import React from "react";
import Image from "next/image";

const SocialProjects = () => {
  return (
    <div className="mt-16">
      <div className="flex justify-center items-center h-[100px]">
        <h1 className="text-3xl font-bold text-center">Social Project</h1>
      </div>
      <div className="grid lg:grid-cols-2 grid-cols-1">
        <div>
          <Image
            width={400}
            height={250}
            src="/images/project image areahakimhub.png"
            alt="img"
            className="w-full"
          />
        </div>
        <div className="flex flex-col items-end justify-center">
          <h6 className="text-blue-800 py-1">Social Project</h6>
          <h5 className="text-2xl font-bold text-blue-800 py-1">Hakim Hub</h5>
          <p className="text-neutral-500 text-sm font-poppins text-right font-light leading-7 tracking-tight max-w-[47ch]">
            HakimHub is a platform that provides information about healthcare
            facilities and healthcare professionals in Ethiopia. Hakimhub makes
            information about hospitals, medical laboratories, and doctors
            conveniently accessible to its users.
          </p>
          <div className="mt-4">
            <Image width={60} height={10} src="/images/Icons.png" alt="" />
          </div>
        </div>
      </div>

      <div className="grid lg:grid-cols-2 grid-cols-1 mt-24">
        <div>
          <h6 className="text-blue-800 py-1">Social Project</h6>
          <h3 className="text-2xl font-bold text-blue-800 py-1">Track Sym</h3>
          <p className="text-neutral-400 text-sm max-w-[50ch] leading-relaxed">
            TrackSym is a non-commercial app that uses crowd-sourcing to collect
            and visualize the density of the relevant Covid-19 symptoms. Symptom
            data, aggregated by places, can help people avoid visiting areas
            that are heavily populated by symptomatic people.
          </p>
          <div className="mt-4">
            <Image width={60} height={10} src="/images/Icons.png" alt="ing" />
          </div>
        </div>
        <div className="my-10">
          <Image
            width={500}
            height={100}
            src="/images/Rectangle 297tracksys (1).png"
            className="w-full"
            alt="img"
          />
        </div>
      </div>
    </div>
  );
};

export default SocialProjects;
