import Footer from "@/components/footer/Footer";
import React from "react";

const LogIn: React.FC = () => {
  return (
    <>
      <div className="flex flex-col items-center justify-center py-10 w-8/12 mx-auto rounded-lg my-10 font-Montserrat bg-gray-100">
        <div className=" p-8 rounded">
          <h2 className="text-2xl font-bold text-nav_text_color mb-4">Login</h2>
          <form>
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
              Sign In
            </button>
          </form>
        </div>
      </div>

      <Footer />
    </>
  );
};

export default LogIn;
