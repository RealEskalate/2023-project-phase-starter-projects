import React from "react";
import Image from "../../node_modules/next/image";

interface Props {
  title: String;
  imageUrl: any;
  description: String;
}
const SessionsCard: React.FC<Props> = ({ title, imageUrl, description }) => {
  return (
      <div className="border p-10 rounded-lg shadow">
        <Image
          width={100}
          height={100}
          className="w-16 h-16 mb-4"
          src={imageUrl || ""}
          alt="Icons"
        />

        <h1 className="font-bold font-poppins mb-4">{title}</h1>
        <p className="font-poppins">{description}</p>
      </div>
  );
};

export default SessionsCard;
