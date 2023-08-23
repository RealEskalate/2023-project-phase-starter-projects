import { useGetStoriesQuery } from "@/lib/redux/features/stories";

export default function useStories() {
  const { data: stories, isLoading, error } = useGetStoriesQuery();
  return { stories, isLoading, error };
}
