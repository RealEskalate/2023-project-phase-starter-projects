import TeamHome from "@/components/teams/TeamHome"
import TeamMemberList from "@/components/teams/TeamMemberList"
import TeamMemberCard from "@/components/teams/TeamMemberCard"
import PaginationButtons from "@/components/teams/PaginationButton"


export default function Home() {
  return (
    <div>
      <TeamHome />
       <TeamMemberList />
      <PaginationButtons /> 
    </div>
  )
}
