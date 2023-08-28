"use client";
import { useState } from "react";
import A2SVProgram from "./A2SVProgram";
import data from "@/data/homepage.json";

const A2SVPrograms = () => {
  // Boolean variable to that controls the image to be rendered to the left or to the right
  const isRight = useState(false);

  return (
    <div className="flex flex-col gap-12 mt-32">
      {data.programs.map(({ title, content, img, isRight }, index) => (
        <A2SVProgram
          key={index}
          title={title}
          content={content}
          img={img}
          isRight={isRight}
        />
      ))}
    </div>
  );
};

export default A2SVPrograms;
