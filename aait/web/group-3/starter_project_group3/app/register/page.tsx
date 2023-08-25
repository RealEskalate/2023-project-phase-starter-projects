import Footer from "@/components/footer/Footer";
import React from "react";

const Register: React.FC = () => {
  return (
    <>
      <div className="flex flex-col items-center justify-center py-5 w-8/12 my-10 mx-auto rounded-lg font-Montserrat bg-gray-100">
        <div className=" p-8 rounded">
          <h2 className="text-2xl text-nav_text_color font-bold mb-4">
            Register
          </h2>
          <form>
            {/* name */}
            <div className="mb-4">
              <label
                htmlFor="name"
                className="block text-gray-700 font-medium mb-2"
              >
                Name
              </label>
              <input
                type="text"
                id="name"
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your name"
              />
            </div>

            {/* father name */}
            <div className="mb-4">
              <label
                htmlFor="father-name"
                className="block text-gray-700 font-medium mb-2"
              >
                Father Name
              </label>
              <input
                type="text"
                id="father-name"
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your father name"
              />
            </div>
            {/* email */}
            <div className="mb-4">
              <label
                htmlFor="email"
                className="block text-gray-700 font-medium mb-2"
              >
                Email
              </label>
              <input
                type="email"
                id="email"
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your email"
              />
            </div>

            {/* password */}
            <div className="mb-4">
              <label
                htmlFor="password"
                className="block text-gray-700 font-medium mb-2"
              >
                Password
              </label>
              <input
                type="password"
                id="password"
                className="w-full border border-gray-300 rounded-md py-2 px-3 focus:outline-none "
                placeholder="Enter your password"
              />
            </div>
            <button
              type="submit"
              className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:bg-blue-600"
            >
              Sign Up
            </button>
          </form>
        </div>
      </div>

      <Footer />
    </>
  );
};

export default Register;
