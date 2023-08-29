export interface SuccessStory {
  _id: string;
  personName: string;
  imgURL: string;
  role: string;
  location: string;
  story: StorySection[];
  __v: number;
}

interface StorySection {
  heading: string;
  paragraph: string;
  _id: string;
}