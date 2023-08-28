interface Author {
  _id: string;
  name: string;
  email: string;
  image: string;
  role: string;
}

interface Blog {
  _id: string;
  image: string;
  title: string;
  description: string;
  author: Author | null;
  isPending: boolean;
  tags: string[];
  likes: number;
  relatedBlogs: Blog[];
  skills: string[];
  createdAt: string;
  updatedAt: string;
  __v: number;
}

interface BlogPostResponse {
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

export type { Author, Blog, BlogPostResponse };


