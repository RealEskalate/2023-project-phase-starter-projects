import TeamMemberCard from "./TeamMemberCard"; 

const members = [
  {
    name: "Nathaniel Awel",
    imageUrl: "/profile.png",
    department: "Software Engineer", 
    bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
    socialMedia: {
      linkedin: "https://www.linkedin.com/john",
      facebook: "https://www.facebook.com/john",
      instagram: "https://www.instagram.com/john",
    }
  },
  {
    name: "Nathaniel Awel",
    imageUrl: "/profile.png",
    department: "Software Engineer", 
    bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
    socialMedia: {
      linkedin: "https://www.linkedin.com/john",
      facebook: "https://www.facebook.com/john",
      instagram: "https://www.instagram.com/john",
    }
  },
  {
    name: "Nathaniel Awel",
    imageUrl: "/profile.png",
    department: "Software Engineer", 
    bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
    socialMedia: {
      linkedin: "https://www.linkedin.com/john",
      facebook: "https://www.facebook.com/john",
      instagram: "https://www.instagram.com/john",
    }
  },
  {
    name: "Nathaniel Awel",
    imageUrl: "/profile.png",
    department: "Software Engineer", 
    bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
    socialMedia: {
      linkedin: "https://www.linkedin.com/john",
      facebook: "https://www.facebook.com/john",
      instagram: "https://www.instagram.com/john",
    }
  },
  {
    name: "Nathaniel Awel",
    imageUrl: "/profile.png",
    department: "Software Engineer", 
    bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
    socialMedia: {
      linkedin: "https://www.linkedin.com/john",
      facebook: "https://www.facebook.com/john",
      instagram: "https://www.instagram.com/john",
    }
  },
  {
    name: "Nathaniel Awel",
    imageUrl: "/profile.png",
    department: "Software Engineer", 
    bio: "He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.",
    socialMedia: {
      linkedin: "https://www.linkedin.com/john",
      facebook: "https://www.facebook.com/john",
      instagram: "https://www.instagram.com/john",
    }
  } 
];

export default function TeamMemberList() {

  return (
    <div className="grid grid-cols-3 gap-10">
      {members.map(member => (
        <TeamMemberCard key={member.name} member={member} />
      ))}
    </div>
  );

}

