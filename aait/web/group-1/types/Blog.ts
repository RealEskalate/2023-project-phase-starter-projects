import { Author } from "./Author";

export interface Blog {
  _id: string;
  image: string;
  title: string;
  description: string;
  author: Author;
  isPending: true;
  tags: string[];
  likes: number;
  relatedBlogs: Blog[];
  skills: string[];
  createdAt: string;
  updatedAt: string;
}
