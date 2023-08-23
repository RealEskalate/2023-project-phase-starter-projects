import { useGetTeamsQuery } from "@/lib/redux/features/teams";

export default function useTeams() {
  const { data: teams, isLoading, error } = useGetTeamsQuery();
  return {
    teams,
    isLoading,
    error,
  };
}
