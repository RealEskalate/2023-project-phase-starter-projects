'use clients';

import Image, { StaticImageData } from 'next/image';
import google from '@/assets/images/googlePartner.svg';
import palantir from '@/assets/images/palantirPartner.svg';
import instadeep from '@/assets/images/InstDeepPartner.png';
import meta from '@/assets/images/metaPartner.svg';
import databricks from '@/assets/images/databricksPartner.svg';
import linkedin from '@/assets/images/linkedinPartner.svg';
import StoriesProfile from '@/assets/images/storiesProfile.png';
import StoriesProfile2 from '@/assets/images/storiesProfile2.png';
import StoriesProfile3 from '@/assets/images/storiesProfile3.png';
import type { Stories } from '@/lib/types';

export function StoriesCard({
  alternate,
  profileImage,
  personName,
  imgURL,
  role,
  location,
  story,
}: Stories) {
  return (
    <div
      className={`${
        alternate ? 'md:flex-row' : 'md:flex-row-reverse'
      } flex flex-col justify-between gap-8 items-center md:items-center md:px-12 lg:px-36  w-full mb-24 `}
    >
      <div className="w-3/4 lg:w-1/2 relative">
        <Image src={profileImage ? profileImage : ''} width={900} height={900} alt="person image" />
        <div className="w-full absolute bottom-0 backdrop-blur-md h-24 md:h-40 p-4 md:p-8">
          <p className="font-semibold font-primaryFont text-lg md:text-3xl text-left text-white md:mb-2">
            {personName}
          </p>
          <p className="font-semibold font-primaryFont text-sm md:text-xl text-left text-white md:mb-2">
            {role}
          </p>
          <p className="font-semibold font-primaryFont text-sm md:text-xl text-left text-white md:mb-2">
            {location}
          </p>
          <p></p>
          <p></p>
        </div>
      </div>

      <div className="w-5/6 md:w-3/5">
        <div className="flex flex-col justify-around">
          {story?.map((item, index) => [
            <div className="mb-4" key={index}>
              <p className="font-secondaryFont font-medium text-2xl mb-8 dark:text-dark-textColor-100">
                {item.heading}
              </p>
              <p className="font-secondaryFont font-light italic text-sm dark:text-dark-textColor-50">
                {item.paragraph}
              </p>
            </div>,
          ])}
        </div>
      </div>
    </div>
  );
}

export default function StoriesPage() {
  const data: Stories[] = [
    {
      personName: 'Yisehak Bogale',
      imgURL: '/images/success-story/people/isaac.png',
      role: 'Software Engineering Intern',
      location: 'Google - Mountain View, CA, USA',
      story: [
        {
          heading: 'My A2SV Experience',
          paragraph:
            'I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.',
        },
        {
          heading: 'What I did/I am doing now',
          paragraph:
            'Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!',
        },
        {
          heading: 'How the A2SV program changed my life',
          paragraph:
            "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities.",
        },
      ],
    },
    {
      personName: 'Lydia Gashawtena',
      imgURL: '/images/success-story/people/lydia.png',
      role: 'Software Engineering Intern',
      location: 'Google - Mountain View, CA, USA',
      story: [
        {
          heading: 'My A2SV Experience',
          paragraph:
            'I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.',
        },
        {
          heading: 'What I did/I am doing now',
          paragraph:
            'Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!',
        },
        {
          heading: 'How the A2SV program changed my life',
          paragraph:
            "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities.",
        },
      ],
    },
    {
      personName: 'Biruk Ayalew',
      imgURL: '/images/success-story/people/biruk.png',
      role: 'Software Engineering Intern',
      location: 'Google - Mountain View, CA, USA',
      story: [
        {
          heading: 'My A2SV Experience',
          paragraph:
            'I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.',
        },
        {
          heading: 'What I did/I am doing now',
          paragraph:
            'Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!',
        },
        {
          heading: 'How the A2SV program changed my life',
          paragraph:
            "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities.",
        },
      ],
    },
  ];

  const profilePictures: StaticImageData[] = [StoriesProfile, StoriesProfile2, StoriesProfile3];

  return (
    <div className="flex flex-col justify-center items-center mt-20 mb-32 transition-colors ease-linear">
      <div className="text-center w-5/6 md:w-2/3">
        <p className="font-primaryFont font-medium text-4xl md:text-5xl mb-10 text-[#2B2A35] dark:text-dark-textColor-100">
          Impact Stories
        </p>
        <p className="font-primaryFont font-light text-2xl md:text-3xl text-[#2E374E] dark:text-dark-textColor-50">
          Behind every success is a story. Learn about the stories of A2SVians
        </p>
      </div>
      <div className="h-[6px] w-[88px] mt-4 bg-[#264FAD] dark:bg-white"></div>
      <div className="mt-8 mb-8">
        {data?.map((item, index) => [
          <StoriesCard
            key={index}
            profileImage={profilePictures[index]}
            {...item}
            alternate={index % 2 == 0}
          />,
        ])}
      </div>

      <div className="text-center w-full">
        <p className="font-primaryFont font-normal text-4xl mb-20 text-[#363636] dark:text-dark-textColor-100">
          Current Interview Partners
        </p>
        <ul className="flex flex-row item-center justify-center gap-12 flex-wrap">
          <li className="w-[200px] h-[50px]">
            <Image src={google} width={200} height={200} alt="" />
          </li>
          <li className="w-[200px] h-[50px] dark:invert ">
            <Image src={palantir} width={200} height={200} alt="" />
          </li>
          <li className="w-[200px] h-[50px] dark:invert">
            <Image src={instadeep} width={200} height={200} alt="" />
          </li>
          <li className="w-[200px] h-[50px] dark:invert">
            <Image src={meta} width={200} height={200} alt="" />
          </li>
        </ul>
        <div>
          <ul className="flex flex-wrap justify-evenly gap-24 lg:flex lg:flex-wrap mt-10 lg:justify-evenly w-full">
            <li className="w-[200px] h-[50px] dark:invert">
              <Image src={databricks} width={500} height={500} alt="" />
            </li>
            <li className="w-[200px] h-[50px] dark:invert">
              <Image src={linkedin} width={500} height={500} alt="" />
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
}
