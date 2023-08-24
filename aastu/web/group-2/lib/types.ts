export interface User {
  name: string;
  role: string;
  picture: string;
}

export interface Blog {
  author: User;
  date: string;
  blog_title: string;
  excerpt: string;
  tags: string[];
  cover_image: string;
}
