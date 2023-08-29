import Image from 'next/image'
import { Story } from '@/types/Story/story-type';

interface StoryCardProps {
    successStory: Story
    index:number
}


export const SuccessStoryCard:React.FC<StoryCardProps> = ({ successStory, index})=> {
  return (
    <div className="flex flex-col md:flex-row md:gap-5 gap-8 md:mx-10 my-5 md:my-10">

    <div className = {`relative flex flex-col ${index % 2 != 0 && "lg:order-last"} w-96 h-100`}>
        <Image width={400} height={100} src = {successStory?.imgURL} className='rounded-md' alt = {successStory?.personName} priority />
            <div className='absolute flex flex-col gap-2 w-full bottom-0 p-8 rounded-lg shadow-lg backdrop-filter backdrop-blur-lg backdrop-opacity-100 text-white'>
                <p className='text-2xl font-semibold'>{successStory?.personName}</p>
                <p className='font-semibold text-lg'>{successStory?.role}</p>
                <p className='font-semibold text-lg' >{successStory?.location}</p>
            </div>
    </div>


    <div className="flex flex-grow flex-col w-full md:w-96 gap-4 md:mt-0 mt-4 md:mx-4">
        {successStory.story.map((item) => {
       
         return (
            <div className = "flex flex-col gap-2" key = {item._id} >
                <h4 className='font-medium text-base md:text-xl '>{item.heading}</h4>
                <p className='text-xs md:test-sm'>{item.paragraph}</p>
            </div>
         )

        })}
    </div>
 
</div>

  );
};



