import SocialMedia from "@/types/team/SocialMedia";

export default interface Member {
    socialMedia: SocialMedia;
    _id: string;
    name: string;
    image:string;
    bio: string;
    department: string;
    __v: number;
}
