import Author from "@/types/blogs/Author";

export default interface BlogData {
    _id: string;
    image: string;
    title: string;
    description: string;
    author: Author;
    isPending: boolean;
    tags: string[];
    likes: number;
    relatedBlogs: string[]; // This should be an array of related blog IDs or some other relevant data
    skills: string[];
    createdAt: string;
    updatedAt: string;
    __v: number;
}