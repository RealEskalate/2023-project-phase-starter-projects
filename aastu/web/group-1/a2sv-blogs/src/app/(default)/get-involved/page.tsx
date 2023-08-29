import React from "react";
import Image from "next/image";
export default function page() {
  return (
    <div className="lg:w-full flex lg:flex-row flex-col h-screen mt-32 lg:px-24 md:px-16 px-10 gap-5">
      <div className="lg:w-2/3 w-full flex flex-col gap-20 py-10">
        <h1 className="text-4xl text-center font-semibold font-poppins">
          What We Need
        </h1>
        <div className="flex md:flex-row flex-col gap-3">
          <div className="md:w-3/5  w-full flex flex-col gap-5 md:px-10 px-5">
            <h1 className="text-3xl font-semibold text-start font-poppins">
              Interview
            </h1>
            <p className="text-start text-2xl font-poppins">
              Our students are working towards world-class internships and
              full-time opportunities. We are not asking for positive
              discrimination, but a chance to shine. You can help us by offering
              interviews.
            </p>
          </div>
          <div className="md:w-2/5 w-full">
            <Image
              src="/images/getinvolved.svg"
              alt=""
              width={100}
              height={100}
              className="w-full h-full"
            ></Image>
          </div>
        </div>
      </div>
      <div className="lg:w-1/3 w-full  flex flex-col gap-10 py-10">
        <h1 className="text-center text-4xl leading-5 font-semibold py-3 font-poppins">
          Contact Us
        </h1>
        <form className="px-10  w-full flex flex-col bg-gray-200 py-10 rounded-3xl">
          <div className="mb-6">
            <label
              htmlFor="large-input"
              className="block mb-2 text-base font-medium text-gray-900 font-poppins"
            >
              Name
            </label>
            <input
              type="text"
              id="large-input"
              className="block w-full p-4 text-gray-900 border-gray-300 rounded-lg bg-gray-50 sm:text-md focus:ring-blue-500 focus:border-blue-500"
            />
          </div>
          <div className="mb-6">
            <label
              htmlFor="base-input"
              className="block mb-2 font-poppins text-base font-medium text-gray-900 "
            >
              Email
            </label>
            <input
              type="text"
              id="base-input"
              className="block w-full p-4 text-gray-900 border-gray-300 rounded-lg bg-gray-50 sm:text-md focus:ring-blue-500 focus:border-blue-500"
            />
          </div>
          <div>
            <label
              htmlFor="message"
              className="block font-poppins mb-2 text-base font-medium text-gray-900 "
            >
              Experience
            </label>
            <textarea
              id="message"
              rows={4}
              className="block p-2.5 w-full mb-2 text-sm text-gray-900 bg-gray-50 rounded-lg border-gray-300 focus:ring-blue-500 focus:border-blue-500"
              placeholder="Leave a comment..."
              defaultValue={""}
            />
          </div>
          <button
            type="submit"
            className="text-white bg-primary mt-3 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-base w-full sm:w-auto px-10 py-2.5 text-center mx-auto"
          >
            Send
          </button>
        </form>
      </div>
    </div>
  );
}
