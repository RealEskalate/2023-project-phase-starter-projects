import React from 'react';
import Image from 'next/image';
import { SuccessStory } from "@/types/story";

interface PropsInterface {
  data: SuccessStory;
}

const Story: React.FC<PropsInterface> = ({ data }) => {
  return (
    <div className={`flex flex-row ${ data.personName === 'Lydia Gashawtena' && 'flex-row-reverse' } font-montserrat w-full`}>
      <div className='w-2/5 relative border'>
        <div className={`bg-cover bg-center h-full w-full`} style={{ backgroundImage: `url(${data.imgURL})` }}></div>
        <div className='absolute bottom-0 bg-opacity-70 backdrop-blur-md w-full py-14 text-white font-poppins flex flex-col px-6 space-y-4'>
          <h1 className='text-3xl font-semibold'>{ data.personName }</h1>
          <p className='text-xl italic'>{ data.role }</p>
          <p className='text-xl italic'>{ data.location }</p>
        </div>
      </div>
      <div className='w-3/5 flex flex-col justify-evenly px-[54px] items-center h-[900px]'>
        {
          data.story.map(story => {
            return (
              <div>
                <h1 className='mb-10 text-xl font-semibold'>{ story.heading }</h1>
                <p className='text-md italic'>{ story.paragraph }</p>
              </div>
            );
          })
        }
      </div>
    </div>
  );
}

export default Story;
