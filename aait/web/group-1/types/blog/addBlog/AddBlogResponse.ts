export interface AddBlogResponse {
  image: string;
  title: string;
  description: string;
  author: string;
  isPending: boolean;
  tags: string[];
  likes: number;
  relatedBlogs: string[];
  skills: string[];
  _id: string;
  createdAt: string;
  updatedAt: string;
  __v: number;
}
