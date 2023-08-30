'use client'
import { Story } from "@/types/story/story-type";
import { useGetAllStoriesQuery } from "@/store/features/story/story-api";
import {SuccessStoryCard} from '@/components/story//StoryCard'
import {Partners} from "@/components/story//Partners";
import { StoryHead } from "@/components/story/StoryHead";
import Loading from "@/components/common/Loading";

export default function ShowStories () {

    const{data:allStories=[], isLoading} = useGetAllStoriesQuery()
   
    if(isLoading){
        return <Loading/>
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