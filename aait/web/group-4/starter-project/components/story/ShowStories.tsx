import { Story } from "@/types/Story/story-type";
import { useGetAllStoriesQuery } from "@/store/story/story-api";
import {SuccessStoryCard} from './StoryCard'
import {Partners} from "./Partners";
import { StoryHead } from "./StoryHead";

export const ShowStories = ()=> {
    const{data:allStories, isLoading, isError} = useGetAllStoriesQuery()
     
    if(isError)
    {
        return <h1>Error: {isError.toString()}</h1>
    }

    if(isLoading){
        return <h1>Loading ... </h1>
    }
    


    return (
        <div className="flex flex-col items-center px-4">
          <StoryHead/>
          {
            allStories.map((story: Story, index: number) => (
              <SuccessStoryCard key={index} successStory={story} index={index} />
            ))
          }
          <Partners/>
        </div>
      );
      
}
