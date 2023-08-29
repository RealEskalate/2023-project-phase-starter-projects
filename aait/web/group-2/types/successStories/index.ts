interface SuccessStoryProps {
    successStory:SuccessStory,
    index:number
}

export interface SuccessStory {
    _id:string,
    personName:string,
    imgURL:string,
    role:string,
    location:string,
    story:Array<Story>;
}
export interface Story {
    _id:string,
    heading:string,
    paragraph:string
}

export default SuccessStoryProps
