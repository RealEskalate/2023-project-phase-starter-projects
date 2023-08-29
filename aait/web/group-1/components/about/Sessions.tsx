import React from "react";
import SessionsCard from "./SessionsCard";
import Image from "@/node_modules/next/image";

const data = [
  {
    title: "Bi-weekly contests",
    description:
      "Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces.",
    imageUrl: "/images/about/icon tag.png",
  },
  {
    title: "Technical Training",
    description:
      "6 days a week, 3 hours of lectures and practice sessions to improve technical problem-solving skills.",
    imageUrl: "/images/about/icon tag(1).png",
  },
  {
    title: "Q&As",
    description:
      "In Q&As, we get to know engineers, founders, and entrepreneurs from top tech companies. We see that they are normal people like us and we learn the best practices.",
    imageUrl: "/images/about/icon tag(2).png",
  },
  {
    title: "Problem Solving Sessions",
    description:
      "We solve technical problems on a whiteboard while explaining to the class. It helps to get a feel of an interview environment.",
    imageUrl: "/images/about/icon tag(3).png",
  },
  {
    title: "Learning How To Approach",
    description:
      "Students observe how an experienced problem solver approaches a problem from understanding it to implementing a working solution.",
    imageUrl: "/images/about/icon tag(4).png",
  },
  {
    title: "Bi-weekly 1:1s ",
    description:
      "In 1:1s, we can talk about anything that matters; clearly no boundaries. The more we speak our minds without a filter, the better for the team.",
    imageUrl: "/images/about/icon tag(5).png",
  },
];

const Sessions = () => {
  return (
    <>
      <div className="">
        <h1 className="font-poppins font-bold text-5xl text-center">
          A2SV <span className="text-blue-first">Sessions</span>
        </h1>
      </div>
      <div className="p-12 mx-auto grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6 ">
        {data.map((each, index) => {
          return (
            <SessionsCard
              key={index}
              title={each.title}
              description={each.description}
              imageUrl={each.imageUrl}
            />
          );
        })}
      </div>
    </>
  );
};

export default Sessions;
