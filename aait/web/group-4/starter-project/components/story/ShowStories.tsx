import { Story } from "@/types/Story/StoryType";
import { useGetAllStoriesQuery } from "@/store/story/StoryApi";
import StoryCard from './StoryCard'
import Partners from "./Partners";

export default function showStories() {
    const{data:allStories, isLoading, isError} = useGetAllStoriesQuery()
     
    if(isError)
    {
        return <h1>Error: {isError.toString()}</h1>
    }

    if(allStories === undefined || isLoading){
        return <h1>Loading ... </h1>
    }
    


    return (
        <div className="flex flex-col items-center">
          <div className="flex flex-col items-center w-1164 h-236">
              <h1 className="font-semibold text-5xl leading-[78px] font-poppins">Impact Stories</h1>
              <p className="font-poppins font-normal text-3xl leading-[54px] text-#2E374E">Behind every success is a story. Learn about the stories of </p>
              <p className="font-poppins font-normal text-3xl leading-[54px] text-#2E374E">A2SVians</p>
              <hr className='w-12 h-0 border-2 border-solid border-blue-500 mx-auto top-150'/>
          </div>

          {
            allStories.map((story: Story, index: number) => (
              <StoryCard key={index} successStory={story} index={index} />
            ))
          }
          <Partners/>
        </div>
      );
      
}
