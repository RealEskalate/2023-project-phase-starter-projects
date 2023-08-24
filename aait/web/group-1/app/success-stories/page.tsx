import React from 'react';
import Image from 'next/image';
import Link from 'next/link';
import Story from "@/components/success-stories/Story";
import { SuccessStory } from "@/types/story";

const Page: React.FC = () => {
  // Here I should place some dummy data for rendering each story with the Story component
  const allData: SuccessStory[]= [{
      "personName": "Yisehak Bogale",
      "imgURL": "/images/success-story/people/isaac.png",
      "role": "Software Engineering Intern",
      "location": "Google - Mountain View, CA, USA",
      "story": [
        {
          "heading": "My A2SV Experience",
          "paragraph": "I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.",
        },
        {
          "heading": "What I did/I am doing now",
          "paragraph": "Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!",
        },
        {
          "heading": "How the A2SV program changed my life",
          "paragraph": "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities.",
        }
      ],
      "order": 0
    },
    {
      "personName": "Lydia Gashawtena",
      "imgURL": "/images/success-story/people/lydia.png",
      "role": "Software Engineering Intern",
      "location": "Google - Mountain View, CA, USA",
      "story": [
        {
          "heading": "My A2SV Experience",
          "paragraph": "I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.",
        },
        {
          "heading": "What I did/I am doing now",
          "paragraph": "Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!",
        },
        {
          "heading": "How the A2SV program changed my life",
          "paragraph": "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities.",
        }
      ],
      "order": 1
    },
    {
      "personName": "Biruk Ayalew",
      "imgURL": "/images/success-story/people/biruk.png",
      "role": "Software Engineering Intern",
      "location": "Google - Mountain View, CA, USA",
      "story": [
        {
          "heading": "My A2SV Experience",
          "paragraph": "I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.",
        },
        {
          "heading": "What I did/I am doing now",
          "paragraph": "Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!",
        },
        {
          "heading": "How the A2SV program changed my life",
          "paragraph": "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities.",
        }
      ],
      "order": 0
    }
  ]


  // These are the images that will be placed in the partners place
  const partners: string[] = [
    'Google',
    'Palantir',
    'InstaDeep',
    'Meta',
    'Databricks',
    'Linkedin'
  ].map(partner => `/images/partners/${ partner }.png`);

  const socialIcons = [
    'facebook',
    'linkedin',
    'telegram',
    'twitter',
  ].map(icon => `/images/success-social-icons/${ icon }.png`);

  return (
    <div className='flex flex-col px-[100px] space-y-32'>
      <div className='text-center font-poppins mt-[70px] mb-[120px]'>
        <h2 className='text-[46px] font-semibold mb-[25px]'>Impact Stories</h2>
        <p className='text-[36px] px-[270px]'>Behind every success is a story. Learn about the stories of A2SVians</p>
        <span></span>
      </div>
      <div className='flex flex-col space-y-20'>
        {
          allData.map(data => <Story data={ data }/>)
        }
      </div>
      <div className=''>
        <h1 className='text-center text-5xl font-dmSans mb-20'>Current Interview Partners</h1>
        <div className='flex justify-center items-center mt-5'>
          {
            partners.slice(0, 4).map(partner => {
              return (
                <Image
                  src={ partner }
                  width={ 250 }
                  height={ 60 }
                  alt={ partner }
                />
              )
            })
          }
        </div>
        <div className='flex justify-evenly items-center px-[400px]'>
          {
            partners.slice(4).map(partner => {
              return (
                <Image
                  src={ partner }
                  width={ 250 }
                  height={ 60 }
                  alt={ partner }
                />
              )
            })
          }
        </div>
      </div>
      <div className='font-poppins grid grid-cols-4 h-[360px] space-x-10'>
        {/* This resembles the Footer component that was made earlier */}

        <div className='col-span-1 mt-20'>
          <Image
            className='pt-3'
            src='/images/logo.png'
            width={ 150 }
            height={ 40 }
            alt='A2SV Main Logo'
          />
          <div className='text-gray-500 mt-[100px]'>
            <p>© Copyright 2023 A2SV Foundation.</p>
            <p>Terms of service | Privacy Policy</p>
          </div>
        </div>

        <div className='col-span-1 mt-20'>
          <h1 className='text-[24px] mb-[14px] font-semibold'>Our Teams</h1>
          <ul className='flex flex-col space-y-[16px] text-gray-500'>
            <li>
              <Link href='/'>Advisors</Link>
            </li>
            <li>
              <Link href='/'>Board Members</Link>
            </li>
            <li>
              <Link href='/'>Executives</Link>
            </li>
            <li>
              <Link href='/'>Groups</Link>
            </li>
          </ul>
        </div>
        <div className='col-span-1 mt-20'>
          <h1 className='text-[24px] mb-[14px] font-semibold'>Our Teams</h1>
          <ul className='flex flex-col space-y-[16px] text-gray-500'>
            <li>
              <Link href='/'>Donate</Link>
            </li>
            <li>
              <Link href='/'>Get involved</Link>
            </li>
            <li>
              <Link href='/'>About us</Link>
            </li>
          </ul>
        </div>
        <div className='col-span-1 mt-20'>
          <div>
            <h3 className='mb-5 text-[24px] font-semibold'>Get in touch</h3>
            <div className='text-gray-500'>
              <p>Questions or feedback?</p>
              <p>we would like to hear from you</p>
            </div>
          </div>
          <div className='mt-5'>
            <ul className='flex flex-row justify-start space-x-5'>
              {
                socialIcons.map(icon => {
                  return (
                    <li key={ icon }>
                      <Image
                        src={ icon }
                        alt='Social Media Icons'
                        width={ 25 }
                        height={ 25 }
                      />
                    </li>
                  );
                })
              }
            </ul>
          </div>
        </div>

      </div>
    </div>
  )
}

export default Page;
