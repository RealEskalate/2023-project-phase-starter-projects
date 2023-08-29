import TeamHome from "@/components/teams/TeamHome";
import TeamMemberList from "@/components/teams/TeamMemberList";

import React from "react";

const page = () => {
  return (
    <div className="lg:px-32 px-5 py-20">
      <TeamHome />
      <TeamMemberList />
    </div>
  );
};

export default page;
