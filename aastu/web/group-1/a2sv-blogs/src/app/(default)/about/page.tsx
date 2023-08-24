import React from "react";
import Hero from "@/components/about/Hero";
import SocialProjects from "@/components/about/SocialProjects";
import A2svSession from "@/components/about/A2svSession";

const Home: React.FC = () => {
  return (
    <div className="bg-white min-h-screen px-16 pt-28">
      <Hero />
      <SocialProjects />
      <A2svSession />
    </div>
  );
};

export default Home;
