import Image from 'next/image'
import React from 'react'
import TeamImage from '../../public/images/team-work.svg'
import { Profile } from '@/types/Profile'
import Card from '@/components/Card'

const page = () => {
  const members: Profile[] = [
    {
      socialMedia: {
        linkedin: "linkedin.com/tadele",
        facebook: "facebook.com/tadele",
        instagram: "instagram.com/tadele"
      },
      _id: "64e0636413118e7f1f0a59c1",
      name: "Tadele Girma",
      bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
      department: "Software Engineer"
    },
    {
      socialMedia: {
        linkedin: "linkedin.com/tadele",
        facebook: "facebook.com/tadele",
        instagram: "instagram.com/tadele"
      },
      _id: "64e0636413118e7f1f0a59c1",
      name: "Tadele Girma",
      bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
      department: "Engineering"
    },
    {
      socialMedia: {
        linkedin: "linkedin.com/tadele",
        facebook: "facebook.com/tadele",
        instagram: "instagram.com/tadele"
      },
      _id: "64e0636413118e7f1f0a59c1",
      name: "Tadele Girma",
      bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
      department: "Engineering"
    },
    {
      socialMedia: {
        linkedin: "linkedin.com/tadele",
        facebook: "facebook.com/tadele",
        instagram: "instagram.com/tadele"
      },
      _id: "64e0636413118e7f1f0a59c1",
      name: "Tadele Girma",
      bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
      department: "Engineering"
    },
    {
      socialMedia: {
        linkedin: "linkedin.com/tadele",
        facebook: "facebook.com/tadele",
        instagram: "instagram.com/tadele"
      },
      _id: "64e0636413118e7f1f0a59c1",
      name: "Tadele Girma",
      bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
      department: "Engineering"
    },
    {
      socialMedia: {
        linkedin: "linkedin.com/tadele",
        facebook: "facebook.com/tadele",
        instagram: "instagram.com/tadele"
      },
      _id: "64e0636413118e7f1f0a59c1",
      name: "Tadele Girma",
      bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
      department: "Engineering"
    },
  ]
  return (
    <div>
      {/* upper hero section */}
      <div className="flex items-center">
        {/*team text section */}
        <div className="w-1/2 ml-16 flex flex-col gap-6 px-10">
            <div className="text-6xl font-extrabold uppercase">The team we’re</div>
            <div className="text-6xl font-extrabold uppercase">currently</div>
            <div className="text-6xl font-extrabold uppercase">working with</div>
            <p className='mt-10 text-xl text-gray-400'>
            Meet our development team is a small but highly skilled and
            experienced group of professionals. We have a talented mix of web
            developers, software engineers, project managers and quality
            assurance specialists who are passionate about developing
            exceptional products and services.
          </p>
        </div>

        {/* team image section */}
        <div className="w-1/2">
          <Image src={TeamImage} alt={"Team work"}/>
        </div>
      </div>

      {/* horizontal line */}
      <div className='mx-56 mt-24 mb-10 rounded-full bg-gray-200 h-0.5'></div>

      {/* members section */}
      <div className='px-20 py-5'>
        <div className='grid grid-cols-3 gap-x-6 gap-y-8'>
          {/* mapping each member to card component */}
          {(members?.map((member: Profile) => <Card key={member._id} _id={member._id} name={member.name} bio={member.bio} department={member.department} socialMedia={member.socialMedia}/>))}
        </div>
      </div>

      {/* pagination */}
      <div className='w-full flex justify-center gap-5 my-8'>
        <div className='page bg-blue-800 text-white'>1</div>
        <div className='page bg-gray-200'>2</div>
        <div className='page bg-gray-200'>3</div>
        <div className='page bg-gray-200'>4</div>
        <div className='page bg-gray-200'>5</div>
      </div>
    </div>
  )
}

export default page