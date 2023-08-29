'use client'
import { Story } from "@/types/Story/story-type";
import { useGetAllStoriesQuery } from "@/store/story/story-api";
import {SuccessStoryCard} from '@/components/story//StoryCard'
import {Partners} from "@/components/story//Partners";
import { StoryHead } from "@/components/story/StoryHead";

export default function ShowStories () {
    const{data:allStories=[], isLoading, isError} = useGetAllStoriesQuery()
     console.log(allStories);
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