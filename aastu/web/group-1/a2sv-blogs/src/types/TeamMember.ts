
export interface SocialMedia {
    linkedin: string;
    facebook: string;
    instagram: string; 
  }
  
  export interface TeamMember {
    id: string;
    name: string;
    imageUrl: string;
    role: string;
    bio: string;
    socialMedia: SocialMedia;
  }