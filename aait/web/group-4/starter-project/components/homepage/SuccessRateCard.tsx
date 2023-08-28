import React from "react";

interface Props{
    year: string, 
    rate: string, 
    average:string
}
const SuccessRateCard = ({year, rate, average}: Props) => {
  return (
    <div className="flex flex-col justify-center items-center gap-16 py-6 px-12 drop-shadow-md shadow-black rounded-xl bg-white">
      <p className="text-grayish-brown font-semibold text-2xl">{year}</p>
      <div className="space-y-4">
        <p className="text-2xl font-semibold">{rate}</p>
        <p className="text-xl text-[#7D7D7D]">{average}</p>
      </div>
    </div>
  );
};

export default SuccessRateCard;
