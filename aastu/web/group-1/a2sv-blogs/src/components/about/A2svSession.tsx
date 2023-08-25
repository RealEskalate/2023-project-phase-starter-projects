import Image from "next/image";
import React from "react";
const cardData = [
  {
    logo: "/images/icon tag.png",
    title: "Bi-weekly contests",
    description:
      "Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces.",
  },
  {
    logo: "/images/icon contest.png",
    title: "Technical Training",
    description:
      "6 days a week, 3 hours of lectures and practice sessions to improve technical problem-solving skills.",
  },
  {
    logo: "/images/icon q.png",
    title: "Q&As",
    description:
      "In Q&As, we get to know engineers, founders, and entrepreneurs from top tech companies. We see that they are normal people like us and we learn the best practices.",
  },
  {
    logo: "/images/icon tag (1).png",
    title: "Problem Solving Sessions",
    description:
      "We solve technical problems on a whiteboard while explaining to the class. It helps to get a feel of an interview environment.",
  },
  {
    logo: "/images/icon tag (2).png",
    title: "Learning How To Approach",
    description:
      "Students observe how an experienced problem solver approaches a problem from understanding it to implementing a working solution.",
  },
  {
    logo: "/images/icon tag (3).png",
    title: "Bi-weekly 1:1s",
    description:
      "In 1:1s, we can talk about anything that matters; clearly no boundaries. The more we speak our minds without a filter, the better for the team.",
  },
];

const A2svSession = () => {
  return (
    <div className="mt-24">
      <div className="flex justify-center items-center mt-16">
        <h1 className="text-3xl font-bold">
          A2SV <span className="text-blue-800">Sessions</span>
        </h1>
      </div>

      <section className="grid lg:grid-cols-3 sm:grid-cols-2 gridcols-1 gap-3 mt-7">
        {cardData.map((data, index) => (
          <div
            className="flex flex-col w-fit shadow-xl px-6 py-2 transition-all hover:-translate-y-2 duration-300"
            style={{
              boxShadow:
                "4px 4px 8px 0px rgba(0, 0, 0, 0.04), -2px -2px 8px 0px rgba(0, 0, 0, 0.05)",
            }}
            key={index}
          >
            <Image
              src={data.logo}
              width={65}
              height={30}
              className="my-3"
              alt=""
            />
            <div>
              <h3 className="font-bold my-2">{data.title} </h3>
            </div>
            <div className="my-5">
              <p>{data.description}</p>
            </div>
          </div>
        ))}
      </section>
    </div>
  );
};

export default A2svSession;
