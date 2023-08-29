import Image from "../../node_modules/next/image";
import React from "react";

const Social = () => {
  return (
    <>
      <div className="p-16">
        
          <h1 className="font-bold text-5xl text-center">
            Social <span className="text-blue-first font-poppins">Projects</span>
          </h1>
      
        <div className="flex flex-col sm:flex-row mt-20">
          <div className="lg:w-full mx-10 sm:w-1/3">
            <Image
              src="/images/about/hakimhub.png"
              alt=""
              width={800}
              height={400}
            />
          </div>
          <div className="sm:ml-10 mt-5">
            <div className="text-right mr-20">
            <h1 className="font-firaCode text-small-blue">Social Project</h1>
            <div>
              <h1 className="text-blue-first mt-5 text-3xl">Hakim Hub</h1>
            </div>
            </div>
            <p className="text-gray-400 mt-10">
              HakimHub is a platform that provides information about healthcare
              facilities and healthcare professionals in Ethiopia. Hakimhub
              makes information about hospitals, medical laboratories, and
              doctors conveniently accessible to its users.
            </p>
            <div className=" w-full flex justify-end pr-20 mt-8">
              <Image
                src="/images/about/github.png"
                alt=""
                width={40}
                height={15}
              />
              <Image
                className="ml-5"
                src="/images/about/link.png"
                alt=""
                width={40}
                height={15}
              />
            </div>
          </div>
        </div>
        <div className="flex flex-col sm:flex-row mt-20">
          <div className="sm:ml-10 mt-5">
            <h1 className="font-firaCode text-small-blue">Social Project</h1>
            <div>
              <h1 className="text-blue-first mt-5 text-3xl">Track Sym</h1>
            </div>
            <p className="text-gray-400 mt-10">
              TrackSym is a non-commercial app that uses crowd-sourcing to
              <br />
              collect and visualize the density of the relevant Covid-19
              <br />
              symptoms. Symptom data, aggregated by places, can help people
              avoid visiting areas that are heavily populated by symptomatic
              people.
            </p>

            <div className="flex mt-8">
              <Image
                src="/images/about/github.png"
                alt=""
                width={40}
                height={15}
              />
              <Image
                className="ml-5"
                src="/images/about/link.png"
                alt=""
                width={40}
                height={15}
              />
            </div>
          </div>
          <div className="mt-10">
            <Image
              className="w-full "
              src="/images/about/covid.png"
              alt=""
              width={800}
              height={400}
            />
          </div>
        </div>
      </div>
    </>
  );
};

export default Social;
