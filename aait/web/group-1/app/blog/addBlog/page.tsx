'use client'

import { useAddBlogMutation } from "@/store/blog/blogApi";
import { useState } from "react";
import AddBlog from "@/components/blog/AddBlog";

const CreateBlogPage: React.FC = () => {
    const [addBlog, {isError, isLoading, isSuccess}] = useAddBlogMutation()
    const [title, setTitle] = useState("");
    const [image, setImage] = useState<File | null>(null);
    const [content, setContent] = useState("");
    const [imageText, setImageText] = useState('Please upload image');
    const [selectedTags, setSelectedTags] = useState<string[]>([]);

    const handleTagClick = (tag: string) => {
      if (selectedTags.includes(tag)) {
        setSelectedTags(selectedTags.filter((t) => t !== tag));
      } else {
        setSelectedTags([...selectedTags, tag]);
      }
    };

    const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
          setTitle(event.target.value);
      };

    const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.files && event.target.files.length > 0) {
            const file = event.target.files[0]
            if (file) {
                setImageText(file.name);
            } else {
                setImageText('Please upload image');
            }
        setImage(event.target.files[0]);
        }
    };

      const handleCancel = (e: React.FormEvent) => {
        e.preventDefault()
        setImage(null)
        setImageText('Please upload image')
        setContent('')
        setTitle('')
        setSelectedTags([])

      }

      const handleDeleteImage = () => {
          setImageText('Please upload image');
          setImage(null);
      };
      const handleContentChange = (newContent:any) => {
          setContent(newContent);
      };

      const handleSubmit = async (event: React.FormEvent) => {
          event.preventDefault();
          const formData = new FormData();
          formData.append("title", title);
          formData.append("description", content);
          selectedTags.forEach(tag => formData.append("tags", tag));
          if (image) {
            formData.append("image", image);
          }
          addBlog(formData)         
      };

    return (
     <AddBlog
      title={title}
      content={content}  
      image={image} 
      imageText={imageText} 
      selectedTags={selectedTags} 
      handleCancel={handleCancel}
      handleContentChange={handleContentChange}
      handleDeleteImage={handleDeleteImage}
      handleImageChange={handleImageChange}
      handleSubmit={handleSubmit}
      handleTagClick={handleTagClick}
      handleTitleChange={handleTitleChange}
      isError={isError}
      isSuccess={isSuccess}
      />
    );
};

export default CreateBlogPage;