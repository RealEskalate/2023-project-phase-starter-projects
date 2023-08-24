export interface Credentials {
  name?: string;
  email: string;
  password: string;
}

export interface SignupResponse {
  token: string;
  userId: string;
}

export interface LoginResponse {
  user: string;
  token: string;
  userRole: string;
  userName: string;
  userProfile?: string;
  userEmail?: string;
}
export interface User {
  name: string;
  email: string;
}

export interface Author {
  _id: string;
  name: string;
  email: string;
  image: string;
  role: string;
}

export interface Blog {
  _id: string;
  image: string;
  title: string;
  description: string;
  author: Author | null;
  isPending: boolean;
  tags: string[];
  likes: number;
  relatedBlogs: string[];
  skills: string[];
  createdAt: string;
  updatedAt: string;
  __v: number;
}

export interface SuccessStory {
  _id: string;
  personName: string;
  imgURL: string;
  role: string;
  location: string;
  story: StorySection[];
  __v: number;
}

export interface StorySection {
  heading: string;
  paragraph: string;
  _id: string;
}

export interface Member {
  socialMedia: {
    linkedin: string;
    facebook: string;
    instagram: string;
  };
  _id: string;
  name: string;
  bio: string;
  department: string;
  __v: number;
}
