"use client";
import { useState } from "react"
import A2SVProgram from "./A2SVProgram";

const A2SVPrograms = () => {

  // Boolean variable to that controls the image to be rendered to the left or to the right 
  const isRight = useState(false);
  const programs = [
    {
      title: "Internships",
      content: "Students who passed their interviews get 3-month internships to gain experience in building scalable products that are widely used around the world.",
      img: "/images/homepage/internship.png",
      isRight: false
    },
    {
      title: "360° Training",
      content: "A2SV upskills students with a 360° software engineering program that focuses on problem-solving, effective speaking, and personal development.",
      img: "/images/homepage/360.png",
      isRight: true
    },
    {
      title: "Social Projects",
      content: "Students work on social projects with industry experts to address the most pressing problems in their community.",
      img: "/images/homepage/social-projects.png",
      isRight: false
    }
  ]


  return (
    <div className="flex flex-col gap-12 mt-32">
      {programs.map(({title, content, img, isRight}, index) => <A2SVProgram key={index} title={title} content={content} img={img} isRight={isRight}/> )}
    </div>
  )
}

export default A2SVPrograms