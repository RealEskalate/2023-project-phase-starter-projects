export type Story = {
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
  };


export type Partner = {
    image: string;
    name: string;
}