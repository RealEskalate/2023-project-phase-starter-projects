export interface SuccessStory {
  _id: string;
  personName: string;
  imgURL: string;
  role: string;
  location: string;
  story: {
    heading: string;
    paragraph: string;
    _id: string;
  }[];
  __v: number;
}
