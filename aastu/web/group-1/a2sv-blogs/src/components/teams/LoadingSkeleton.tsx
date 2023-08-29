import React from "react";

const LoadingSkeleton = () => {
  return (
    <div>
      <div className="w-full h-[505px] rounded-[12px] bg-white shadow-lg mt-5 sm:w-full">
        <div className="text-center py-5">
          <div className="animate-pulse w-[150px] h-[150px] rounded-full mx-auto bg-gray-300"></div>
        </div>

        <div className="text-center py-2">
          <div className="animate-pulse w-3/4 h-6 rounded bg-gray-300 mx-auto"></div>
          <div className="animate-pulse w-1/2 h-4 rounded mt-2 bg-gray-300 mx-auto"></div>
          <div className="animate-pulse w-1/3 h-4 rounded mt-2 bg-gray-300 mx-auto"></div>
        </div>

        <div className="text-center py-2">
          <div className="animate-pulse w-5/6 h-16 rounded bg-gray-300 mx-auto"></div>
        </div>

        <div className="text-center pt-20">
          <hr className="border-gray-200" />
        </div>

        <div className="flex justify-evenly pt-4">
          <div className="animate-pulse w-10 h-10 rounded-full bg-gray-300"></div>
          <div className="animate-pulse w-10 h-10 rounded-full bg-gray-300"></div>
          <div className="animate-pulse w-10 h-10 rounded-full bg-gray-300"></div>
        </div>
      </div>
    </div>
  );
};

export default LoadingSkeleton;
